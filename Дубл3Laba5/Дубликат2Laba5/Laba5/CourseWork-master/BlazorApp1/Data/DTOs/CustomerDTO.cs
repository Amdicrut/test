namespace BlazorApp1.Data.DTOs
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tarriff { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int[] Cargos { get; set; }
    }

}
