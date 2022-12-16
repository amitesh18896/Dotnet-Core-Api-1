using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Domin.Models
{
    public class StudentUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal Rate { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDelete { get; set; }
    }

}