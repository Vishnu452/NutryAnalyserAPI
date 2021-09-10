using DLLUtility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DLLMedicineIntake
{
    public class PAL_MedicineIntake : Utility
    {
        public Int32 Id { get; set; }
        public Int32 userId { get; set; }
        public Int32 entryUserID { get; set; }
        public Int32 userMedicationId { get; set; }
        public Int32 medicineID { get; set; }
        public Int32 brandID { get; set; }
        public Int32 doseFormID { get; set; }
        public decimal doseStrength { get; set; }
        public decimal doseQuantity { get; set; }
        public Int32 consumptionPercentage { get; set; }
        public Int32 doseUnitID { get; set; }
        public DateTime intakeDateTime { get; set; }
        public Int32 intakeTimeID { get; set; }
        public string intakeTime { get; set; }
        public Int32 memberID { get; set; }
        public DateTime entryDateTime { get; set; }
        public Int32 status { get; set; }

        public Int32 intakeType { get; set; }
        public Int32 foodIntakeRefID { get; set; }
        public Int32 nutrientID { get; set; }
        public decimal nutrientQty { get; set; }
        public Int32 unitID { get; set; }
    }

    public class DAL_MedicineIntake
    {
        public static void ReturnTable(PAL_MedicineIntake pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_MedicineIntake", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@userMedicationId", pobj.userMedicationId);
                sqlCmd.Parameters.AddWithValue("@userId", pobj.userId);
                sqlCmd.Parameters.AddWithValue("@entryUserID", pobj.entryUserID);
                sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
                sqlCmd.Parameters.AddWithValue("@brandID", pobj.brandID);
                sqlCmd.Parameters.AddWithValue("@medicineID", pobj.medicineID);
                sqlCmd.Parameters.AddWithValue("@doseFormID", pobj.doseFormID);
                sqlCmd.Parameters.AddWithValue("@doseStrength", pobj.doseStrength);
                sqlCmd.Parameters.AddWithValue("@doseQuantity", pobj.doseQuantity);
                sqlCmd.Parameters.AddWithValue("@consumptionPercentage", pobj.consumptionPercentage);
                sqlCmd.Parameters.AddWithValue("@doseUnitID", pobj.doseUnitID);
                sqlCmd.Parameters.AddWithValue("@intakeTime", pobj.intakeTime);
                sqlCmd.Parameters.AddWithValue("@intakeTimeID", pobj.intakeTimeID);
                if (pobj.intakeDateTime > DateTime.MinValue)
                    sqlCmd.Parameters.AddWithValue("@intakeDateTime", pobj.intakeDateTime);

                sqlCmd.Parameters.Add("@isException", SqlDbType.Bit);
                sqlCmd.Parameters["@isException"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@exceptionMessage", SqlDbType.VarChar, 500);
                sqlCmd.Parameters["@exceptionMessage"].Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                pobj.DS = new DataSet();
                sqlAdp.Fill(pobj.DS);
                pobj.isException = Convert.ToBoolean(sqlCmd.Parameters["@isException"].Value);
                pobj.exceptionMessage = sqlCmd.Parameters["@exceptionMessage"].Value.ToString();
            }
            catch (Exception ex)
            {
                pobj.isException = true;
                pobj.exceptionMessage = ex.Message;
            }
        }
    }

    public class BAL_MedicineIntake
    {
        public static void AddIntakeDetails(PAL_MedicineIntake pobj)
        {
            pobj.opCode = 11;
            DAL_MedicineIntake.ReturnTable(pobj);
        }
        public static void UpdateIntakeDetails(PAL_MedicineIntake pobj)
        {
            pobj.opCode = 21;
            DAL_MedicineIntake.ReturnTable(pobj);
        }
        public static void UpdateConsumptionPercentage(PAL_MedicineIntake pobj)
        {
            pobj.opCode = 22;
            DAL_MedicineIntake.ReturnTable(pobj);
        }
        public static void DeleteIntakeDetails(PAL_MedicineIntake pobj)
        {
            pobj.opCode = 31;
            DAL_MedicineIntake.ReturnTable(pobj);
        }
        public static void GetIntakeByMedicineTimeId(PAL_MedicineIntake pobj)
        {
            pobj.opCode = 41;
            DAL_MedicineIntake.ReturnTable(pobj);
        }
    }
}
