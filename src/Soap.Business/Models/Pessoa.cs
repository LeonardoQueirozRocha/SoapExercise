namespace Soap.Business.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ssn { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public Cidade Casa { get; set; }
        public Cidade Escritorio { get; set; }
        public IEnumerable<string> CoresFavoritas { get; set; }
    }
}
