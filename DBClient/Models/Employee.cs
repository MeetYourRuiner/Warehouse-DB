using DBClient.Models.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace DBClient.Models
{
    public class Employee
    {
        [IgnoreInForm]
        [System.ComponentModel.DisplayName("ИД")]
        public long Id { get; set; }

        [System.ComponentModel.DisplayName("Фамилия")]
        public string Surname { get; set; }

        [System.ComponentModel.DisplayName("Имя")]
        public string Name { get; set; }

        [System.ComponentModel.DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [Mask("8(000)000-00-00")]
        [System.ComponentModel.DisplayName("Телефон")]
        public string PhoneNumber { get; set; }

        [IgnoreInForm]
        [System.ComponentModel.Browsable(false)]
        public User User { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Должность")]
        public Position Position { get; set; }

        [System.ComponentModel.Browsable(false)]
        public long? PositionId { get; set; }

        public List<Supply> Supplies { get; set; }
        public List<Shipment> Shipments { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name.FirstOrDefault()}. {Patronymic.FirstOrDefault()}.";
        }
        public string Display { get => this.ToString(); }
    }
}
