using DLLInvestigationFoodRelation;
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
    /// Summary description for InvestigationFoodRelation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InvestigationFoodRelation : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetInvestigationFoodRelation(string memberId, string pid, string diseaseID, string userLoginId,string fromDate,string toDate,string nutrientID)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_InvestigationFoodRelation pobj = new PAL_InvestigationFoodRelation();
                    pobj.pid = Convert.ToInt32(pid);
                    pobj.diseaseID = Convert.ToInt32(diseaseID);
                    pobj.nutrientID = Convert.ToInt32(nutrientID);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.fromDate = fromDate;
                    pobj.toDate = toDate;
                    BAL_InvestigationFoodRelation.getInvestigationFoodRelation(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "whatToEatNotToEat";
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
