using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebServer.Data.Models
{
    public class Transport
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public Cargo Cargo { get; set; }    

    }
}