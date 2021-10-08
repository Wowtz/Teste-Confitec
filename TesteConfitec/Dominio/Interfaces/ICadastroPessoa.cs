using Domain.Interfaces.Generics;
using Entities.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using System;


namespace Domain.Interfaces
{
    public interface ICadastroPessoa : IGenerics<CadastroPessoa>
    {
        Task<List<CadastroPessoa>> ListPessoas(Expression<Func<CadastroPessoa, bool>> exCadastroPessoa);
        Task<bool> ValidateEmail(string email);
    }
}
