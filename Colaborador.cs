public class Colaborador{
    public string? Nome {get; set;}
    public string? Email {get; set;}
    public string? Cargo {get; set;}
    public string? Telefone {get; set;}
    public int Id { get; protected set; }

    public Colaborador(){

    }

    public Colaborador(string nome, string email, string cargo, string telefone)
    {
        Nome = nome;
        Email = email;
        Cargo = cargo;
        Telefone = telefone;
    }

    public Colaborador (int Id, string nome, string email, string cargo, string telefone) : this(nome, email, cargo, telefone){

    }
}   