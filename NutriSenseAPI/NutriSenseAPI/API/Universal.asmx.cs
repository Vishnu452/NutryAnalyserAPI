using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using DLLUniversal;
namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for Universal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   [System.Web.Script.Services.ScriptService]
    public class Universal : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCountryList()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                BAL_Universal.GetCountryList(pobj);

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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCountryCallingCode()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                BAL_Universal.GetCountryCallingCode(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[0];
                    ServiceResponse.GeneralResponse(1, "Success!", returnTable);
                }
                else
                {
                    ServiceResponse.GeneralResponse(0, pobj.exceptionMessage,returnTable);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message,returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetStateList(string countryId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                pobj.countryId = Convert.ToInt32(countryId);
                BAL_Universal.GetStateList(pobj);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDistrictList(string stateId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                pobj.stateId = Convert.ToInt32(stateId);
                BAL_Universal.GetDistrictList(pobj);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetPregnantCondition()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                BAL_Universal.GetPregnantCondition(pobj);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetLifeStyleCategory()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                BAL_Universal.GetLifeStyleCategory(pobj);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetGender()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                BAL_Universal.GetGender(pobj);

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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetNutrientActivecompoundFact(string foodId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                pobj.foodId = Convert.ToInt32(foodId);
                BAL_Universal.GetNutrientActivecompoundFact(pobj);
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


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetFoodUnitByFoodId(string foodId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                pobj.foodId = Convert.ToInt32(foodId);
                BAL_Universal.GetFoodUnitByFoodId(pobj);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetLactationCondition()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                BAL_Universal.GetLactationCondition(pobj);
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
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetIntakeUnitByIntakeId(int intakeID, int textID, int isSupplement, int isSynonym)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Universal pobj = new PAL_Universal();
                pobj.intakeID = intakeID;
                pobj.textID = textID;
                pobj.isSupplement = isSupplement;
                pobj.isSynonym = isSynonym;
                BAL_Universal.GetIntakeUnitByIntakeId(pobj);
                if (!pobj.isException)
                {
                    IntakeDoseData intakeDoseData = new IntakeDoseData();
                    for (int i = 0; i < pobj.DS.Tables[1].Rows.Count; i++)
                    {
                        List<UnitList> unitList = new List<UnitList>();
                        for (int j = 0; j < pobj.DS.Tables[1].Rows.Count; j++)
                        {
                            unitList.Add(new UnitList
                            {
                                id = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["unitID"]),
                                unitName = pobj.DS.Tables[1].Rows[j]["unitName"].ToString()
                            });
                        }

                        intakeDoseData.defaultQuantity = pobj.DS.Tables[0].Rows[0]["defaultQuantity"].ToString();
                        intakeDoseData.defaultUnitID = Convert.ToInt32(pobj.DS.Tables[0].Rows[0]["defaultUnitID"]);
                        intakeDoseData.unitList = unitList;
                    }

                    ServiceResponse.GeneralResponseObject(1, "Success!", intakeDoseData);
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
