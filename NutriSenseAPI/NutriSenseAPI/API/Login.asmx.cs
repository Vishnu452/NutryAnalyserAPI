using System;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using DLLLogin;
using System.Threading;
using DLLUtility;
using DLLUniversal;
using System.Web;
using System.Linq;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Login : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void LoginAuthentication(string CallingCodeId, string userName, string password)
        {
           DataTable returnTable = new DataTable();
            try
            {
                PAL_Login pobj = new PAL_Login();
                pobj.CallingCodeId = CallingCodeId;
                pobj.userName = userName;
                pobj.userPwd = password;
                pobj.ipAddress = Context.Request.UserHostAddress;
                BAL_Login.LoginAuthentication(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[1];
                    ServiceResponse.TokenResponse(1, "Success!", returnTable, pobj.DS.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    ServiceResponse.TokenResponse(0, pobj.exceptionMessage, returnTable,"");
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.TokenResponse(0, exception.Message, returnTable,"");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ForgetPassword(string CallingCodeId, string userName)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Login pobj = new PAL_Login();
                pobj.CallingCodeId = CallingCodeId;
                pobj.userName = userName;
                BAL_Login.ForgetPassword(pobj);
                if (!pobj.isException)
                {
                    BackgroundMobileMessage(Convert.ToInt32(pobj.DS.Tables[0].Rows[0]["MessageId"]), pobj.DS.Tables[0].Rows[0]["Message"].ToString(), pobj.DS.Tables[0].Rows[0]["MobileNo"].ToString());
                    ServiceResponse.ResponseWithoutValue(1, "Success!");
                }
                else
                {
                    ServiceResponse.ResponseWithoutValue(0, pobj.exceptionMessage);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ChangePassword(string oldPassword, string newPassword, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_Login pobj = new PAL_Login();
                    pobj.oldPassword = oldPassword;
                    pobj.newPassword = newPassword;
                    pobj.userLoginID = userLoginID;
                    BAL_Login.ChangePassword(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Logout(string deviceToken, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_Login pobj = new PAL_Login();
                    pobj.deviceToken = deviceToken;
                    pobj.userLoginID = userLoginID;
                    pobj.userToken = HttpContext.Current.Request.Headers.GetValues("token").First();
                    BAL_Login.Logout(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CheckVersion(string appVersion, int appType)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Login pobj = new PAL_Login();
                pobj.appVersion = appVersion;
                pobj.appType = appType;
                BAL_Login.CheckVersion(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetMenuList(int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_Login pobj = new PAL_Login();
                    pobj.userLoginID = userLoginID;
                    BAL_Login.GetMenuList(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, returnTable);
            }
        }

        private void BackgroundMobileMessage(int messageId, string message, string mobileNo)
        {
            Thread messageThread = new Thread(delegate ()
            {
                if (Utility.SendMessage(message, mobileNo))
                {
                    PAL_Universal pobj = new PAL_Universal();
                    pobj.messageId = messageId;
                    BAL_Universal.UpdateMobileMessageStatus(pobj);
                }
            });
            messageThread.IsBackground = true;
            messageThread.Start();
        }
    }
}
