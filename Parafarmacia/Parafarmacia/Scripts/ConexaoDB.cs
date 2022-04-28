using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace Parafarmacia.Scripts {
    class ConexaoDB {
        
        public static string connectionString;

        /// <summary>
        /// Função que retorna a string que faz a conexão à base de dados access.
        /// </summary>
        public static void getConnectionString() {
            string appBinPath = System.IO.Path.GetDirectoryName(Application.StartupPath);   // Diretoria da pasta /bin
            string accessPath = appBinPath.Remove(appBinPath.Length - 3);                   // Diretoria do projeto

            // Gerar a string de conexão
            connectionString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" + accessPath + "\\BaseDados.mdb";
        }

        /// <summary>
        /// Função que opera funções de Write na base de dados.
        /// Exemplo: "INSERT" "UPDATE"
        /// </summary>
        /// <param name="cmdSQL"></param>
        public static void ExecuteSQLnonReader(string cmdSQL) {
            OleDbConnection conn = null;
            conn.ConnectionString = connectionString;
            conn.Open();

            OleDbCommand cmd = null;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cmdSQL;
            cmd.Dispose();

            conn.Close();
        }

        /// <summary>
        /// Função que opera funções de Read na base de dados. (Buscar dados)
        /// Exemplo: "SELECT"
        /// </summary>
        /// <param name="cmdSQL"></param>
        /// <returns></returns>
        public static DataTable ExecuteSQLreader(string cmdSQL) {
            OleDbConnection conn = null;
            conn.ConnectionString = connectionString;
            conn.Open();

            OleDbCommand cmd = null;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cmdSQL;

            OleDbDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(reader);
            reader.Close();

            cmd.Dispose();
            conn.Close ();

            return dt;
        }

    }
}
