using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicClass
{
    public static class Module
    {
        public static string ConString = "Server=.;Database=AFSS;User Id=sa;Password=123456;";
        public static string encryptKey = "1549523A648E345DFED23490DFD2345D";
        public static string arabicalphabit = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";
        public static string UserName = "";
        public static bool IsDataOwner = false;
        public static int GetNewId(String tableName, String column, int right)
        {
            int maxNumber = 0;
            try
            {
                using (var con = new SqlConnection(ConString))
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    String query = "select isNull(max(" + column + "),0) + 1  from " + tableName + ";";
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    maxNumber = cmd.ExecuteScalar().ToInt();
                    return maxNumber;
                }
            }

            catch (Exception ex)
            {
                return -1;
            }

        }
        public static int ToInt(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static bool? ToBool(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return bool.Parse(obj.ToString());
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
    }
}
