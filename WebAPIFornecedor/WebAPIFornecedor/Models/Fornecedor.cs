namespace WebAPIFornecedor.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? CNPJ { get; set; }
        public string? IE { get; set; }
    }
}
