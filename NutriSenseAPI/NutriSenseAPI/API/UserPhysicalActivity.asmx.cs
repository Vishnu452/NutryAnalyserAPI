using DLLUserPhysicalActivity;
using System;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for UserPhysicalActivity
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserPhysicalActivity : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddUserActivity(int activityID, int rating, string activityDate, string activityTimeFrom, string activityTimeTo, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_UserPhysicalActivity pobj = new PAL_UserPhysicalActivity();
                    pobj.activityID = activityID;
                    pobj.rating = rating;
                    pobj.activityDate = activityDate;
                    pobj.activityTimeFrom = activityTimeFrom;
                    pobj.activityTimeTo = activityTimeTo;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_UserPhysicalActivity.AddUserActivity(pobj);
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
        public void UpdateUserActivity(int userActivityID, int activityID, int rating, string activityDate, string activityTimeFrom, string activityTimeTo, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_UserPhysicalActivity pobj = new PAL_UserPhysicalActivity();
                    pobj.userActivityID = userActivityID;
                    pobj.activityID = activityID;
                    pobj.rating = rating;
                    pobj.activityDate = activityDate;
                    pobj.activityTimeFrom = activityTimeFrom;
                    pobj.activityTimeTo = activityTimeTo;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_UserPhysicalActivity.UpdateUserActivity(pobj);
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
        public void RemoveUserActivity(int userActivityID, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_UserPhysicalActivity pobj = new PAL_UserPhysicalActivity();
                    pobj.userActivityID = userActivityID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_UserPhysicalActivity.RemoveUserActivity(pobj);
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
        public void GetActivityListBySearchText(string searchText, int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_UserPhysicalActivity pobj = new PAL_UserPhysicalActivity();
                    pobj.searchText = searchText;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_UserPhysicalActivity.GetActivityListBySearchText(pobj);
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
        public void GetActivityList(int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_UserPhysicalActivity pobj = new PAL_UserPhysicalActivity();
                pobj.memberID = memberID;
                pobj.userID = userLoginID;
                BAL_UserPhysicalActivity.GetActivityList(pobj);
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
        public void GetUserActivityListByActivityDate(string activityDate, int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_UserPhysicalActivity pobj = new PAL_UserPhysicalActivity();
                    pobj.activityDate = activityDate;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_UserPhysicalActivity.GetUserActivityListByActivityDate(pobj);
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