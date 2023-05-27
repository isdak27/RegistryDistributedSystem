using Microsoft.EntityFrameworkCore;
using InscriptionsWebAPI.Models;

namespace InscriptionWebAPI.Models
{
    public class DbInscriptionRepository : IInscriptionRepository
    {
        private readonly InscriptionDbContext _dbContext;

        public DbInscriptionRepository(InscriptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Inscription GetInscriptionById(int code)
        {
            return _dbContext.Inscriptions.FirstOrDefault(s => s.code == code);
        }

        public Inscription CreateInscription(int studentCode, int subjectCode, string status)
        {
            Inscription inscription = new Inscription(studentCode, subjectCode, status);
            _dbContext.Inscriptions.Add(inscription);
            _dbContext.SaveChanges();
            return inscription;
        }

        public Inscription UpdateInscription(int studentCode, int subjectCode, string status)
        {
            Inscription inscription = new Inscription(studentCode, subjectCode, status);
            _dbContext.Entry(inscription).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return inscription;
        }
    }

}
