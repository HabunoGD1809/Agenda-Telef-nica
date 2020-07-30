using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace my_Agenda
{
    class agenda
    {
        private DataTable table = null;
        private SQLiteConnection cn = null; 
        private SQLiteDataReader reader = null;
        private SQLiteCommand cmd = null;

        public bool insertar(string nombre, string telefono)
        {
            try
            {
                string query = "Insert Into directorioj(nombre,telefono)Values ('" + nombre + "','" + telefono + "')";
                cn = conexion.conectar();
                cn.Open();

                cmd = new SQLiteCommand(query, cn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return false;

        }
        //Consulta
        public DataTable consultar(int id)
        {
            try
            {
                NombresColumnas();
                string query = "Select * From directorioj";
                cn = conexion.conectar();
                cn.Open();
                cmd = new SQLiteCommand(query,cn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    table.Rows.Add(new Object[] { reader["Id"], reader["Nombre"], reader["Telefono"] });
                }
                reader.Close();
                cn.Close();
                return table;

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }
            finally
            {
                if(cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return table;
        }
        //Metodo para eliminar
        public bool eliminar(int id)
        {
            try
            {
                string query = "Delete From directorioj where id = '" + id + "'";
                cn = conexion.conectar();
                cn.Open();
                cmd = new SQLiteCommand(query,cn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cn.Close();
                    return true;
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Process error");
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return false;

        }
        
        public DataTable filtrar(string filtro)
        {
            return table;

        }
       //Update
        public bool actualizar(int id,string nombre, string telefono)
        {
            try
            {
                string query = "Update directorioj Set Nombre = '" + nombre + "', Telefono = '" + telefono + "Where id = '" + id.ToString() + "'";
                System.Windows.Forms.MessageBox.Show(query);
                cn = conexion.conectar();
                cn.Open();
                cmd = new SQLiteCommand(query,cn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "process error");
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
            }
            return false;

        }
        
        private void nombresColumnas()
        {
            table = new DataTable();
            table.Columns.Add("Id");           
            table.Columns.Add("Télefono");
            table.Columns.Add("Nombre");
        }

    }
}
