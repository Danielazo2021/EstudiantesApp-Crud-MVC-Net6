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
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                EstudianteDto estudiante = Formulario(collection);
                var respuesta = await _IEstudianteServices.CrearEstudiante(estudiante);

                if(!respuesta)
                {
                    TempData["Error"] = "Ocurrió un error en la creación ";
                }else
                {
                    TempData["Exito"] = "Creación exitosa";
                }

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
         
            try
            {
                EstudianteDto estudiante = Formulario(collection);
                var fecha = "" + collection["FechaDate"];
                var fechaDate = DateTime.Parse(fecha);
                estudiante.FechaInscripcion = fechaDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                var respuesta = await _IEstudianteServices.EditarEstudiante(estudiante);

                if (!respuesta)
                {
                    TempData["Error"] = "Ocurrió un error en la actualización ";
                }
                else
                {
                    TempData["Exito"] = "Actualización exitosa";
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return View();
            }
        }

      

        //Get: EstudianteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            EstudianteDto estudiante = await _IEstudianteServices.ConsultarEstudiante(id);
            
            return View(estudiante);
        }


        //POst:EstudianteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
           
            try
            {           
                var respuesta = await _IEstudianteServices.EliminarEstudiante(id);

                if (!respuesta)
                {
                    TempData["Error"] = "Ocurrió un error en la eliminación ";
                }
                else
                {
                    TempData["Exito"] = "Eliminación exitosa";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }





        private EstudianteDto Formulario(IFormCollection collection)
        {
            EstudianteDto result = new EstudianteDto();

            result.Id = int.Parse(string.IsNullOrEmpty(collection["Id"]) ? "0" : collection["Id"]);
            result.Nombre = collection["Nombre"];
            result.Apellido = collection["Apellido"];
            result.FechaInscripcion = collection["FechaInscripcion"];
            

            return result;
        }
    }
}
