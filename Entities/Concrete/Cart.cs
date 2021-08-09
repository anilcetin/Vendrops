using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Cart : IEntity
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
    }
}
