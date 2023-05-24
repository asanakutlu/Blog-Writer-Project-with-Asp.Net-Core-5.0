﻿using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44351/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient=new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content=new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44351/api/Default",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeEdit(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage= await httpClient.GetAsync("https://localhost:44351/api/Default/"+ id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeEdit(Class1 p)
        {
            var httpClient=new HttpClient();
            var jsonEmployee=JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8,"application/json");
            var reponseMesssage = await httpClient.PutAsync("https://localhost:44351/api/Default/",content);
            if(reponseMesssage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p); 
        }
        public async Task<IActionResult> EmployeeDelete(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44351/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
