using System;
using System.Web.Services;
using System.Data;
using DLLNotification;
using System.Web.Script.Services;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for Notification
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Notification : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertFCMDeviceToken(string deviceToken, string userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_Notification pobj = new PAL_Notification();
                    pobj.deviceToken = deviceToken;
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_Notification.InsertFCMDeviceToken(pobj);
                    if (!pobj.isException)
                    {
                        ServiceResponse.ResponseWithoutValue(1, "Success!");
                    }
                    else
                    {
                        ServiceResponse.ResponseWithoutValue(0, pobj.exceptionMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.ResponseWithoutValue(0, ex.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetNotificationList(string userLoginID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_Notification pobj = new PAL_Notification();
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_Notification.GetNotificationList(pobj);
                    if (!pobj.isException)
                    {
                        dt = pobj.DS.Tables[0];
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, dt);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetNotificationDetails(string notificationID, string userLoginID)
        {
            DataSet ds = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_Notification pobj = new PAL_Notification();
                    pobj.notificationID = Convert.ToInt32(notificationID);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_Notification.GetNotificationDetails(pobj);
                    if (!pobj.isException)
                    {
                        ds = pobj.DS;
                        ds.Tables[0].TableName = "NotificationDetails";
                        ds.Tables[1].TableName = "IntakeList";
                        ServiceResponse.GeneralResponseDataSet(1, "Success!", ds);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, ds);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponseDataSet(0, ex.Message, ds);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetUnreadNotificationCount(string userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_Notification pobj = new PAL_Notification();
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_Notification.GetUnreadNotificationCount(pobj);
                    if (!pobj.isException)
                    {
                        returnTable = pobj.DS.Tables[0];
                        ServiceResponse.GeneralResponse(1, "Success!", returnTable);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, returnTable);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, returnTable);
            }
        }

        public static void SendNotification(string notificationBody, string notificationTitle, int notificationBadge, int notificationID, string deviceToken)
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAZD8idME:APA91bEf8YUOBDsc0x7s2Qg4MG3TrJwjS0VWA56Dhff0MdaeqKyOyQS6u2uDCAG0OG4vd5jJ_42Vq4FiBG7dd406faZQ_PCnd6luos34XBd6dE_Ls2qGmJ5tjUWR1tCo3g-vEjcukCXL"));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", "430555952321"));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = deviceToken,
                priority = "high",
                content_available = true,
                notification = new
                {
                    body = notificationBody,
                    title = notificationTitle,
                    badge = notificationBadge
                },
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                dynamic json = JsonConvert.DeserializeObject(sResponseFromServer);
                                PAL_Notification pobj = new PAL_Notification();
                                pobj.notificationID = notificationID;
                                if (json.success == 1)
                                {
                                    pobj.messageID = json.results[0].message_id;
                                    BAL_Notification.UpdateNotificationSentStatus(pobj);
                                }
                                else
                                {
                                    BAL_Notification.UpdateNotificationStatus(pobj);
                                }
                            }
                    }
                }
            }
        }
    }
}
