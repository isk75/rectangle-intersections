namespace RectanglesApp.Models
{
    using NetTopologySuite.Geometries;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rectangle
    {
        public int Id { get; set; }
        [Column(TypeName = "geometry")]
        public required Polygon Data { get; set; }
    }
}
