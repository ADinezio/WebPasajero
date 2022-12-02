using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebPasajero.Data;
using WebPasajero.Models;

namespace WebPasajero.Controllers
{
    public class PasajeroController : Controller
    {
        private readonly PasajeroContext _context;

        public PasajeroController(PasajeroContext context) 
        {
            _context = context;
        }

        //GET: Pasajero o Pasajero/index
        [Route("Pasajero")]
        public IActionResult Index()
        {
            return View(_context.Pasajeros.ToList());
        }

        //GET: Pasajero/Create
        [Route("Pasajero/Create")]
        public IActionResult Create() 
        {
            Pasajero pasajero = new Pasajero();
            return View("Create", pasajero);
        }

        //GET: Pasajero/Create
        [HttpPost]
        public IActionResult Create(Pasajero pasajero)
        {
            if (pasajero != null)
            {
                _context.Pasajeros.Add(pasajero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        //GET: Person/ListarPorFechaNacimiento/fecha
        
       // [Route("Pasajero/ListarPorFechaNacimiento/{fecha:Datetime}")]
        public IActionResult ListarPorFechaNacimiento(DateTime fecha) 
        {
            List<Pasajero> list = BuscaXFechaNacimiento(fecha);

            if (list == null)
            {
                return NotFound();
            }
            else
            {
                return View("index",list);
            }

        }

        [NonAction]
        public List<Pasajero> BuscaXFechaNacimiento(DateTime fecha)
        {
            List<Pasajero> list = (from f in _context.Pasajeros
                                   where DateTime.Compare(f.FechaNacimiento,fecha)==0
                                   select f).ToList();

            return list;
        }

        //GET: Person/ListarXCiudad/ciudad

        
       // [Route("Pasajero/ListarXCiudad/{ciudad:string}")]
        public IActionResult ListarXCiudad(string ciudad)
        {
            List<Pasajero> list = BuscaXCiudad(ciudad);

            if (list == null)
            {
                return NotFound();
            }
            else
            {
                return View("index", list);
            }

        }

        [NonAction]
        public List<Pasajero> BuscaXCiudad(string ciudad)
        {
            List<Pasajero> list = (from c in _context.Pasajeros
                                   where c.Ciudad.ToUpper() == ciudad.ToUpper()
                                   select c).ToList();

            return list;
        }
    }
}
