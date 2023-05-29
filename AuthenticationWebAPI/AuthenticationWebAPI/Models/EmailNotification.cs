namespace AuthenticationWebAPI.Models
{
    public class EmailNotification
    {

        public string senderEmail  { get; set; }
        public string subject { get; set; }
        public string body  { get; set; }
        public string from  { get; set; }
        public string to  { get; set; }
        public User userInfo { get; set; }
        public bool isSent { get; set; }

        public EmailNotification(string senderEmail, string subject, string body, User user, bool isSent)
        {

            this.senderEmail = senderEmail;
            this.subject = subject;
            this.body = body;
            this.userInfo = user;
            this.isSent = isSent;
        }

}
}
