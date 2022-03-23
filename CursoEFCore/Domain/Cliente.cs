namespace CursoEFCore.Domain
{
    public class Cliente
    {
        public Cliente(string nome, string telefone, string cep, string estado, string cidade, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Cep = cep;
            Estado = estado;
            Cidade = cidade;
            Email = email;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
    }
}
