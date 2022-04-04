using MySql.Data.MySqlClient;
using MySql.Data;
using GESTAO_FORNECEDOR;
using System.Data;

string opcaoUsuario = ObterOpcaoUsuario();

MySqlConnection conexao = new MySqlConnection();
MySqlCommand sqlCmd = new MySqlCommand();
DataTable sqlDt = new DataTable();
string sqlQuery;
MySqlDataAdapter adapter = new MySqlDataAdapter();
string server = "localhost";
string username = "root";
string password = "";
string database = "gestao_fornecedor";

DataSet DS = new DataSet();

while (opcaoUsuario.ToUpper() != "X")
{
    switch(opcaoUsuario)
    {
        case "1":
            Fornecedor.Salvar();
            break;
        case "2":
            Fornecedor.Listar();
            break;
        case "3":
            Fornecedor.Consultar();
            break;
        case "4":
            Console.WriteLine("Teste conexão");
            conectar();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
    opcaoUsuario = ObterOpcaoUsuario();
}

void conectar()
{
      try
      {
          conexao.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
          conexao.Open();
          sqlCmd.Connection = conexao;
         // sqlCmd.CommandText = "SELECT * FROM gestao_fornecedor;";
          Console.WriteLine("Conectado!");
          conexao.Close();
      }
      catch (Exception)
      {
          Console.WriteLine("Problema ao conectar!");
      }
}


static string ObterOpcaoUsuario()
{
    Console.WriteLine();
    Console.WriteLine("=====Fornecedor LITE VERSION 0.01a=====");
    Console.WriteLine("Informe a opção desejada:");

    Console.WriteLine("1- Cadastrar Fornecedor");
    Console.WriteLine("2- Listar Fornecedores");
    Console.WriteLine("3- Consultar Fornecedor");
    Console.WriteLine("4- Testar Conexão");
    Console.WriteLine("X- Sair");
    Console.WriteLine();

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
}
