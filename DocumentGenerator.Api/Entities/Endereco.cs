using Newtonsoft.Json;

namespace DocumentGenerator.Api.Entities
{
    public class Endereco
    {
        [JsonIgnore]
        public int Id { get; }
        [JsonProperty("cep")]
        public string Cep { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("localidade")]
        public string Cidade { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("ddd")]
        public string DDD { get; set; }

        public Endereco()
        {
        }

        public Endereco(string cep, string complemento, string bairro, string cidade, string uf, string ddd)
        {
            Cep = cep;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            DDD = ddd;
        }
    }

    public class EnderecoApi
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string DDD { get; set; }

        public EnderecoApi(Endereco endereco)
        {
            Cep = endereco.Cep;
            Logradouro = endereco.Logradouro;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Cidade = endereco.Cidade;
            Uf = endereco.Uf;
            DDD = endereco.DDD;
        }
    }
}