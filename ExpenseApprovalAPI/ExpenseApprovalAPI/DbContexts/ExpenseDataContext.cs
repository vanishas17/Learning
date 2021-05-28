using ExpenseApproval.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApproval.API.DbContexts
{
    public class ExpenseDataContext : DbContext
    {
        public ExpenseDataContext(DbContextOptions<ExpenseDataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserExpense> UserExpenses { get; set; }
        public DbSet<UserBudget> UserBudget { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBudget>().HasNoKey();
        }
    }
}
