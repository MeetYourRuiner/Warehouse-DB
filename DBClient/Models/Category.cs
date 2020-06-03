using DBClient.Models.Attributes;
using System.Collections.Generic;

namespace DBClient.Models
{
    public class Category
    {
        [IgnoreInForm]
        [System.ComponentModel.DisplayName("ИД")]
        public long Id { get; set; }

        [System.ComponentModel.DisplayName("Название")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public string Display { get => this.ToString(); }
    }
}
