using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Projeto
    {
        public string Titulo { get; set; }
        public decimal VerbaAprovada { get; set; }
        public decimal ValorBolsaIndividual { get; set; }
        public string AreaConhecimento { get; set; }
        public Coordenador coordenador{ get; set; }
        public List<Bolsista> Bolsista { get; set; } = new List<Bolsista>();
        
        //inicialize a lista dos bolsistas!
    }
}