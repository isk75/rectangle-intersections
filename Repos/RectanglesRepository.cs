using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using RectanglesApp.Data;

namespace RectanglesApp.Repos
{
    public class RectanglesRepository
    {
        private readonly RectanglesContext _context;

        public RectanglesRepository(RectanglesContext context)
        {
            _context = context;
            Init();
        }
        public void Init()
        {
            if (!_context.Rectangle.Any()) 
            {
                _context.Rectangle.AddRange(
                    new Models.Rectangle() { Data = CreateRectangle(100, 100, 300, 300)},
                    new Models.Rectangle() { Data = CreateRectangle(600, 600, 2000, 2000) },
                    new Models.Rectangle() { Data = CreateRectangle(4000, 4000, 6000, 6000) },
                    new Models.Rectangle() { Data = CreateRectangle(8000, 9000, 8300, 9300) }
                    );
                _context.SaveChanges();
            }
        }
        public Task<List<double[]>> GetIntersection(double left, double top, double right, double bootom)
        {
            var geometry = CreateRectangle(left, top, right, bootom);
            return _context.Rectangle.Where(r => r.Data.Intersects(geometry))
                .Select(item => GetBounds(item.Data))
                .ToListAsync();
        }
        private Polygon CreateRectangle(double left, double top, double right, double bottom)
        {
            Coordinate[] coordinates = new Coordinate[] { 
                new Coordinate(left, top), 
                new Coordinate(right, top), 
                new Coordinate(right, bottom), 
                new Coordinate(left, bottom), 
                new Coordinate(left, top) 
            };
            LinearRing shell = new LinearRing(coordinates);
            var rectangle = new Polygon(shell);
            return rectangle;
        }
        private static double[] GetBounds(Geometry geometry) 
        {
            return [geometry.Coordinates[0].X, geometry.Coordinates[0].Y, geometry.Coordinates[2].X, geometry.Coordinates[2].Y];
        }
    }
}
