using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using DLLSupplementIntake;

namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for MedicineIntake
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SupplementIntake : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddIntakeDetails(int memberID, int medicineID, int brandID, string doseStrength, string doseQuantity, int doseUnitID, string intakeDate, string intakeTime, string entryType, int entryUserID, int isIntakeGiven, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.memberID = memberID;
                    pobj.medicineID = medicineID;
                    pobj.brandID = brandID;
                    pobj.doseStrength = Convert.ToDecimal(doseStrength);
                    pobj.doseQuantity = Convert.ToDecimal(doseQuantity);
                    pobj.doseUnitID = doseUnitID;
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.intakeTime = intakeTime;
                    pobj.entryType = entryType;
                    pobj.userID = userLoginID;
                    pobj.entryUserID = entryUserID;
                    pobj.isIntakeGiven = isIntakeGiven;
                    BAL_SupplementIntake.AddIntakeDetails(pobj);
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
        public void AddSupplementDetails(int memberID, int supplementID, string supplementQuantity, int supplementUnitID, string intakeDate, string intakeTime, string entryType, int entryUserID, int isIntakeGiven, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.memberID = memberID;
                    pobj.supplementID = supplementID;
                    pobj.supplementQuantity = Convert.ToDecimal(supplementQuantity);
                    pobj.supplementUnitID = supplementUnitID;
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.intakeTime = intakeTime;
                    pobj.entryType = entryType;
                    pobj.entryUserID = entryUserID;
                    pobj.isIntakeGiven = isIntakeGiven;
                    pobj.userID = userLoginID;
                    BAL_SupplementIntake.AddSupplementDetails(pobj);
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
        public void RepeatLastDayIntake(string intakeDate, string entryType, int entryUserID, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.entryType = entryType;
                    pobj.entryUserID = entryUserID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_SupplementIntake.RepeatLastDayIntake(pobj);
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
        public void GetSupplementList(int memberID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_SupplementIntake.GetSupplementList(pobj);
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
        public void GetIntakeBySupplementTimeID(int memberID, string intakeDate, int intakeTimeID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.memberID = memberID;
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.intakeTimeID = intakeTimeID;
                    pobj.userID = userLoginID;
                    BAL_SupplementIntake.GetIntakeBySupplementTimeID(pobj);
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
        public void GetGivenIntakeBySupplementTimeID(int memberID, string intakeDate, int intakeTimeID, int userLoginID)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.memberID = memberID;
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.intakeTimeID = intakeTimeID;
                    pobj.userID = userLoginID;
                    BAL_SupplementIntake.GetGivenIntakeBySupplementTimeID(pobj);
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
        public void DeleteIntakeDetails(int userMedicationID, string entryType, int entryUserID, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.userMedicationID = userMedicationID;
                    pobj.entryType = entryType;
                    pobj.entryUserID = entryUserID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_SupplementIntake.DeleteIntakeDetails(pobj);
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
        public void DeleteAllSupplementByDate(string intakeDate, string entryType, int entryUserID, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.intakeDate = Convert.ToDateTime(intakeDate);
                    pobj.entryType = entryType;
                    pobj.entryUserID = entryUserID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_SupplementIntake.DeleteAllSupplementByDate(pobj);
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
        public void UpdateConsumptionPercentage(int userMedicationID, int consumptionPercentage, int entryUserID, int memberID, int userLoginID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(userLoginID, memberID))
                {
                    PAL_SupplementIntake pobj = new PAL_SupplementIntake();
                    pobj.userMedicationID = userMedicationID;
                    pobj.consumptionPercentage = consumptionPercentage;
                    pobj.entryUserID = entryUserID;
                    pobj.memberID = memberID;
                    pobj.userID = userLoginID;
                    BAL_SupplementIntake.UpdateConsumptionPercentage(pobj);
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
    }
}
