namespace NTH.Windows.Forms
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Credentials()
            : this(null)
        { }
        public Credentials(string username)
            : this(username, null)
        { }
        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
