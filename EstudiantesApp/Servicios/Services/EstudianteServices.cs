using EstudiantesApp.Dominio.IRepositories;
using EstudiantesApp.Dominio.IServices;
using EstudiantesApp.Dominio.Models;
using EstudiantesApp.Transporte;

namespace EstudiantesApp.Servicios.Services
{
    public class EstudianteServices : IEstudianteServices
    {
        private readonly IEstudianteRepository _IEstudianteRepository;
        public EstudianteServices(IEstudianteRepository iEstudianteRepository)
        {
            _IEstudianteRepository = iEstudianteRepository;
        }

        public async Task<List<EstudianteDto>> ConsultaEstudiante()
        {
            return await _IEstudianteRepository.ConsultaEstudiante();
        }

        public async Task<EstudianteDto> ConsultarEstudiante(int id)
        {
            return await _IEstudianteRepository.ConsultarEstudiante(id);
        }

        public async Task<bool> CrearEstudiante(EstudianteDto estudiante)
        {
            return await _IEstudianteRepository.CrearEstudiante(estudiante); 
        }

        public async Task<bool> EditarEstudiante(EstudianteDto estudiante)
        {
            return await _IEstudianteRepository.EditarEstudiante(estudiante);
        }

        public async Task<bool> EliminarEstudiante(int id)
        {
            return await _IEstudianteRepository.EliminarEstudiante(id);
        }
    }
}
