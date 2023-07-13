using EstudiantesApp.Dominio.IRepositories;
using EstudiantesApp.Dominio.IServices;
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
    }
}
