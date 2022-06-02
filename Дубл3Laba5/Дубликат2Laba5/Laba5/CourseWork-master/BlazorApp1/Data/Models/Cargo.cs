using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Data.Models
{
    public class Cargo
    {

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Transport Transport { get; set; }
        public int Cost { get; set; }
        public string Amount { get; set; }
        public string Terms { get; set; }

    }
}
