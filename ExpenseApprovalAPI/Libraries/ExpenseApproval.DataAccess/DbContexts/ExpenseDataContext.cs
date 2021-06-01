using ExpenseApproval.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApproval.DataAccess.DbContexts
{
    public class ExpenseDataContext : DbContext
    {
        public ExpenseDataContext(DbContextOptions<ExpenseDataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserExpense> UserExpenses { get; set; }
        public DbSet<UserBudget> UserBudget { get; set; }
        public DbSet<Logger> Logger { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBudget>().HasNoKey();
        }
    }
}
