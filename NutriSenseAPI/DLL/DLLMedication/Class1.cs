using System;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLMedication
{
    public class PAL_Medication : Utility
    {
        public int userID { get; set; }
        public int memberID { get; set; }
        public string searchKeyword { get; set; }
        public int medicineID { get; set; }
        public decimal doseStrength { get; set; }
        public int doseUnitID { get; set; }
        public int medicationID { get; set; }
        public int medicineStrengthID { get; set; }
        public string intakeDate { get; set; }
        public string intakeTime { get; set; }
        public int intakeTimeID { get; set; }
    }

    public class DAL_Medication
    {
        public static void returnTable(PAL_Medication pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_Medication", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@userID", pobj.userID);
            cmd.Parameters.AddWithValue("@memberID", pobj.memberID);
            cmd.Parameters.AddWithValue("@searchKeyword", pobj.searchKeyword);
            cmd.Parameters.AddWithValue("@medicineID", pobj.medicineID);
            cmd.Parameters.AddWithValue("@doseStrength", pobj.doseStrength);
            cmd.Parameters.AddWithValue("@doseUnitID", pobj.doseUnitID);
            cmd.Parameters.AddWithValue("@medicationID", pobj.medicationID);
            cmd.Parameters.AddWithValue("@medicineStrengthID", pobj.medicineStrengthID);
            cmd.Parameters.AddWithValue("@intakeDate", pobj.intakeDate);
            cmd.Parameters.AddWithValue("@intakeTime", pobj.intakeTime);
            cmd.Parameters.AddWithValue("@intakeTimeID", pobj.intakeTimeID);
            cmd.Parameters.Add("@isException", SqlDbType.Bit);
            cmd.Parameters["@isException"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@exceptionMessage", SqlDbType.VarChar, 500);
            cmd.Parameters["@exceptionMessage"].Direction = ParameterDirection.Output;
            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            pobj.DS = new DataSet();
            sqlAdp.Fill(pobj.DS);
            pobj.isException = Convert.ToBoolean(cmd.Parameters["@isException"].Value);
            pobj.exceptionMessage = cmd.Parameters["@exceptionMessage"].Value.ToString();
        }
    }
    public class BAL_Medication
    {
        public static void AddMedication(PAL_Medication pobj)
        {
            pobj.opCode = 11;
            DAL_Medication.returnTable(pobj);
        }
        public static void UpdateMedication(PAL_Medication pobj)
        {
            pobj.opCode = 21;
            DAL_Medication.returnTable(pobj);
        }
        public static void RemoveMedication(PAL_Medication pobj)
        {
            pobj.opCode = 31;
            DAL_Medication.returnTable(pobj);
        }
        public static void SearchMedicine(PAL_Medication pobj)
        {
            pobj.opCode = 41;
            DAL_Medication.returnTable(pobj);
        }
        public static void GetUserMedicationList(PAL_Medication pobj)
        {
            pobj.opCode = 42;
            DAL_Medication.returnTable(pobj);
        }
        public static void GetAllMedicineStrengthList(PAL_Medication pobj)
        {
            pobj.opCode = 43;
            DAL_Medication.returnTable(pobj);
        }
        public static void GetMedicineList(PAL_Medication pobj)
        {
            pobj.opCode = 44;
            DAL_Medication.returnTable(pobj);
        }
    }
}