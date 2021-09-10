using DLLNutritionReports;
using System;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for NutritionReports
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NutritionReports : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetNutrititionBetweenTwoDates(string memberId, string intakeFromDate, string intakeToDate, string nutrientList, string userLoginId)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_NutritionReports pobj = new PAL_NutritionReports();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.intakeFromDate = Convert.ToDateTime(intakeFromDate);
                    pobj.intakeToDate = Convert.ToDateTime(intakeToDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    DataTable nutrientTable = new DataTable();
                    nutrientTable.Columns.Add("nutrientName");
                    nutrientList= nutrientList.Trim(',');
                    string[] nutrientNameArray = nutrientList.Split(',');
                    for (int i = 0; i < nutrientNameArray.Length; i++)
                    {
                        nutrientTable.Rows.Add(nutrientNameArray[i].Trim());
                    }
                    pobj.nutrientNameList = nutrientTable;

                    BAL_NutritionReports.GetNutrititionBetweenTwoDates(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "DatewiseNutrients";
                        returnDataset.Tables[1].TableName = "RDA";
                        returnDataset.Tables[2].TableName = "NutrientForHeading";
                        returnDataset.Tables[3].TableName = "DateForHeading";
                        returnDataset.Tables[4].TableName = "NutrientInRow";
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
    }
}
