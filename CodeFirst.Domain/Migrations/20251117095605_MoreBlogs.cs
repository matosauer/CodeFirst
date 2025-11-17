using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Domain.Migrations
{
    /// <inheritdoc />
    public partial class MoreBlogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Name" },
                values: new object[] { 2, "second" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2);
        }
    }
}
