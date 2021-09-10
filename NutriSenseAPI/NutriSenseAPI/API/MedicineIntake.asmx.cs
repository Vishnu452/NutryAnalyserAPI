using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using DLLMedicineIntake;

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
    public class MedicineIntake : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddMedicineIntakeDetails(string memberId, string medicineID, string brandID, string doseStrength, string doseQuantity, string doseUnitID, string intakeTime, string intakeDateTime, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_MedicineIntake pobj = new PAL_MedicineIntake();
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.medicineID = Convert.ToInt32(medicineID);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.entryUserID = 0;
                    pobj.brandID = Convert.ToInt32(brandID);
                    pobj.doseStrength = Convert.ToDecimal(doseStrength);
                    pobj.doseQuantity = Convert.ToDecimal(doseQuantity);
                    pobj.doseUnitID = Convert.ToInt32(doseUnitID);
                    pobj.intakeTime = intakeTime;
                    pobj.intakeDateTime = Convert.ToDateTime(intakeDateTime);
                    BAL_MedicineIntake.AddIntakeDetails(pobj);
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
        public void AddMedicineIntakeDetailsWithEntryId(string memberId, string medicineID, string brandID, string doseStrength, string doseQuantity, string doseUnitID, string intakeTime, string intakeDateTime, string userLoginId,int entryUserID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberId)))
                {
                    PAL_MedicineIntake pobj = new PAL_MedicineIntake();
                    pobj.memberID = Convert.ToInt32(memberId);
                    pobj.medicineID = Convert.ToInt32(medicineID);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.entryUserID = Convert.ToInt32(entryUserID);
                    pobj.brandID = Convert.ToInt32(brandID);
                    pobj.doseStrength = Convert.ToDecimal(doseStrength);
                    pobj.doseQuantity = Convert.ToDecimal(doseQuantity);
                    pobj.doseUnitID = Convert.ToInt32(doseUnitID);
                    pobj.intakeTime = intakeTime;
                    pobj.intakeDateTime = Convert.ToDateTime(intakeDateTime);
                    BAL_MedicineIntake.AddIntakeDetails(pobj);
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
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void UpdateIntakeDetails(string memberID, string medicineID, string userLoginId, string doseFormID, string doseStrength, string doseUnitID, string intakeDateTime)
        //{
        //    try
        //    {
        //        if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberID)))
        //        {
        //            PAL_MedicineIntake pobj = new PAL_MedicineIntake();
        //            pobj.memberID = Convert.ToInt32(memberID);
        //            pobj.medicineID = Convert.ToInt32(medicineID);
        //            pobj.userId = Convert.ToInt32(userLoginId);
        //            pobj.entryUserID = 0;
        //            pobj.doseFormID = Convert.ToInt32(doseFormID);
        //            pobj.doseStrength = Convert.ToInt32(doseStrength);
        //            pobj.doseUnitID = Convert.ToInt32(doseUnitID);
        //            pobj.intakeDateTime = Convert.ToDateTime(intakeDateTime);
        //            BAL_MedicineIntake.UpdateIntakeDetails(pobj);
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
        public void UpdateConsumptionPercentage(string memberID, int userMedicationId, string consumptionPercentage, string userLoginId, int entryUserID)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberID)))
                {
                    PAL_MedicineIntake pobj = new PAL_MedicineIntake();
                    pobj.memberID = Convert.ToInt32(memberID);
                    pobj.userMedicationId = Convert.ToInt32(userMedicationId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    pobj.entryUserID = entryUserID;
                    pobj.consumptionPercentage = Convert.ToInt32(consumptionPercentage);
                    BAL_MedicineIntake.UpdateConsumptionPercentage(pobj);
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
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void UpdateIntakeDetailsWithEntryId(string memberID, string medicineID, string userLoginId, string doseFormID, string doseStrength, string doseUnitID, string intakeDateTime, int entryUserID)
        //{
        //    try
        //    {
        //        if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberID)))
        //        {
        //            PAL_MedicineIntake pobj = new PAL_MedicineIntake();
        //            pobj.memberID = Convert.ToInt32(memberID);
        //            pobj.medicineID = Convert.ToInt32(medicineID);
        //            pobj.userId = Convert.ToInt32(userLoginId);
        //            pobj.entryUserID = Convert.ToInt32(entryUserID);
        //            pobj.doseFormID = Convert.ToInt32(doseFormID);
        //            pobj.doseStrength = Convert.ToInt32(doseStrength);
        //            pobj.doseUnitID = Convert.ToInt32(doseUnitID);
        //            pobj.intakeDateTime = Convert.ToDateTime(intakeDateTime);
        //            BAL_MedicineIntake.UpdateIntakeDetails(pobj);
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
        public void GetIntakeByMedicineTimeId(string memberID, string intakeTimeID, string intakeDate, string userLoginId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId), Convert.ToInt32(memberID)))
                {
                    PAL_MedicineIntake pobj = new PAL_MedicineIntake();
                    pobj.memberID = Convert.ToInt32(memberID);
                    pobj.intakeTimeID = Convert.ToInt32(intakeTimeID);
                    pobj.intakeDateTime = Convert.ToDateTime(intakeDate);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_MedicineIntake.GetIntakeByMedicineTimeId(pobj);
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
        public void DeleteIntakeDetails(string userMedicationId, string userLoginId)
        {
            try
            {
                if (Authentication.IsValidUserAuthentication(Convert.ToInt32(userLoginId)))
                {
                    PAL_MedicineIntake pobj = new PAL_MedicineIntake();
                    pobj.userMedicationId = Convert.ToInt32(userMedicationId);
                    pobj.userId = Convert.ToInt32(userLoginId);
                    BAL_MedicineIntake.DeleteIntakeDetails(pobj);
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
