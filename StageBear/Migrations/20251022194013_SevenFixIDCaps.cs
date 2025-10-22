using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StageBear.Migrations
{
    /// <inheritdoc />
    public partial class SevenFixIDCaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryId1",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Owner_OwnerId1",
                table: "Owner");

            migrationBuilder.DropForeignKey(
                name: "FK_Venue_Venue_VenueId1",
                table: "Venue");

            migrationBuilder.RenameColumn(
                name: "VenueId1",
                table: "Venue",
                newName: "VenueID1");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Venue",
                newName: "VenueID");

            migrationBuilder.RenameIndex(
                name: "IX_Venue_VenueId1",
                table: "Venue",
                newName: "IX_Venue_VenueID1");

            migrationBuilder.RenameColumn(
                name: "OwnerId1",
                table: "Owner",
                newName: "OwnerID1");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Owner",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Owner_OwnerId1",
                table: "Owner",
                newName: "IX_Owner_OwnerID1");

            migrationBuilder.RenameColumn(
                name: "CategoryId1",
                table: "Category",
                newName: "CategoryID1");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Category_CategoryId1",
                table: "Category",
                newName: "IX_Category_CategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryID1",
                table: "Category",
                column: "CategoryID1",
                principalTable: "Category",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Owner_OwnerID1",
                table: "Owner",
                column: "OwnerID1",
                principalTable: "Owner",
                principalColumn: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Venue_Venue_VenueID1",
                table: "Venue",
                column: "VenueID1",
                principalTable: "Venue",
                principalColumn: "VenueID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryID1",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Owner_OwnerID1",
                table: "Owner");

            migrationBuilder.DropForeignKey(
                name: "FK_Venue_Venue_VenueID1",
                table: "Venue");

            migrationBuilder.RenameColumn(
                name: "VenueID1",
                table: "Venue",
                newName: "VenueId1");

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "Venue",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Venue_VenueID1",
                table: "Venue",
                newName: "IX_Venue_VenueId1");

            migrationBuilder.RenameColumn(
                name: "OwnerID1",
                table: "Owner",
                newName: "OwnerId1");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Owner",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Owner_OwnerID1",
                table: "Owner",
                newName: "IX_Owner_OwnerId1");

            migrationBuilder.RenameColumn(
                name: "CategoryID1",
                table: "Category",
                newName: "CategoryId1");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Category",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_CategoryID1",
                table: "Category",
                newName: "IX_Category_CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryId1",
                table: "Category",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Owner_OwnerId1",
                table: "Owner",
                column: "OwnerId1",
                principalTable: "Owner",
                principalColumn: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venue_Venue_VenueId1",
                table: "Venue",
                column: "VenueId1",
                principalTable: "Venue",
                principalColumn: "VenueId");
        }
    }
}
