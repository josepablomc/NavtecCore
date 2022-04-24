using FE.Identity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FE.Identity.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        public void Delete(Usuarios t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = cl.DeleteAsync("api/Usuarios/" + t.IdUsuario.ToString()).Result;

                    if (!res.IsSuccessStatusCode)
                    {
                        throw new Exception(res.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public IEnumerable<Usuarios> GetAll()
        {
            List<Models.Usuarios> aux = new List<Models.Usuarios>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Usuarios").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Usuarios>>(auxres);
                }
            }
            return aux;
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            List<Models.Usuarios> aux = new List<Models.Usuarios>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Usuarios");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Usuarios>>(auxres);
                }
            }
            return aux;
        }

        public Usuarios GetOneById(int id)
        {
            Models.Usuarios aux = new Models.Usuarios();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Usuarios/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Usuarios>(auxres);
                }
            }
            return aux;
        }

        public async Task<Usuarios> GetOneByIdAsync(int id)
        {
            Models.Usuarios aux = new Models.Usuarios();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Usuarios/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Usuarios>(auxres);
                }
            }
            return aux;
        }

        public void Insert(Usuarios t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(t);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Usuarios", byteContent).Result;

                    if (!postTask.IsSuccessStatusCode)
                    {
                        throw new Exception(postTask.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public void Update(Usuarios t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(t);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PutAsync("api/Usuarios/" + t.IdUsuario, byteContent).Result;


                    if (!postTask.IsSuccessStatusCode)
                    {
                        throw new Exception(postTask.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
    }
}
    
