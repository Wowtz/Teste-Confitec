using Application.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICadastroPessoaApplication : IGenericsApplication<CadastroPessoa>
    {
        Task<bool> ValidateEmail(string email);
    }
}
