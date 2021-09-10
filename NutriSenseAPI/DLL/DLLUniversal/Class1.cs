using System;
using DLLUtility;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace DLLUniversal
{
    public class PAL_Universal : Utility
    {
        public int messageId { get; set; }
        public int countryId { get; set; }
        public int foodId { get; set; }
        public int stateId { get; set; }
        public int intakeID { get; set; }
        public int textID { get; set; }
        public int isSupplement { get; set; }
        public int isSynonym { get; set; }
    }

    public class UnitList
    {
        public int id { get; set; }
        public string unitName { get; set; }
    }
    public class IntakeDoseData
    {
        public string defaultQuantity { get; set; }
        public int defaultUnitID { get; set; }
        public List<UnitList> unitList { get; set; }
    }

    public class DAL_Universal
    {
        public static void returnTable(PAL_Universal pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_Universal", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@countryId", pobj.countryId);
            cmd.Parameters.AddWithValue("@foodId", pobj.foodId);
            cmd.Parameters.AddWithValue("@stateId", pobj.stateId);
            cmd.Parameters.AddWithValue("@intakeID", pobj.intakeID);
            cmd.Parameters.AddWithValue("@textID", pobj.textID);
            cmd.Parameters.AddWithValue("@isSupplement", pobj.isSupplement);
            cmd.Parameters.AddWithValue("@isSynonym", pobj.isSynonym);
            cmd.Parameters.AddWithValue("@messageId", pobj.messageId);
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
    public class BAL_Universal
    {
        public static void GetCountryList(PAL_Universal pobj)
        {
            pobj.opCode = 41;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetCountryCallingCode(PAL_Universal pobj)
        {
            pobj.opCode = 42;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetStateList(PAL_Universal pobj)
        {
            pobj.opCode = 43;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetDistrictList(PAL_Universal pobj)
        {
            pobj.opCode = 44;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetPregnantCondition(PAL_Universal pobj)
        {
            pobj.opCode = 45;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetLifeStyleCategory(PAL_Universal pobj)
        {
            pobj.opCode = 46;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetGender(PAL_Universal pobj)
        {
            pobj.opCode = 47;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetNutrientActivecompoundFact(PAL_Universal pobj)
        {
            pobj.opCode = 48;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetFoodUnitByFoodId(PAL_Universal pobj)
        {
            pobj.opCode = 49;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetLactationCondition(PAL_Universal pobj)
        {
            pobj.opCode = 410;
            DAL_Universal.returnTable(pobj);
        }
        public static void GetIntakeUnitByIntakeId(PAL_Universal pobj)
        {
            pobj.opCode = 412;
            DAL_Universal.returnTable(pobj);
        }
        public static void UpdateMobileMessageStatus(PAL_Universal pobj)
        {
            pobj.opCode = 21;
            DAL_Universal.returnTable(pobj);
        }
    }
}
