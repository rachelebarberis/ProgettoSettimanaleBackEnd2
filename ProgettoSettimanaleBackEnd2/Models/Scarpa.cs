﻿namespace ProgettoSettimanaleBackEnd2.Models
{
    public class Scarpa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Prezzo { get; set; }
        public string? Descrizione { get; set; }
        public string? Img { get; set; }
        public List<string>? AddImg { get; set; }
    }
}
