using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBServer.Models
{
    public class Unit
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Указывать пользователем
        public long Id { get; set; }
        [Required(ErrorMessage = "Требуется указать название")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
