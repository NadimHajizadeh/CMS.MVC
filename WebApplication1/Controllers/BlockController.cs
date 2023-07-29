using CMS.Entities;
using ComplexManagment.Services.Blocks.Contracts;
using ComplexManagment.Services.Blocks.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WepAplication.Controllers
{
    public class BlockController : Controller
    {
        private readonly BlockService service;


        public BlockController(BlockService service)
        {
            this.service = service;
        }

        public IActionResult GetAll(ComplexIdDto dto)
        {
            return View(service.GetAll2(dto.Id));
        }
        
        public IActionResult Add(AddBlockDto dto)
        {
            service.Add(dto);
            var complextIdDto = new ComplexIdDto { Id = dto.ComplexID };
            return View("GetAll", service.GetAll2(dto.ComplexID));
        }
        
        public IActionResult AddBlock(ComplexIdDto dto)
        {
            return View("~/Views/Block/Add.cshtml", dto);
        }
    }
}