using System;
using System.Web.Services;
using System.Web.Script.Services;
using DLLFamilyMember;
using System.Data;
namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for FamilyMember
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FamilyMember : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertMemberDetails(string memberName, string dob, string gender, string address, string height, string weight, string activity, string isPregnant, string pregnantCondition, string islactation, string lactationCondition, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.memberName = memberName;
                    pobj.dob = Convert.ToDateTime(dob);
                    pobj.address = address;
                    pobj.gender = Convert.ToInt32(gender);
                    pobj.height = Convert.ToInt32(height);
                    pobj.weight = Convert.ToInt32(weight);
                    pobj.activity = Convert.ToInt32(activity);
                    pobj.isPregnant = Convert.ToInt32(isPregnant);
                    pobj.pregnantCondition = Convert.ToInt32(pregnantCondition);
                    pobj.isLactation = Convert.ToInt32(islactation);
                    pobj.lactationCondition = Convert.ToInt32(lactationCondition);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALFamilyMember.InsertMemberDetails(pobj);
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
        public void UpdateMemberDetails(string memberName, string dob, string gender, string address, string height, string weight, string activity, string isPregnant, string pregnantCondition, string isLactation, string lactationCondition, string userLoginId, string memberId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.memberName = memberName;
                    pobj.dob = Convert.ToDateTime(dob);
                    pobj.address = address;
                    pobj.gender = Convert.ToInt32(gender);
                    pobj.height = Convert.ToInt32(height);
                    pobj.weight = Convert.ToInt32(weight);
                    pobj.activity = Convert.ToInt32(activity);
                    pobj.isPregnant = Convert.ToInt32(isPregnant);
                    pobj.pregnantCondition = Convert.ToInt32(pregnantCondition);
                    pobj.isLactation = Convert.ToInt32(isLactation);
                    pobj.lactationCondition = Convert.ToInt32(lactationCondition);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.memberId = Convert.ToInt32(memberId);
                    BALFamilyMember.UpdateMemberDetails(pobj);
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
        public void GetMemberDetails(string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALFamilyMember.GetMemberDetails(pobj);
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
        public void DeleteMemberDetails(string memberId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALFamilyMember.DeleteMemberDetails(pobj);
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
        public void GetMemberDetailsById(string memberId, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.memberId = Convert.ToInt32(memberId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BALFamilyMember.GetMemberDetailsById(pobj);
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
        public void GetUserProfileByPID(string PID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidOPDToken())
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.PID = Convert.ToInt32(PID);
                    BALFamilyMember.GetUserProfileByPID(pobj);
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
        public void AddNutriAnalyserProfile(string PID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidOPDToken())
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.PID = Convert.ToInt32(PID);
                    BALFamilyMember.AddNutriAnalyserProfile(pobj);
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
        public void AddPatientToNutritionalPanel(int userLoginId, int memberId)
        {
            try
            {
                if (Authentication.IsValidOPDToken())
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.memberId = Convert.ToInt32(memberId);
                    BALFamilyMember.AddPatientToNutritionalPanel(pobj);
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
        public void RemovePatientFromNutritionalPanel(int userLoginId, int memberId)
        {
            try
            {
                if (Authentication.IsValidOPDToken())
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.memberId = Convert.ToInt32(memberId);
                    BALFamilyMember.RemovePatientFromNutritionalPanel(pobj);
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
        public void GetNutritionalPanelPatientList(string memberType,string memberName,string diagnosis)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidOPDToken())
                {
                    PALFamilyMember pobj = new PALFamilyMember();
                    pobj.memberType = memberType;
                    pobj.memberName = memberName!="" ? memberName:null;
                    pobj.diagnosis = diagnosis!=""? diagnosis:null;
                    BALFamilyMember.GetNutritionalPanelPatientList(pobj);
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
