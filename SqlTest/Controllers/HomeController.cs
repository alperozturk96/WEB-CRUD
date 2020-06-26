using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dataAccess;
using dataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SqlTest.Models;
using dataAccess.Managers;

namespace SqlTest.Controllers
{
    public class HomeController : Controller
    { 
        SingletonClassMaker _manager = SingletonClassMaker.instance;
        CpuManager cpuManager = new CpuManager();
        MoboManager moboManager = new MoboManager();

        public IActionResult Index() // Direk gider view'i açar.
        {
            return View();
        }

        public IActionResult UpdateViewCpu(int cpuid)
        {
            Cpu getcpu = new Cpu();
            getcpu.cpuid = cpuid;
            return View("UpdateCPU", getcpu);
        }

        public IActionResult UpdateViewMobo(int moboId)
        {
            Motherboard getmobo = new Motherboard();
            getmobo.moboId = moboId;
            //var Mobo1 = new Motherboard();
            return View("UpdateMOBO", getmobo);
        }

        public IActionResult Update()
        {
            return View();
        }
     
        [HttpPost]
        public IActionResult UpdateMobo(Motherboard model)
        { 
            try
            {
                moboManager.UpdateFromTable(model);
                return RedirectToAction("ShowMobo"); //method adını verecen cshtml adını değil.
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult UpdateCpu(Cpu model)
        {

            try
            {
                cpuManager.UpdateFromTable(model);
                return RedirectToAction("ShowCpu");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        
        public IActionResult Viewws()
        {
            return View("View");
        }

        public IActionResult ShowCpu()
        {
            var model = cpuManager.SelectTable();
            return View("ViewCPU",model);
        }

        public IActionResult ShowMobo()
        {
            var model = moboManager.SelectTable();
            return View("ViewMOBO",model);
        }

        public IActionResult Delete()
        {
            return View("Delete");
        }

        [HttpGet]
        public IActionResult DeleteCpu(byte id)
        {
            try
            {
                cpuManager.DeleteTableData(id);
                return RedirectToAction("ShowCpu");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult DeleteMobo(byte id)
        {
            try
            {
                moboManager.DeleteTableData(id);
                return RedirectToAction("ShowMobo");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult CreateViewCpu()
        {
            var Cpu1 = new Cpu();
            //name,cachesize,nanometer,speed
            return View("AddCPU",Cpu1);
        }

        public IActionResult CreateViewMobo()
        {
            var Mobo1 = new Motherboard();
            return View("AddMOBO", Mobo1);
        }

        public IActionResult Create()
        {
            //var Cpu1 = new Cpu();
            //var Mobo1 = new Motherboard();
            //var Tuple1 = Tuple.Create<Cpu, Motherboard>(Cpu1, Mobo1);
            //name,cachesize,nanometer,speed
            return View("Create");
        }

        [HttpPost]
        public IActionResult CreateMobo(Motherboard model)
        {
            try
            {
                moboManager.InsertIntoTable(model);
                return RedirectToAction("ShowMobo");
            }
            catch
            {
                ViewBag.name = model.chipsetName;
                ViewBag.cachesize = model.name;
                ViewBag.nanometer = model.socketName;
                return View(model);
            }
        }
  
        [HttpPost]
        public IActionResult CreateCpu(Cpu model)
        {
            try
            {
                cpuManager.InsertIntoTable(model);
                return RedirectToAction("ShowCpu");
            }
            catch
            {
                ViewBag.name = model.Name;
                ViewBag.cachesize = model.cachesize;
                ViewBag.nanometer = model.nanometer;
                ViewBag.speed = model.speed;
                return View(model);
            }
        }
    }
}
