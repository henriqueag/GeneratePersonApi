using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using DocumentGenerator.Api.Entities;
using DocumentGenerator.Api.DataContext;
using DocumentGenerator.Api.Interfaces;

namespace DocumentGenerator.Api.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly AppDataContext _context;
        private readonly ILogRegisterService _gravadorDeLogs;

        public EnderecoService(AppDataContext context, ILogRegisterService gravadorDeLogs)
        {
            _context = context;
            _gravadorDeLogs = gravadorDeLogs;
        }

        public async Task<Endereco> GetEnderecoAsync(string estadoBR_sigla = null, string cityName = null)
        {
            Random random = new();
            string cep = string.Empty;
            Endereco endereco = null;
            try
            {
                if (estadoBR_sigla is null && cityName is not null)
                {
                    throw new ArgumentNullException(nameof(estadoBR_sigla), $"Para ser preenchido o parâmetro {nameof(cityName)} o {nameof(estadoBR_sigla)} deverá ser selecionado.");
                }
                if (estadoBR_sigla is not null && cityName is null)
                {
                    var query = await _context.Enderecos.Where(x => x.Uf.Equals(estadoBR_sigla.ToString())).AsNoTracking().ToListAsync();
                    if (query.Count == 0)
                    {
                        return null;
                    }
                    while (true)
                    {
                        try
                        {
                            cep = query[random.Next(0, query.Count)].Cep;
                            endereco = await GetEnderecoByCepAsync(cep);
                            if (endereco.Logradouro == string.Empty || endereco.Bairro == string.Empty || endereco.Cidade == string.Empty || endereco.DDD == string.Empty)
                            {
                                continue;
                            }
                            if (endereco != null)
                            {
                                break;
                            }
                        }
                        catch (JsonReaderException)
                        {
                            continue;
                        }
                    }
                }
                if (estadoBR_sigla is not null && cityName is not null)
                {
                    var cidades = await _context.Enderecos.Where(end => end.Uf.Equals(estadoBR_sigla.ToString())).AsNoTracking().ToListAsync();

                    cidades.ForEach(x => x.Cidade = Validations.RemoverAcentuacaoMinuscula(x.Cidade));
                    cityName = Validations.RemoverAcentuacaoMinuscula(cityName);
                    var query = (from end in cidades
                                 where end.Cidade.Equals(cityName)
                                 && end.Uf.Equals(estadoBR_sigla.ToString())
                                 select end).ToList();

                    if (query.Count == 0)
                    {
                        return null;
                    }
                    while (true)
                    {
                        try
                        {
                            cep = query[random.Next(0, query.Count)].Cep;
                            endereco = await GetEnderecoByCepAsync(cep);
                            if (endereco.Logradouro == string.Empty || endereco.Bairro == string.Empty || endereco.Cidade == string.Empty || endereco.DDD == string.Empty)
                            {
                                continue;
                            }
                            if (endereco != null)
                            {
                                break;
                            }
                        }
                        catch (JsonReaderException)
                        {
                            continue;
                        }
                    }
                }
                if (estadoBR_sigla is null && cityName is null)
                {
                    var query = await _context.Enderecos.ToListAsync();
                    while (true)
                    {
                        try
                        {
                            cep = query[random.Next(0, query.Count)].Cep;
                            endereco = await GetEnderecoByCepAsync(cep);
                            if (endereco.Logradouro == string.Empty || endereco.Bairro == string.Empty || endereco.Cidade == string.Empty || endereco.DDD == string.Empty)
                            {
                                continue;
                            }
                            if (endereco != null)
                            {
                                break;
                            }
                        }
                        catch (JsonReaderException)
                        {
                            continue;
                        }
                    }
                }
                return endereco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<Endereco> GetEnderecoByCepAsync(string cep)
        {
            Endereco endereco;
            try
            {
                using HttpClient httpClient = new();
                var response = httpClient.GetAsync($"http://viacep.com.br/ws/{cep}/json/").Result;
                while (true)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    endereco = JsonConvert.DeserializeObject<Endereco>(json);
                    if (endereco.Cep != null)
                    {
                        return endereco;
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                _gravadorDeLogs.GravaLog(ex.ToString(), "erroInvalid.txt");
                throw;
            }
            catch (HttpRequestException ex)
            {
                _gravadorDeLogs.GravaLog(ex.ToString(), "erroHttp.txt");
                throw;
            }
            catch (Exception ex)
            {
                _gravadorDeLogs.GravaLog(ex.ToString(), "erroGeral.txt");
                throw;
            }
        }

        public IList<string> GetCidades(string estadoBR_sigla)
        {
            var query = (from cidade in _context.Enderecos
                         where cidade.Uf.Equals(estadoBR_sigla) 
                         select cidade.Cidade).Distinct();
            query = query.OrderBy(x => x);
            return query.ToList();
        }

        public IList<EstadosBR> GetEstados()
        {
            return EstadosBR.GetEstadosBR();
        }

    }
}