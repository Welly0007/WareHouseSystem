using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
	/// <inheritdoc />
	public partial class addedExpirefields : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameColumn(
				name: "Price",
				table: "Products",
				newName: "SellingPrice");

			migrationBuilder.AlterColumn<DateTime>(
				name: "ExpiryDate",
				table: "Products",
				type: "datetime2",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "datetime2");

			migrationBuilder.AddColumn<decimal>(
				name: "BuyingPrice",
				table: "Products",
				type: "decimal(10,2)",
				nullable: false,
				defaultValue: 0m);

			migrationBuilder.AddColumn<int>(
				name: "DurationType",
				table: "Products",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "Expirable",
				table: "Products",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<int>(
				name: "LowStockThreshold",
				table: "Products",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "NearExpireThreshold",
				table: "Products",
				type: "int",
				nullable: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "BuyingPrice",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "DurationType",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "Expirable",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "LowStockThreshold",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "NearExpireThreshold",
				table: "Products");

			migrationBuilder.RenameColumn(
				name: "SellingPrice",
				table: "Products",
				newName: "Price");


			migrationBuilder.AlterColumn<DateTime>(
				name: "ExpiryDate",
				table: "Products",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
				oldClrType: typeof(DateTime),
				oldType: "datetime2",
				oldNullable: true);
		}
	}
}
