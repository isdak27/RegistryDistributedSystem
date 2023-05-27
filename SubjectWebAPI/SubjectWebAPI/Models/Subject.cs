namespace SubjectWebAPI.Models
{
    public class Subject
    {
        public int code { get; set; } 
        public string name { get; set; } = null!;
        public int group { get; set; }
        public int quotas { get; set; }
        public string actualStatus { get; set; } = null!;

        public Subject(string name, int group, int quotas, string actualStatus)
        {
            this.name = name;
            this.group = group;
            this.quotas = quotas;
            this.actualStatus = actualStatus;
        }

        public Subject() {
            
        }
    }


}
