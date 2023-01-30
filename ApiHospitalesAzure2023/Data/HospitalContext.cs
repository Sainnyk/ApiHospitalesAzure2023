using ApiHospitalesAzure2023.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiHospitalesAzure2023.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        public DbSet<Hospital> Hospitales { get; set; }
    }
}
