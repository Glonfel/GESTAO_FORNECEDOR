using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace GESTAO_FORNECEDOR.Connection
{
    public partial class Connection
    {
        MySqlConnection conexao = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDT = new DataTable();
        string sqlQuery;
        MySqlDataAdapter DtA = new MySqlDataAdapter();

        DataSet DS = new DataSet();

        string server = "localhost";
        string username = "root";
        string password = "digital2";
        string database = "gestao_fornecedor";
    }
}
