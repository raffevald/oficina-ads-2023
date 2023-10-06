

public class Enderecos {
    public int? id_endereco { get; set; }
    public string? cep { get; set; }
    public string? pais { get; set; }
    public string? estado { get; set; }
    public string? cidade { get; set; }
    public string? bairro { get; set; }
    public string? rua { get; set; }
    public string? numero { get; set; }
    public string? referencias { get; set; }
    public string? complementos { get; set; }


    public Enderecos (
        int? id_endereco,
        string? cep,
        string? pais,
        string? estado,
        string? cidade,
        string? bairro,
        string? rua,
        string? numero,
        string? referencias,
        string? complementos
    ) {
        this.id_endereco = id_endereco;
        this.cep = cep;
        this.pais = pais;
        this.estado = estado;
        this.cidade = cidade;
        this.bairro = bairro;
        this.rua = rua;
        this.numero = numero;
        this.referencias = referencias;
        this.complementos = complementos;
    }
}
