using System;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using DLLNutrientAchievementReport;
using System.Threading;
using DLLUtility;
using DLLUniversal;
using System.Web;
using System.Linq;
using Newtonsoft.Json;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for NutrientAchievementReport
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class NutrientAchievementReport : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDateListBetweenDates(string intakeFromdate, string intakeToDate, int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_NutrientAchievementReport pobj = new PAL_NutrientAchievementReport();
                    pobj.intakeFromdate = intakeFromdate;
                    pobj.intakeToDate = intakeToDate;
                    BAL_NutrientAchievementReport.GetDateListBetweenDates(pobj);
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
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetNutrientAverageBySelectedDates(string dateList, int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_NutrientAchievementReport pobj = new PAL_NutrientAchievementReport();
                    pobj.dateList = JsonConvert.DeserializeObject<DataTable>(dateList);
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_NutrientAchievementReport.GetNutrientAverageBySelectedDates(pobj);
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
