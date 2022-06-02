using System;

namespace WebServer.Data.DTOs
{


    public class TransportDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public int CargoId { get; set; }
    }

}