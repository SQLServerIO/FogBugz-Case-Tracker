#region

using System;
using System.IO;
using System.Net;
using System.Text;

#endregion

namespace FogBugzNet
{
    public class EServerError : Exception
    {
        public EServerError(string reason)
            : base(reason)
        {
        }
    }

    public class EURLError : Exception
    {
        public EURLError(string reason)
            : base(reason)
        {
        }
    }

    public class HttpUtils
    {
        public static string httpGet(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse res = req.GetResponse();
                var sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                return sr.ReadToEnd();
            }
            catch (WebException x)
            {
                Utils.LogError(x + ". Connection status: " + x.Status);
                throw new EServerError("Unable to find FogBugz server at location: " + url);
            }
            catch (UriFormatException x)
            {
                Utils.LogError(x.ToString());
                throw new EURLError("The server URL you provided appears to be malformed: " + url);
            }
        }

        public static void ReadStreamToFile(Stream src, string dst)
        {
            var fs = new FileStream(dst, FileMode.Create, FileAccess.Write, FileShare.None);
            var br = new BinaryWriter(fs);

            var buffer = new byte[4096];
            int count = 0;
            do
            {
                count = src.Read(buffer, 0, buffer.Length);
                br.Write(buffer, 0, count);
            } while (count != 0);

            fs.Close();
        }

        public static void httpGetBinary(string url, string targetFile)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse res = req.GetResponse();
                ReadStreamToFile(res.GetResponseStream(), targetFile);
            }
            catch (WebException x)
            {
                Utils.LogError(x + ". Connection status: " + x.Status);
                throw new EServerError("Unable to find FogBugz server at location: " + url);
            }
            catch (UriFormatException x)
            {
                Utils.LogError(x.ToString());
                throw new EURLError("The server URL you provided appears to be malformed: " + url);
            }
        }
    }
}