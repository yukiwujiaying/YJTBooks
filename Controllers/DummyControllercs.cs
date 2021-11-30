using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YJKBooks.Contexts;

namespace YJKBooks.Controllers
{
    [ApiController]
    [Route("api/testdatabase")]
    public class DummyControllers :ControllerBase
    {
        private readonly ApplicationDbContext _Bookctx;
        private readonly UsersInfoDbContext _Userctx;

        public DummyControllers(ApplicationDbContext Bookctx, UsersInfoDbContext Usersctx)
        {
            _Bookctx = Bookctx ?? throw new ArgumentNullException(nameof(Bookctx));
            _Userctx = Usersctx ?? throw new ArgumentNullException(nameof(Usersctx));
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            return Ok();
        }

    }
}
