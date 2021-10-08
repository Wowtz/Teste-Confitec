using Application.Interfaces;
using CadastroDePessoa.Model;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace CadastroDePessoa.Controllers
{
    [Route("api/v1/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class CadastroPessoaController : ControllerBase
    {
        private readonly ICadastroPessoaApplication _ICadastroPessoaApplication;

        public CadastroPessoaController(ICadastroPessoaApplication cadastroPessoaApplication)
        {
            _ICadastroPessoaApplication = cadastroPessoaApplication;
        }


        [HttpGet("listar")]
        public async Task<IActionResult> ListarCadastros()
        {
            var list = await _ICadastroPessoaApplication.List();
            List<CadastroPessoa> result;
            result = list;
            return  Ok(result);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> AdicionarCadastro(CadastroPessoaModel cadastroPessoa)
        {
            try
            {
                var validador = await _ICadastroPessoaApplication.ValidateEmail(cadastroPessoa.Email);

                if (validador) { return Ok("Email Ja Cadastrado"); }

                var cadastro = new CadastroPessoa();
                if (cadastroPessoa != null)
                {
                    cadastro.Nome = cadastroPessoa.Nome;
                    cadastro.Sobrenome = cadastroPessoa.Sobrenome;
                    cadastro.Email = cadastroPessoa.Email;
                    cadastro.DataNascimento = cadastroPessoa.DataNascimento;
                    cadastro.Escolaridade = cadastroPessoa.Escolaridade;
                }

                
                await _ICadastroPessoaApplication.Add(cadastro);

                return Ok(cadastro);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarCadastro(CadastroPessoaModel cadastroPessoa)
        {
            try
            {
                var cadastro = await _ICadastroPessoaApplication.FindById(cadastroPessoa.Id);
                if (cadastroPessoa != null)
                {
                    cadastro.Id = cadastroPessoa.Id;
                    cadastro.Nome = cadastroPessoa.Nome;
                    cadastro.Sobrenome = cadastroPessoa.Sobrenome;
                    cadastro.Email = cadastroPessoa.Email;
                    cadastro.DataNascimento = cadastroPessoa.DataNascimento;
                    cadastro.Escolaridade = cadastroPessoa.Escolaridade;
                }

                await _ICadastroPessoaApplication.Update(cadastro);

                return Ok(cadastro);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpDelete("excluir")]
        public async Task<IActionResult> ExcluirCadastro(int id)
        {
            try
            {
                var cadastro = await _ICadastroPessoaApplication.FindById(id);

                await _ICadastroPessoaApplication.Delete(cadastro);

                return Ok(true);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet("buscarPorId")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var cadastro = await _ICadastroPessoaApplication.FindById(id);

                return Ok(cadastro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
