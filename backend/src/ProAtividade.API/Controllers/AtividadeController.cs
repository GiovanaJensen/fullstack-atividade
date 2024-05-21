using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.models;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        public IEnumerable<Atividade> Atividades = new List<Atividade>(){
            new Atividade(1),
            new Atividade(2),
            new Atividade(3)
        };

        [HttpGet]
        public IEnumerable<Atividade> get(){
            return Atividades;
        }

        [HttpGet("{id}")]
        public Atividade getComId(int id){
            return Atividades.FirstOrDefault(ati => ati.Id == id);
        }

        [HttpPost("{id}")]
        public IEnumerable<Atividade> post(Atividade atividade){
            return Atividades.Append<Atividade>(atividade);
        }

        [HttpPut("{id}")]
        public string put(int id){
            return $"meu primeiro PUT com parametro {id}";
        }

        [HttpDelete("{id}")]
        public string delete(int id){
            return $"meu primeiro DELETE com {id}";
        }
    }
}