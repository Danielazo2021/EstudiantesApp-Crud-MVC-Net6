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
using EstudiantesApp.Transporte;
using System.Globalization;

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
        public async Task<ActionResult> Details(int id)
        {
            EstudianteDto estudiante = await _IEstudianteServices.ConsultarEstudiante(id);

            return View(estudiante);
        }




        // GET: EstudiantesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EstudianteDto estudiante = await _IEstudianteServices.ConsultarEstudiante(id);

            return View(estudiante);
        }



        // GET: EstudiantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudiantesController/Create
        
        [HttpPost("Estudiantes/Create")]         
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                EstudianteDto estudiante = Formulario(collection);
                var respuesta = await _IEstudianteServices.CrearEstudiante(estudiante);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //Post: EstidianteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( int id, IFormCollection collection)
        {
            //el ID en collection viene repetido por una coma... porque eso esta mal!!
            try
            {
                EstudianteDto estudiante = Formulario(collection);
                var fecha = "" + collection["FechaDate"];
                var fechaDate = DateTime.Parse(fecha);
                estudiante.FechaInscripcion = fechaDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                var respuesta = await _IEstudianteServices.EditarEstudiante(estudiante);

               return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return View();
            }
        }

      

        //Get: EstudianteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        //entra or el catch como si no estuviera volviendo el formato correcto cuando hago el edit
        private EstudianteDto Formulario(IFormCollection collection)
        {
            //EstudianteDto result= new EstudianteDto
            //{
            //    Id = int.Parse(string.IsNullOrEmpty(collection["Id"])?"0":collection["Id"]),
            //    Nombre = collection["Nombre"],
            //    Apellido = collection["Apellido"],
            //    FechaInscripcion = collection["FechaInscripcion"]
            //};

            //return result;

            EstudianteDto result = new EstudianteDto();

            result.Id = int.Parse(string.IsNullOrEmpty(collection["Id"]) ? "0" : collection["Id"]);
                result.Nombre = collection["Nombre"];
            result.Apellido = collection["Apellido"];
            result.FechaInscripcion = collection["FechaInscripcion"];
            

            return result;
        }
    }
}
