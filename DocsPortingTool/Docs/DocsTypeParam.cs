﻿using System.Threading;
using System.Xml.Linq;

namespace DocsPortingTool.Docs
{
    /// <summary>
    /// Each one of these typeparam objects live inside the Docs section inside the Member object.
    /// </summary>
    public class DocsTypeParam
    {
        private XElement XEDocsTypeParam = null;
        public IDocsAPI ParentAPI
        {
            get; private set;
        }
        public string Name
        {
            get
            {
                return XmlHelper.GetAttributeValue(XEDocsTypeParam, "name");
            }
        }
        public string Value
        {
            get
            {
                return XmlHelper.GetNodesInPlainText(XEDocsTypeParam);
            }
            set
            {
                XmlHelper.SaveFormattedAsXml(XEDocsTypeParam, value);
                ParentAPI.Changed = true;
            }
        }

        public DocsTypeParam(IDocsAPI parentAPI, XElement xeDocsTypeParam)
        {
            ParentAPI = parentAPI;
            XEDocsTypeParam = xeDocsTypeParam;
        }
    }
}