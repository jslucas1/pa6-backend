namespace api
{
    public class ConnectionString
    {
        public string cs { get; set; }

        public ConnectionString()
        {
            string server = "lfmerukkeiac5y5w.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "h53wx3ev49x13g2p";
            string port = "3306";
            string userName = "v5ksvrjqmn7vkof3";
            string password = "a5358oifn8g8zo52";

            cs = $@"server = {server};user={userName};database={database};port={port};password={password};";
        }
    }
}