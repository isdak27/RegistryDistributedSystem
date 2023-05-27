namespace AuthenticationWebAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool status { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public User(string name, string email, bool status, int credentialAsociate, string userName, string password)
        {
            this.name = name;
            this.email = email;
            this.status = status;
            this.userName = userName;
            this.password = password;
        }


        public User() { }


    }
}
