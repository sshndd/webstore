using Microsoft.AspNetCore.Mvc;
using webstore.api.Data;

namespace webstore.api.Controller
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class StoreController : ControllerBase
    {
        protected readonly AppDbContext dbContext;
        public StoreController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
