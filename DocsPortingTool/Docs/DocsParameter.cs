﻿using System.Xml.Linq;

namespace DocsPortingTool.Docs
{
    public class DocsParameter
    {
        private XElement XEParameter = null;
        public string Name
        {
            get
            {
                return XmlHelper.GetAttributeValue(XEParameter, "Name");
            }
        }
        public string Type
        {
            get
            {
                return XmlHelper.GetAttributeValue(XEParameter, "Type");
            }
        }
        public DocsParameter(XElement xeParameter)
        {
            XEParameter = xeParameter;
        }
    }
}