using CRUD_sem_banco_de_dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_sem_banco_de_dados.Repositories.Interfaces {
    public interface IPessoaRepository {

        void Cadastrar(Pessoa pessoa);
        void Editar(Pessoa pessoa);
        void Excluir(int id);
        Pessoa Buscar(int id);
        List<Pessoa> Listar();

    }
}
