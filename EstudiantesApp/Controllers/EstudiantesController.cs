using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstudiantesApp.Dominio.Models;
using EstudiantesApp.Persistencia.Context;
using EstudiantesApp.Dominio.IServices;

namespace EstudiantesApp.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly IEstudianteServices _IEstudianteServices;
        public EstudiantesController(IEstudianteServices iEstudianteServices)
        {
            _IEstudianteServices = iEstudianteServices;

        }


        // GET: Estudiantes Controller

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Index()
        {
            var estudiantes = await _IEstudianteServices.ConsultaEstudiante();
            return View(estudiantes);
        }

        // GET: EstudiantesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
       

        // GET: EstudiantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudiantesController/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       


      
    }
}
