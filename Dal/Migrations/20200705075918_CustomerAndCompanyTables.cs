using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class CustomerAndCompanyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "Companys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Companys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Companys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Companys");
        }
    }
}
