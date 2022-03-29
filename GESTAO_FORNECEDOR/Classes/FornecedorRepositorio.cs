using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTAO_FORNECEDOR.Interface;

namespace GESTAO_FORNECEDOR.Repositorio
{
    internal class FornecedorRepositorio : IRepositorio<Fornecedor>
    {
        private List<Fornecedor> listaFornecedor = new List<Fornecedor>();
        public void Atualiza(int id, Fornecedor obj)
        {
            listaFornecedor[id] = obj; //Utilizamos a ID para atualizar as informações
        }

        public void Exclui(int id)
        {
            listaFornecedor[id].Excluir(); //Utilizamos o método EXCLUIR para excluir o fornecedor da lista
        }

        public void Insere(Fornecedor obj)
        {
            listaFornecedor.Add(obj); //Adiciona o objeto dentro de nossa lista de fornecedores
        }

        public List<Fornecedor> Lista()
        {
            return listaFornecedor; //Retornamos a lista de fornecedores por completo
        }

        public int ProximoId()
        {
            return listaFornecedor.Count; //Buscamos pelo próximo ID da nossa lista de fornecedor
        }

        public Fornecedor RetornaPorId(int id)
        {
            return listaFornecedor[id]; //Retornamos um fornecedor baseado em seu ID na lista
        }
    }
}
