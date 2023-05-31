using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjCsharp.Migrations {
    /// <inheritdoc />
    public partial class PopularDepartaments : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("INSERT INTO Departaments(Name)" +
                "VALUES ('Computers')");
            migrationBuilder.Sql("INSERT INTO Departaments(Name)" +
                "VALUES ('Eletronics')");
            migrationBuilder.Sql("INSERT INTO Departaments(Name)" +
                "VALUES ('Fashion')");
            migrationBuilder.Sql("INSERT INTO Departaments(Name)" +
                "VALUES ('Books')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("DELETE FROM Departaments");
        }
    }
}
