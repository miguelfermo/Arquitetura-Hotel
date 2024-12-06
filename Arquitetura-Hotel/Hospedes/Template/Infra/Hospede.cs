using System;
using System.ComponentModel.DataAnnotations;

namespace MicroserviceHospedes.Infra
{
    public class Hospede
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
