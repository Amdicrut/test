using System;

namespace WebServer.Data.DTOs
{


    public class CargoDTO
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string Terms { get; set; }
        public string Expenses { get; set; }
        public int[] Transports { get; set; }
        public int CustomerId { get; set; }
    }

}