using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/* MIT License

Copyright (c) 2019 Magenta ApS

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */

namespace CprBrokerNotificationReceiver
{
    public static class NotificationProcessor
    {
        public static void ProcessNotification(CommonEventStructureType notification)
        {
            string filePath = System.Configuration.ConfigurationManager.AppSettings["filePath"];
            string fileName = System.Configuration.ConfigurationManager.AppSettings["fileName"];
            string target = string.Format("{0}/{1}", filePath, fileName);

            string soapEnvelope = SerializeToXML(notification);

            if (!File.Exists(target))
            {
                using (StreamWriter sw = File.CreateText(target))
                {
                    sw.WriteLine(soapEnvelope);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(target))
                {
                    sw.WriteLine(soapEnvelope);
                }
            }
        }

        public static string SerializeToXML<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
