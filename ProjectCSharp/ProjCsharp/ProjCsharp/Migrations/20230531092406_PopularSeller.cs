using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjCsharp.Migrations
{
    /// <inheritdoc />
    public partial class PopularSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Sellers(Name, Email, CPF, BaseSalary,DepartamentId)" +
                "VALUES ('Bob Brown', 'bob@gmail.com','22804636879', 1000.0, 1)");
            migrationBuilder.Sql("INSERT INTO Sellers(Name, Email, CPF, BaseSalary,DepartamentId)" +
                "VALUES ('Vinicius Pereira', 'vini@gmail.com','21789596874', 2000.0, 3)");
            migrationBuilder.Sql("INSERT INTO Sellers(Name, Email, CPF, BaseSalary,DepartamentId)" +
                "VALUES ('Alex Grey', 'greymarta@gmail.com','31637337868', 1900.0, 2)");
            migrationBuilder.Sql("INSERT INTO Sellers(Name, Email, CPF, BaseSalary,DepartamentId)" +
                "VALUES ('Roberto Silva', 'robsilva@gmail.com','31637337968', 2500.0, 4)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Sellers");
        }
    }
}
