using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRM.Migrations
{
    /// <inheritdoc />
    public partial class Init_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    INN = table.Column<string>(type: "text", nullable: true),
                    KPP = table.Column<string>(type: "text", nullable: true),
                    OGRN = table.Column<string>(type: "text", nullable: true),
                    SupervisorFullName = table.Column<string>(type: "text", nullable: true),
                    SupervisorINNFL = table.Column<string>(type: "text", nullable: true),
                    SupervisorJobTitle = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber01 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber02 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber03 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber04 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber05 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber06 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber07 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber08 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhoneNumber09 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    EmailAddress01 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress02 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress03 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress04 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress05 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress06 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress07 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress08 = table.Column<string>(type: "text", nullable: true),
                    EmailAddress09 = table.Column<string>(type: "text", nullable: true),
                    FullAddress = table.Column<string>(type: "text", nullable: true),
                    SiteLink = table.Column<string>(type: "text", nullable: true),
                    FocusLink = table.Column<string>(type: "text", nullable: true),
                    CompanyStatus = table.Column<string>(type: "text", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MSPList = table.Column<string>(type: "text", nullable: true),
                    Revenue = table.Column<double>(type: "double precision", nullable: true),
                    Balance = table.Column<double>(type: "double precision", nullable: true),
                    Arbitration = table.Column<double>(type: "double precision", nullable: true),
                    IncomeLoss = table.Column<double>(type: "double precision", nullable: true),
                    SpecialTaxRegime = table.Column<string>(type: "text", nullable: true),
                    ValueAddedTax = table.Column<string>(type: "text", nullable: true),
                    MainActivity = table.Column<string>(type: "text", nullable: true),
                    ExtraActivity = table.Column<string>(type: "text", nullable: true),
                    OKPD2 = table.Column<string>(type: "text", nullable: true),
                    RegistrationRegion = table.Column<string>(type: "text", nullable: true),
                    ObtainedLicenses = table.Column<string>(type: "text", nullable: true),
                    Jobs = table.Column<string>(type: "text", nullable: true),
                    LeasingSubject = table.Column<string>(type: "text", nullable: true),
                    LeasingSubjectCategory = table.Column<string>(type: "text", nullable: true),
                    PropertyPledge = table.Column<string>(type: "text", nullable: true),
                    EmploeeCount = table.Column<double>(type: "double precision", nullable: true),
                    CompanyBranches = table.Column<string>(type: "text", nullable: true),
                    CompanyBranchesCount = table.Column<double>(type: "double precision", nullable: true),
                    CompanySource = table.Column<string>(type: "text", nullable: true),
                    CompanySegmentName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyName",
                table: "Company",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_INN",
                table: "Company",
                column: "INN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
