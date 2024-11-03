using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracker.Core.Entities
{
    public class Hall : BaseEntity
    {
        public string Name { get; set; }
        public string Building { get; set; }
        public bool IsValid { get; set; }
        public string? MicrocontrollerMac { get; set; }
        public string? MicrocontrollerSerial { get; set; }
        public string? MicrocontrollerIp { get; set; }
        public string? Nut1 { get; set; }
        public string? Nut2 { get; set; }
        public string? Nut3 { get; set; }
        // New properties for dimensions
        public double Length { get; set; }  
        public double Width { get; set; }
        public double Height { get; set; }

        //Navigation Properties
        public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();

    }
}
