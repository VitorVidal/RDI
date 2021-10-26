using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class receiveCardResponse
    {
        [Required]
        public DateTime Registration { get; set; }
        [Required]
        public long Token { get; set; }
        [Required]
        public int CardId { get; set; }
    }
}
