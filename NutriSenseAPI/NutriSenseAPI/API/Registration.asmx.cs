using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Threading;
using DLLRegistration;
using DLLUtility;
using DLLUniversal;
using System.Data;
namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for Registration
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Registration : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CheckExistMobile(string CallingCodeId, string mobileNo)
        {
            DataSet ReturnDS = new DataSet();
            try
            {
                PAL_Registration pobj = new PAL_Registration();
                pobj.CallingCodeId = CallingCodeId;
                pobj.mobileNo = mobileNo;
                BAL_Registration.CheckExistMobile(pobj);
                if (!pobj.isException)
                {
                    if (pobj.DS.Tables.Count > 2)
                    {
                        ReturnDS.Tables.Add(pobj.DS.Tables[0].Copy());
                        ReturnDS.Tables.Add(pobj.DS.Tables[2].Copy());
                        ReturnDS.Tables[0].TableName = "Table";
                        ReturnDS.Tables[1].TableName = "Table1";
                        BackgroundMobileMessage(Convert.ToInt32(pobj.DS.Tables[1].Rows[0]["MessageId"]), pobj.DS.Tables[1].Rows[0]["Message"].ToString(), pobj.DS.Tables[1].Rows[0]["MobileNo"].ToString());
                        ServiceResponse.ExistsResponse(1, "Success!", ReturnDS, 1);
                    }
                    else
                    {
                        ServiceResponse.ExistsResponse(1, "Success!", pobj.DS, 0);
                    }
                }
                else
                {
                    ServiceResponse.ExistsResponse(0, pobj.exceptionMessage, ReturnDS,0);
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.ExistsResponse(0, ex.Message, ReturnDS, 0);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SendMobileOTP(string CallingCodeId, string mobileNo)
        {
            DataTable returnTable = new DataTable();
            try
            {
                DataSet ReturnDS = new DataSet();
                PAL_Registration pobj = new PAL_Registration();
                pobj.CallingCodeId = CallingCodeId;
                pobj.mobileNo = mobileNo;
                BAL_Registration.SendMobileOTP(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[0];
                    BackgroundMobileMessage(Convert.ToInt32(pobj.DS.Tables[1].Rows[0]["MessageId"]), pobj.DS.Tables[1].Rows[0]["Message"].ToString(), pobj.DS.Tables[1].Rows[0]["MobileNo"].ToString());
                    ServiceResponse.GeneralResponse(1, "Success!", returnTable);
                }
                else
                {
                    ServiceResponse.GeneralResponse(0, pobj.exceptionMessage,returnTable);
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message,returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ResendMobileOTP(string mobileOTPId, string CallingCodeId, string mobileNo)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Registration pobj = new PAL_Registration();
                pobj.mobileOTPId = Convert.ToInt32(mobileOTPId);
                pobj.CallingCodeId = CallingCodeId;
                pobj.mobileNo = mobileNo;

                BAL_Registration.ReGenerateMobileOTP(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[0];
                    BackgroundMobileMessage(Convert.ToInt32(pobj.DS.Tables[1].Rows[0]["MessageId"]), pobj.DS.Tables[1].Rows[0]["Message"].ToString(), pobj.DS.Tables[1].Rows[0]["MobileNo"].ToString());
                    ServiceResponse.GeneralResponse(1, "Success!", returnTable);
                }
                else
                {
                    ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, returnTable);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message,returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void MobileOTPVerification(string mobileOTPId, string CallingCodeId, string mobileNo, string otp)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Registration pobj = new PAL_Registration();
                pobj.mobileOTPId = Convert.ToInt32(mobileOTPId);
                pobj.CallingCodeId = CallingCodeId;
                pobj.mobileNo = mobileNo;
                pobj.otp = Convert.ToInt32(otp);
                pobj.ipAddress = Context.Request.UserHostAddress;
                BAL_Registration.MobileOTPVerification(pobj);
                if (!pobj.isException)
                {
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
        public void NewRegistration(string CallingCodeId, string mobileNo, string emailId, string password, string name, string gender, string dob, string height, string weight, string activity, string isPregnant, string pregnantCondition, string islactation, string lactationCondition)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (HttpContext.Current.Request.Headers.GetValues("token") != null)
                {
                    PAL_Registration pobj = new PAL_Registration();
                    pobj.CallingCodeId = CallingCodeId;
                    pobj.mobileNo = mobileNo;
                    pobj.emailId = emailId;
                    pobj.password = password;
                    pobj.name = name;
                    pobj.gender = Convert.ToInt32(gender);
                    pobj.dob = Convert.ToDateTime(dob);
                    pobj.height = Convert.ToDecimal(height);
                    pobj.weight = Convert.ToDecimal(weight);
                    pobj.activity = Convert.ToInt32(activity);
                    pobj.isPregnant = Convert.ToInt32(isPregnant);
                    pobj.pregnantCondition = Convert.ToInt32(pregnantCondition);
                    pobj.islactation = Convert.ToInt32(islactation);
                    pobj.lactationCondition = Convert.ToInt32(lactationCondition);
                    pobj.ipAddress = Context.Request.UserHostAddress;
                    pobj.regToken = HttpContext.Current.Request.Headers.GetValues("token").First();
                    BAL_Registration.NewRegistration(pobj);
                    if (!pobj.isException)
                    {
                        returnTable = pobj.DS.Tables[1];
                        BackgroundMobileMessage(Convert.ToInt32(pobj.DS.Tables[0].Rows[0]["MessageId"]), pobj.DS.Tables[0].Rows[0]["Message"].ToString(), pobj.DS.Tables[0].Rows[0]["MobileNo"].ToString());
                        ServiceResponse.TokenResponse(1, "Success!", returnTable, pobj.DS.Tables[0].Rows[0]["Token"].ToString());
                    }
                    else
                    {
                        if (pobj.exceptionMessage == "Not Authorised!")
                        {
                            ServiceResponse.AuthenticationErrorTokenResponse();
                        }
                        else
                        {
                            ServiceResponse.TokenResponse(0, pobj.exceptionMessage, returnTable,"");
                        }
                    }
                }
                else
                {
                    ServiceResponse.AuthenticationErrorTokenResponse();
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.TokenResponse(0, exception.Message, returnTable,"");
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
