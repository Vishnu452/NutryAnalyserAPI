using DLLFoodNutrientList;
using System;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for FoodNutritionalList
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FoodNutritionalList : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetFoodCategory(string userLoginID, string memberId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberId)))
                {
                    PAL_FoodNutrientList pobj = new PAL_FoodNutrientList();
                    
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_FoodNutrientList.getFoodCategory(pobj);
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
        public void GetFoodGroup(string userLoginID, string memberId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberId)))
                {
                    PAL_FoodNutrientList pobj = new PAL_FoodNutrientList();

                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_FoodNutrientList.getFoodGroup(pobj);
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
        public void GetFoodUnit(string userLoginID, string memberId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberId)))
                {
                    PAL_FoodNutrientList pobj = new PAL_FoodNutrientList();

                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_FoodNutrientList.geFoodUnit(pobj);
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
        public void GetFoodList(int? groupID, int? categoryID, string foodNamePrefix, int userLoginID, int memberId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberId)))
                {
                    PAL_FoodNutrientList pobj = new PAL_FoodNutrientList();
                    pobj.groupID = (groupID== 0 || groupID == null)?null: groupID;
                    pobj.categoryID = (categoryID == 0 || categoryID == null) ? null : categoryID;
                    pobj.foodNamePrefix = foodNamePrefix;
                    pobj.userID = userLoginID;
                    BAL_FoodNutrientList.getFoodList(pobj);
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
        public void GetNutrientList(string foodID, string unitID, string quantity, string userLoginID, string memberId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberId)))
                {
                    PAL_FoodNutrientList pobj = new PAL_FoodNutrientList();
                    pobj.foodID = Convert.ToInt32(foodID); 
                    pobj.unitID = Convert.ToInt32(unitID);
                    pobj.quantity = Convert.ToInt32(quantity);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_FoodNutrientList.getFoodNutrientList(pobj);
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
