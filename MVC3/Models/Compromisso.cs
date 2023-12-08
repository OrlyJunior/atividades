﻿namespace MVC3.Models
{
    public class Compromisso
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public Local LocalC { get; set; }
        public Contato ContatoC {  get; set; }
        public string Status { get; set; }
    }
}
