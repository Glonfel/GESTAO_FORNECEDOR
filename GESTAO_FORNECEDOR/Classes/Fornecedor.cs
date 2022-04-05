using GESTAO_FORNECEDOR;
using GESTAO_FORNECEDOR.Classes;
using GESTAO_FORNECEDOR.Interface;
using GESTAO_FORNECEDOR.Repositorio;
using MySql.Data.MySqlClient;

namespace GESTAO_FORNECEDOR
{
	public class Fornecedor : EntidadeBase
	{
		static FornecedorRepositorio fornecedor = new FornecedorRepositorio();
		private bool isRascunho { get; set; }

		private String email { get; set; }

		private String cnpj { get; set; }

		private String inscricaoEstadual { get; set; }

		private String inscricaoMunicipal { get; set; }

		private long dtCadastro { get; set; }

		private String rzSocial { get; set; }

		private String nmFantasia { get; set; }

		private bool dispo { get; set; }

		private int distancia { get; set; }

		public Fornecedor(int id, bool isRascunho, string email, string cnpj, string inscricaoEstadual, string inscricaoMunicipal, long dtCadastro, string rzSocial, string nmFantasia, bool dispo, int distancia)
        {//Método construtor
			this.Id = id;
			this.isRascunho = isRascunho;
			this.email = email;
			this.cnpj = cnpj;
			this.inscricaoEstadual = inscricaoEstadual;
			this.inscricaoMunicipal = inscricaoMunicipal;
			this.dtCadastro = dtCadastro;
			this.rzSocial = rzSocial;
			this.nmFantasia = nmFantasia;
			this.dispo = dispo;
			this.distancia = distancia;
        }

        public override string ToString()
        {
			string retorno = "";
            retorno += "Rascunho: " + this.isRascunho + Environment.NewLine;
			retorno += "E-Mail: " + this.email + Environment.NewLine;
			retorno += "CNPJ: " + this.cnpj + Environment.NewLine;
			retorno += "Inscrição Estadual: " + this.inscricaoEstadual + Environment.NewLine;
			retorno += "Inscrição Municiapal: " + this.inscricaoMunicipal + Environment.NewLine;
			retorno += "Data de Cadastro: " + this.dtCadastro + Environment.NewLine;
			retorno += "Razão Social: " + this.rzSocial + Environment.NewLine;
			retorno += "Nome Fantasia: " + this.nmFantasia + Environment.NewLine;
			retorno += "Disponibilidade: " + this.dispo + Environment.NewLine;
			retorno += "Distância em KM: " + this.distancia + Environment.NewLine;

			return retorno;
        }
        public static void Salvar()
		{
			var lista = fornecedor.Lista();
			Console.WriteLine("Inserir novo Fornecedor");

			Console.WriteLine("Informe o Email: ");
			string entradaEmail = Console.ReadLine();

			Console.WriteLine("Informe o CNPJ: ");
			string entradaCNPJ = Console.ReadLine();

			Console.WriteLine("Informe a Inscrição Estadual: ");
			string entradaEstadual = Console.ReadLine();

			Console.WriteLine("Informe a Inscrição Municipal: ");
			string entradaMunicipal = Console.ReadLine();

			Console.WriteLine("Informe a data de Cadastro: ");
			long entradaDTCadastro = long.Parse(Console.ReadLine());

			Console.WriteLine("Informe a Razão Social: ");
			string entradaRzSocial = Console.ReadLine();

			Console.WriteLine("Informe o Nome Fantasia: ");
			string entradaNmFantasia = Console.ReadLine();

			Console.WriteLine("Informe a Distância em KM: ");
			int entradaDistancia = int.Parse(Console.ReadLine());

			Fornecedor novoFornecedor = new Fornecedor(id: fornecedor.ProximoId(), isRascunho: false, email : entradaEmail, cnpj : entradaCNPJ, inscricaoEstadual : entradaEstadual, inscricaoMunicipal : entradaMunicipal, dtCadastro : entradaDTCadastro, rzSocial : entradaRzSocial, nmFantasia : entradaNmFantasia, dispo : true, distancia : entradaDistancia);
			fornecedor.Insere(novoFornecedor);			
			Console.Clear();
			Console.WriteLine("O Seguinte Fornecedor está prestes a ser cadastrado no banco de dados, pressione S para confirmar");
			var cadFornecedor = Fornecedor.fornecedor.RetornaPorId(novoFornecedor.Id);
			Console.WriteLine(cadFornecedor);
			string opt = Console.ReadLine().ToUpper();
            if (opt.ToUpper() == "S")
            {
				MySqlConnection conexao = new MySqlConnection();
				string server = "localhost";
				string username = "root";
				string password = "";
				string database = "gestao_fornecedor";
				conexao.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database; //String de Conexão
				conexao.Open(); //Abre a Conexão
				MySqlCommand sqlCmd = new MySqlCommand("insert into fornecedor(forn_ID, forn_Rasc, forn_email, forn_cnpj, forn_inscEst, forn_inscMuni, forn_dtCad, forn_rzSocial, forn_nmFantasia, forn_dispo, forn_distancia) values(null, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);", conexao);//Comando SQL de inserção
				//Parametros do comando SQL
				sqlCmd.Parameters.AddWithValue("@forn_Rasc", novoFornecedor.isRascunho);
				sqlCmd.Parameters.AddWithValue("@forn_email", novoFornecedor.email);
				sqlCmd.Parameters.AddWithValue("@forn_cnpj", novoFornecedor.cnpj);
				sqlCmd.Parameters.AddWithValue("@forn_inscEst", novoFornecedor.inscricaoEstadual);
				sqlCmd.Parameters.AddWithValue("@forn_inscMuni", novoFornecedor.inscricaoMunicipal);
				sqlCmd.Parameters.AddWithValue("@forn_dtCad", novoFornecedor.dtCadastro);
				sqlCmd.Parameters.AddWithValue("@forn_rzSocial", novoFornecedor.rzSocial);
				sqlCmd.Parameters.AddWithValue("@forn_nmFantasia", novoFornecedor.nmFantasia);
				sqlCmd.Parameters.AddWithValue("@forn_dispo", novoFornecedor.dispo);
				sqlCmd.Parameters.AddWithValue("@forn_distancia", novoFornecedor.distancia);

				sqlCmd.ExecuteNonQuery(); //Executa a Query
				Console.WriteLine("Fornecedor cadastrado com Sucesso! Retornando ao menu...");
				System.Threading.Thread.Sleep(3000);
				Console.Clear();
            }
            else
            {
				Console.Clear();
				Console.WriteLine("O Fornecedor não foi cadastrado, Retornando ao menu...");
				System.Threading.Thread.Sleep(3000);
				Console.Clear();
			}
			
		}


		public void Alterar()
		{

		}

		public static void Listar()
		{
			Console.Clear();
			Console.WriteLine("Listar Fornecedores");

			var lista = fornecedor.Lista();

			foreach(var fornecedor in lista)
            {
				Console.WriteLine("#ID {0}: - CNPJ {1}", fornecedor.retornaId(), fornecedor.retornaCNPJ());
            }
		}

		public static void Consultar()
        {
			Console.Clear();
			Console.WriteLine("Informe o ID do Fornecedor a ser consultado");
			int idForn = int.Parse(Console.ReadLine());

			var fornecedor = Fornecedor.fornecedor.RetornaPorId(idForn);
			Console.WriteLine(fornecedor);
        }

		public string retornaCNPJ()
        {
			return this.cnpj;
        }

		public int retornaId()
        {
			return this.Id;
        }

		public void Excluir()
		{

		}

		public void Inativar()
		{

		}

		public void Ativar()
		{

		}

		public void addContato(Contato contato)
		{

		}

		public void validarCNPJ()
		{

		}

		/// Implementação da RN-1005:
		/// 
		/// Registro de fornecimento
		/// 
		/// Apenas é possível concluir o cadastro do fornecedor caso a lista de fornecimentos (produto e/ou serviço) oferecidos esteja preenchida com, no mínimo, um item.
		public void validarListaFornecimento()
		{

		}

		public void validarDistancia()
		{

		}

	}

}

