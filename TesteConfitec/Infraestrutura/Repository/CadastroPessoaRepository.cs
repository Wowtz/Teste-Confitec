using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CadastroPessoaRepository : GenericRepository<CadastroPessoa>, ICadastroPessoa
    {
        private readonly DbContextOptions<CadastroContext> _optionsBuilder;

        public CadastroPessoaRepository()
        {
            _optionsBuilder = new DbContextOptions<CadastroContext>();
        }

        public async Task<List<CadastroPessoa>> ListPessoas(Expression<Func<CadastroPessoa, bool>> exCadastroPessoa)
        {
            using(var db = new CadastroContext(_optionsBuilder))
            {
                return await db.CadastroPessoa.Where(exCadastroPessoa).AsNoTracking().ToListAsync();
            }
        }



        public async Task<bool> ValidateEmail(string email)
        {
            try
            {
                using (var db = new CadastroContext(_optionsBuilder))
                {
                    return await db.CadastroPessoa.
                         Where(x => x.Email.Equals(email))
                         .AsNoTracking()
                         .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
