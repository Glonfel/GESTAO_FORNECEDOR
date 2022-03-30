


using GESTAO_FORNECEDOR;

string opcaoUsuario = ObterOpcaoUsuario();

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

        default:
            throw new ArgumentOutOfRangeException();
    }
    opcaoUsuario = ObterOpcaoUsuario();
}


static string ObterOpcaoUsuario()
{
    Console.WriteLine();
    Console.WriteLine("=====Fornecedor LITE VERSION 0.01a=====");
    Console.WriteLine("Informe a opção desejada:");

    Console.WriteLine("1- Cadastrar Fornecedor");
    Console.WriteLine("2- Listar Fornecedores");
    Console.WriteLine("3- Consultar Fornecedor");
    Console.WriteLine("X- Sair");
    Console.WriteLine();

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
}
