using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAtividade.API.models
{
    public class Atividade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Prioridade Propriedade { get; set; }
        public Atividade(){}
        public Atividade(int id){
            this.Id = id;
        }
    }
}