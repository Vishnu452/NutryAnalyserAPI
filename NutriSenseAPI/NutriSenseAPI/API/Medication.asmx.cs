using System;
using System.Web.Services;
using System.Web.Script.Services;
using DLLMedication;
using System.Data;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for Medication
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Medication : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddMedication(string medicineStrengthID, string intakeDate, string intakeTime, string userLoginID, string memberID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_Medication pobj = new PAL_Medication();
                    pobj.medicineStrengthID = Convert.ToInt32(medicineStrengthID);
                    pobj.intakeDate = intakeDate;
                    pobj.intakeTime = intakeTime;
                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.memberID = Convert.ToInt32(memberID);
                    BAL_Medication.AddMedication(pobj);
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
        public void GetAllMedicineStrengthList(string medicationID, string userLoginID, string memberID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_Medication pobj = new PAL_Medication();
                    pobj.medicationID = Convert.ToInt32(medicationID);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.memberID = Convert.ToInt32(memberID);
                    BAL_Medication.GetAllMedicineStrengthList(pobj);
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
        public void UpdateMedication(string medicationID, string medicineStrengthID, string intakeDate, string intakeTime, string userLoginID, string memberID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_Medication pobj = new PAL_Medication();
                    pobj.medicationID = Convert.ToInt32(medicationID);
                    pobj.medicineStrengthID = Convert.ToInt32(medicineStrengthID);
                    pobj.intakeDate = intakeDate;
                    pobj.intakeTime = intakeTime;
                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.memberID = Convert.ToInt32(memberID);
                    BAL_Medication.UpdateMedication(pobj);
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
        public void RemoveMedication(string medicationID, string userLoginID, string memberID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_Medication pobj = new PAL_Medication();
                    pobj.medicationID = Convert.ToInt32(medicationID);
                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.memberID = Convert.ToInt32(memberID);
                    BAL_Medication.RemoveMedication(pobj);
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
        public void SearchMedicine(string searchKeyword)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Medication pobj = new PAL_Medication();
                pobj.searchKeyword = searchKeyword;
                BAL_Medication.SearchMedicine(pobj);
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
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetUserMedicationList(string userLoginID, string intakeDate, string memberID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_Medication pobj = new PAL_Medication();
                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.intakeDate = intakeDate;
                    pobj.memberID = Convert.ToInt32(memberID);
                    BAL_Medication.GetUserMedicationList(pobj);
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
        public void GetMedicineList(string userLoginID, string memberID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginID), Convert.ToInt32(memberID)))
                {
                    PAL_Medication pobj = new PAL_Medication();
                    pobj.userID = Convert.ToInt32(userLoginID);
                    pobj.memberID = Convert.ToInt32(memberID);
                    BAL_Medication.GetMedicineList(pobj);
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
