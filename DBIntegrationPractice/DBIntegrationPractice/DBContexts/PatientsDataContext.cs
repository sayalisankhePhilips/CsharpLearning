using DBIntegrationPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBIntegrationPractice.DBContexts
{
    public class PatientsDataContext : DbContext
    {
        public PatientsDataContext(DbContextOptions<PatientsDataContext> opts) : base(opts)
        {

        }

        public DbSet<PatientsModel> Patients => Set<PatientsModel>();


    }
}
