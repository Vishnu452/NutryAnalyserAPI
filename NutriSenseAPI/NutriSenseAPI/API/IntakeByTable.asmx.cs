using System;
using System.Web.Services;
using System.Web.Script.Services;
using DLLIntakeByTable;
using System.Data;
using Newtonsoft.Json;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for IntakeByTable
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IntakeByTable : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetDiningTableList()
        {
            DataTable dt = new DataTable();
            try
            {
                PALIntakeByTable pobj = new PALIntakeByTable();
                BALIntakeByTable.GetDiningTableList(pobj);
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
        public void CheckDiningTableSession(int diningTableID, int userLoginID)
        {
            DataSet ds = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PALIntakeByTable pobj = new PALIntakeByTable();
                    pobj.diningTableID = diningTableID;
                    pobj.userID = userLoginID;
                    BALIntakeByTable.CheckDiningTableSession(pobj);
                    if (!pobj.isException)
                    {
                        ds = pobj.DS;
                        ds.Tables[0].TableName = "Exist";
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["isExists"]) == 1)
                        {
                            ds.Tables[1].TableName = "SessionID";
                            ds.Tables[2].TableName = "FoodList";
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
        public void StartDiningTableSession(int diningTableID, string foodContainerDetails, int userLoginID)
        {
            DataSet ds = new DataSet();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PALIntakeByTable pobj = new PALIntakeByTable();
                    pobj.diningTableID = diningTableID;
                    pobj.foodContainerDetails = JsonConvert.DeserializeObject<DataTable>(foodContainerDetails);
                    pobj.userID = userLoginID;
                    BALIntakeByTable.StartDiningTableSession(pobj);
                    if (!pobj.isException)
                    {
                        ds = pobj.DS;
                        ds.Tables[0].TableName = "SessionID";
                        ds.Tables[1].TableName = "FoodList";
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
        public void GetConsumedFoodListByMember(int diningTableSessionMainID, int memberID, int userLoginID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PALIntakeByTable pobj = new PALIntakeByTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BALIntakeByTable.GetConsumedFoodListByMember(pobj);
                    if (!pobj.isException)
                    {
                        dt = pobj.DS.Tables[0];
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
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
        public void GetIntakeListByFoodID(int foodID, int userLoginID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID))
                {
                    PALIntakeByTable pobj = new PALIntakeByTable();
                    pobj.foodID = foodID;
                    pobj.userID = userLoginID;
                    BALIntakeByTable.GetIntakeListByFoodID(pobj);
                    if (!pobj.isException)
                    {
                        dt = pobj.DS.Tables[0];
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponse(1, "Success!", dt);
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
        public void StartTakingDish(int diningTableSessionMainID, int foodID, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PALIntakeByTable pobj = new PALIntakeByTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.foodID = foodID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BALIntakeByTable.StartTakingDish(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertDiningTableFoodQuantity(string diningTableName, decimal foodQuantity, int type)
        {
            try
            {
                PALIntakeByTable pobj = new PALIntakeByTable();
                pobj.foodContainerName = diningTableName;
                pobj.foodQuantity = foodQuantity;
                pobj.type = type;
                pobj.unitID = 8;
                BALIntakeByTable.InsertTableFoodQuantity(pobj);
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
        public void GetConsumedFoodQuantity(int diningTableSessionMainID, int foodID, int memberID, int userLoginID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PALIntakeByTable pobj = new PALIntakeByTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.foodID = foodID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BALIntakeByTable.GetConsumedFoodQuantity(pobj);
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
        public void InsertDiningTableIntake(int diningTableSessionMainID, int foodID, int recipeCombinationMainID, decimal foodQuantity, int memberID, int userLoginID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PALIntakeByTable pobj = new PALIntakeByTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.foodID = foodID;
                    pobj.recipeCombinationMainID = recipeCombinationMainID;
                    pobj.foodQuantity = foodQuantity;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BALIntakeByTable.InsertDiningTableIntake(pobj);
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
        public void EndDiningTableSession(int diningTableSessionMainID, int userLoginID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID)))
                {
                    PALIntakeByTable pobj = new PALIntakeByTable();
                    pobj.diningTableSessionMainID = diningTableSessionMainID;
                    pobj.userID = userLoginID;
                    BALIntakeByTable.EndDiningTableSession(pobj);
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
        public void LadleBiometricData(string ladleName, int memberID)
        {
            DataTable dt = new DataTable();
            try
            {
                PALIntakeByTable pobj = new PALIntakeByTable();
                pobj.ladleName = ladleName;
                pobj.memberID = memberID;
                BALIntakeByTable.LadleBiometricData(pobj);
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
                PALIntakeByTable pobj = new PALIntakeByTable();
                pobj.ladleName = ladleName;
                pobj.buttonData = buttonData;
                pobj.bluetoothBandName = bluetoothBandName;
                BALIntakeByTable.LadleButtonData(pobj);
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
    }
}