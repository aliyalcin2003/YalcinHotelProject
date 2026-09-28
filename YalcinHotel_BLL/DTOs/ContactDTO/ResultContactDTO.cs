using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.ContactDTO
{
    public class ResultContactDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Subject { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
