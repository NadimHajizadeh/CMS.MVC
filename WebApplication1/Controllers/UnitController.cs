using CMS.Entities;
using CMS.Services.Units.Contracts.Dto;
using ComplexManagment.Services.Units.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WepAplication.Controllers
{
    public class UnitController : Controller
    {
        private readonly UnitService service;


        public UnitController(UnitService service)
        {
            this.service = service;
        }

        public IActionResult GetAll(ComplexIdDto dto)
        {
            return View(service.GettAllByBlockId(dto.Id));
        }
        
        public IActionResult Add(ComplexIdDto dto)
        {
            return View(dto);
        }
        
        public IActionResult AddUnit(AddUnitDto dto)
        {
            service.Add(dto);
            return View("GetAll",service.GettAllByBlockId(dto.BlockId));
        }
    }
}
