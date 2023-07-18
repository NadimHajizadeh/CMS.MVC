using CMS.Services.Complexs.Contract;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WepAplication.Controllers
{
    public class ComplexController : Controller
    {
        
        private readonly ComplexService service;


        public ComplexController(ComplexService service)
        {
            this.service = service;
        }
        public IActionResult GetAll()
        {
            return View(service.GetAllComplexesWithUnitCountDeatail());
        }
    }
}
