using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Service : IEntity
    {
        [Key]
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
    }
}
