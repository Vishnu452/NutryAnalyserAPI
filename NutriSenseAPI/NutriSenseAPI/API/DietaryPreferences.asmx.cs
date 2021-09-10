using System;
using System.Web.Services;
using System.Web.Script.Services;
using DLLDietaryPreferences;
using Newtonsoft.Json;
using System.Data;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for DietaryDetails
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DietaryPreferences : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertUserDietaryPrefferedFood(string foodFamilyList, int memberID, int foodTypeID ,int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_DietaryPreferences pobj = new PAL_DietaryPreferences();
                    pobj.dtDietFoodPreffered = JsonConvert.DeserializeObject<DataTable>(foodFamilyList);
                    pobj.memberId = Convert.ToInt32(memberID);
                    pobj.userId = Convert.ToInt32(userLoginID);
                    pobj.foodTypeID = foodTypeID;
                    BAL_DietaryPreferences.InsertUserDietaryPrefferedFood(pobj);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertUserDietaryAvoidFood(string foodFamilyList, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_DietaryPreferences pobj = new PAL_DietaryPreferences();
                    pobj.dtDietFoodAvoid = JsonConvert.DeserializeObject<DataTable>(foodFamilyList);
                    pobj.memberId = Convert.ToInt32(memberID);
                    pobj.userId = Convert.ToInt32(userLoginID);
                    BAL_DietaryPreferences.InsertUserDietaryAvoidFood(pobj);
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


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertUserDisease(string diseaseList, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PAL_DietaryPreferences pobj = new PAL_DietaryPreferences();
                    pobj.diseaseList = JsonConvert.DeserializeObject<DataTable>(diseaseList);
                    pobj.memberId = Convert.ToInt32(memberID);
                    pobj.userId = Convert.ToInt32(userLoginID);
                    BAL_DietaryPreferences.InsertUserDisease(pobj);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetFoodType()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_DietaryPreferences pobj = new PAL_DietaryPreferences();
                BAL_DietaryPreferences.GetFoodType(pobj);
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
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetFoodFamilyListByFoodType(int foodTypeID, int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_DietaryPreferences pobj = new PAL_DietaryPreferences();
                pobj.foodTypeID = Convert.ToInt32(foodTypeID);
                pobj.memberId = Convert.ToInt32(memberID);
                BAL_DietaryPreferences.GetFoodByFoodType(pobj);
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
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, returnTable);
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetRestrictedFoodFamilyList(int foodTypeID, int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_DietaryPreferences pobj = new PAL_DietaryPreferences();
                pobj.foodTypeID = Convert.ToInt32(foodTypeID);
                pobj.memberId = Convert.ToInt32(memberID);
                BAL_DietaryPreferences.GetRestrictedFood(pobj);
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
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, returnTable);
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetAllergicFoodFamilyList(int foodTypeID, int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_DietaryPreferences pobj = new PAL_DietaryPreferences();
                pobj.foodTypeID = Convert.ToInt32(foodTypeID);
                pobj.memberId = Convert.ToInt32(memberID);
                BAL_DietaryPreferences.GetAllergicFood(pobj);
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
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCommonDiseaseList(int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_DietaryPreferences pobj = new PAL_DietaryPreferences();
                pobj.memberId = Convert.ToInt32(memberID);
                BAL_DietaryPreferences.GetDiseaseList(pobj);
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
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponse(0, ex.Message, returnTable);
            }
        }
    }
}
