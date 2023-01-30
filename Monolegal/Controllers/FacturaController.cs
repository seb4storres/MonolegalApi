using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monolegal.Models;
using Monolegal.Services;
using System.Collections.Generic;

namespace Monolegal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        public FacturasService _facturasService;
        public FacturaController(FacturasService facturasService) 
        {
            _facturasService = facturasService;    
        }

      
        [HttpGet]
        public ActionResult<List<Factura>> Getf() 
        {
            return _facturasService.Getf();
        }


        [HttpPost]
        public ActionResult<Factura> Create(Factura factura)
        {
            _facturasService.Create(factura);
            return Ok(factura);
        }

        [HttpPut]
        public ActionResult Update(Factura factura)
        {                        
            _facturasService.Update(factura.Id, factura);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            _facturasService.Delete(id);
            return Ok();
        }
    }
}
