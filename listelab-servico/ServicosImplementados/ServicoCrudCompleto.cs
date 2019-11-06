﻿using ListElab.Data.Repositorios;
using ListElab.Dominio.Abstrato;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.InterfaceDeServico;
using ListElab.Servico.Conversores.Interfaces;
using ListElab.Servico.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListElab.Servico.ServicosImplementados
{
    public abstract class ServicoCrudCompleto<TObjeto, TDto> : IServicoCrudCompleto<TObjeto, TDto> where TObjeto : ObjetoComId
    {
        /// <summary>
        /// Representa uma lista de erros.
        /// </summary>
        public List<DtoResultado<TDto>> Erros { get; set; }

        /// <summary>
        /// Atualiza um objeto genérico no banco.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        public TDto Atualize(TDto dto)
        {
            var objeto = Conversor().Converta(dto);

            Validador().AssineRegrasAtualizacao();

            var resultado = Validador().Valide(objeto);

            if (resultado.IsValid)
            {
                Repositorio().Atualize(x => x.Id == objeto.Id, objeto);

                var dtoAtualizado = Conversor().Converta(objeto);
                return dtoAtualizado;
            }
            else
            {
                Erros = resultado.Errors.Select(x => new DtoResultado<TDto> { Campo = x.PropertyName, Mensagem = x.ErrorMessage, Resultado = null, Sucesso = false }).ToList();

                throw new Exception("Ocorreu algum erro durante a validação.");
            }


        }

        /// <summary>
        /// Cadastra um objeto de tipo genérico.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        public virtual TDto Cadastre(TDto dto)
        {
            var objeto = Conversor().Converta(dto);

            Validador().AssineRegrasCadastro();

            var resultado = Validador().Valide(objeto);

            if (resultado.IsValid)
            {
                Repositorio().Cadastre(objeto);

                return Conversor().Converta(objeto);
            }
            else
            {
                Erros = resultado.Errors.Select(x => new DtoResultado<TDto> { Campo = x.PropertyName, Mensagem = x.ErrorMessage, Resultado = null, Sucesso = false }).ToList();

                throw new Exception("Ocorreu algum erro durante a validação.");
            }
        }

        /// <summary>
        /// Consulta um conceito por id.
        /// </summary>
        /// <param name="id">O id a ser pesquisado.</param>
        /// <returns>Retorna o conceito que possui aquele id.</returns>
        public TDto Consulte(string id)
        {
            TObjeto resultado = null;

            try
            {
                if (Guid.TryParse(id, out Guid idConvertido))
                {
                    resultado = Repositorio().ConsulteUm(x => x.Id == idConvertido);
                }
            }
            catch (Exception)
            {
                throw new Exception("Id passado não é valido ou não está cadastrado.");
            }

            return Conversor().Converta(resultado);
        }

        /// <summary>
        /// Consulta todos os objetos que obedecem uma condição.
        /// </summary>
        /// <returns>Retorna uma coleção de objetos genéricos.</returns>
        public virtual IList<TDto> ConsulteLista()
        {
            return Repositorio().ConsulteLista(x => true).Select(x => Conversor().Converta(x)).ToList();
        }

        /// <summary>
        /// Exclua todos os objetos que atendem determinada condição.
        /// </summary>
        /// <param name="id">O id que será usado como filtro.</param>
        public virtual void Exclua(string id)
        {
            Guid idConvertido = Guid.Empty;

            if (Guid.TryParse(id, out idConvertido))
            {
                Validador().AssineRegrasExclusao();

                var objeto = (TObjeto)Activator.CreateInstance(typeof(TObjeto));

                objeto.Id = idConvertido;

                var resultado = Validador().Valide(objeto);

                if (resultado.IsValid)
                {
                    Repositorio().Exclua(x => x.Id == idConvertido);
                }
                else
                {
                    Erros = resultado.Errors.Select(x => new DtoResultado<TDto> { Campo = x.PropertyName, Mensagem = x.ErrorMessage, Resultado = null, Sucesso = false }).ToList();

                    throw new Exception("Ocorreu algum erro durante a validação.");
                }

            }
            else
            {
                throw new Exception("Id inválido.");
            }
        }

        protected abstract IRepositorio<TObjeto> Repositorio();

        protected abstract ValidadorPadrao<TObjeto> Validador();

        protected abstract IConversor<TDto, TObjeto> Conversor();
    }
}