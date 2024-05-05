using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace RectanglesApp.Migrations
{
    /// <inheritdoc />
    public partial class InitRectangle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rectangle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<Geometry>(type: "geometry", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangle", x => x.Id);
                });
            migrationBuilder.Sql(@"CREATE SPATIAL INDEX SPATIAL_Rectangle ON dbo.Rectangle(Data) USING GEOMETRY_GRID
	            WITH( BOUNDING_BOX  = ( xmin  = 0.0, ymin  = 0.0, xmax  = 10000, ymax  = 10000), GRIDS  = ( LEVEL_1  = MEDIUM, LEVEL_2  = MEDIUM, LEVEL_3  = MEDIUM, LEVEL_4  = MEDIUM), CELLS_PER_OBJECT  = 16, STATISTICS_NORECOMPUTE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
                GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rectangle");
            migrationBuilder.DropIndex(
                name: "SPATIAL_RECTANGLE_INDEX");
        }
    }
}
