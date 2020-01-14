using CRUD_sem_banco_de_dados.Models;
using CRUD_sem_banco_de_dados.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_sem_banco_de_dados.Repositories {
    public class PessoaRepository : IPessoaRepository {

        private readonly List<Pessoa> _pessoas;

        public PessoaRepository(List<Pessoa> pessoas) {
            _pessoas = pessoas;
        }

        public Pessoa Buscar(int id) {
            return _pessoas.FirstOrDefault(p => p.Id == id);
        }

        public void Cadastrar(Pessoa pessoa) {
            pessoa = GerarIdDaPessoa(pessoa);
            _pessoas.Add(pessoa);
        }

        private Pessoa GerarIdDaPessoa(Pessoa pessoa) {
            var id = 0;

            if (_pessoas.Count != 0) {
                id = _pessoas.LastOrDefault().Id + 1;
            }
            pessoa.Id = id;

            return pessoa;
        }

        public void Editar(Pessoa pessoa) {
            var pessoaLista = Buscar(pessoa.Id);
            pessoaLista.Nome = pessoa.Nome;
            pessoaLista.Sobrenome = pessoa.Sobrenome;
            pessoaLista.Telefone = pessoa.Telefone;
            pessoaLista.Email = pessoa.Email;
        }

        public void Excluir(int id) {
            var pessoaLista = Buscar(id);
            _pessoas.Remove(pessoaLista);
        }

        public List<Pessoa> Listar() {
            return _pessoas;
        }
    }
}
