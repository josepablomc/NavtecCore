using FE.Identity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FE.Identity.Services
{
    public class GastosServices : IGastosServices
    {
        public void Delete(Gastos t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = cl.DeleteAsync("api/Gastos/" + t.IdGasto.ToString()).Result;

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

        public IEnumerable<Gastos> GetAll()
        {
            List<Models.Gastos> aux = new List<Models.Gastos>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Gastos").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Gastos>>(auxres);
                }
            }
            return aux;
        }

        public Task<IEnumerable<Gastos>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Gastos GetOneById(int id)
        {
            Models.Gastos aux = new Models.Gastos();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Gastos/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Gastos>(auxres);
                }
            }
            return aux;
        }

        public Task<Gastos> GetOneByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Gastos t)
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
                    var postTask = cl.PostAsync("api/Gastos", byteContent).Result;

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

        public void Update(Gastos t)
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
                    var postTask = cl.PutAsync("api/Gastos/" + t.IdGasto, byteContent).Result;


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
