using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebServer.Data.Models
{


    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tarriff { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public IEnumerable<Cargo> Cargos { get; set; }
    }
}