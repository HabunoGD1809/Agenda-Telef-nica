using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace my_Agenda
{
    class conexion
    {
        public static SQLiteConnection conectar()
        {
            string database = Application.StartupPath+"\\directorio.db;";
            SQLiteConnection cn = new SQLiteConnection("Data Source  = " +database);
            //cn.Open();
            return cn;
        }
    }
}
