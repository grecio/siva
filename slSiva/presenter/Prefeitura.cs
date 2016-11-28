namespace Dominio
{
    public class Prefeitura :EntidadeBase
    {
        public string Nome { get; set; }
        public string Prefeito { get; set; }
        public string SecretarioTributacao { get; set; }
        public string Contador { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Contato { get; set; }
        public decimal NumeroHabitantes { get; set; }
        public decimal Territorio { get; set; }

    }
}
