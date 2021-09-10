using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using DDLCustomisedRda;
using DLLUtility;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for CustomisedRda
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomisedRda : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertCustomisedRda(string nutrientID, string originalRDA, string rdaUnitID, string rdaPercentage, string userLoginId,string memberId,string entryUserID,string fromDate, string toDate)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.nutrientID = Convert.ToInt32(nutrientID);
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.entryUserID = Convert.ToInt32(entryUserID);
                    pobj.originalRDA = Convert.ToDecimal(originalRDA);
                    pobj.rdaUnitID = Convert.ToInt32(rdaUnitID);
                    pobj.rdaPercentage = Convert.ToDecimal(rdaPercentage);
                    pobj.fromDate = fromDate;
                    pobj.toDate = toDate;
                    pobj.userID = Convert.ToInt32(userLoginId);
                    BAL_CustomisedRda.InsertCustomisedRda(pobj);
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
        public void UpdateCustomisedRda(string Id, string nutrientID, string originalRDA, string rdaUnitID, string rdaPercentage, string userLoginId, string memberId, string entryUserID, string fromDate, string toDate)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.nutrientID = Convert.ToInt32(nutrientID);
                    pobj.Id = Convert.ToInt32(Id);
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.entryUserID = Convert.ToInt32(entryUserID);
                    pobj.originalRDA = Convert.ToDecimal(originalRDA);
                    pobj.rdaUnitID = Convert.ToInt32(rdaUnitID);
                    pobj.rdaPercentage = Convert.ToDecimal(rdaPercentage);
                    pobj.fromDate = fromDate;
                    pobj.toDate = toDate;
                    pobj.userID = Convert.ToInt32(userLoginId);
                    BAL_CustomisedRda.UpdateCustomisedRda(pobj);
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
        public void DeleteCustomisedRda(string Id,string userLoginId, string memberId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.Id = Convert.ToInt32(Id);
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.userID = Convert.ToInt32(userLoginId);
                    BAL_CustomisedRda.DeleteCustomisedRda(pobj);
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
        public void GetRdaDetails(string memberId, string userLoginId, string nutrientID)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.nutrientID = Convert.ToInt32(nutrientID);
                    pobj.userID = Convert.ToInt32(userLoginId);
                    BAL_CustomisedRda.GetRdaDetails(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "rdaDetails";
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
        public void GetCustomizeRDAChangedData(int nutrientID, decimal rdaPercentage,string intakeDate,int memberID, int userLoginID)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.nutrientID = Convert.ToInt32(nutrientID);
                    pobj.rdaPercentage = rdaPercentage;
                    pobj.intakeDate = intakeDate;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_CustomisedRda.GetCustomizeRDAChangedData(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "additional";
                        returnDataset.Tables[1].TableName = "modifiedFoodList";
                        returnDataset.Tables[2].TableName = "modifiedNutrient1";
                        returnDataset.Tables[3].TableName = "modifiedNutrient2";
                        returnDataset.Tables[4].TableName = "modifiedNutrient3";
                        returnDataset.Tables[5].TableName = "modifiedNutrient4";
                        returnDataset.Tables[6].TableName = "modifiedNutrient5";
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
        public void GetCustomisedRdaList(string userLoginId, string memberId, string nutrientID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.userID = Convert.ToInt32(userLoginId);
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.nutrientID = Convert.ToInt32(nutrientID);
                    BAL_CustomisedRda.GetCustomisedRdaList(pobj);
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
        public void GetNutrientRatioByNutrient(string memberId, string nutrientId, string rdaPercent, string intakeDate, string userLoginId)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.nutrientID = Convert.ToInt32(nutrientId);
                    pobj.intakeDate = intakeDate;
                    pobj.rdaPercentage = Convert.ToDecimal(rdaPercent);
                    pobj.userID = Convert.ToInt32(userLoginId);
                    BAL_CustomisedRda.GetNutrientRatioByNutrient(pobj);
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
                        DataTable dtNutrientRatio = new DataTable();
                        DataTable dtProblems = new DataTable();
                        dtNutrientRatio = Utility.ToDataTable(NutrientRatio);
                        returnDataset.Tables.Add(dtNutrientRatio);
                        dtProblems = pobj.DS.Tables[2].Copy();
                        dtProblems.TableName = "nutrientEffect";
                        returnDataset.Tables.Add(dtProblems);
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
        public void GetRDAChangedEffect(int nutrientID, decimal rdaPercentage, int memberID, int userLoginID)
        {
            DataSet returnDataset = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.nutrientID = Convert.ToInt32(nutrientID);
                    pobj.rdaPercentage = rdaPercentage;
                    pobj.userID = userLoginID;
                    BAL_CustomisedRda.GetRDAChangedEffect(pobj);
                    if (!pobj.isException)
                    {
                        returnDataset = pobj.DS;
                        returnDataset.Tables[0].TableName = "nutrientDeficiencyToxicity";
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
        public void GetChangeRDADateListBetweenDates(string rdaChangeFrom, string rdaChangeTo, int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.rdaChangeFrom = rdaChangeFrom;
                    pobj.rdaChangeTo = rdaChangeTo;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_CustomisedRda.GetChangeRDADateListBetweenDates(pobj);
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
        public void GetRDAChangeEffect(string rdaChangeDate, int memberID, int userLoginID)
        {
            DataSet DS = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_CustomisedRda pobj = new PAL_CustomisedRda();
                    pobj.rdaChangeDate = rdaChangeDate;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_CustomisedRda.GetRDAChangeEffect(pobj);
                    if (!pobj.isException)
                    {
                        DS = pobj.DS;
                        DS.Tables[0].TableName = "problemList";
                        DS.Tables[1].TableName = "symptomList";
                        DS.Tables[2].TableName = "testList";
                        ServiceResponse.GeneralResponseDataSet(1, "Success!", DS);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, DS);
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.GeneralResponseDataSet(0, ex.Message, DS);
            }
        }
    }
}
