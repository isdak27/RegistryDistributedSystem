using InscriptionsWebAPI.Models;

namespace InscriptionWebAPI.Models
{
    
        public interface IInscriptionRepository
        {
            Inscription GetInscriptionById(int code);
            Inscription CreateInscription(int studentCode, int subjectCode, string status);
            Inscription UpdateInscription(int studentCode, int subjectCode, string status);
        }

}
