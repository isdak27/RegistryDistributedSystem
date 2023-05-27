namespace InscriptionsWebAPI.Models
{
    public class Inscription
    {
        public int code { get; set; }

        public int StudentCode { get; set; }

        public int SubjectCode { get; set; }

        public DateTime InscriptionDate { get; set; }

        public string Status { get; set; } = null!;

        public Inscription(int studentCode,int subjectCode, string status) {
            StudentCode = studentCode;
            SubjectCode = subjectCode;
            Status = status;
        }

        public Inscription(int studentCode, int subjectCode, string status, DateTime date)
        {
            StudentCode = studentCode;
            SubjectCode = subjectCode;
            Status = status;
            InscriptionDate = date;
        }

        public Inscription() { }

    }


}
