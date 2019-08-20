using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

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
