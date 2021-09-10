using DLLUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLWhatToEatNotToEat
{
    public class PAL_WhatToEatNotToEat : Utility
    {
        public int pid { get; set; }
        public Int32 userId { get; set; }
        public Int32 memberId { get; set; }
        public Int32 foodId { get; set; }
        public Int32 recipeMainId { get; set; }
        public string newDish { get; set; }
        public string prefixText { get; set; }
        public Int32 foodGroupId { get; set; }
        public decimal cookedFoodQty { get; set; }
        public Int32 cookedFoodQtyUnit { get; set; }
        public Int32 diseaseID { get; set; }
        public string nutrientsIn { get; set; }
        public string nutrientsNotIn { get; set; }
        public DataTable tblIngredient { get; set; }
    }
    public class DAL_WhatToEatNotToEat
    {
        public static void returnTable(PAL_WhatToEatNotToEat pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_WhatToEatNotToEat", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@pid", pobj.pid);
            cmd.Parameters.AddWithValue("@userID", pobj.userId);
            cmd.Parameters.AddWithValue("@memberId", pobj.memberId);
            cmd.Parameters.AddWithValue("@foodId", pobj.foodId);
            cmd.Parameters.AddWithValue("@recipeMainId", pobj.recipeMainId);
            cmd.Parameters.AddWithValue("@newDish", pobj.newDish);
            cmd.Parameters.AddWithValue("@foodGroupId", pobj.foodGroupId);
            cmd.Parameters.AddWithValue("@cookedFoodQty", pobj.cookedFoodQty);
            cmd.Parameters.AddWithValue("@cookedFoodQtyUnit", pobj.cookedFoodQtyUnit);
            cmd.Parameters.AddWithValue("@tblIngredient", pobj.tblIngredient);
            cmd.Parameters.AddWithValue("@diseaseID", pobj.diseaseID);
            cmd.Parameters.AddWithValue("@nutrientsIn", pobj.nutrientsIn);
            cmd.Parameters.AddWithValue("@nutrientsNotIn", pobj.nutrientsNotIn);
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
    public class BAL_WhatToEatNotToEat
    {
        public static void InsertRecipeDetails(PAL_WhatToEatNotToEat pobj)
        {
            pobj.opCode = 11;
            DAL_WhatToEatNotToEat.returnTable(pobj);
        }
        public static void InsertNewDish(PAL_WhatToEatNotToEat pobj)
        {
            pobj.opCode = 12;
            DAL_WhatToEatNotToEat.returnTable(pobj);
        }
        public static void getWhatToEatNotToEat(PAL_WhatToEatNotToEat pobj)
        {
            pobj.opCode = 41;
            DAL_WhatToEatNotToEat.returnTable(pobj);
        }
        public static void getFoodInteractedNutrients(PAL_WhatToEatNotToEat pobj)
        {
            pobj.opCode = 42;
            DAL_WhatToEatNotToEat.returnTable(pobj);
        }
        public static void getCustomeDiseaseList(PAL_WhatToEatNotToEat pobj)
        {
            pobj.opCode = 43;
            DAL_WhatToEatNotToEat.returnTable(pobj);
        }
    }
}
