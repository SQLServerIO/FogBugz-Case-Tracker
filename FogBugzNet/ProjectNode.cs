#region

using System.Collections.Generic;
using System.Xml;

#endregion

namespace FogBugzNet
{
    internal class ProjectNode
    {
        public Dictionary<int, XmlNode> MileStoneIdToNode = new Dictionary<int, XmlNode>();
        public XmlNode Node;
    }
}