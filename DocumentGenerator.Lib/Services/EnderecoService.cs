using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using DocumentGenerator.Entities;
using DocumentGenerator.DataContext;
using DocumentGenerator.Interfaces;
using DocumentGenerator.Entities.Enum;

namespace DocumentGenerator.Lib.Services
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

        public async Task<Endereco> GetEnderecoAsync(EstadosBR? estado = null, string cityName = null)
        {
            Random random = new();
            string cep = string.Empty;
            Endereco endereco = null;
            try
            {
                if (estado is null && cityName is not null)
                {
                    throw new ArgumentNullException(nameof(estado), $"Para ser preenchido o parâmetro {nameof(cityName)} o {nameof(estado)} deverá ser selecionado.");
                }
                if (estado is not null && cityName is null)
                {
                    var query = await _context.Enderecos.Where(x => x.Uf.Equals(estado.ToString())).AsNoTracking().ToListAsync();
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
                if (estado is not null && cityName is not null)
                {
                    var cidades = await _context.Enderecos.Where(end => end.Uf.Equals(estado.ToString())).AsNoTracking().ToListAsync();

                    cidades.ForEach(x => x.Cidade = Validations.RemoverAcentuacaoMinuscula(x.Cidade));
                    cityName = Validations.RemoverAcentuacaoMinuscula(cityName);
                    var query = (from end in cidades
                                 where end.Cidade.Equals(cityName)
                                 && end.Uf.Equals(estado.ToString())
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
                if (estado is null && cityName is null)
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

        public IList<string> GetCidades(EstadosBR? estado)
        {
            var query = (from cidade in _context.Enderecos where cidade.Uf.Equals(estado.ToString()) select cidade.Cidade).Distinct();
            query = query.OrderBy(x => x);
            return query.ToList();
        }

        public IList<string> GetEstados()
        {
            var estados = Enum.GetNames<EstadosBR>();
            return estados.ToList();
        }

    }
}