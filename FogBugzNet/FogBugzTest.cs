#region

using System;
using System.Threading;
using System.Xml;
using NUnit.Framework;

#endregion

namespace FogBugzNet
{
    [TestFixture]
    public class FogBugzTest
    {
        private readonly Credentials _creds;


/*
 
In order to run the test create an XML file with this format:
 
<Credentials>
	<UserName>yourUserName</UserName>
	<Password>yourPassword</Password>
	<Server>http://your-server/FogBugz</Server>
</Credentials>
 
 */

        public FogBugzTest()
        {
            var doc = new XmlDocument();
            doc.Load("credentials.xml");
            _creds = new Credentials();
            _creds.UserName = doc.SelectSingleNode("//UserName").InnerText;
            _creds.Password = doc.SelectSingleNode("//Password").InnerText;
            _creds.Server = doc.SelectSingleNode("//Server").InnerText;
        }

        private void BadLogin()
        {
            var fb = new FogBugz("bad url");
            fb.Logon("bad", "bad");
        }

        private void GoodLogin()
        {
            var fb = new FogBugz(_creds.Server);
            fb.Logon(_creds.UserName, _creds.Password);
        }

        [Test]
        private FogBugz Login()
        {
            var fb = new FogBugz(_creds.Server);

            var evw = new EventWaitHandle(false, EventResetMode.ManualReset);
            Assert.True(fb.Logon(_creds.UserName, _creds.Password));
            return fb;
        }

        [Test]
        public void TestEstimate()
        {
            FogBugz fb = Login();
            Case testCase = fb.GetCases("7523")[0];
            fb.SetEstimate(testCase.ID, "1h");

            Assert.AreEqual(new TimeSpan(1, 0, 0), fb.GetCases("7523")[0].Estimate);
            fb.SetEstimate(testCase.ID, "30m");

            Assert.AreEqual(new TimeSpan(0, 30, 0), fb.GetCases("7523")[0].Estimate);

            Assert.Throws(typeof (ECommandFailed), delegate { fb.SetEstimate(testCase.ID, "$%#$RSD time"); });
        }

        [Test]
        public void TestLogin()
        {
            Assert.Throws(typeof (EURLError), BadLogin);
            Assert.DoesNotThrow(GoodLogin);
        }

        [Test]
        public void TestMindMapExport()
        {
            FogBugz fb = Login();

            string query = "project:\"infra\" milestone:\"test\"";
            var ex = new Exporter(fb, new Search(query, fb.GetCases(query)));
            ex.CasesToMindMap().Save("output.mm");
        }

        [Test]
        public void TestMindMapImport()
        {
            var doc = new XmlDocument();
            doc.Load("input.mm");

            FogBugz fb = Login();
            var im = new Importer(doc, fb);
            ImportAnalysis res = im.Analyze();
            Assert.AreEqual(res.CaseToNewParent.Count, 1);
//            Assert.AreEqual(res.CasesWithNewParents[0].ID, 7164);
            //Assert.AreEqual(res.CasesWithNewParents[0].ParentCase, 7163);

            foreach (Case c in res.CaseToNewParent.Keys)
                fb.SetParent(c, res.CaseToNewParent[c].ID);
        }

        [Test]
        public void TestModifyParent()
        {
            FogBugz fb = Login();
            Case[] cases = fb.GetCases("7523");
            fb.SetParent(cases[0], 7522);
            cases = fb.GetCases("7523");
            Assert.AreEqual(cases[0].ParentCaseID, 7522);
            fb.SetParent(cases[0], 7521);
            cases = fb.GetCases("7523");
            Assert.AreEqual(cases[0].ParentCaseID, 7521);
        }
    }
}