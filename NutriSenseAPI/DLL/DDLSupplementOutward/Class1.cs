using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DDLSupplementOutward
{
    public class PAL_SupplementOutWard : Utility
    {
        public int userID { get; set; }
        public int entryUserID { get; set; }
        public DataTable DT_outwardItemList { get; set; }
    }

    public class DAL_SupplementOutward {

        public static void returnTable(PAL_SupplementOutWard pobj)
        {
            Config connect = new Config();
            SqlCommand sqlCmd = new SqlCommand("proc_supplementoutward", connect.con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);          
            sqlCmd.Parameters.AddWithValue("@DT_outwardsupplement", pobj.DT_outwardItemList);
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

    public class BAL_SupplementOutward
    {
        public static void OutwardsupplementDetails(PAL_SupplementOutWard pobj)
        {
            pobj.opCode = 11;
            DAL_SupplementOutward.returnTable(pobj);
        }
    }
  
}
