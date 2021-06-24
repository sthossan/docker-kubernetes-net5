using Microsoft.EntityFrameworkCore;


namespace Models.DataContext
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Class>().HasData(
            //    new Class { Id = 1, ClassName = "Class V" });

        }
    }
}
