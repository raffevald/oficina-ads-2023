
using Npgsql;

public class EnderecoRepositoryImpl : IEnderecoRepository {

    private readonly DBConnection _dbConnection;

    public EnderecoRepositoryImpl (
        DBConnection dBConnection
        ) {
            _dbConnection = dBConnection;
    }

    public async Task<Enderecos> GetUltimoEnderecoCadastrado() {
        NpgsqlConnection? connection = _dbConnection.ConnectWithDataBase();
        Enderecos endereco = new( null, null, null, null, null, null, null, null, null, null);

        string dataBaseTable = "enderecos";
        string idTable = "id_endereco";

        try {
            string selectQuery = $"select * from { dataBaseTable } where { idTable } = ( select MAX({ idTable }) from { dataBaseTable })";

            NpgsqlCommand command = new(selectQuery, connection);
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            while ( await reader.ReadAsync() ) {
                int? id_endereco = reader["id_endereco"] as int?;
                string? cep = reader["cep"] as string;
                string? pais = reader["pais"] as string;
                string? estado = reader["estado"] as string;
                string? cidade = reader["cidade"] as string;
                string? bairro = reader["bairro"] as string;
                string? rua = reader["rua"] as string;
                string? numero = reader["numero"] as string;
                string? referencias = reader["referencias"] as string;
                string? complementos = reader["complementos"] as string;

                endereco = new( id_endereco, cep, pais, estado, cidade, bairro, rua, numero, referencias, complementos );
            }

        } catch {
            connection.Close();
            string message = "";
            throw new Exception( message );
        }
        connection.Close();

        return endereco;
    }

    public async Task<Enderecos> CadastrarEnderecoAsync( Enderecos request ) {
        NpgsqlConnection? connection = _dbConnection.ConnectWithDataBase();

        try {
            string insertQuery = QueryCadastrarEnderecoAsync( request );

            NpgsqlCommand command = new(insertQuery, connection);
            await command.ExecuteNonQueryAsync();

        } catch {
            connection.Close();
            string message = "";
            throw new Exception( message );
        }
        connection.Close();

        return await GetUltimoEnderecoCadastrado();
    }

    public async Task<List<Enderecos>> GetAllEnderecosAsync() {
        NpgsqlConnection? connection = _dbConnection.ConnectWithDataBase();
        
        List<Enderecos> enderecos = new();

        try {
            string selectQuery = "select * from enderecos e ";

            NpgsqlCommand command = new(selectQuery, connection);
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int? id_endereco = reader["id_endereco"] as int?;
                string? cep = reader["cep"] as string;
                string? pais = reader["pais"] as string;
                string? estado = reader["estado"] as string;
                string? cidade = reader["cidade"] as string;
                string? bairro = reader["bairro"] as string;
                string? rua = reader["rua"] as string;
                string? numero = reader["numero"] as string;
                string? referencias = reader["referencias"] as string;
                string? complementos = reader["complementos"] as string;

                Enderecos endereco = new(id_endereco, cep, pais, estado, cidade, bairro, rua, numero, referencias, complementos);
                enderecos.Add(endereco);
            }

        } catch {
            connection.Close();
            string message = "";
            throw new Exception( message );
        }
        connection.Close();

        return enderecos;
    }

    public async Task<Enderecos> GetEnderecoByIdAsync( int? IdEndereco ) {
        NpgsqlConnection? connection = _dbConnection.ConnectWithDataBase();
        
        Enderecos endereco = new( null, null, null, null, null, null, null, null, null, null);

        try {
            string selectQuery = $"select * from enderecos e where id_endereco = {IdEndereco}";

            NpgsqlCommand command = new(selectQuery, connection);
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int? id_endereco = reader["id_endereco"] as int?;
                string? cep = reader["cep"] as string;
                string? pais = reader["pais"] as string;
                string? estado = reader["estado"] as string;
                string? cidade = reader["cidade"] as string;
                string? bairro = reader["bairro"] as string;
                string? rua = reader["rua"] as string;
                string? numero = reader["numero"] as string;
                string? referencias = reader["referencias"] as string;
                string? complementos = reader["complementos"] as string;

                endereco = new(id_endereco, cep, pais, estado, cidade, bairro, rua, numero, referencias, complementos);
            }

        } catch {
            connection.Close();
            string message = "";
            throw new Exception( message );
        }
        connection.Close();

        return endereco;
    }

    public async Task<Enderecos> UpdateEnderecoByIdAsync( Enderecos request ) {
        NpgsqlConnection? connection = _dbConnection.ConnectWithDataBase();

        try {
            string updateQuery = QueryUpdateEnderecoByIdAsync( request );

            NpgsqlCommand command = new(updateQuery, connection);
            await command.ExecuteNonQueryAsync();

        } catch {
            connection.Close();
            string message = "";
            throw new Exception( message );
        }
        connection.Close();

        return await GetEnderecoByIdAsync( request.id_endereco );
    }

    public async Task<Boolean> DeleteEnderecoByIdAsync( int? idEndereco ) {
        NpgsqlConnection? connection = _dbConnection.ConnectWithDataBase();

        try {
            string deleteQuery = $"DELETE FROM public.enderecos " +
                $"WHERE id_endereco = { idEndereco };";

            NpgsqlCommand command = new(deleteQuery, connection);
            await command.ExecuteNonQueryAsync();

        } catch {
            connection.Close();
            // string message = "";
            // throw new Exception( message );
            return false;
        }
        connection.Close();

        return true;
    }


    private string QueryCadastrarEnderecoAsync( Enderecos request ) {
        string insertQuery = "INSERT INTO public.enderecos " +
            "(cep, pais, estado, cidade, bairro, rua, numero, referencias, complementos) " +
            $"VALUES('{ request.cep }', '{ request.pais }', '{ request.estado }', '{ request.cidade }', '{ request.bairro }',  " +
            $"'{ request.rua }', '{ request.numero }', '{ request.referencias }', '{ request.complementos }');";

        return insertQuery;
    }

    private string QueryUpdateEnderecoByIdAsync( Enderecos request ) {
        string updateQuery = "UPDATE public.enderecos " +
            $"SET cep='{ request.cep }', pais='{ request.pais }', estado='{ request.estado }', cidade='{ request.cidade }', bairro='{ request.bairro }', rua='{ request.rua }', numero='{ request.numero }', referencias='{ request.referencias }', complementos='{ request.complementos }' " +
            $"WHERE id_endereco = { request.id_endereco };";


        return updateQuery;
    }
}
