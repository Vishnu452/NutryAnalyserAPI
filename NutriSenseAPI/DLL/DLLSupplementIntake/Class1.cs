using System;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLSupplementIntake
{
    public class PAL_SupplementIntake : Utility
    {
        public int userMedicationID { get; set; }
        public int consumptionPercentage { get; set; }
        public int userID { get; set; }
        public int entryUserID { get; set; }
        public int isIntakeGiven { get; set; }
        public int medicineID { get; set; }
        public int brandID { get; set; }
        public int doseFormID { get; set; }
        public decimal doseStrength { get; set; }
        public decimal doseQuantity { get; set; }
        public int doseUnitID { get; set; }
        public DateTime intakeDate { get; set; }
        public string intakeTime { get; set; }
        public string updatedTime { get; set; }
        public int intakeTimeID { get; set; }
        public int supplementID { get; set; }
        public decimal supplementQuantity { get; set; }
        public int supplementUnitID { get; set; }
        public int memberID { get; set; }
        public string entryType { get; set; }
    }

    public class DAL_SupplementIntake
    {
        public static void returnTable(PAL_SupplementIntake pobj)
        {
            Config connect = new Config();
            SqlCommand sqlCmd = new SqlCommand("usp_SupplementIntake", connect.con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            sqlCmd.Parameters.AddWithValue("@userMedicationID", pobj.userMedicationID);
            sqlCmd.Parameters.AddWithValue("@consumptionPercentage", pobj.consumptionPercentage);
            sqlCmd.Parameters.AddWithValue("@userID", pobj.userID);
            sqlCmd.Parameters.AddWithValue("@entryUserID", pobj.entryUserID);
            sqlCmd.Parameters.AddWithValue("@isIntakeGiven", pobj.isIntakeGiven);
            sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
            sqlCmd.Parameters.AddWithValue("@brandID", pobj.brandID);
            sqlCmd.Parameters.AddWithValue("@medicineID", pobj.medicineID);
            sqlCmd.Parameters.AddWithValue("@doseFormID", pobj.doseFormID);
            sqlCmd.Parameters.AddWithValue("@doseStrength", pobj.doseStrength);
            sqlCmd.Parameters.AddWithValue("@doseQuantity", pobj.doseQuantity);
            sqlCmd.Parameters.AddWithValue("@doseUnitID", pobj.doseUnitID);
            if (pobj.intakeDate > DateTime.MinValue)
                sqlCmd.Parameters.AddWithValue("@intakeDate", pobj.intakeDate);
            sqlCmd.Parameters.AddWithValue("@intakeTime", pobj.intakeTime);
            sqlCmd.Parameters.AddWithValue("@updatedTime", pobj.updatedTime);
            sqlCmd.Parameters.AddWithValue("@intakeTimeID", pobj.intakeTimeID);
            sqlCmd.Parameters.AddWithValue("@supplementID", pobj.supplementID);
            sqlCmd.Parameters.AddWithValue("@supplementQuantity", pobj.supplementQuantity);
            sqlCmd.Parameters.AddWithValue("@supplementUnitID", pobj.supplementUnitID);
            sqlCmd.Parameters.AddWithValue("@entryType", pobj.entryType);
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
    }
    public class BAL_SupplementIntake
    {
        public static void AddIntakeDetails(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 11;
            DAL_SupplementIntake.returnTable(pobj);
        }
        public static void RepeatLastDayIntake(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 12;
            DAL_SupplementIntake.returnTable(pobj);
        }
        public static void AddSupplementDetails(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 13;
            DAL_SupplementIntake.returnTable(pobj);
        }
        public static void UpdateConsumptionPercentage(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 21;
            DAL_SupplementIntake.returnTable(pobj);
        }
        public static void DeleteIntakeDetails(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 31;
            DAL_SupplementIntake.returnTable(pobj);
        }
        public static void DeleteAllSupplementByDate(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 32;
            DAL_SupplementIntake.returnTable(pobj);
        }
        public static void GetSupplementList(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 41;
            DAL_SupplementIntake.returnTable(pobj);
        }
        public static void GetIntakeBySupplementTimeID(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 42;
            DAL_SupplementIntake.returnTable(pobj);
        }
        public static void GetGivenIntakeBySupplementTimeID(PAL_SupplementIntake pobj)
        {
            pobj.opCode = 43;
            DAL_SupplementIntake.returnTable(pobj);
        }
    }
}
