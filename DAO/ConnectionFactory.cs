using MySql.Data.MySqlClient;



namespace UnivalGeovanni.DAO
{
    public class ConnectionFactory
    {
            public static MySqlConnection Build()
            {
                var connectionString = "Server=localhost;Database=Unival;Uid=root;Pwd=30122006";
                return new MySqlConnection(connectionString);
            }
    }
}
