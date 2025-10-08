using Iventis.Domain.DTO;
using Iventis.Domain.Interfaces.Services;

namespace Iventis.Domain.Services
{
    public class CalculoLocacaoService : ICalculoLocacaoService
    {
        public async Task<RetornoCalculoLocacaoDTO> CalcularLocacao(LocacaoDetalheDTO locacao, DateTime dataInformada)
        {
            RetornoCalculoLocacaoDTO retornoCalculoLocacaoDTO = new RetornoCalculoLocacaoDTO();

            retornoCalculoLocacaoDTO.QuantidadeDiasLocacao = CalcularQuantidadeDiasLocacao(locacao.DtInicio, dataInformada);

            if (dataInformada.Date < locacao.DtPrevisaoTermino.Date)
            {
                retornoCalculoLocacaoDTO.ValorTotalLocacao = CalcularValorComMulta(locacao, dataInformada);
            }
            else if (dataInformada.Date > locacao.DtPrevisaoTermino.Date)
            {
                retornoCalculoLocacaoDTO.ValorTotalLocacao = CalcularValorDiasExcedentes(locacao, dataInformada);
            }
            else
                retornoCalculoLocacaoDTO.ValorTotalLocacao = CalcularValor(locacao.ValoDiaria, retornoCalculoLocacaoDTO.QuantidadeDiasLocacao);

            return retornoCalculoLocacaoDTO;
        }

        private double CalcularValorComMulta(LocacaoDetalheDTO locacao, DateTime dataInformada)
        {
            double valorTotal;

            var diasEfetivados = CalcularQuantidadeDiasLocacao(dataInformada, locacao.DtPrevisaoTermino);
            var diasNaoEfetivados = ((int)locacao.Plano) - diasEfetivados;

            switch (locacao.Plano)
            {
                case Utils.Enums.PlanoLocacao.SeteDias:
                    valorTotal = CalcularValor(locacao.ValoDiaria, diasNaoEfetivados, 0.2);
                    valorTotal += CalcularValor(locacao.ValoDiaria, diasEfetivados);
                    break;
                case Utils.Enums.PlanoLocacao.QuinzeDias:
                    valorTotal = CalcularValor(locacao.ValoDiaria, diasNaoEfetivados, 0.4);
                    valorTotal += CalcularValor(locacao.ValoDiaria, diasEfetivados);
                    break;
                default:
                    valorTotal = CalcularValor(locacao.ValoDiaria, diasEfetivados);
                    break;
            }
            return valorTotal;
        }

        private double CalcularValorDiasExcedentes(LocacaoDetalheDTO locacao, DateTime dataInformada)
        {
            double valorTotal;

            var quantidadeDiasPlano = ((int)locacao.Plano);

            var diasoEfetivados = CalcularQuantidadeDiasLocacao(locacao.DtInicio, dataInformada);
            var diasExcedentes = diasoEfetivados - quantidadeDiasPlano;

            valorTotal = CalcularValor(locacao.ValoDiaria, quantidadeDiasPlano);
            valorTotal += CalcularValor(locacao.ValoDiaria, diasExcedentes, 0.5);

            return valorTotal;
        }

        private double CalcularValor(double valorDiaria, int quantidadeDiasLocacao, double percentualAdicional = 0)
        {
            double valorTotal;

            valorTotal = valorDiaria * quantidadeDiasLocacao;

            if (percentualAdicional > 0)
                valorTotal += (valorTotal * percentualAdicional);

            return valorTotal;
        }

        private int CalcularQuantidadeDiasLocacao(DateTime dataInicio, DateTime dataTermino)
        {
            return (dataTermino - dataInicio).Days;
        }
    }
}
