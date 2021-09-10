using System;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using DLLHealthPrediction;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for HealthPrediction
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HealthPrediction : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetTodaysHealthPrediction(string userLoginID, string memberID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_HealthPrediction pobj = new PAL_HealthPrediction();
                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.memberID = Convert.ToInt32(memberID);
                    BAL_HealthPrediction.GetTodaysHealthPrediction(pobj);
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
    }
}
