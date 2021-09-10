using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using DLLRecipeMaster;
using System.Data;
using Newtonsoft.Json;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for RecipeMaster
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RecipeMaster : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertRecipeDetails(string Ingredient, string foodId, string cookedFoodQty, string cookedFoodQtyUnit, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALRecipeMaster pobj = new PALRecipeMaster();
                    pobj.tblIngredient = JsonConvert.DeserializeObject<DataTable>(Ingredient);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.cookedFoodQty = Convert.ToDecimal(cookedFoodQty);
                    pobj.cookedFoodQtyUnit = Convert.ToInt32(cookedFoodQtyUnit);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALRecipeMster.InsertRecipeDetails(pobj);
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
        public void DeleteRecipeDetails(string foodId, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALRecipeMaster pobj = new PALRecipeMaster();
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALRecipeMster.DeleteRecipeDetails(pobj);
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
        public void InsertNewDish(string newDish, string foodGroupId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALRecipeMaster pobj = new PALRecipeMaster();
                    pobj.newDish = newDish;
                    pobj.foodGroupId = Convert.ToInt32(foodGroupId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALRecipeMster.InsertNewDish(pobj);
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
        public void GetRecipeList()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PALRecipeMaster pobj = new PALRecipeMaster();
                BALRecipeMster.GetRecipeList(pobj);
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
        public void GetRecipeListByUserId(string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALRecipeMaster pobj = new PALRecipeMaster();
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALRecipeMster.GetRecipeListByUserId(pobj);
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
        public void GetIngredientsByfoodId(string foodId, string userLoginId)
        {
            List<RecipeMasterData> RecipeMasterData = new List<RecipeMasterData>();
            int isExists = 0;
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALRecipeMaster pobj = new PALRecipeMaster();
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALRecipeMster.GetIngredientsByfoodId(pobj);
                    if (!pobj.isException)
                    {
                        List<tblIngredient> tblIngredient = new List<tblIngredient>();
                        List<CookedFoodUnits> CookedUnit = new List<CookedFoodUnits>();
                        List<CookedFoodDetails> CookedFoodDetails = new List<CookedFoodDetails>();

                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            List<Units> tblUnit = new List<Units>();
                            for (int j = 0; j < pobj.DS.Tables[1].Rows.Count; j++)
                            {
                                if (pobj.DS.Tables[0].Rows[i]["id"].ToString() == pobj.DS.Tables[1].Rows[j]["foodID"].ToString())
                                {
                                    tblUnit.Add(new Units
                                    {
                                        id = pobj.DS.Tables[1].Rows[j]["unitID"].ToString(),
                                        unitName = pobj.DS.Tables[1].Rows[j]["unitName"].ToString()
                                    });
                                }
                            }

                            tblIngredient.Add(new tblIngredient
                            {
                                foodId = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["id"].ToString()),
                                foodName = pobj.DS.Tables[0].Rows[i]["foodName"].ToString(),
                                ingredientQuantity = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["ingredientQuantity"].ToString()),
                                unitID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["unitID"].ToString()),
                                unitName = pobj.DS.Tables[0].Rows[i]["unitName"].ToString(),
                                tblUnit = tblUnit
                            });
                        }

                        for (int i = 0; i < pobj.DS.Tables[2].Rows.Count; i++)
                        {
                            CookedUnit.Add(new CookedFoodUnits
                            {
                                unitID = pobj.DS.Tables[2].Rows[i]["unitID"].ToString(),
                                unitName = pobj.DS.Tables[2].Rows[i]["unitName"].ToString()
                            });
                        }

                        if (pobj.DS.Tables[3].Rows.Count > 0)
                        {
                            CookedFoodDetails.Add(new CookedFoodDetails
                            {
                                foodID = Convert.ToInt32(pobj.DS.Tables[3].Rows[0]["foodID"].ToString()),
                                foodQuantity = Convert.ToDecimal(pobj.DS.Tables[3].Rows[0]["foodQuantity"].ToString()),
                                unitID = Convert.ToInt32(pobj.DS.Tables[3].Rows[0]["unitID"].ToString()),
                                unitName = pobj.DS.Tables[3].Rows[0]["unitName"].ToString(),
                            });
                        }

                        RecipeMasterData.Add(new RecipeMasterData
                        {
                            tblIngredient = tblIngredient,
                            cookedFoodUnit = CookedUnit,
                            CookedFoodDetails = CookedFoodDetails
                        });

                        if (pobj.DS.Tables[0].Rows.Count > 0)
                        {
                            isExists = 1;
                        }
                          ServiceResponse.GeneralResponseObjectWithIsExists(1, "Success!", RecipeMasterData, isExists);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseObjectWithIsExists(0, pobj.exceptionMessage, RecipeMasterData, isExists);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponseObjectWithIsExists(0, ex.Message, RecipeMasterData, isExists);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetIngredientByPrefixText(string prefixText)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PALRecipeMaster pobj = new PALRecipeMaster();
                pobj.prefixText = prefixText;
                BALRecipeMster.GetIngredientsByPrefixtext(pobj);
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
        public void GetCookedFoodListByPrefixText(string prefixText)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PALRecipeMaster pobj = new PALRecipeMaster();
                pobj.prefixText = prefixText;
                BALRecipeMster.GetCookedFoodListByPrefixText(pobj);
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
        public void GetFoodListByPrefixText(string prefixText, string memberId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PALRecipeMaster pobj = new PALRecipeMaster();
                pobj.prefixText = prefixText;
                pobj.memberId = Convert.ToInt32(memberId);
                pobj.userId = Convert.ToInt32(userLoginId);
                BALRecipeMster.GetFoodListByPrefixText(pobj);
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
        public void GetIntakeListByPrefixText(string prefixText, string memberId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PALRecipeMaster pobj = new PALRecipeMaster();
                pobj.prefixText = prefixText;
                pobj.memberId = Convert.ToInt32(memberId);
                pobj.userId = Convert.ToInt32(userLoginId);
                BALRecipeMster.GetIntakeListByPrefixText(pobj);
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