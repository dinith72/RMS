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
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VLM6UA1;Initial Catalog=RMS;Integrated Security=True;Connect Timeout=30");
            con.Open();
            return con;

        }
    }
}
