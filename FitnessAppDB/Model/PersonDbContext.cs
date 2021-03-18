using Microsoft.EntityFrameworkCore;

namespace FitnessAppDB.Model
{
    public class PersonDbContext : DbContext
    {
        private DbSet<MemberInfo> memberInfos;
        private DbSet<Member> members;

        public DbSet<MemberInfo> MemberInfos
        {
            get { return memberInfos; }
            set { memberInfos = value; }
        }
        public DbSet<Member> Members
        {
            get { return members; }
            set { members = value; }
        }

        public PersonDbContext()
        {
            // guarantee that the database will automatically be created 
            Database.EnsureCreated();
        }
        /// <summary>
        /// Конфигуриране на контекста
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (
                "Server=(localdb)\\ProjectsV13;" +
                "Database=Members;" +
                "Integrated Security=true"
                );
        }

    }
}
