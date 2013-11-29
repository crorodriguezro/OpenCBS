using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace OpenCBS.GUI.Localization
{
    class LanguageParser
    {
        private static string _fileName = @"C:\repos\opencbs\Src\OpenCBS.GUI\Localization\strings.xml";
        private static Dictionary<string, string> _dictionary;
        private static List<string> _languages;

        public static Dictionary<string, string> Dictionary
        {
            get { return _dictionary; }
        }

        public static List<string> Languages
        {
            get { return _languages; }
        }

        public static void parseXML(string language)
        {
            List<KeyValuePair<string, string>> keypair = new List<KeyValuePair<string, string>>();
            _dictionary = new Dictionary<string, string>();
            _languages = new List<string>();

            Trace.IndentLevel = 1;
            Trace.Indent();
            Trace.WriteLine("Loading " + _fileName);
            Trace.Unindent();
            XmlDocument doc = new XmlDocument();
            doc.Load(_fileName);
            XmlElement root = doc.DocumentElement;
            Debug.Assert(root != null, "Root element not found");

            XmlNodeList node1 = doc.GetElementsByTagName("languages");

            foreach (XmlNode node in node1[0].ChildNodes)
            {
                XmlAttribute fn = node.Attributes["name"];
                if (null == fn) continue;
                _languages.Add(fn.Value);
            }


            XmlNodeList nodelist = doc.GetElementsByTagName("items");

            foreach (XmlNode node in nodelist[0].ChildNodes)
            {
                XmlAttribute fn = node.Attributes["name"];
                XmlNode la = node.SelectSingleNode(language);
                if (null == fn || null == la) continue;
                if (!language.Equals("en-En")) keypair.Add(new KeyValuePair<string, string>(fn.Value, la.InnerText));
                else keypair.Add(new KeyValuePair<string, string>(fn.Value, fn.Value));
            }

            foreach (var res in keypair.OrderByDescending(i => i.Key.Length)) _dictionary.Add(res.Key, res.Value);

        }
    }
}
