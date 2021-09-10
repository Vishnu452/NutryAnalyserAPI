using System;
using System.Web.Services;
using System.Data;
using DLLIntake;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Web;
using System.Threading;
using DLLUtility;
using DLLUniversal;
using System.Collections.Generic;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for UserIntake
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserIntake : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddIntakeDetails(string memberId, string foodId, string foodQuantity, string foodUnitId, string intakeDate, string foodTime, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.foodQuantity = Convert.ToDecimal(foodQuantity);
                    pobj.entryUserID = 0;
                    pobj.foodUnitId = Convert.ToInt32(foodUnitId);
                    pobj.foodTime = foodTime;
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.isIntakeGiven = 1;
                    pobj.queryType = "Add";
                    BAL_Intake.AddIntakeDetails(pobj);
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
        public void AddIntakeDetailsWithEntryId(string memberId, string foodId, string foodQuantity, string foodUnitId, string intakeDate, string foodTime, string entryType, int entryUserID, int isIntakeGiven, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.foodQuantity = Convert.ToDecimal(foodQuantity);
                    pobj.foodUnitId = Convert.ToInt32(foodUnitId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.foodTime = foodTime;
                    pobj.entryType = entryType;
                    pobj.entryUserID = entryUserID;
                    pobj.isIntakeGiven = isIntakeGiven;
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.queryType = "Add";
                    
                    BAL_Intake.AddIntakeDetails(pobj);
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
        public void RepeatLastDayIntakeWithEntryId(string intakeDate, string entryType, int memberID, int userLoginID, int entryUserID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.entryType = entryType;
                    pobj.memberId = memberID;
                    pobj.userId = userLoginID;
                    pobj.entryUserID = entryUserID;
                    BAL_Intake.RepeatLastDayIntake(pobj);
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
        public void UpdateIntakeDetails(string dietId, string memberId, string foodId, string foodQuantity, string foodUnitId, string intakeDate, string foodTime, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.dietId = Convert.ToInt32(dietId);
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.foodQuantity = Convert.ToDecimal(foodQuantity);
                    pobj.foodUnitId = Convert.ToInt32(foodUnitId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.foodTime = foodTime;
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.entryUserID = 0;
                    pobj.isIntakeGiven = 1;
                    pobj.queryType = "Update";
                    BAL_Intake.AddIntakeDetails(pobj);
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
        public void UpdateIntakeDetailsWithEntryId(string memberId, string dietId, string foodId, string foodQuantity, string foodUnitId, string intakeDate, string foodTime, string entryType, int entryUserID, int isIntakeGiven, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.dietId = Convert.ToInt32(dietId);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.foodQuantity = Convert.ToDecimal(foodQuantity);
                    pobj.foodUnitId = Convert.ToInt32(foodUnitId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.foodTime = foodTime;
                    pobj.entryType = entryType;
                    pobj.entryUserID = entryUserID;
                    pobj.isIntakeGiven = isIntakeGiven;
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.queryType = "Update";
                    BAL_Intake.AddIntakeDetails(pobj);
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
        public void DeleteIntakeDetails(string dietId, string memberId, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.dietId = Convert.ToInt32(dietId);
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.DeleteIntakeDetails(pobj);
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
        public void DeleteIntakeDetailsByEntryId(string dietId, string entryType, string entryUserID, string memberId, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.dietId = Convert.ToInt32(dietId);
                    pobj.entryType = entryType;
                    pobj.entryUserID = Convert.ToInt32(entryUserID);
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.DeleteIntakeDetails(pobj);
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
        public void DeleteAllFoodByDate(string intakeDate, string entryType, string entryUserID, string memberId, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.entryType = entryType;
                    pobj.entryUserID = Convert.ToInt32(entryUserID);
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.DeleteAllFoodByDate(pobj);
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
        public void GetFoodTiming()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                BAL_Intake.GetFoodTimeing(pobj);
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
        public void GetFoodList(string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.GetFoodList(pobj);
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
        public void GetIntakeByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.isConsumption = 0;
                    BAL_Intake.GetIntakeByFoodTimeId(pobj);
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
        public void GetIntakeWithConsumptionByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.isConsumption = 1;
                    BAL_Intake.GetIntakeByFoodTimeId(pobj);
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
        public void UpdateIntakeConsumption(string memberId, string intakeConsumption, string userLoginId, string entryUserID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.intakeConsumption = JsonConvert.DeserializeObject<DataTable>(intakeConsumption);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.entryUserID = Convert.ToInt32(entryUserID);
                    BAL_Intake.UpdateIntakeConsumption(pobj);
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
        public void GetRecentFoodItems(string memberId, string timeId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    BAL_Intake.GetRecentFoodItems(pobj);
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
        public void GetAllNutrientValuesByFood(string memberId, string foodId, string foodQuantity, string unitId, string userLoginId)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.foodQuantity = Convert.ToDecimal(foodQuantity);
                    pobj.foodUnitId = Convert.ToInt32(unitId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "AllNutrients";
                    BAL_Intake.GetNutrientValuesByFood(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "PriorityNutrients";
                        returnDataset.Tables[1].TableName = "Energy";
                        returnDataset.Tables[2].TableName = "NormalNutrients";
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
        public void GetPriorityNutrientValuesByFood(string memberId, string foodId, string foodQuantity, string unitId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.foodQuantity = Convert.ToDecimal(foodQuantity);
                    pobj.foodUnitId = Convert.ToInt32(unitId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "PriorityNutrients";
                    BAL_Intake.GetNutrientValuesByFood(pobj);
                    if (!pobj.isException)
                    {
                        returnTable = pobj.DS.Tables[0];
                        ServiceResponse.ResponseWithEnergyValues(1, "Success!", returnTable, pobj.DS.Tables[1].Rows[0]["consumed"].ToString(), pobj.DS.Tables[1].Rows[0]["target"].ToString(), Convert.ToInt32(pobj.DS.Tables[1].Rows[0]["achievedRDAPercentage"].ToString()), pobj.DS.Tables[1].Rows[0]["colorCode"].ToString());
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
        public void GetNormalNutrientValuesByFood(string memberId, string foodId, string foodQuantity, string unitId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodId = Convert.ToInt32(foodId);
                    pobj.foodQuantity = Convert.ToDecimal(foodQuantity);
                    pobj.foodUnitId = Convert.ToInt32(unitId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "NormalNutrients";
                    BAL_Intake.GetNutrientValuesByFood(pobj);
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
        public void GetNutriAnalyserValuesByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string nutrientList, string userLoginId)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    DataTable nutrientTable = new DataTable();
                    nutrientTable.Columns.Add("nutrientName");
                    string[] nutrientNameArray = nutrientList.Split(',');
                    for (int i = 0; i < nutrientNameArray.Length; i++)
                    {
                        nutrientTable.Rows.Add(nutrientNameArray[i].Trim());
                    }
                    pobj.nutrientNameList = nutrientTable;
                    pobj.nutrientType = "SelectedNutrients";
                    pobj.isFoodList = 1;
                    pobj.isSupplementList = 1;
                    pobj.isImmediateEffect = 1;
                    pobj.isGraphCategory = 1;
                    pobj.isChartNutrients = 1;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;

                        AllNutrientValuesCombinedByFoodTimeId AllNutrientValuesCombinedByFoodTimeId = new AllNutrientValuesCombinedByFoodTimeId();

                        List<FoodList> FoodList = new List<FoodList>();
                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            FoodList.Add(new FoodList
                            {
                                dietID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietID"]),
                                foodID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["foodID"]),
                                foodName = pobj.DS.Tables[0].Rows[i]["foodName"].ToString(),
                                foodQuantity = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["foodQuantity"]),
                                unitID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["unitID"].ToString()),
                                unitName = pobj.DS.Tables[0].Rows[i]["unitName"].ToString(),
                                dietTimeId = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietTimeId"]),
                                dietTiming = pobj.DS.Tables[0].Rows[i]["dietTiming"].ToString(),
                                dietType = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietType"])
                            });
                        }

                        List<Nutrients> Nutrients = new List<Nutrients>();

                        for (int i = 0; i < pobj.DS.Tables[1].Rows.Count; i++)
                        {
                            List<NutrientList> NutrientList = new List<NutrientList>();
                            for (int j = 0; j < pobj.DS.Tables[2].Rows.Count; j++)
                            {
                                if (Convert.ToInt32(pobj.DS.Tables[1].Rows[i]["nutrientCategoryId"]) == Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["nutrientCategoryId"]))
                                {
                                    NutrientList.Add(new NutrientList
                                    {
                                        nutrientID = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["nutrientID"]),
                                        nutrientName = pobj.DS.Tables[2].Rows[j]["nutrientName"].ToString(),
                                        target = pobj.DS.Tables[2].Rows[j]["target"].ToString(),
                                        achievedNutrientValue = pobj.DS.Tables[2].Rows[j]["achievedNutrientValue"].ToString(),
                                        achievedRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["achievedRDAPercentage"]),
                                        achievedRDAColorCode = pobj.DS.Tables[2].Rows[j]["achievedRDAColorCode"].ToString(),
                                        extraNutrientValue = pobj.DS.Tables[2].Rows[j]["extraNutrientValue"].ToString(),
                                        extraRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["extraRDAPercentage"]),
                                        extraRDAColorCode = pobj.DS.Tables[2].Rows[j]["extraRDAColorCode"].ToString(),
                                        totalNutrientValue = pobj.DS.Tables[2].Rows[j]["totalNutrientValue"].ToString(),
                                        totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["totalRDAPercentage"]),
                                        unitName = pobj.DS.Tables[2].Rows[j]["unitName"].ToString(),
                                        graphCategory = pobj.DS.Tables[2].Rows[j]["graphCategory"].ToString(),
                                        customizedPercentage = pobj.DS.Tables[2].Rows[j]["customizedPercentage"].ToString()
                                    });
                                }
                            }
                            Nutrients.Add(new Nutrients
                            {
                                nutrientCategory = pobj.DS.Tables[1].Rows[i]["nutrientCategory"].ToString(),
                                nutrientList = NutrientList
                            });
                        }

                        List<SupplementList> SupplementList = new List<SupplementList>();
                        for (int i = 0; i < pobj.DS.Tables[3].Rows.Count; i++)
                        {
                            List<SupplementDetails> SupplementDetails = new List<SupplementDetails>();
                            for (int j = 0; j < pobj.DS.Tables[4].Rows.Count; j++)
                            {
                                if (pobj.DS.Tables[3].Rows[i]["nutrientName"].ToString() == pobj.DS.Tables[4].Rows[j]["nutrientName"].ToString())
                                {
                                    SupplementDetails.Add(new SupplementDetails
                                    {
                                        supplementName = pobj.DS.Tables[4].Rows[j]["supplementName"].ToString(),
                                        supplementDose = pobj.DS.Tables[4].Rows[j]["supplementDose"].ToString()
                                    });
                                }
                            }
                            SupplementList.Add(new SupplementList
                            {
                                nutrientName = pobj.DS.Tables[3].Rows[i]["nutrientName"].ToString(),
                                nutrientValue = pobj.DS.Tables[3].Rows[i]["nutrientValue"].ToString(),
                                rda = pobj.DS.Tables[3].Rows[i]["rda"].ToString(),
                                requiredQuantity = pobj.DS.Tables[3].Rows[i]["requiredQuantity"].ToString(),
                                supplementDetails = SupplementDetails
                            });
                        }

                        List<ImmediateEffect> ImmediateEffect = new List<ImmediateEffect>();
                        for (int i = 0; i < pobj.DS.Tables[5].Rows.Count; i++)
                        {
                            ImmediateEffect.Add(new ImmediateEffect
                            {
                                nutrientName = pobj.DS.Tables[5].Rows[i]["nutrientName"].ToString(),
                                nutrientLevel = pobj.DS.Tables[5].Rows[i]["nutrientLevel"].ToString(),
                                symptom = pobj.DS.Tables[5].Rows[i]["symptom"].ToString()
                            });
                        }

                        List<GraphCategory> GraphCategory = new List<GraphCategory>();
                        for (int i = 0; i < pobj.DS.Tables[6].Rows.Count; i++)
                        {
                            GraphCategory.Add(new GraphCategory
                            {
                                graphCategory = pobj.DS.Tables[6].Rows[i]["graphCategory"].ToString(),
                                unitName = pobj.DS.Tables[6].Rows[i]["unitName"].ToString()
                            });
                        }

                        List<ChartNutrients> ChartNutrients = new List<ChartNutrients>();
                        for (int i = 0; i < pobj.DS.Tables[7].Rows.Count; i++)
                        {
                            ChartNutrients.Add(new ChartNutrients
                            {
                                nutrientID = Convert.ToInt32(pobj.DS.Tables[7].Rows[i]["nutrientID"]),
                                tagName = pobj.DS.Tables[7].Rows[i]["tagName"].ToString(),
                                target = pobj.DS.Tables[7].Rows[i]["target"].ToString(),
                                totalNutrientValue = pobj.DS.Tables[7].Rows[i]["totalNutrientValue"].ToString(),
                                totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[7].Rows[i]["totalRDAPercentage"]),
                                unitName = pobj.DS.Tables[7].Rows[i]["unitName"].ToString(),
                                nutrientCategory = pobj.DS.Tables[7].Rows[i]["nutrientCategory"].ToString()
                            });
                        }

                        AllNutrientValuesCombinedByFoodTimeId.FoodList = FoodList;
                        AllNutrientValuesCombinedByFoodTimeId.Nutrients = Nutrients;
                        AllNutrientValuesCombinedByFoodTimeId.SupplementList = SupplementList;
                        AllNutrientValuesCombinedByFoodTimeId.ImmediateEffect = ImmediateEffect;
                        AllNutrientValuesCombinedByFoodTimeId.GraphCategory = GraphCategory;
                        AllNutrientValuesCombinedByFoodTimeId.ChartNutrients = ChartNutrients;

                        ServiceResponse.GeneralResponseObject(1, "Success!", AllNutrientValuesCombinedByFoodTimeId);
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
        public void GetNutriAnalyserValuesByFoodTimeIdByRDA(string memberId, string foodTimeId, string intakeDate, string nutrientList, string userLoginId, bool isRDARequired, bool isActualDiet)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.isRDARequired = isRDARequired;
                    DataTable nutrientTable = new DataTable();
                    nutrientTable.Columns.Add("nutrientName");
                    string[] nutrientNameArray = nutrientList.Split(',');
                    for (int i = 0; i < nutrientNameArray.Length; i++)
                    {
                        nutrientTable.Rows.Add(nutrientNameArray[i].Trim());
                    }
                    pobj.nutrientNameList = nutrientTable;
                    pobj.nutrientType = "SelectedNutrients";
                    pobj.isFoodList = 1;
                    pobj.isSupplementList = 1;
                    pobj.isImmediateEffect = 1;
                    pobj.isGraphCategory = 1;
                    pobj.isChartNutrients = 1;
                    pobj.isActualDiet = isActualDiet;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;

                        AllNutrientValuesCombinedByFoodTimeId AllNutrientValuesCombinedByFoodTimeId = new AllNutrientValuesCombinedByFoodTimeId();

                        List<FoodList> FoodList = new List<FoodList>();
                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            FoodList.Add(new FoodList
                            {
                                dietID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietID"]),
                                foodID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["foodID"]),
                                foodName = pobj.DS.Tables[0].Rows[i]["foodName"].ToString(),
                                foodQuantity = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["foodQuantity"]),
                                unitID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["unitID"].ToString()),
                                unitName = pobj.DS.Tables[0].Rows[i]["unitName"].ToString(),
                                dietTimeId = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietTimeId"]),
                                dietTiming = pobj.DS.Tables[0].Rows[i]["dietTiming"].ToString(),
                                dietType = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietType"])
                            });
                        }

                        List<Nutrients> Nutrients = new List<Nutrients>();

                        for (int i = 0; i < pobj.DS.Tables[1].Rows.Count; i++)
                        {
                            List<NutrientList> NutrientList = new List<NutrientList>();
                            for (int j = 0; j < pobj.DS.Tables[2].Rows.Count; j++)
                            {
                                if (Convert.ToInt32(pobj.DS.Tables[1].Rows[i]["nutrientCategoryId"]) == Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["nutrientCategoryId"]))
                                {
                                    NutrientList.Add(new NutrientList
                                    {
                                        nutrientID = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["nutrientID"]),
                                        nutrientName = pobj.DS.Tables[2].Rows[j]["nutrientName"].ToString(),
                                        target = pobj.DS.Tables[2].Rows[j]["target"].ToString(),
                                        achievedNutrientValue = pobj.DS.Tables[2].Rows[j]["achievedNutrientValue"].ToString(),
                                        achievedRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["achievedRDAPercentage"]),
                                        achievedRDAColorCode = pobj.DS.Tables[2].Rows[j]["achievedRDAColorCode"].ToString(),
                                        extraNutrientValue = pobj.DS.Tables[2].Rows[j]["extraNutrientValue"].ToString(),
                                        extraRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["extraRDAPercentage"]),
                                        extraRDAColorCode = pobj.DS.Tables[2].Rows[j]["extraRDAColorCode"].ToString(),
                                        totalNutrientValue = pobj.DS.Tables[2].Rows[j]["totalNutrientValue"].ToString(),
                                        totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["totalRDAPercentage"]),
                                        unitName = pobj.DS.Tables[2].Rows[j]["unitName"].ToString(),
                                        graphCategory = pobj.DS.Tables[2].Rows[j]["graphCategory"].ToString(),
                                        customizedPercentage = pobj.DS.Tables[2].Rows[j]["customizedPercentage"].ToString(),
                                        investigationResult = pobj.DS.Tables[2].Rows[j]["investigationResult"].ToString()
                                    });
                                }
                            }
                            Nutrients.Add(new Nutrients
                            {
                                nutrientCategory = pobj.DS.Tables[1].Rows[i]["nutrientCategory"].ToString(),
                                nutrientList = NutrientList
                            });
                        }

                        List<SupplementList> SupplementList = new List<SupplementList>();
                        for (int i = 0; i < pobj.DS.Tables[3].Rows.Count; i++)
                        {
                            List<SupplementDetails> SupplementDetails = new List<SupplementDetails>();
                            for (int j = 0; j < pobj.DS.Tables[4].Rows.Count; j++)
                            {
                                if (pobj.DS.Tables[3].Rows[i]["nutrientName"].ToString() == pobj.DS.Tables[4].Rows[j]["nutrientName"].ToString())
                                {
                                    SupplementDetails.Add(new SupplementDetails
                                    {
                                        supplementName = pobj.DS.Tables[4].Rows[j]["supplementName"].ToString(),
                                        supplementDose = pobj.DS.Tables[4].Rows[j]["supplementDose"].ToString()
                                    });
                                }
                            }
                            SupplementList.Add(new SupplementList
                            {
                                nutrientName = pobj.DS.Tables[3].Rows[i]["nutrientName"].ToString(),
                                nutrientValue = pobj.DS.Tables[3].Rows[i]["nutrientValue"].ToString(),
                                rda = pobj.DS.Tables[3].Rows[i]["rda"].ToString(),
                                requiredQuantity = pobj.DS.Tables[3].Rows[i]["requiredQuantity"].ToString(),
                                supplementDetails = SupplementDetails
                            });
                        }

                        List<ImmediateEffect> ImmediateEffect = new List<ImmediateEffect>();
                        for (int i = 0; i < pobj.DS.Tables[5].Rows.Count; i++)
                        {
                            ImmediateEffect.Add(new ImmediateEffect
                            {
                                nutrientName = pobj.DS.Tables[5].Rows[i]["nutrientName"].ToString(),
                                nutrientLevel = pobj.DS.Tables[5].Rows[i]["nutrientLevel"].ToString(),
                                symptom = pobj.DS.Tables[5].Rows[i]["symptom"].ToString()
                            });
                        }

                        List<GraphCategory> GraphCategory = new List<GraphCategory>();
                        for (int i = 0; i < pobj.DS.Tables[6].Rows.Count; i++)
                        {
                            GraphCategory.Add(new GraphCategory
                            {
                                graphCategory = pobj.DS.Tables[6].Rows[i]["graphCategory"].ToString(),
                                unitName = pobj.DS.Tables[6].Rows[i]["unitName"].ToString()
                            });
                        }

                        List<ChartNutrients> ChartNutrients = new List<ChartNutrients>();
                        for (int i = 0; i < pobj.DS.Tables[7].Rows.Count; i++)
                        {
                            ChartNutrients.Add(new ChartNutrients
                            {
                                nutrientID = Convert.ToInt32(pobj.DS.Tables[7].Rows[i]["nutrientID"]),
                                tagName = pobj.DS.Tables[7].Rows[i]["tagName"].ToString(),
                                target = pobj.DS.Tables[7].Rows[i]["target"].ToString(),
                                totalNutrientValue = pobj.DS.Tables[7].Rows[i]["totalNutrientValue"].ToString(),
                                totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[7].Rows[i]["totalRDAPercentage"]),
                                unitName = pobj.DS.Tables[7].Rows[i]["unitName"].ToString(),
                                nutrientCategory = pobj.DS.Tables[7].Rows[i]["nutrientCategory"].ToString()
                            });
                        }

                        AllNutrientValuesCombinedByFoodTimeId.FoodList = FoodList;
                        AllNutrientValuesCombinedByFoodTimeId.Nutrients = Nutrients;
                        AllNutrientValuesCombinedByFoodTimeId.SupplementList = SupplementList;
                        AllNutrientValuesCombinedByFoodTimeId.ImmediateEffect = ImmediateEffect;
                        AllNutrientValuesCombinedByFoodTimeId.GraphCategory = GraphCategory;
                        AllNutrientValuesCombinedByFoodTimeId.ChartNutrients = ChartNutrients;

                        ServiceResponse.GeneralResponseObject(1, "Success!", AllNutrientValuesCombinedByFoodTimeId);
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
        public void GetNutriAnalyserValuesByFoodTimeIdPID(string memberId, string foodTimeId, string intakeDate, string nutrientList, string userLoginId, string PID)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    DataTable nutrientTable = new DataTable();
                    nutrientTable.Columns.Add("nutrientName");
                    string[] nutrientNameArray = nutrientList.Split(',');
                    for (int i = 0; i < nutrientNameArray.Length; i++)
                    {
                        nutrientTable.Rows.Add(nutrientNameArray[i].Trim());
                    }
                    pobj.nutrientNameList = nutrientTable;
                    pobj.nutrientType = "SelectedNutrients";
                    pobj.isFoodList = 1;
                    pobj.isSupplementList = 1;
                    pobj.isImmediateEffect = 1;
                    pobj.isGraphCategory = 1;
                    pobj.isChartNutrients = 1;
                    pobj.PID = Convert.ToInt32(PID);
                    pobj.searchBy = "PID";
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;

                        AllNutrientValuesCombinedByFoodTimeId AllNutrientValuesCombinedByFoodTimeId = new AllNutrientValuesCombinedByFoodTimeId();

                        List<FoodList> FoodList = new List<FoodList>();
                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            FoodList.Add(new FoodList
                            {
                                dietID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietID"]),
                                foodID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["foodID"]),
                                foodName = pobj.DS.Tables[0].Rows[i]["foodName"].ToString(),
                                foodQuantity = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["foodQuantity"]),
                                unitID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["unitID"].ToString()),
                                unitName = pobj.DS.Tables[0].Rows[i]["unitName"].ToString(),
                                dietTimeId = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietTimeId"]),
                                dietTiming = pobj.DS.Tables[0].Rows[i]["dietTiming"].ToString(),
                                dietType = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietType"])
                            });
                        }

                        List<Nutrients> Nutrients = new List<Nutrients>();

                        for (int i = 0; i < pobj.DS.Tables[1].Rows.Count; i++)
                        {
                            List<NutrientList> NutrientList = new List<NutrientList>();
                            for (int j = 0; j < pobj.DS.Tables[2].Rows.Count; j++)
                            {
                                if (Convert.ToInt32(pobj.DS.Tables[1].Rows[i]["nutrientCategoryId"]) == Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["nutrientCategoryId"]))
                                {
                                    NutrientList.Add(new NutrientList
                                    {
                                        nutrientID = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["nutrientID"]),
                                        nutrientName = pobj.DS.Tables[2].Rows[j]["nutrientName"].ToString(),
                                        target = pobj.DS.Tables[2].Rows[j]["target"].ToString(),
                                        achievedNutrientValue = pobj.DS.Tables[2].Rows[j]["achievedNutrientValue"].ToString(),
                                        achievedRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["achievedRDAPercentage"]),
                                        achievedRDAColorCode = pobj.DS.Tables[2].Rows[j]["achievedRDAColorCode"].ToString(),
                                        extraNutrientValue = pobj.DS.Tables[2].Rows[j]["extraNutrientValue"].ToString(),
                                        extraRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["extraRDAPercentage"]),
                                        extraRDAColorCode = pobj.DS.Tables[2].Rows[j]["extraRDAColorCode"].ToString(),
                                        totalNutrientValue = pobj.DS.Tables[2].Rows[j]["totalNutrientValue"].ToString(),
                                        totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["totalRDAPercentage"]),
                                        unitName = pobj.DS.Tables[2].Rows[j]["unitName"].ToString(),
                                        graphCategory = pobj.DS.Tables[2].Rows[j]["graphCategory"].ToString()
                                    });
                                }
                            }
                            Nutrients.Add(new Nutrients
                            {
                                nutrientCategory = pobj.DS.Tables[1].Rows[i]["nutrientCategory"].ToString(),
                                nutrientList = NutrientList
                            });
                        }

                        List<SupplementList> SupplementList = new List<SupplementList>();
                        for (int i = 0; i < pobj.DS.Tables[3].Rows.Count; i++)
                        {
                            List<SupplementDetails> SupplementDetails = new List<SupplementDetails>();
                            for (int j = 0; j < pobj.DS.Tables[4].Rows.Count; j++)
                            {
                                if (pobj.DS.Tables[3].Rows[i]["nutrientName"].ToString() == pobj.DS.Tables[4].Rows[j]["nutrientName"].ToString())
                                {
                                    SupplementDetails.Add(new SupplementDetails
                                    {
                                        supplementName = pobj.DS.Tables[4].Rows[j]["supplementName"].ToString(),
                                        supplementDose = pobj.DS.Tables[4].Rows[j]["supplementDose"].ToString()
                                    });
                                }
                            }
                            SupplementList.Add(new SupplementList
                            {
                                nutrientName = pobj.DS.Tables[3].Rows[i]["nutrientName"].ToString(),
                                nutrientValue = pobj.DS.Tables[3].Rows[i]["nutrientValue"].ToString(),
                                rda = pobj.DS.Tables[3].Rows[i]["rda"].ToString(),
                                requiredQuantity = pobj.DS.Tables[3].Rows[i]["requiredQuantity"].ToString(),
                                supplementDetails = SupplementDetails
                            });
                        }

                        List<ImmediateEffect> ImmediateEffect = new List<ImmediateEffect>();
                        for (int i = 0; i < pobj.DS.Tables[5].Rows.Count; i++)
                        {
                            ImmediateEffect.Add(new ImmediateEffect
                            {
                                nutrientName = pobj.DS.Tables[5].Rows[i]["nutrientName"].ToString(),
                                nutrientLevel = pobj.DS.Tables[5].Rows[i]["nutrientLevel"].ToString(),
                                symptom = pobj.DS.Tables[5].Rows[i]["symptom"].ToString()
                            });
                        }

                        List<GraphCategory> GraphCategory = new List<GraphCategory>();
                        for (int i = 0; i < pobj.DS.Tables[6].Rows.Count; i++)
                        {
                            GraphCategory.Add(new GraphCategory
                            {
                                graphCategory = pobj.DS.Tables[6].Rows[i]["graphCategory"].ToString(),
                                unitName = pobj.DS.Tables[6].Rows[i]["unitName"].ToString()
                            });
                        }

                        List<ChartNutrients> ChartNutrients = new List<ChartNutrients>();
                        for (int i = 0; i < pobj.DS.Tables[7].Rows.Count; i++)
                        {
                            ChartNutrients.Add(new ChartNutrients
                            {
                                nutrientID = Convert.ToInt32(pobj.DS.Tables[7].Rows[i]["nutrientID"]),
                                tagName = pobj.DS.Tables[7].Rows[i]["tagName"].ToString(),
                                target = pobj.DS.Tables[7].Rows[i]["target"].ToString(),
                                totalNutrientValue = pobj.DS.Tables[7].Rows[i]["totalNutrientValue"].ToString(),
                                totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[7].Rows[i]["totalRDAPercentage"]),
                                unitName = pobj.DS.Tables[7].Rows[i]["unitName"].ToString(),
                                nutrientCategory = pobj.DS.Tables[7].Rows[i]["nutrientCategory"].ToString()
                            });
                        }

                        AllNutrientValuesCombinedByFoodTimeId.FoodList = FoodList;
                        AllNutrientValuesCombinedByFoodTimeId.Nutrients = Nutrients;
                        AllNutrientValuesCombinedByFoodTimeId.SupplementList = SupplementList;
                        AllNutrientValuesCombinedByFoodTimeId.ImmediateEffect = ImmediateEffect;
                        AllNutrientValuesCombinedByFoodTimeId.GraphCategory = GraphCategory;
                        AllNutrientValuesCombinedByFoodTimeId.ChartNutrients = ChartNutrients;

                        ServiceResponse.GeneralResponseObject(1, "Success!", AllNutrientValuesCombinedByFoodTimeId);
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
        public void GetNutriAnalyserFoodListByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "";
                    pobj.isFoodList = 1;
                    pobj.isSupplementList = 0;
                    pobj.isImmediateEffect = 0;
                    pobj.isGraphCategory = 0;
                    pobj.isChartNutrients = 0;
                    pobj.isActualDiet = true;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
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
        public void GetAllNutrientValuesWithFoodListByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "AllNutrients";
                    pobj.isFoodList = 1;
                    pobj.isSupplementList = 0;
                    pobj.isImmediateEffect = 0;
                    pobj.isGraphCategory = 0;
                    pobj.isChartNutrients = 0;
                    pobj.isActualDiet = true;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "FoodList";
                        returnDataset.Tables[1].TableName = "PriorityNutrients";
                        returnDataset.Tables[2].TableName = "Energy";
                        returnDataset.Tables[3].TableName = "NormalNutrients";
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
        public void GetPriorityNutrientValuesByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "PriorityNutrients";
                    pobj.isFoodList = 0;
                    pobj.isSupplementList = 0;
                    pobj.isImmediateEffect = 0;
                    pobj.isGraphCategory = 0;
                    pobj.isChartNutrients = 0;
                    pobj.isActualDiet = true;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
                    if (!pobj.isException)
                    {
                        returnTable = pobj.DS.Tables[0];
                        ServiceResponse.ResponseWithEnergyValues(1, "Success!", returnTable, pobj.DS.Tables[1].Rows[0]["consumed"].ToString(), pobj.DS.Tables[1].Rows[0]["target"].ToString(), Convert.ToInt32(pobj.DS.Tables[1].Rows[0]["achievedRDAPercentage"].ToString()), pobj.DS.Tables[1].Rows[0]["colorCode"].ToString());
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
        public void GetNormalNutrientValuesByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "NormalNutrients";
                    pobj.isFoodList = 0;
                    pobj.isSupplementList = 0;
                    pobj.isImmediateEffect = 0;
                    pobj.isGraphCategory = 0;
                    pobj.isChartNutrients = 0;
                    pobj.isActualDiet = true;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
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
        public void GetAllNutrientValuesCombinedByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "AllNutrientsCombined";
                    pobj.isFoodList = 0;
                    pobj.isSupplementList = 0;
                    pobj.isImmediateEffect = 0;
                    pobj.isGraphCategory = 0;
                    pobj.isChartNutrients = 0;
                    pobj.isActualDiet = true;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
                    if (!pobj.isException)
                    {
                        List<Nutrients> Nutrients = new List<Nutrients>();

                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            List<NutrientList> nutrientList = new List<NutrientList>();
                            for (int j = 0; j < pobj.DS.Tables[1].Rows.Count; j++)
                            {
                                if (Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["nutrientCategoryId"]) == Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["nutrientCategoryId"]))
                                {
                                    nutrientList.Add(new NutrientList
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
                                        customizedPercentage = pobj.DS.Tables[1].Rows[j]["customizedPercentage"].ToString()
                                    });
                                }
                            }
                            Nutrients.Add(new Nutrients
                            {
                                nutrientCategory = pobj.DS.Tables[0].Rows[i]["nutrientCategory"].ToString(),
                                nutrientList = nutrientList
                            });
                        }

                        ServiceResponse.GeneralResponseObject(1, "Success!", Nutrients);
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
        public void GetRequiredSupplementByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "";
                    pobj.isFoodList = 0;
                    pobj.isSupplementList = 1;
                    pobj.isImmediateEffect = 0;
                    pobj.isGraphCategory = 0;
                    pobj.isChartNutrients = 0;
                    pobj.isActualDiet = true;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
                    if (!pobj.isException)
                    {
                        List<SupplementList> SupplementList = new List<SupplementList>();
                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            List<SupplementDetails> SupplementDetails = new List<SupplementDetails>();
                            for (int j = 0; j < pobj.DS.Tables[1].Rows.Count; j++)
                            {
                                if (pobj.DS.Tables[0].Rows[i]["nutrientName"].ToString() == pobj.DS.Tables[1].Rows[j]["nutrientName"].ToString())
                                {
                                    SupplementDetails.Add(new SupplementDetails
                                    {
                                        supplementName = pobj.DS.Tables[1].Rows[j]["supplementName"].ToString(),
                                        supplementDose = pobj.DS.Tables[1].Rows[j]["supplementDose"].ToString()
                                    });
                                }
                            }
                            SupplementList.Add(new SupplementList
                            {
                                nutrientName = pobj.DS.Tables[0].Rows[i]["nutrientName"].ToString(),
                                nutrientValue = pobj.DS.Tables[0].Rows[i]["nutrientValue"].ToString(),
                                rda = pobj.DS.Tables[0].Rows[i]["rda"].ToString(),
                                requiredQuantity = pobj.DS.Tables[0].Rows[i]["requiredQuantity"].ToString(),
                                supplementDetails = SupplementDetails
                            });
                        }

                        ServiceResponse.GeneralResponseObject(1, "Success!", SupplementList);
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
        public void GetNutrientLevelImmediateEffectByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.nutrientType = "";
                    pobj.isFoodList = 0;
                    pobj.isSupplementList = 0;
                    pobj.isImmediateEffect = 1;
                    pobj.isActualDiet = true;
                    BAL_Intake.GetNutrientValuesByFoodTimeId(pobj);
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
        public void GetNutrientRatioByNutrientId(string memberId, string nutrientId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.nutrientId = Convert.ToInt32(nutrientId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.GetNutrientRatioByNutrientId(pobj);
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
        public void GetNutrientRatioWithDetailsByNutrientId(string memberId, string nutrientId, bool isActualDiet, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.isActualDiet = isActualDiet;
                    pobj.nutrientId = Convert.ToInt32(nutrientId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.GetNutrientRatioWithDetailsByNutrientId(pobj);
                    if (!pobj.isException)
                    {
                        List<NutrientRatio> NutrientRatio = new List<NutrientRatio>();

                        for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                        {
                            List<IngredientNutrientValue> ingredientNutrientValue = new List<IngredientNutrientValue>();
                            for (int j = 0; j < pobj.DS.Tables[1].Rows.Count; j++)
                            {
                                if (Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietID"]) == Convert.ToInt32(pobj.DS.Tables[1].Rows[j]["dietID"]))
                                {
                                    ingredientNutrientValue.Add(new IngredientNutrientValue
                                    {
                                        ingredientName = pobj.DS.Tables[1].Rows[j]["ingredientName"].ToString(),
                                        nutrientValue = Convert.ToDecimal(pobj.DS.Tables[1].Rows[j]["nutrientValue"]),
                                        unitName = pobj.DS.Tables[1].Rows[j]["unitName"].ToString(),
                                    });
                                }
                            }
                            NutrientRatio.Add(new NutrientRatio
                            {
                                dietID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietID"]),
                                foodName = pobj.DS.Tables[0].Rows[i]["foodName"].ToString(),
                                foodQuantity = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["foodQuantity"]),
                                foodUnit = pobj.DS.Tables[0].Rows[i]["foodUnit"].ToString(),
                                nutrientValue = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["nutrientValue"]),
                                nutrientUnit = pobj.DS.Tables[0].Rows[i]["nutrientUnit"].ToString(),
                                nutrientPercentage = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["nutrientPercentage"]),
                                foodTiming = pobj.DS.Tables[0].Rows[i]["foodTiming"].ToString(),
                                ingredientNutrientValue = ingredientNutrientValue
                            });
                        }
                        ServiceResponse.GeneralResponseObject(1, "Success!", NutrientRatio);
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
        public void GetNutrientListByIntake(string memberId, string dietId, string dietType, bool isActualDiet, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.dietId = Convert.ToInt32(dietId);
                    pobj.dietType = Convert.ToInt32(dietType);
                    pobj.isActualDiet = isActualDiet;
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.GetNutrientListByIntake(pobj);
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
        public void GetAchievedRDAPercentageColor()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                BAL_Intake.GetAchievedRDAPercentageColor(pobj);
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
        public void GetCurrentTimeWithTimeID()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                BAL_Intake.GetCurrentTimeWithTimeID(pobj);
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
        public void GetNutrientByPrefixText(string prefixText)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                string[] prefix = prefixText.Split(',');
                pobj.prefixText = prefix[prefix.Length - 1].ToString().Trim();
                BAL_Intake.GetNutrientByPrefixText(pobj);
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
        public void GetDiseaseList()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                BAL_Intake.GetDiseaseList(pobj);
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
        public void GetNutrientListByDiseaseID(string diseaseID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                pobj.diseaseID = Convert.ToInt32(diseaseID);
                BAL_Intake.GetNutrientListByDiseaseID(pobj);
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
        public void CompleteIntake(string memberId, string intakeDate, string userLoginId)
        {
            //DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.CompleteIntake(pobj);
                    if (!pobj.isException)
                    {
                        //returnTable = pobj.DS.Tables[0];
                        //Thread messageThread = new Thread(delegate ()
                        //{
                        //    Thread.Sleep(Convert.ToInt32(pobj.DS.Tables[1].Rows[0]["waitMinutes"].ToString()) * 60 * 1000);
                        //    for (int i = 0; i < returnTable.Rows.Count; i++)
                        //    {
                        //        Notification.SendNotification(returnTable.Rows[i]["notificationBody"].ToString(), returnTable.Rows[i]["notificationTitle"].ToString(), Convert.ToInt32(returnTable.Rows[i]["notificationBadge"].ToString()), Convert.ToInt32(returnTable.Rows[i]["notificationID"].ToString()), returnTable.Rows[i]["deviceToken"].ToString());
                        //    }
                        //});
                        //messageThread.IsBackground = true;
                        //messageThread.Start();
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

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void GetNutriAnalyserValuesByFoodTimeId(string memberId, string foodTimeId, string intakeDate, string nutrientList, string userLoginId)
        //{
        //    DataSet returnDataset = new DataSet();
        //    try
        //    {
        //        if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
        //        {
        //            PAL_Intake pobj = new PAL_Intake();
        //            pobj.memberId = Convert.ToInt32(memberId);
        //            pobj.foodTimeId = Convert.ToInt32(foodTimeId);
        //            pobj.intakeDate = Convert.ToDateTime(intakeDate);
        //            pobj.userId = Convert.ToInt32(userLoginId);
        //            DataTable nutrientTable = new DataTable();
        //            nutrientTable.Columns.Add("nutrientName");
        //            string[] nutrientNameArray = nutrientList.Split(',');
        //            for (int i = 0; i < nutrientNameArray.Length; i++)
        //            {
        //                nutrientTable.Rows.Add(nutrientNameArray[i].Trim());
        //            }
        //            pobj.nutrientNameList = nutrientTable;
        //            pobj.nutrientType = "SelectedNutrients";
        //            pobj.isFoodList = 1;
        //            pobj.isSupplementList = 1;
        //            pobj.isImmediateEffect = 1;
        //            pobj.isGraphCategory = 1;
        //            pobj.isChartNutrients = 1;
        //            BAL_Intake.GetNutriAnalyserValuesByFoodTimeId(pobj);
        //            if (!pobj.isException)
        //            {
        //                returnDataset = pobj.DS;

        //                NutriAnalyserValues nutriAnalyserValues = new NutriAnalyserValues();

        //                List<FoodList> foodList = new List<FoodList>();
        //                for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
        //                {
        //                    foodList.Add(new FoodList
        //                    {
        //                        dietID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietID"]),
        //                        foodID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["foodID"]),
        //                        foodName = pobj.DS.Tables[0].Rows[i]["foodName"].ToString(),
        //                        foodQuantity = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["foodQuantity"]),
        //                        unitID = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["unitID"].ToString()),
        //                        unitName = pobj.DS.Tables[0].Rows[i]["unitName"].ToString(),
        //                        dietTimeId = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietTimeId"]),
        //                        dietTiming = pobj.DS.Tables[0].Rows[i]["dietTiming"].ToString(),
        //                        dietType = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["dietType"])
        //                    });
        //                }

        //                List<CategoryWiseNutrients> categoryWiseNutrients = new List<CategoryWiseNutrients>();

        //                for (int i = 0; i < pobj.DS.Tables[1].Rows.Count; i++)
        //                {
        //                    List<NutrientValues> nutrientValues = new List<NutrientValues>();
        //                    for (int j = 0; j < pobj.DS.Tables[2].Rows.Count; j++)
        //                    {
        //                        if (Convert.ToInt32(pobj.DS.Tables[1].Rows[i]["nutrientCategoryId"]) == Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["nutrientCategoryId"]))
        //                        {
        //                            nutrientValues.Add(new NutrientValues
        //                            {
        //                                nutrientID = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["nutrientID"]),
        //                                nutrientName = pobj.DS.Tables[2].Rows[j]["nutrientName"].ToString(),
        //                                rdaMin = pobj.DS.Tables[2].Rows[j]["rdaMin"].ToString(),
        //                                rdaMax = pobj.DS.Tables[2].Rows[j]["rdaMax"].ToString(),
        //                                achievedNutrientValue = pobj.DS.Tables[2].Rows[j]["achievedNutrientValue"].ToString(),
        //                                unitName = pobj.DS.Tables[2].Rows[j]["unitName"].ToString(),
        //                                achievedPercentageBeforeMinRDA = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["achievedPercentageBeforeMinRDA"]),
        //                                achievedPercentageDuringRDA = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["achievedPercentageDuringRDA"]),
        //                                achievedPercentageAfterMaxRDA = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["achievedPercentageAfterMaxRDA"]),
        //                                achievedRDAPercentage = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["achievedRDAPercentage"]),
        //                                achievedRDAColorCode = pobj.DS.Tables[2].Rows[j]["achievedRDAColorCode"].ToString(),
        //                                extraRDAColorCode = pobj.DS.Tables[2].Rows[j]["extraRDAColorCode"].ToString(),
        //                                graphCategory = pobj.DS.Tables[2].Rows[j]["graphCategory"].ToString()
        //                            });
        //                        }
        //                    }
        //                    categoryWiseNutrients.Add(new CategoryWiseNutrients
        //                    {
        //                        nutrientCategory = pobj.DS.Tables[1].Rows[i]["nutrientCategory"].ToString(),
        //                        nutrientValues = nutrientValues
        //                    });
        //                }

        //                //List<SupplementList> SupplementList = new List<SupplementList>();
        //                //for (int i = 0; i < pobj.DS.Tables[3].Rows.Count; i++)
        //                //{
        //                //    SupplementList.Add(new SupplementList
        //                //    {
        //                //        nutrientName = pobj.DS.Tables[3].Rows[i]["nutrientName"].ToString(),
        //                //        nutrientValue = pobj.DS.Tables[3].Rows[i]["nutrientValue"].ToString(),
        //                //        rda = pobj.DS.Tables[3].Rows[i]["rda"].ToString(),
        //                //        requiredQuantity = pobj.DS.Tables[3].Rows[i]["requiredQuantity"].ToString().ToString(),
        //                //        supplementName = pobj.DS.Tables[3].Rows[i]["supplementName"].ToString(),
        //                //        supplementDose = pobj.DS.Tables[3].Rows[i]["supplementDose"].ToString(),
        //                //    });
        //                //}

        //                //List<ImmediateEffect> ImmediateEffect = new List<ImmediateEffect>();
        //                //for (int i = 0; i < pobj.DS.Tables[4].Rows.Count; i++)
        //                //{
        //                //    ImmediateEffect.Add(new ImmediateEffect
        //                //    {
        //                //        nutrientName = pobj.DS.Tables[4].Rows[i]["nutrientName"].ToString(),
        //                //        nutrientLevel = pobj.DS.Tables[4].Rows[i]["nutrientLevel"].ToString(),
        //                //        symptom = pobj.DS.Tables[4].Rows[i]["symptom"].ToString()
        //                //    });
        //                //}

        //                //List<GraphCategory> GraphCategory = new List<GraphCategory>();
        //                //for (int i = 0; i < pobj.DS.Tables[5].Rows.Count; i++)
        //                //{
        //                //    GraphCategory.Add(new GraphCategory
        //                //    {
        //                //        graphCategory = pobj.DS.Tables[5].Rows[i]["graphCategory"].ToString(),
        //                //        unitName = pobj.DS.Tables[5].Rows[i]["unitName"].ToString()
        //                //    });
        //                //}

        //                //List<ChartNutrients> ChartNutrients = new List<ChartNutrients>();
        //                //for (int i = 0; i < pobj.DS.Tables[6].Rows.Count; i++)
        //                //{
        //                //    ChartNutrients.Add(new ChartNutrients
        //                //    {
        //                //        nutrientID = Convert.ToInt32(pobj.DS.Tables[6].Rows[i]["nutrientID"]),
        //                //        tagName = pobj.DS.Tables[6].Rows[i]["tagName"].ToString(),
        //                //        target = pobj.DS.Tables[6].Rows[i]["target"].ToString(),
        //                //        totalNutrientValue = pobj.DS.Tables[6].Rows[i]["totalNutrientValue"].ToString(),
        //                //        totalRDAPercentage = Convert.ToInt32(pobj.DS.Tables[6].Rows[i]["totalRDAPercentage"]),
        //                //        unitName = pobj.DS.Tables[6].Rows[i]["unitName"].ToString(),
        //                //        nutrientCategory = pobj.DS.Tables[6].Rows[i]["nutrientCategory"].ToString()
        //                //    });
        //                //}

        //                nutriAnalyserValues.foodList = foodList;
        //                nutriAnalyserValues.categoryWiseNutrients = categoryWiseNutrients;
        //                //AllNutrientValuesCombinedByFoodTimeId.SupplementList = SupplementList;
        //                //AllNutrientValuesCombinedByFoodTimeId.ImmediateEffect = ImmediateEffect;
        //                //AllNutrientValuesCombinedByFoodTimeId.GraphCategory = GraphCategory;
        //                //AllNutrientValuesCombinedByFoodTimeId.ChartNutrients = ChartNutrients;

        //                ServiceResponse.GeneralResponseObject(1, "Success!", nutriAnalyserValues);
        //            }
        //            else
        //            {
        //                ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, returnDataset);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceResponse.GeneralResponseDataSet(0, ex.Message, returnDataset);
        //    }
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCutomizedRDAList(string intakeDate, string memberId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                pobj.intakeDate = Convert.ToDateTime(intakeDate);
                pobj.memberId = Convert.ToInt32(memberId);
                pobj.userId = Convert.ToInt32(userLoginId);
                BAL_Intake.GetCutomizedRDAList(pobj);
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
        public void CheckPreference(string memberId, string pid, string foodId, string userLoginId)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.PID = Convert.ToInt32(pid);
                    pobj.foodId = Convert.ToInt32(foodId);
                    BAL_Intake.checkPreference(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "foodPreference";
                        returnDataset.Tables[1].TableName = "foodEffect";
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
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void UpdateIntakeTime(string intakeDate, string foodTime, string updateFoodTime, string memberId, string userLoginId)
        //{
        //    try
        //    {
        //        if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
        //        {
        //            PAL_Intake pobj = new PAL_Intake();
        //            pobj.memberId = Convert.ToInt32(memberId);
        //            pobj.userId = Convert.ToInt32(userLoginId);
        //            pobj.intakeDate = Convert.ToDateTime(intakeDate);
        //            pobj.foodTime = foodTime;
        //            pobj.updateFoodTime = updateFoodTime;
        //            BAL_Intake.UpdateIntakeTime(pobj);
        //            if (!pobj.isException)
        //            {
        //                ServiceResponse.ResponseWithoutValue(1, "Success!");
        //            }
        //            else
        //            {
        //                ServiceResponse.ResponseWithoutValue(0, pobj.exceptionMessage);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceResponse.ResponseWithoutValue(0, ex.Message);
        //    }
        //}
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateIntakeTimeByDietID(string dietId, string dietTime, string memberId, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.dietTime = dietTime;
                    pobj.dietId = Convert.ToInt32(dietId);
                    BAL_Intake.UpdateIntakeTimeByDietID(pobj);
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
        public void UpdateIntakeDateTimeByIntakeID(int id, string intakeDateTime, int isSupplement, int memberID, int userLoginID, int entryUserID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = memberID;
                    pobj.userId = userLoginID;
                    pobj.id = id;
                    pobj.intakeDateTime = intakeDateTime;
                    pobj.isSupplement = isSupplement;
                    pobj.entryUserID = entryUserID;
                    BAL_Intake.UpdateIntakeDateTimeByIntakeID(pobj);
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
        public void UpdateIsGivenFoodSupplementByIntakeID(int id, string intakeDateTime, int isSupplement, int memberID, int userLoginID, int entryUserID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberID);
                    pobj.userId = Convert.ToInt32(userLoginID);
                    pobj.id = id;
                    pobj.intakeDateTime = intakeDateTime;
                    pobj.isSupplement = isSupplement;
                    pobj.entryUserID = entryUserID;
                    BAL_Intake.UpdateIsGivenFoodSupplementByIntakeID(pobj);
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
        public void GetNutrientCombinationList()
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                BAL_Intake.GetNutrientCombinationList(pobj);
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
        public void GetNutrientListByCombination(int nutrientCombinationID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Intake pobj = new PAL_Intake();
                pobj.nutrientCombinationID = nutrientCombinationID;
                BAL_Intake.GetNutrientListByCombination(pobj);
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
        public void GetIntakeByFoodTimeIdWithoutEnergy(string memberId, string foodTimeId, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_Intake pobj = new PAL_Intake();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.foodTimeId = Convert.ToInt32(foodTimeId);
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_Intake.GetIntakeByFoodTimeIdWithoutEnergy(pobj);
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
    }
}