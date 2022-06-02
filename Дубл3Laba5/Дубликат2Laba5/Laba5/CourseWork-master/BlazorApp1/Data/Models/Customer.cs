using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Data.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Country { get; set; }
        public IEnumerable<Cargo> Cargos { get; set; }
        public string Tariff { get; internal set; }
    }
}
