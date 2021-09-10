using System;
using System.Web.Services;
using System.Web.Script.Services;
using DLLIdealNutrientGraph;
using System.Data;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for IdealNutrientGraph
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IdealNutrientGraph : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetNutrientSerachList(string searchText, int memberID, int userLoginID)
        {
            DataTable DT = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_IdealNutrientGraph pobj = new PAL_IdealNutrientGraph();
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    pobj.searchText = searchText;
                    BAL_IdealNutrientGraph.GetNutrientSerachList(pobj);
                    if (!pobj.isException)
                    {
                        DT = pobj.DS.Tables[0];
                        ServiceResponse.GeneralResponse(1, "Success!", DT);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, DT);
                    }
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, DT);
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetIdealNutrientIntakeGraphData(int nutrientID, int memberID, int userLoginID)
        {
            DataSet DS = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_IdealNutrientGraph pobj = new PAL_IdealNutrientGraph();
                    pobj.nutrientID = nutrientID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_IdealNutrientGraph.GetIdealNutrientIntakeGraphData(pobj);
                    if (!pobj.isException)
                    {
                        DS = pobj.DS;
                        DS.Tables[0].TableName = "RDADetails";
                        DS.Tables[1].TableName = "IntakeDetails";
                        DS.Tables[2].TableName = "GraphDetails";
                        ServiceResponse.GeneralResponseDataSet(1, "Success!", DS);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, DS);
                    }
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponseDataSet(0, exception.Message, DS);
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetIdealSupplementIntakeGraphData(int nutrientID, string intakeDate, int memberID, int userLoginID)
        {
            DataSet DS = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_IdealNutrientGraph pobj = new PAL_IdealNutrientGraph();
                    pobj.nutrientID = nutrientID;
                    pobj.intakeDate = intakeDate;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_IdealNutrientGraph.GetIdealSupplementIntakeGraphData(pobj);
                    if (!pobj.isException)
                    {
                        DS = pobj.DS;
                        DS.Tables[0].TableName = "RDADetails";
                        DS.Tables[1].TableName = "IntakeDetails";
                        DS.Tables[2].TableName = "GraphDetails";
                        DS.Tables[3].TableName = "GraphDetailsFood";
                        ServiceResponse.GeneralResponseDataSet(1, "Success!", DS);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, DS);
                    }
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponseDataSet(0, exception.Message, DS);
            }
        }
    }
}
