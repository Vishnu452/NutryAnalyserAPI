using DLLUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDLCustomisedRda
{
    public class PAL_CustomisedRda : Utility
    {
        public int? pid { get; set; }
        public Int32 userID { get; set; }
        public Int32 memberID { get; set; }
        public Int32 nutrientID { get; set; }
        public Int32 Id { get; set; }
        public Int32 nutrientUnitID { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string intakeDate { get; set; }
        public decimal originalRDA { get; set; }
        public Int32 rdaUnitID { get; set; }
        public decimal rdaPercentage { get; set; }
        public Int32 entryUserID { get; set; }
        public string rdaChangeFrom { get; set; }
        public string rdaChangeTo { get; set; }
        public string rdaChangeDate { get; set; }
    }
    public class NutrientRatio
    {
        public int dietID { get; set; }
        public string foodName { get; set; }
        public decimal foodQuantity { get; set; }
        public string foodUnit { get; set; }
        public decimal nutrientValue { get; set; }
        public string nutrientUnit { get; set; }
        public int nutrientPercentage { get; set; }
        public string foodTiming { get; set; }
        public List<IngredientNutrientValue> ingredientNutrientValue { get; set; }
    }

    public class IngredientNutrientValue
    {
        public string ingredientName { get; set; }
        public decimal nutrientValue { get; set; }
        public string unitName { get; set; }
    }
    public class DAL_CustomisedRda
    {
        public static void returnTable(PAL_CustomisedRda pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_customisedRda", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@pid", pobj.pid);
            cmd.Parameters.AddWithValue("@Id", pobj.Id);
            cmd.Parameters.AddWithValue("@userID", pobj.userID);
            cmd.Parameters.AddWithValue("@memberId", pobj.memberID);
            cmd.Parameters.AddWithValue("@nutrientID", pobj.nutrientID);
            cmd.Parameters.AddWithValue("@fromDate", pobj.fromDate);
            cmd.Parameters.AddWithValue("@toDate", pobj.toDate);
            //cmd.Parameters.AddWithValue("@intakeDate", pobj.intakeDate);
            cmd.Parameters.AddWithValue("@originalRDA", pobj.originalRDA);
            cmd.Parameters.AddWithValue("@rdaUnitID", pobj.rdaUnitID);
            cmd.Parameters.AddWithValue("@rdaPercentage", pobj.rdaPercentage);
            cmd.Parameters.AddWithValue("@entryUserID", pobj.entryUserID);
            cmd.Parameters.AddWithValue("@rdaChangeFrom", pobj.rdaChangeFrom);
            cmd.Parameters.AddWithValue("@rdaChangeTo", pobj.rdaChangeTo);
            cmd.Parameters.AddWithValue("@rdaChangeDate", pobj.rdaChangeDate);
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
    public class BAL_CustomisedRda
    {
        public static void InsertCustomisedRda(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 11;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void UpdateCustomisedRda(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 21;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void DeleteCustomisedRda(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 31;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void GetRdaDetails(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 41;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void GetCustomizeRDAChangedData(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 42;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void GetCustomisedRdaList(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 43;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void GetNutrientRatioByNutrient(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 44;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void GetRDAChangedEffect(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 45;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void GetChangeRDADateListBetweenDates(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 46;
            DAL_CustomisedRda.returnTable(pobj);
        }
        public static void GetRDAChangeEffect(PAL_CustomisedRda pobj)
        {
            pobj.opCode = 47;
            DAL_CustomisedRda.returnTable(pobj);
        }
    }
}
