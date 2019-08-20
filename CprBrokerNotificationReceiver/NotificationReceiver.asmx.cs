using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CprBrokerNotificationReceiver
{
    /// <summary>
    /// This API sole purpose is to receive notifications(SOAP Requests) from CPR Broker.
    /// An an example
    /// </summary>
    [WebService(Namespace = "https://CprBrokerNotificationReceiver/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Receiver : System.Web.Services.WebService, INotificationSoap12
    {
        public void Notify(CommonEventStructureType notification)
        {
            NotificationProcessor.ProcessNotification(notification);
        }

        public void Ping()
        {
            throw new NotImplementedException();
        }
    }
}
