using DBClient.Models.Attributes;
using System.Collections.Generic;

namespace DBClient.Models
{
    public class Supplier
    {
        [IgnoreInForm]
        [System.ComponentModel.DisplayName("ИД")]
        public long Id { get; set; }

        [System.ComponentModel.DisplayName("Название")]
        public string Name { get; set; }

        [Mask("000000")]
        [System.ComponentModel.DisplayName("Индекс")]
        public string PostalCode { get; set; }

        [System.ComponentModel.DisplayName("Адрес")]
        public string Address { get; set; }

        [Mask("8(000)000-00-00")]
        [System.ComponentModel.DisplayName("Телефон")]
        public string PhoneNumber { get; set; }

        [Mask("000000000099")]
        [System.ComponentModel.DisplayName("ИНН")]
        public string INN { get; set; }

        [Mask("000000000")]
        [System.ComponentModel.DisplayName("КПП")]
        public string KPP { get; set; }

        [Mask("00000000000000000000")]
        [System.ComponentModel.DisplayName("Р/С")]
        public string PaymentAccount { get; set; }

        public List<Supply> Supplies { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
        public string Display { get => this.ToString(); }
    }
}
