using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RectanglesApp.Data;
using RectanglesApp.Models;
using RectanglesApp.Repos;

namespace RectanglesApp
{
    [Route("api/Rectangles")]
    [ApiController]
    public class RectanglesController : ControllerBase
    {
        private readonly RectanglesRepository _repo;

        public RectanglesController(RectanglesContext context)
        {
            _repo = new RectanglesRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<double[]>>> GetRectangleIntersection(double left, double top, double right, double bootom)
        {
            return await _repo.GetIntersection(left, top, right, bootom);
        }
    }
}
