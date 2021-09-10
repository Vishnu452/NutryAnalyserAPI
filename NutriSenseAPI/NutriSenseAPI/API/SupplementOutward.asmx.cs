using DDLSupplementOutward;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using DLLUtility;
using Newtonsoft.Json;
using System.Data;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for SupplementOutward
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SupplementOutward : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SaveSupplementOutward(string supplementoutward)
        {
            try
            {
                PAL_SupplementOutWard pobj = new PAL_SupplementOutWard();
                if ((supplementoutward != null) && (supplementoutward.Any()))
                {
                    pobj.DT_outwardItemList = JsonConvert.DeserializeObject<DataTable>(supplementoutward);                   
                    BAL_SupplementOutward.OutwardsupplementDetails(pobj);
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
            catch (Exception ex)
            {
                ServiceResponse.ResponseWithoutValue(0, ex.Message);
            }
        }
    }
}
