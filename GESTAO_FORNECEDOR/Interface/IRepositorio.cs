﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTAO_FORNECEDOR.Interface
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T obj);
        void Exclui(int id);
        void Atualiza(int id, T obj);
        int ProximoId();
    }
}
