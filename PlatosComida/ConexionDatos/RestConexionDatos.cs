using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PlatosComida.Models;

namespace PlatosComida.ConexionDatos
{
    public class RestConexionDatos : IRestConexionDatos
    {
        public readonly HttpClient httpClient;
        private readonly string dominio;
        private readonly string url;
        private readonly JsonSerializerOptions opcionesJson;
        public RestConexionDatos(HttpClient httpClient)
        {
            //httpClient = new HttpClient();
            this.httpClient = httpClient;
            //dominio = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7169" : "https://localhost:7169";
            dominio = "https://localhost:7169";
            url = $"{dominio}/api";
            opcionesJson = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task AddPlatoAsync(Platos plato)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin acceso a internet.");
                return;
            }
            try
            {
                //Serializamos plato a pasar
                string platoSer = JsonSerializer.Serialize<Platos>(plato, opcionesJson);
                StringContent contenido = new StringContent(platoSer, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync($"{url}/plato", contenido);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("[RED] Se registró correctamente.");
                else
                    Debug.WriteLine("[RED] NO se registró correctamente.");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
        }

        public async Task DeletePlatoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin acceso a internet.");
                return;
            }
            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"{url}/plato/{id}");
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("[RED] Se eliminó correctamente.");
                else
                    Debug.WriteLine("[RED] NO se eliminó correctamente.");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
        }

        public async Task<List<Platos>> GetPlatosAsync()
        {
            List<Platos> platos = new List<Platos>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin acceso a internet.");
                return platos;
            }
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{url}/plato");
                if (response.IsSuccessStatusCode)
                {
                    //Deserializamos
                    var contenido = await response.Content.ReadAsStringAsync();
                    platos = JsonSerializer.Deserialize<List<Platos>>(contenido, opcionesJson);
                }
                else
                {
                    Debug.WriteLine("[RED] Sin respuesta favorable desde el servidor API.");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
            return platos;
        }

        public async Task UpdatePlatoAsync(Platos plato)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin acceso a internet.");
                return;
            }
            try
            {
                //Serializamos plato a pasar
                string platoSer = JsonSerializer.Serialize<Platos>(plato, opcionesJson);
                StringContent contenido = new StringContent(platoSer, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{url}/plato/{plato.Id}", contenido);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("[RED] Se modificó correctamente.");
                else
                    Debug.WriteLine("[RED] NO se modificó correctamente.");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERROR] {e.Message}");
            }
        }
    }

}
