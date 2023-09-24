using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQLProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartySize = table.Column<int>(type: "int", nullable: false),
                    SpecialRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "appetizers.png", "Appetizers" },
                    { 2, "maincourse.png", "Main Course" },
                    { 3, "dessert.png", "Desserts" },
                    { 4, "drinks.png", "Drinks" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerName", "Email", "PartySize", "PhoneNumber", "ReservationDate", "SpecialRequest" },
                values: new object[,]
                {
                    { 1, "John Doe", "johndoe@example.com", 2, "555-123-4567", "9/24/2023 12:04:02 PM", "No nuts in the dishes, please." },
                    { 2, "Jane Smith", "janesmith@example.com", 4, "555-987-6543", "9/24/2023 12:04:02 PM", "Gluten-free options required." },
                    { 3, "Michael Johnson", "michaeljohnson@example.com", 6, "555-789-0123", "9/24/2023 12:04:02 PM", "Celebrating a birthday." }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Spicy chicken wings served with blue cheese dip.", "chickenwings.jpeg", "Chicken Wings", 9.9900000000000002 },
                    { 2, 2, "Grilled salmon fillet with a lemon dill sauce, accompanied by rice and asparagus.", "salmon.jpg", "Salmon", 17.989999999999998 },
                    { 3, 3, "Decadent chocolate cake with a scoop of vanilla ice cream.", "chocolatecake.jpg", "Chocolate Cake", 6.9500000000000002 },
                    { 4, 1, "Toasted baguette slices topped with diced tomatoes, garlic, basil, and balsamic glaze.", "bruschetta.jpg", "Bruschetta", 7.9900000000000002 },
                    { 5, 1, "Creamy spinach and artichoke dip served with tortilla chips.", "spinachartichokedip.jpg", "Spinach Artichoke Dip", 9.9900000000000002 },
                    { 6, 2, "Juicy grilled chicken breast served with garlic mashed potatoes and steamed vegetables.", "grilledchickenbreast.jpg", "Grilled Chicken Breast", 15.99 },
                    { 7, 2, "Sauteed shrimp in a garlic butter sauce served over linguine pasta.", "shrimpscampi.jpg", "Shrimp Scampi", 19.989999999999998 },
                    { 8, 3, "Creamy New York-style cheesecake with a graham cracker crust.", "cheesecake.jpg", "Cheesecake", 5.9900000000000002 },
                    { 9, 3, "Homemade apple pie with a flaky crust and cinnamon-spiced filling.", "applepie.jpg", "Apple Pie", 4.9900000000000002 },
                    { 10, 4, "Refreshing iced tea with a hint of lemon.", "icedtea.jpg", "Iced Tea", 2.9900000000000002 },
                    { 11, 4, "Carbonated soft drink in various flavors.", "soda.jpg", "Soda", 1.99 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
