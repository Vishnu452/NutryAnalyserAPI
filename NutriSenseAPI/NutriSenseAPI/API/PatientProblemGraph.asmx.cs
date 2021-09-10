using DLLPatientProblemGraph;
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
    /// Summary description for PatientProblemGraph
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PatientProblemGraph : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetPatientProblemGraph(string userLoginID, string memberId, string fromDate, string toDate)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberId)))
                {
                    PAL_PatientProblemGraph pobj = new PAL_PatientProblemGraph();

                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.fromDate = fromDate;
                    pobj.toDate = toDate;
                    BAL_PatientProblemGraph.getPatientProblemGraph(pobj);
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
