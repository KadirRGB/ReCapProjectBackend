using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Business.Concrete;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        //Loosely coupled --dependent only abstract
        //IoC Container --Inversion of Control.
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
     public IActionResult GetAll(){
        var result = _carService.GetAll();
        if(result.Success){
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
     
    }
    
        [HttpPost("add")]
     public IActionResult Add(Car car){
         var result =_carService.Add(car);
           if(result.Success){
            return Ok(result);
        }
        return BadRequest(result);
     }

   [HttpGet("getbyid")]
     public IActionResult GetById(int id){
        var result = _carService.GetById(id);
        if(result.Success){
            return Ok(result);
        }
        return BadRequest(result.Message);
     
    }
    

    }

}