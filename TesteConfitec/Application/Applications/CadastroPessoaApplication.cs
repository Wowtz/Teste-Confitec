using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Entities.Entities;

namespace Application.Applications
{
    public class CadastroPessoaApplication : ICadastroPessoaApplication
    {
        ICadastroPessoa _ICadastroPessoa;

        public CadastroPessoaApplication(ICadastroPessoa cadastroPessoa)
        {
            _ICadastroPessoa = cadastroPessoa;
        }

        public async Task Add(CadastroPessoa cadastro)
        {
            await _ICadastroPessoa.Add(cadastro);
        }

        public async Task Delete(CadastroPessoa cadastro)
        {
            await _ICadastroPessoa.Delete(cadastro);
        }

        public async Task<CadastroPessoa> FindById(int id)
        {
            return await _ICadastroPessoa.FindById(id);
        }

        public async Task<List<CadastroPessoa>> List()
        {
            return await _ICadastroPessoa.List();
        }

        public async Task Update(CadastroPessoa cadastro)
        {
            await _ICadastroPessoa.Update(cadastro);
        }

        public async Task<bool> ValidateEmail(string email)
        {
            return await _ICadastroPessoa.ValidateEmail(email);
        }
    }
}
