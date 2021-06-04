using FCCNet5.Data;
using Microsoft.AspNetCore.Mvc;

namespace FCCNet5.Controllers
{
    public class BaseControllerClass : Controller
    {
        protected readonly ApplicationDbContext _db;

        public BaseControllerClass(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}