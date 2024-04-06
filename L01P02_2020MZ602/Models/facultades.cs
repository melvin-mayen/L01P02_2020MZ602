using System.ComponentModel.DataAnnotations;

namespace L01P02_2020MZ602.Models
{
    public class facultades
    {


        [Key]

        public int Id { get; set; }

        public string? facultad { get; set; }


    }
}
