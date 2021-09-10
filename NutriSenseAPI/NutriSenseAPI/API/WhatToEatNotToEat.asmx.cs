using DLLWhatToEatNotToEat;
using Newtonsoft.Json;
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
    /// Summary description for WhatToEatNotToEat
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WhatToEatNotToEat : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetWhatToEatNotToEat(string memberId, string pid, string diseaseID, string userLoginId)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_WhatToEatNotToEat pobj = new PAL_WhatToEatNotToEat();
                    pobj.pid = Convert.ToInt32(pid);
                    pobj.diseaseID = Convert.ToInt32(diseaseID);
                    //pobj.nutrientsIn = nutrientsIn;
                    //pobj.nutrientsNotIn = nutrientsNotIn;
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_WhatToEatNotToEat.getWhatToEatNotToEat(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "whatToEat";
                        returnDataset.Tables[1].TableName = "notToEat";
                        returnDataset.Tables[2].TableName = "common";
                        returnDataset.Tables[3].TableName = "nutral";
                        returnDataset.Tables[4].TableName = "foodGroups";
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
        public void GetFoodInteractedNutrients(string memberId, string pid, string diseaseID, string foodId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_WhatToEatNotToEat pobj = new PAL_WhatToEatNotToEat();
                    pobj.pid = Convert.ToInt32(pid);
                    pobj.diseaseID = Convert.ToInt32(diseaseID);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_WhatToEatNotToEat.getFoodInteractedNutrients(pobj);
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
        public void InsertRecipeDetails(string Ingredient, int pid, string foodId, string cookedFoodQty, string cookedFoodQtyUnit, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PAL_WhatToEatNotToEat pobj = new PAL_WhatToEatNotToEat();
                    pobj.tblIngredient = JsonConvert.DeserializeObject<DataTable>(Ingredient);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.pid = pid;
                    pobj.cookedFoodQty = Convert.ToDecimal(cookedFoodQty);
                    pobj.cookedFoodQtyUnit = Convert.ToInt32(cookedFoodQtyUnit);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_WhatToEatNotToEat.InsertRecipeDetails(pobj);
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
        public void InsertNewDish(string newDish, int pid, string foodGroupId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PAL_WhatToEatNotToEat pobj = new PAL_WhatToEatNotToEat();
                    pobj.newDish = newDish;
                    pobj.pid = pid;
                    pobj.foodGroupId = Convert.ToInt32(foodGroupId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_WhatToEatNotToEat.InsertNewDish(pobj);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCustomeDiseaseList(string userLoginId, string memberId, int pid)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_WhatToEatNotToEat pobj = new PAL_WhatToEatNotToEat();
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.pid = pid;
                    BAL_WhatToEatNotToEat.getCustomeDiseaseList(pobj);
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
