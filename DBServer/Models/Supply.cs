using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBServer.Models
{
    public class Supply
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Требуется указать дату")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Требуется указать поставщика")]
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public List<SupplyProduct> SupplyProducts { get; set; }
    }
}
