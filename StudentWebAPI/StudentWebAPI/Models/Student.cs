namespace StudentWebAPI.Models
{
    public class Student
    {
        public int code { get; set; }
        public string name { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public string documentType { get; set; } = null!;
        public string documentNumber { get; set; } = null!;
        public string status { get; set; } = null!;
        public string gender { get; set; } = null!;
        public string imageRef { get; set; } = null!;

        public Student(string name, string lastName, string documentType, string documentNumber, string status, string gender, string imageRef)
        {
            this.name = name;
            this.lastName = lastName;
            this.documentType = documentType;
            this.documentNumber = documentNumber;
            this.status = status;
            this.gender = gender;
            this.imageRef = imageRef;
        }

        public Student()
        {
        }
    }
}
