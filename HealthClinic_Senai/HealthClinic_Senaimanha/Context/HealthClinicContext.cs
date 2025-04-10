using HealthClinic_Senaimanha.Domains;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_Senaimanha.Context
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<Clinica> Clinica {  get; set; }
        
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Comentario> Comentario { get; set; }

        public DbSet<Especialidade> Especialidade { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Paciente> Paciente { get; set;}

        public DbSet<TipoDeUsuario> TipoDeUsuario { get;set; }

        public DbSet<Consulta> Consulta { get; set; }

        //Define as opcoes de construcao do Banco(string conexao)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE02-S15; DataBase= health_clinic_manha; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
