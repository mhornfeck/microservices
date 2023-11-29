using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepareDb 
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var dbService = serviceScope.ServiceProvider.GetService<AppDbContext>();

            if (dbService != null)
            {
                SeedData(dbService);
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "GMail", Publisher = "Google", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Database has already been seeded.");
            }
        }
    }
}