using DLLDeficientNutrientReport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for DeficientNutrientReport
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DeficientNutrientReport : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDeficientNutrientBetweenTwoDates(string memberId, string intakeFromDate, string intakeToDate, string userLoginId)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_DeficientNutrientReport pobj = new PAL_DeficientNutrientReport();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.intakeFromDate = Convert.ToDateTime(intakeFromDate);
                    pobj.intakeToDate = Convert.ToDateTime(intakeToDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_DeficientNutrientReport.GetDeficientNutrientBetweenTwoDates(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "DatewiseNutrients";
                        returnDataset.Tables[1].TableName = "RDA";
                        returnDataset.Tables[2].TableName = "NutrientForHeading";
                        returnDataset.Tables[3].TableName = "NutrientAverage";
                        ServiceResponse.GeneralResponseDataSet(1, "Success!", returnDataset);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, returnDataset);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponseDataSet(0, ex.Message, returnDataset);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetNutrientAverageDeficiencyBetweenTwoDates(string memberId, string intakeFromDate, string intakeToDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_DeficientNutrientReport pobj = new PAL_DeficientNutrientReport();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.intakeFromDate = Convert.ToDateTime(intakeFromDate);
                    pobj.intakeToDate = Convert.ToDateTime(intakeToDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_DeficientNutrientReport.GetNutrientAverageDeficiencyBetweenTwoDates(pobj);
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
    }
}
