using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebServer.Data.Models
{
    public class Cargo
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string Terms { get; set; }
        public string Expenses { get; set; }
        public IEnumerable<Transport> Transports { get; set; }
        public Customer Customer { get; set; }

    }
}