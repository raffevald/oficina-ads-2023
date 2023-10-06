

public interface IEnderecoService {
    Task<Enderecos> CadastrarEnderecoAsync( Enderecos request );
    Task<List<Enderecos>> GetAllEnderecosAsync();
    Task<Enderecos> GetEnderecoByIdAsync( int IdEndereco );
    Task<Enderecos> UpdateEnderecoByIdAsync( Enderecos request );
    Task<Boolean> DeleteEnderecoByIdAsync( int? idEndereco );
}