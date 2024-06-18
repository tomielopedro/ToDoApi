namespace Aposta.Models
{
    public class ApostaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string NumerosAposta { get; set; }

        public DateTime DataAposta { get; set; }
    }
}