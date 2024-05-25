using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using ProAtividade.API.Data;
using ProAtividade.API.models;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _context;

        public AtividadeController()
        {
            _context = new DataContext();
        }

        [HttpGet]
        public IEnumerable<Atividade> get()
        {
            return _context.Atividades;
        }

        [HttpGet("{id}")]
        public Atividade getComId(int id)
        {
            return _context.Atividades.FirstOrDefault(ati => ati.Id == id);
        }

        [HttpPost]
        public IEnumerable<Atividade> post(Atividade atividade)
        {
            _context.Add(atividade);
            if (_context.SaveChanges() > 0)
            {
                return _context.Atividades;
            }
            else
            {
                throw new Exception("Você não conseguiu preencher nenhuma atividade");
            }
        }

        [HttpPut("{id}")]
        public Atividade put(int id, Atividade atividade)
        {
            var atividadeExistente = _context.Atividades.FirstOrDefault(ati => ati.Id == id);
            if (atividadeExistente == null) throw new Exception("Atividade não encontrada");

            atividadeExistente.Titulo = atividade.Titulo;
            atividadeExistente.Descricao = atividade.Descricao;
            atividadeExistente.Propriedade = atividade.Propriedade;

            if (_context.SaveChanges() > 0)
            {
                return atividadeExistente;
            }
            else
            {
                throw new Exception("Falha ao salvar as alterações");
            }
        }

        [HttpDelete("{id}")]
        public bool delete(int id)
        {
            var atividade = _context.Atividades.FirstOrDefault(ati => ati.Id == id);
            if (atividade == null)
                throw new Exception("Você está tentando excluir uma atividade que não existe");

            _context.Remove(atividade);
            return _context.SaveChanges() > 0;
        }
    }
}