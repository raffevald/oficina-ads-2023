
public class EnderecoServiceImpl : IEnderecoService {

    private readonly IEnderecoRepository _enderecoRepository;

    public EnderecoServiceImpl (
            IEnderecoRepository enderecoRepository
        ) {
            _enderecoRepository = enderecoRepository;
    }

    public async Task<Enderecos> CadastrarEnderecoAsync(Enderecos request) {
        return await _enderecoRepository.CadastrarEnderecoAsync( request );
    }

    public async Task<List<Enderecos>> GetAllEnderecosAsync() {
        return await _enderecoRepository.GetAllEnderecosAsync();
    }

    public async Task<Enderecos> GetEnderecoByIdAsync( int IdEndereco ) {
        return await _enderecoRepository.GetEnderecoByIdAsync( IdEndereco );
    }

    public async Task<Enderecos> UpdateEnderecoByIdAsync( Enderecos request ) {
        return await _enderecoRepository.UpdateEnderecoByIdAsync( request );
    }

    public async Task<Boolean> DeleteEnderecoByIdAsync( int? idEndereco ) {
        return await _enderecoRepository.DeleteEnderecoByIdAsync( idEndereco );
    }
}