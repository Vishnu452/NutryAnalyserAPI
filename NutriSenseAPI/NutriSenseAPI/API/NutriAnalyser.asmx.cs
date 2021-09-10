using System;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using DLLNutriAnalyser;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for NutriAnalyser
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class NutriAnalyser : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetOriginalNutriAnalyserValues(string nutrientIDList, string intakeDate, int memberID, int userLoginID)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_NutriAnalyser pobj = new PAL_NutriAnalyser();
                    var dtNutrientIDList = JsonConvert.DeserializeObject<DataTable>(nutrientIDList);
                    if (dtNutrientIDList.Rows.Count > 0)
                    {
                        pobj.nutrientIDList = dtNutrientIDList;
                    }
                    pobj.intakeDate = intakeDate;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    pobj.queryType = "Original";
                    BAL_NutriAnalyser.GetNutriAnalyserValues(pobj);
                    if (!pobj.isException)
                    {
                        DLLNutriAnalyser.NutriAnalyserValues nutriAnalyserValues = new DLLNutriAnalyser.NutriAnalyserValues();

                        List<DLLNutriAnalyser.FoodList> foodList = new List<DLLNutriAnalyser.FoodList>();

                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            List<DLLNutriAnalyser.IngredientList> ingredientList = new List<DLLNutriAnalyser.IngredientList>();
                            for (int j = 0; j < pobj.DS.Tables[1].Rows.Count; j++)
                            {
                                if (Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietID"]) == Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["dietID"]))
                                {
                                    ingredientList.Add(new DLLNutriAnalyser.IngredientList
                                    {
                                        ingredientID = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["ingredientID"]),
                                        ingredientName = pobj.DS.Tables[1].Rows[j]["ingredientName"].ToString(),
                                        ingredientQuantity = Convert.ToDecimal(pobj.DS.Tables[1].Rows[j]["ingredientQuantity"]),
                                        minIngredientQuantity = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["minIngredientQuantity"]),
                                        maxIngredientQuantity = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["maxIngredientQuantity"]),
                                        step = Convert.ToDecimal(pobj.DS.Tables[1].Rows[j]["step"]),
                                        ingredientUnitID = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["ingredientUnitID"]),
                                        ingredientUnitName = pobj.DS.Tables[1].Rows[j]["ingredientUnitName"].ToString(),
                                        percentageRatio = Convert.ToDecimal(pobj.DS.Tables[1].Rows[j]["percentageRatio"]),
                                    });
                                }
                            }

                            foodList.Add(new DLLNutriAnalyser.FoodList
                            {
                                dietID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietID"]),
                                foodID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["foodID"]),
                                brandID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["brandID"]),
                                foodName = pobj.DS.Tables[0].Rows[i]["foodName"].ToString(),
                                foodQuantity = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["foodQuantity"]),
                                minFoodQuantity = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["minFoodQuantity"]),
                                maxFoodQuantity = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["maxFoodQuantity"]),
                                step = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["step"]),
                                unitID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["unitID"]),
                                unitName = pobj.DS.Tables[0].Rows[i]["unitName"].ToString(),
                                dietTime = pobj.DS.Tables[0].Rows[i]["dietTime"].ToString(),
                                isCooked = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["isCooked"]),
                                dietType = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietType"]),
                                ingredientList = ingredientList
                            });
                        }

                        List<DLLNutriAnalyser.Nutrients> nutrients = new List<DLLNutriAnalyser.Nutrients>();

                        for (int i = 0; i < pobj.DS.Tables[2].Rows.Count; i++)
                        {
                            List<DLLNutriAnalyser.NutrientList> nutrientList = new List<DLLNutriAnalyser.NutrientList>();
                            for (int j = 0; j < pobj.DS.Tables[3].Rows.Count; j++)
                            {
                                if (Convert.ToInt32(pobj.DS.Tables[2].Rows[i]["nutrientCategoryId"]) == Convert.ToInt32(pobj.DS.Tables[3].Rows[j]["nutrientCategoryId"]))
                                {
                                    nutrientList.Add(new DLLNutriAnalyser.NutrientList
                                    {
                                        nutrientID = Convert.ToInt32(pobj.DS.Tables[3].Rows[j]["nutrientID"]),
                                        nutrientName = pobj.DS.Tables[3].Rows[j]["nutrientName"].ToString(),
                                        target = pobj.DS.Tables[3].Rows[j]["target"].ToString(),
                                        achievedNutrientValue = pobj.DS.Tables[3].Rows[j]["achievedNutrientValue"].ToString(),
                                        achievedRDAPercentage = Convert.ToInt32(pobj.DS.Tables[3].Rows[j]["achievedRDAPercentage"]),
                                        achievedRDAColorCode = pobj.DS.Tables[3].Rows[j]["achievedRDAColorCode"].ToString(),
                                        extraNutrientValue = pobj.DS.Tables[3].Rows[j]["extraNutrientValue"].ToString(),
                                        extraRDAPercentage = Convert.ToInt32(pobj.DS.Tables[3].Rows[j]["extraRDAPercentage"]),
                                        extraRDAColorCode = pobj.DS.Tables[3].Rows[j]["extraRDAColorCode"].ToString(),
                                        totalNutrientValue = pobj.DS.Tables[3].Rows[j]["totalNutrientValue"].ToString(),
                                        totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[3].Rows[j]["totalRDAPercentage"]),
                                        unitName = pobj.DS.Tables[3].Rows[j]["unitName"].ToString(),
                                        graphCategory = pobj.DS.Tables[3].Rows[j]["graphCategory"].ToString(),
                                        isRequired = ""
                                    });
                                }
                            }
                            nutrients.Add(new DLLNutriAnalyser.Nutrients
                            {
                                nutrientCategory = pobj.DS.Tables[2].Rows[i]["nutrientCategory"].ToString(),
                                nutrientList = nutrientList
                            });
                        }

                        nutriAnalyserValues.foodList = foodList;
                        nutriAnalyserValues.nutrients = nutrients;
                        ServiceResponse.GeneralResponseObjectPost(1, "Success!", nutriAnalyserValues);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseObjectPost(0, pobj.exceptionMessage, returnDataset);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponseObjectPost(0, ex.Message, returnDataset);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetModifiedNutriAnalyserValues(string foodList, string ingredientList, string nutrientIDList, int memberID, int userLoginID)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_NutriAnalyser pobj = new PAL_NutriAnalyser();
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    pobj.queryType = "Modified";
                    var dtFoodList = JsonConvert.DeserializeObject<DataTable>(foodList);
                    if (dtFoodList.Rows.Count > 0)
                    {
                        pobj.foodList = dtFoodList;
                    }
                    var dtIngredientList = JsonConvert.DeserializeObject<DataTable>(ingredientList);
                    if (dtIngredientList.Rows.Count > 0)
                    {
                        pobj.ingredientList = dtIngredientList;
                    }
                    var dtNutrientIDList = JsonConvert.DeserializeObject<DataTable>(nutrientIDList);
                    if (dtNutrientIDList.Rows.Count > 0)
                    {
                        pobj.nutrientIDList = dtNutrientIDList;
                    }
                    BAL_NutriAnalyser.GetNutriAnalyserValues(pobj);
                    if (!pobj.isException)
                    {
                        List<DLLNutriAnalyser.Nutrients> nutrients = new List<DLLNutriAnalyser.Nutrients>();

                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            List<DLLNutriAnalyser.NutrientList> nutrientList = new List<DLLNutriAnalyser.NutrientList>();
                            for (int j = 0; j < pobj.DS.Tables[1].Rows.Count; j++)
                            {
                                if (Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["nutrientCategoryId"]) == Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["nutrientCategoryId"]))
                                {
                                    nutrientList.Add(new DLLNutriAnalyser.NutrientList
                                    {
                                        nutrientID = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["nutrientID"]),
                                        nutrientName = pobj.DS.Tables[1].Rows[j]["nutrientName"].ToString(),
                                        target = pobj.DS.Tables[1].Rows[j]["target"].ToString(),
                                        achievedNutrientValue = pobj.DS.Tables[1].Rows[j]["achievedNutrientValue"].ToString(),
                                        achievedRDAPercentage = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["achievedRDAPercentage"]),
                                        achievedRDAColorCode = pobj.DS.Tables[1].Rows[j]["achievedRDAColorCode"].ToString(),
                                        extraNutrientValue = pobj.DS.Tables[1].Rows[j]["extraNutrientValue"].ToString(),
                                        extraRDAPercentage = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["extraRDAPercentage"]),
                                        extraRDAColorCode = pobj.DS.Tables[1].Rows[j]["extraRDAColorCode"].ToString(),
                                        totalNutrientValue = pobj.DS.Tables[1].Rows[j]["totalNutrientValue"].ToString(),
                                        totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["totalRDAPercentage"]),
                                        unitName = pobj.DS.Tables[1].Rows[j]["unitName"].ToString(),
                                        graphCategory = pobj.DS.Tables[1].Rows[j]["graphCategory"].ToString(),
                                        isRequired = ""
                                    });
                                }
                            }
                            nutrients.Add(new DLLNutriAnalyser.Nutrients
                            {
                                nutrientCategory = pobj.DS.Tables[0].Rows[i]["nutrientCategory"].ToString(),
                                nutrientList = nutrientList
                            });
                        }
                        ServiceResponse.GeneralResponseObjectPost(1, "Success!", nutrients);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseObjectPost(0, pobj.exceptionMessage, returnDataset);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponseObjectPost(0, ex.Message, returnDataset);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void NutrientPriorityWiseFood(string nutrientPriorityList, int memberID, int userLoginID)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_NutriAnalyser pobj = new PAL_NutriAnalyser();
                    pobj.nutrientPriorityList = JsonConvert.DeserializeObject<DataTable>(nutrientPriorityList);
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_NutriAnalyser.NutrientPriorityWiseFood(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "toEatList";
                        returnDataset.Tables[1].TableName = "nutralList";
                        returnDataset.Tables[2].TableName = "notToEatList";
                        ServiceResponse.GeneralResponseObjectPost(1, "Success!", returnDataset);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseObjectPost(0, pobj.exceptionMessage, returnDataset);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponseObjectPost(0, ex.Message, returnDataset);
            }
        }
		[WebMethod]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public void getWhatToEat(int memberID, int userLoginID,int PID)
		{
			DataSet returnDataset = new DataSet();
			try
			{
				if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
				{
					PAL_NutriAnalyser pobj = new PAL_NutriAnalyser();					
					pobj.memberID = memberID;
					pobj.userID = userLoginID;
					pobj.PID = PID;
					BAL_NutriAnalyser.getWhatToEat(pobj);
					if (!pobj.isException)
					{
						returnDataset = pobj.DS;						
						ServiceResponse.GeneralResponseObjectPost(1, "Success!", returnDataset);
					}
					else
					{
						ServiceResponse.GeneralResponseObjectPost(0, pobj.exceptionMessage, returnDataset);
					}
				}
			}
			catch (Exception ex)
			{
				ServiceResponse.GeneralResponseObjectPost(0, ex.Message, returnDataset);
			}
		}
	}
}