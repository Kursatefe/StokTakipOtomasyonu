using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipOtomasyonu
{
    public class OrtakDAL
    {
      public  SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=StokTakip; trusted_connection=true");
        public void BaglantiyiAc()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
    }
}
