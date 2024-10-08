using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatosComida.Models;

namespace PlatosComida.ConexionDatos
{
    public interface IRestConexionDatos
    {
        Task<List<Platos>> GetPlatosAsync();
        Task AddPlatoAsync(Platos plato);
        Task UpdatePlatoAsync(Platos plato);
        Task DeletePlatoAsync(int id);
    }
}
