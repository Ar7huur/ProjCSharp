using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjCsharp.Migrations
{
    /// <inheritdoc />
    public partial class PopularSalesRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO SelesRecords(Date,Amount,SellerId)" +
                "VALUES ('18/02/2020', 11000.0, 4)");
            migrationBuilder.Sql("INSERT INTO SelesRecords(Date,Amount,SellerId)" +
                "VALUES ('18/09/2012', 15000.0, 2)");
            migrationBuilder.Sql("INSERT INTO SelesRecords(Date,Amount,SellerId)" +
                "VALUES ('12/09/2019', 50000.0, 1)");
            migrationBuilder.Sql("INSERT INTO SelesRecords(Date,Amount,SellerId)" +
                "VALUES ('01/05/2013', 90000.0, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SelesRecord");
        }
    }
}
