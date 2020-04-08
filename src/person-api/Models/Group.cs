using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace person_api.Models
{
    [Table("Groups")]
    public class Group
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }
    }
}
