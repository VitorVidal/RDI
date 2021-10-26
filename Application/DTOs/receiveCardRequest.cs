using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class receiveCardRequest
    {
        [Required]        
        [DefaultValueAttribute(1)]
        public int CustomerId { get; set; }
        [Required]
        [DefaultValueAttribute(1234)]
        public long CardNumber { get; set; }
        [Required]
        [DefaultValueAttribute(2)]
        public int CVV { get; set; }
    }
}
