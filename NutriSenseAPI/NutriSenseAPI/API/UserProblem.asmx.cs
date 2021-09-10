using System;
using System.Web.Services;
using DLLUserProblem;
using System.Web.Script.Services;
using System.Data;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for UserProblem
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserProblem : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddUserProblem(string problemID, string problemDate, string problemTimeFrom, string problemTimeTo, string memberID, string userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_UserProblem pobj = new PAL_UserProblem();
                    pobj.problemID = Convert.ToInt32(problemID);
                    pobj.problemDate = problemDate;
                    pobj.problemTimeFrom = problemTimeFrom;
                    pobj.problemTimeTo = problemTimeTo;
                    pobj.memberID = Convert.ToInt32(memberID);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_UserProblem.AddUserProblem(pobj);
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
        public void UpdateUserProblem(string userProblemID, string problemID, string problemDate, string problemTimeFrom, string problemTimeTo, string memberID, string userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_UserProblem pobj = new PAL_UserProblem();
                    pobj.userProblemID = Convert.ToInt32(userProblemID);
                    pobj.problemID = Convert.ToInt32(problemID);
                    pobj.problemDate = problemDate;
                    pobj.problemTimeFrom = problemTimeFrom;
                    pobj.problemTimeTo = problemTimeTo;
                    pobj.memberID = Convert.ToInt32(memberID);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_UserProblem.UpdateUserProblem(pobj);
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
        public void RemoveUserProblem(string userProblemID, string memberID, string userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_UserProblem pobj = new PAL_UserProblem();
                    pobj.userProblemID = Convert.ToInt32(userProblemID);
                    pobj.memberID = Convert.ToInt32(memberID);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_UserProblem.RemoveUserProblem(pobj);
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
        public void GetProblemListBySearchText(string searchText, string memberID, string userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_UserProblem pobj = new PAL_UserProblem();
                    pobj.searchText = searchText;
                    pobj.memberID = Convert.ToInt32(memberID);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_UserProblem.GetProblemListBySearchText(pobj);
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
        public void GetUserProblemListByProblemDate(string problemDate, string memberID, string userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_UserProblem pobj = new PAL_UserProblem();
                    pobj.problemDate = problemDate;
                    pobj.memberID = Convert.ToInt32(memberID);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    BAL_UserProblem.GetUserProblemListByProblemDate(pobj);
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
