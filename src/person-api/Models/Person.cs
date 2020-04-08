using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace person_api.Models
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
