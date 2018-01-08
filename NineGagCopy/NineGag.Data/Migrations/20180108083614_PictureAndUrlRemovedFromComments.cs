namespace NineGag.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PictureAndUrlRemovedFromComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Comments",
                nullable: true);
        }
    }
}
