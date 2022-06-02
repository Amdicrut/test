using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Data.Models
{
    public class Transport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public IEnumerable<Cargo> Cargos { get; set; }
    }
}
