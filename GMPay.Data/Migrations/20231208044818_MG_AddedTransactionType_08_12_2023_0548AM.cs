using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMPay.Data.Migrations
{
    /// <inheritdoc />
    public partial class MGAddedTransactionType081220230548AM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionCategory",
                table: "CustomerTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionCategory",
                table: "CustomerTransactions");
        }
    }
}
