
using Npgsql;

public class DBConnection {

    private readonly IConfiguration _configuration;

    public DBConnection (
        IConfiguration configuration
        ) {
        _configuration = configuration;
    }

    public NpgsqlConnection ConnectWithDataBase() {
        string env = _configuration.GetSection("Environment").Value!;
        string ConnectionString = _configuration.GetSection($"ConnectionStrings:ConnectionString_{env}").Value!;

        try {
            NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
            connection.Open();

            return connection;
        } catch {
            string message = "Erro com a conexão do banco de dados.";
            throw new Exception( message );
        }
    }
}
