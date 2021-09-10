using System;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using Newtonsoft.Json;
using DLLIntakeByDiningTable;
using System.Collections.Generic;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for IntakeByDiningTable
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IntakeByDiningTable : WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertDiningTableFoodQuantity(string diningTableName, decimal foodQuantity, int type)
        {
            try
            {
                PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                pobj.foodContainerName = diningTableName;
                pobj.foodQuantity = foodQuantity;
                pobj.type = type;
                pobj.unitID = 8;
                BALIntakeByDiningTable.InsertDiningTableFoodQuantity(pobj);
                if (!pobj.isException)
                {
                    ServiceResponse.ResponseWithoutValue(1, "Success!");
                }
                else
                {
                    ServiceResponse.ResponseWithoutValue(0, pobj.exceptionMessage);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDiningTableList()
        {
            DataTable dt = new DataTable();
            try
            {
                PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                BALIntakeByDiningTable.GetDiningTableList(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, dt);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CheckDiningTableSession(int diningTableID, int userLoginID, int memberID)
        {
            DataSet ds = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                    pobj.diningTableID = diningTableID;
                    pobj.userID = userLoginID;
                    pobj.memberID = memberID;
                    BALIntakeByDiningTable.CheckDiningTableSession(pobj);
                    if (!pobj.isException)
                    {
                        ds = pobj.DS;
                        ds.Tables[0].TableName = "Exist";
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["isExists"]) == 1)
                        {
                            ds.Tables[1].TableName = "SessionID";
                            ds.Tables[2].TableName = "FoodList";
                            ds.Tables[3].TableName = "ConsumedFood";
                        }
                        else if (ds.Tables.Count == 3)
                        {
                            ds.Tables[1].TableName = "FoodList";
                            ds.Tables[2].TableName = "ContainerList";
                        }
                        ServiceResponse.GeneralResponseDataSet(1, "Success!", ds);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, ds);
                    }
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponseDataSet(0, exception.Message, ds);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void StartDiningTableSession(int diningTableID, string foodContainerDetails, int userLoginID, int memberID)
        {
            DataSet ds = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                    pobj.diningTableID = diningTableID;
                    pobj.foodContainerDetails = JsonConvert.DeserializeObject<DataTable>(foodContainerDetails);
                    pobj.userID = userLoginID;
                    pobj.memberID = memberID;
                    BALIntakeByDiningTable.StartDiningTableSession(pobj);
                    if (!pobj.isException)
                    {
                        ds = pobj.DS;
                        ds.Tables[0].TableName = "Exists";
                        ds.Tables[1].TableName = "SessionID";
                        ds.Tables[2].TableName = "FoodList";
                        ServiceResponse.GeneralResponseDataSet(1, "Success!", ds);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, ds);
                    }
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponseDataSet(0, exception.Message, ds);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void LadleBiometricData(string ladleName, int memberID)
        {
            DataTable dt = new DataTable();
            try
            {
                PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                pobj.ladleName = ladleName;
                pobj.memberID = memberID;
                BALIntakeByDiningTable.LadleBiometricData(pobj);
                if (!pobj.isException)
                {
                    ServiceResponse.ResponseWithoutValue(1, "Success!");
                }
                else
                {
                    ServiceResponse.ResponseWithoutValue(0, pobj.exceptionMessage);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void LadleButtonData(string ladleName, int buttonData, string bluetoothBandName)
        {
            DataTable dt = new DataTable();
            try
            {
                PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                pobj.ladleName = ladleName;
                pobj.buttonData = buttonData;
                pobj.bluetoothBandName = bluetoothBandName;
                BALIntakeByDiningTable.LadleButtonData(pobj);
                if (!pobj.isException)
                {
                    ServiceResponse.ResponseWithoutValue(1, "Success!");
                }
                else
                {
                    ServiceResponse.ResponseWithoutValue(0, pobj.exceptionMessage);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetContainerSessionData(int diningTableSessionMainID, int memberID, int userLoginID)
        {
            DataSet ds = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BALIntakeByDiningTable.GetContainerSessionData(pobj);
                    if (!pobj.isException)
                    {
                        ds = pobj.DS;
                        ds.Tables[0].TableName = "Data";
                        if (ds.Tables.Count == 3)
                        {
                            ds.Tables[1].TableName = "diningTableContainerSession";
                            ds.Tables[2].TableName = "FoodCombination";
                        }
                        else
                        {
                            ds.Tables[1].TableName = "ConsumedFood";
                        }
                        ServiceResponse.GeneralResponseDataSet(1, "Success!", ds);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, ds);
                    }
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponseDataSet(0, exception.Message, ds);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertDiningTableIntake(int diningTableSessionMainID, int foodID, int recipeCombinationMainID, decimal foodQuantity, int memberID, int userLoginID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.foodID = foodID;
                    pobj.recipeCombinationMainID = recipeCombinationMainID;
                    pobj.foodQuantity = foodQuantity;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BALIntakeByDiningTable.InsertDiningTableIntake(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, dt);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EndDiningTableSession(int diningTableSessionMainID, int userLoginID, int memberID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.userID = userLoginID;
                    pobj.memberID = memberID;
                    BALIntakeByDiningTable.EndDiningTableSession(pobj);
                    if (!pobj.isException)
                    {
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, dt);
                    }
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, dt);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDiningTableSessionDetails(string diningTableName)
        {
            DataSet ds = new DataSet();
            try
            {
                PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                pobj.diningTableName = diningTableName;
                BALIntakeByDiningTable.GetDiningTableSessionDetails(pobj);
                if (!pobj.isException)
                {
                    ds = pobj.DS;

                    List<ContainerDetails> containerDetails = new List<ContainerDetails>();

                    for (int i = 0; i < pobj.DS.Tables[1].Rows.Count; i++)
                    {
                        List<IngredientList> ingredientList = new List<IngredientList>();
                        for (int j = 0; j < pobj.DS.Tables[2].Rows.Count; j++)
                        {
                            if (pobj.DS.Tables[1].Rows[i]["foodID"].ToString() == pobj.DS.Tables[2].Rows[j]["foodID"].ToString())
                            {
                                ingredientList.Add(new IngredientList
                                {
                                    ingredientID = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["ingredientID"]),
                                    ingredientName = pobj.DS.Tables[2].Rows[j]["ingredientName"].ToString()
                                });
                            }
                        }

                        containerDetails.Add(new ContainerDetails
                        {
                            foodContainerName = pobj.DS.Tables[1].Rows[i]["foodContainerName"].ToString(),
                            foodID = Convert.ToInt32(pobj.DS.Tables[1].Rows[i]["foodID"]),
                            foodName = pobj.DS.Tables[1].Rows[i]["foodName"].ToString(),
                            ingredientList = ingredientList
                        });
                    }
                    List<DiningTableSessionDetailResponse> diningTableSessionDetailResponse = new List<DiningTableSessionDetailResponse>();
                    diningTableSessionDetailResponse.Add(new DiningTableSessionDetailResponse
                    {
                        sessionID = pobj.DS.Tables[0].Rows[0]["diningTableSessionMainID"].ToString(),
                        containerDetails = containerDetails
                    });

                    ServiceResponse.GeneralResponseObject(1, "Success!", containerDetails);
                }
                else
                {
                    ServiceResponse.GeneralResponseDataSet(0, pobj.exceptionMessage, null);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponseDataSet(0, exception.Message, null);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertDiningTableIntakeData(int sessionID, int foodID, int ingredientID, decimal foodQuantity, string intakeDateTime, int memberID)
        {
            DataTable dt = new DataTable();
            try
            {
                PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                pobj.diningTableSessionMainID = sessionID;
                pobj.foodID = foodID;
                pobj.recipeCombinationMainID = ingredientID;
                pobj.foodQuantity = foodQuantity;
                pobj.intakeDateTime = intakeDateTime;
                pobj.foodUnitId = 8;
                pobj.memberID = memberID;
                BALIntakeByDiningTable.InsertDiningTableIntakeData(pobj);
                if (!pobj.isException)
                {
                    ServiceResponse.ResponseWithoutValue(1, "Success!");
                }
                else
                {
                    ServiceResponse.ResponseWithoutValue(0, pobj.exceptionMessage);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDiningTableSessionFoodData(int diningTableSessionMainID, int memberID, int userLoginID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PALIntakeByDiningTable pobj = new PALIntakeByDiningTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BALIntakeByDiningTable.GetDiningTableSessionFoodData(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, dt);
            }
        }
    }
}