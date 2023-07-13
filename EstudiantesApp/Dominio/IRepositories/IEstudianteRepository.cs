using EstudiantesApp.Transporte;

namespace EstudiantesApp.Dominio.IRepositories
{
    public interface IEstudianteRepository
    {
        Task<List<EstudianteDto>> ConsultaEstudiante();
    }
}
