using CMS.Services.Complexs.Contract;
using CMS.Services.Complexs.Contract.Dto;
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

        public IActionResult Add()
        {
            return View();
        }
        
        public IActionResult AddComplex(AddComplexDto dto)
        {
            service.Add(dto);
            return View("GetAll", service
                .GetAllComplexesWithUnitCountDeatail());
        }
    }
}
