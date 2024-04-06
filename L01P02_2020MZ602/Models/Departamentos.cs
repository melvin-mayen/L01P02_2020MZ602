using System.ComponentModel.DataAnnotations;

namespace L01P02_2020MZ602.Models
{
    public class Departamentos
    {

        [Key]

        public int Id { get; set; }

        public string? departamento  { get; set; }
    }
}
