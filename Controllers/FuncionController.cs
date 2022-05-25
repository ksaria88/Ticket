using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections;
using System.Text;
using Newtonsoft.Json;
using AtencionCliente.Data;
using AtencionCliente.Models;

namespace LatiniumBlazor.Server.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class FuncionController : ControllerBase
  {
    private readonly AtencionClienteContext _context;

    public FuncionController(AtencionClienteContext context)
    {
      _context = context;
    }

    // GET: api/Funciones        
    [HttpPost("DevolverInt")]
    public int GetDevolverInt([FromBody] Consulta consulta)
    {
      return Funcion.DevolverInt(_context.Database.GetDbConnection().ConnectionString, consulta.SentenciaSql);
    }

    // GET: api/Funciones        
    [HttpPost("DevolverBool")]
    public bool GetDevolverBool([FromBody] Consulta consulta)
    {
      return Funcion.DevolverBool(_context.Database.GetDbConnection().ConnectionString, consulta.SentenciaSql);
    }


    // GET: api/Funciones        
    [HttpPost("DevolverDouble")]
    public double GetDevolverDouble([FromBody] Consulta consulta)
    {
      return (Double)Funcion.DevolverDouble(_context.Database.GetDbConnection().ConnectionString, consulta.SentenciaSql);
    }


  // GET: api/Funciones        
    [HttpPost("EjecutarSql")]
    public string GetEjecutarSql1([FromBody] Consulta consulta)
    {
      return Funcion.EjecutarSql(_context.Database.GetDbConnection().ConnectionString, consulta.SentenciaSql);
    }
   

    // GET: /api/Funciones/DevolverGrilla1
    [HttpPost("DevolverLista")]
    public string GetDevolverLista([FromBody] Consulta consulta)
    {
      DataTable table = Funcion.DevolverLista(_context.Database.GetDbConnection().ConnectionString, consulta.SentenciaSql);
      string JSONString = string.Empty;
      JSONString = JsonConvert.SerializeObject(table);
      return JSONString;
    }
  }
}
