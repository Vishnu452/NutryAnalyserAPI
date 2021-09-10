using DLLUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFoodNutrientList
{
    public class PAL_FoodNutrientList : Utility
    {
        public int userID { get; set; }
        public int? groupID { get; set; }
        public int? categoryID { get; set; }
        public int foodID { get; set; }
        public int unitID { get; set; }
        public decimal quantity { get; set; }
        public string foodNamePrefix { get; set; }
    }
    public class DAL_FoodNutrientList
    {
        public static void returnTable(PAL_FoodNutrientList pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_FoodNutrientList", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@groupID", pobj.groupID);
            cmd.Parameters.AddWithValue("@categoryID", pobj.categoryID);
            cmd.Parameters.AddWithValue("@foodID", pobj.foodID);
            cmd.Parameters.AddWithValue("@unitID", pobj.unitID);
            cmd.Parameters.AddWithValue("@quantity", pobj.quantity);
            cmd.Parameters.AddWithValue("@foodNamePrefix", pobj.foodNamePrefix);
            cmd.Parameters.AddWithValue("@userID", pobj.userID);
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
    public class BAL_FoodNutrientList
    {
        public static void getFoodCategory(PAL_FoodNutrientList pobj)
        {
            pobj.opCode = 41;
            DAL_FoodNutrientList.returnTable(pobj);
        }
        public static void getFoodGroup(PAL_FoodNutrientList pobj)
        {
            pobj.opCode = 42;
            DAL_FoodNutrientList.returnTable(pobj);
        }
        public static void geFoodUnit(PAL_FoodNutrientList pobj)
        {
            pobj.opCode = 43;
            DAL_FoodNutrientList.returnTable(pobj);
        }
        public static void getFoodList(PAL_FoodNutrientList pobj)
        {
            pobj.opCode = 44;
            DAL_FoodNutrientList.returnTable(pobj);
        }
        public static void getFoodNutrientList(PAL_FoodNutrientList pobj)
        {
            pobj.opCode = 45;
            DAL_FoodNutrientList.returnTable(pobj);
        }

    }
}
