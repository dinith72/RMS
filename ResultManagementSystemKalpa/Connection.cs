using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ResultManagementSystemKalpa
{
    class Connection
    {
        public SqlConnection con = null;
        public SqlConnection connect()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ASUS-PC;Initial Catalog=RMS;Integrated Security=True");
            con.Open();
            return con;

        }
    }
}
