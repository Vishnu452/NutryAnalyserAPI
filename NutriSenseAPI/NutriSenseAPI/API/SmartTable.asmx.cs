using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using DLLSmartTable;
using Newtonsoft.Json;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for SmartTable
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SmartTable : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddSmartTableIntakeDetail(int sessionID, int idNo, int foodID, int combinationID, decimal foodQuantity, string intakeDateTime)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Authentication.IsValidSmartTableToken())
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.sessionID = sessionID;
                    pobj.idNo = idNo;
                    pobj.foodID = foodID;
                    pobj.combinationID = combinationID;
                    pobj.foodQuantity = foodQuantity;
                    pobj.intakeDateTime = intakeDateTime;
                    BAL_SmartTable.AddSmartTableIntakeDetail(pobj);

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
        public void GetSmartTableSessionDetail(string smartTableName)
        {
            List<SmartTableResponse> smartTableResponse = new List<SmartTableResponse>();
            try
            {
                if (Authentication.IsValidSmartTableToken())
                {
                    DataSet ds = new DataSet();
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.smartTableName = smartTableName;
                    BAL_SmartTable.GetSmartTableSessionDetail(pobj);

                    if (!pobj.isException)
                    {
                        ds = pobj.DS;
                        List<FoodContainerDetail> foodContainerDetail = new List<FoodContainerDetail>();

                        for (int i = 0; i < pobj.DS.Tables[1].Rows.Count; i++)
                        {
                            List<CombinationList> combinationList = new List<CombinationList>();
                            for (int j = 0; j < pobj.DS.Tables[2].Rows.Count; j++)
                            {
                                if (pobj.DS.Tables[1].Rows[i]["foodID"].ToString() == pobj.DS.Tables[2].Rows[j]["foodID"].ToString())
                                {
                                    combinationList.Add(new CombinationList
                                    {
                                        combinationID = Convert.ToInt32(pobj.DS.Tables[2].Rows[j]["combinationID"]),
                                        combinationName = pobj.DS.Tables[2].Rows[j]["combinationName"].ToString()
                                    });
                                }
                            }

                            foodContainerDetail.Add(new FoodContainerDetail
                            {
                                containerName = pobj.DS.Tables[1].Rows[i]["containerName"].ToString(),
                                foodID = Convert.ToInt32(pobj.DS.Tables[1].Rows[i]["foodID"]),
                                foodName = pobj.DS.Tables[1].Rows[i]["foodName"].ToString(),
                                combinationList = combinationList
                            });
                        }
                        smartTableResponse.Add(new SmartTableResponse
                        {
                            sessionID = Convert.ToInt32(pobj.DS.Tables[0].Rows[0]["sessionID"]),
                            foodContainerDetail = foodContainerDetail
                        });

                        ServiceResponse.GeneralResponseObject(1, "Success!", smartTableResponse);
                    }
                    else
                    {
                        ServiceResponse.GeneralResponseObject(0, pobj.exceptionMessage, smartTableResponse);
                    }
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponseObject(0, exception.Message, smartTableResponse);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetActiveSessionDetailByMemberID(int memberID, int userLoginID)
        {
            if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
            {

                DataTable dt = new DataTable();
                try
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.memberID = memberID;
                    pobj.userLoginID = userLoginID;
                    BAL_SmartTable.GetActiveSessionDetailByMemberID(pobj);

                    if (!pobj.isException)
                    {
                        pobj.DS.Tables[0].TableName = "SessionExist";
                        pobj.DS.Tables[1].TableName = "ContainerDetail";
                        pobj.DS.Tables[2].TableName = "memberDetail";
                        pobj.DS.Tables[3].TableName = "tableList";

                        ServiceResponse.GeneralResponseDataSet(1, "Success!", pobj.DS);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetContainerDetailByTableID(int memberID, int userLoginID, int smartTableID)
        {
            if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
            {
                DataTable dt = new DataTable();
                try
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.memberID = memberID;
                    pobj.userLoginID = userLoginID;
                    pobj.smartTableID = smartTableID;
                    BAL_SmartTable.GetContainerDetailByTableID(pobj);

                    if (!pobj.isException)
                    {
                        pobj.DS.Tables[0].TableName = "ContainerList";
                        pobj.DS.Tables[1].TableName = "memberList";

                        ServiceResponse.GeneralResponseDataSet(1, "Success!", pobj.DS);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetRecipeCombinationList(int memberID, int userLoginID, int foodID)
        {
            if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
            {
                DataTable dt = new DataTable();
                try
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.foodID = foodID;
                    pobj.memberID = memberID;
                    pobj.userLoginID = userLoginID;
                    BAL_SmartTable.GetRecipeCombinationList(pobj);

                    if (!pobj.isException)
                    {
                        ServiceResponse.GeneralResponse(1, "Success!", pobj.DS.Tables[0]);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateRecipeCombination(int memberID, int userLoginID, int foodID, string combinationList)
        {
            if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
            {
                DataTable dt = new DataTable();
                try
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.memberID = memberID;
                    pobj.userLoginID = userLoginID;
                    pobj.foodID = foodID;
                    pobj.combinationList = JsonConvert.DeserializeObject<DataTable>(combinationList);
                    BAL_SmartTable.UpdateRecipeCombination(pobj);

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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void StartNewSession(int memberID, int userLoginID, int smartTableID, string participantDetail, string containerDetail)
        {
            if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
            {
                DataTable dt = new DataTable();
                try
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.memberID = memberID;
                    pobj.userLoginID = userLoginID;
                    pobj.smartTableID = smartTableID;
                    pobj.participantDetail = JsonConvert.DeserializeObject<DataTable>(participantDetail);
                    pobj.containerDetail = JsonConvert.DeserializeObject<DataTable>(containerDetail);

                    BAL_SmartTable.StartNewSession(pobj);

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
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void StopSession(int memberID, int userLoginID, int smartTableID)
        {
            if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
            {
                DataTable dt = new DataTable();
                try
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.memberID = memberID;
                    pobj.userLoginID = userLoginID;
                    pobj.smartTableID = smartTableID;
                    BAL_SmartTable.StopSession(pobj);

                    if (!pobj.isException)
                    {
                        ServiceResponse.ResponseWithoutValue(0, "Success!");
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetLiveMemberFoodDetail(int memberID, int userLoginID, int sessionID, string queryParam)
        {
            if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
            {
                DataTable dt = new DataTable();
                try
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.memberID = memberID;
                    pobj.userLoginID = userLoginID;
                    pobj.sessionID = sessionID;
                    pobj.queryParam = queryParam;
                    BAL_SmartTable.GetLiveMemberFoodDetail(pobj);

                    if (!pobj.isException)
                    {
                        ServiceResponse.GeneralResponse(1, "Success!", pobj.DS.Tables[0]);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetRecipeIngredientList(int memberID, int userLoginID, int foodID)
        {
            if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
            {
                DataTable dt = new DataTable();
                try
                {
                    PAL_SmartTable pobj = new PAL_SmartTable();
                    pobj.foodID = foodID;
                    pobj.memberID = memberID;
                    pobj.userLoginID = userLoginID;
                    BAL_SmartTable.GetRecipeIngredientList(pobj);

                    if (!pobj.isException)
                    {
                        ServiceResponse.GeneralResponse(1, "Success!", pobj.DS.Tables[0]);
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
}