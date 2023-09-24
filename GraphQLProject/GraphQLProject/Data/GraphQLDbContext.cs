using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
              new Category { Id = 1, Name = "Appetizers", ImageUrl = "appetizers.png" },
              new Category { Id = 2, Name = "Main Course", ImageUrl = "maincourse.png" },
              new Category { Id = 3, Name = "Desserts", ImageUrl = "dessert.png" },
              new Category { Id = 4, Name = "Drinks", ImageUrl = "drinks.png" }
           );

            modelBuilder.Entity<Menu>().HasData(
            new Menu { Id = 1, Name = "Chicken Wings", Description = "Spicy chicken wings served with blue cheese dip.", Price = 9.99, ImageUrl = "chickenwings.jpeg", CategoryId = 1 },
            new Menu { Id = 2, Name = "Salmon", Description = "Grilled salmon fillet with a lemon dill sauce, accompanied by rice and asparagus.", Price = 17.99, ImageUrl = "salmon.jpg", CategoryId = 2 },
            new Menu { Id = 3, Name = "Chocolate Cake", Description = "Decadent chocolate cake with a scoop of vanilla ice cream.", Price = 6.95, ImageUrl = "chocolatecake.jpg", CategoryId = 3 },

            new Menu { Id = 4, Name = "Bruschetta", Description = "Toasted baguette slices topped with diced tomatoes, garlic, basil, and balsamic glaze.", Price = 7.99, ImageUrl = "bruschetta.jpg", CategoryId = 1 },
            new Menu { Id = 5, Name = "Spinach Artichoke Dip", Description = "Creamy spinach and artichoke dip served with tortilla chips.", Price = 9.99, ImageUrl = "spinachartichokedip.jpg", CategoryId = 1 },

            new Menu { Id = 6, Name = "Grilled Chicken Breast", Description = "Juicy grilled chicken breast served with garlic mashed potatoes and steamed vegetables.", Price = 15.99, ImageUrl = "grilledchickenbreast.jpg", CategoryId = 2 },
            new Menu { Id = 7, Name = "Shrimp Scampi", Description = "Sauteed shrimp in a garlic butter sauce served over linguine pasta.", Price = 19.99, ImageUrl = "shrimpscampi.jpg", CategoryId = 2 },

            new Menu { Id = 8, Name = "Cheesecake", Description = "Creamy New York-style cheesecake with a graham cracker crust.", Price = 5.99, ImageUrl = "cheesecake.jpg", CategoryId = 3 },
            new Menu { Id = 9, Name = "Apple Pie", Description = "Homemade apple pie with a flaky crust and cinnamon-spiced filling.", Price = 4.99, ImageUrl = "applepie.jpg", CategoryId = 3 },

            new Menu { Id = 10, Name = "Iced Tea", Description = "Refreshing iced tea with a hint of lemon.", Price = 2.99, ImageUrl = "icedtea.jpg", CategoryId = 4 },
            new Menu { Id = 11, Name = "Soda", Description = "Carbonated soft drink in various flavors.", Price = 1.99, ImageUrl = "soda.jpg", CategoryId = 4 }

           );
            modelBuilder.Entity<Reservation>().HasData(
             new Reservation { Id = 1, CustomerName = "John Doe", Email = "johndoe@example.com", PhoneNumber = "555-123-4567", PartySize = 2, SpecialRequest = "No nuts in the dishes, please.", ReservationDate = DateTime.Now.ToString() },
             new Reservation { Id = 2, CustomerName = "Jane Smith", Email = "janesmith@example.com", PhoneNumber = "555-987-6543", PartySize = 4, SpecialRequest = "Gluten-free options required.", ReservationDate = DateTime.Now.ToString() },
             new Reservation { Id = 3, CustomerName = "Michael Johnson", Email = "michaeljohnson@example.com", PhoneNumber = "555-789-0123", PartySize = 6, SpecialRequest = "Celebrating a birthday.", ReservationDate = DateTime.Now.ToString() }
         );
        }

    }
}
