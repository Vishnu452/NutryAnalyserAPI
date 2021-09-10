using System;
using System.Web.Services;
using System.Web.Script.Services;
using DLLFeedback;
using System.Data;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for Feedback
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Feedback : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SubmitFeedback(string userLoginID, string feedbackCategoryID, string feedback)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_Feedback pobj = new PAL_Feedback();
                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.feedbackCategoryID = Convert.ToInt32(feedbackCategoryID);
                    pobj.feedback = feedback;
                    BAL_Feedback.SubmitFeedback(pobj);
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
        public void GetFeedbackCategory()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Feedback pobj = new PAL_Feedback();
                BAL_Feedback.GetFeedbackCategory(pobj);
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
    }
}
