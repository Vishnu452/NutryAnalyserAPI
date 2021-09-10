using System;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using DLLWaterIntake;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for WaterIntake
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WaterIntake : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetWaterIntakeDetail(string memberId, string userLoginId, string date)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_WaterIntake pobj = new PAL_WaterIntake();
                    pobj.userID = Convert.ToInt32(userLoginId);
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.date = date;
                    BAL_WaterIntake.GetWaterIntakeDetail(pobj);
                    if (!pobj.isException)
                    {
                        dt = pobj.DS.Tables[0];
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, dt);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddWaterGlass(string memberId, string userLoginId, string date)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_WaterIntake pobj = new PAL_WaterIntake();
                    pobj.userID = Convert.ToInt32(userLoginId);
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.date = date;
                    BAL_WaterIntake.IntakeWaterGlass(pobj);
                    if (!pobj.isException)
                    {
                        dt = pobj.DS.Tables[0];
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, dt);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void RemoveWaterGlass(string memberId, string userLoginId, string date)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_WaterIntake pobj = new PAL_WaterIntake();
                    pobj.userID = Convert.ToInt32(userLoginId);
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.date = date;
                    BAL_WaterIntake.RemoveWaterGlass(pobj);
                    if (!pobj.isException)
                    {
                        dt = pobj.DS.Tables[0];
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, dt);
            }
        }
    }
}
