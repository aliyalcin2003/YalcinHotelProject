using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.EmployeeDTO
{
    public class ResultEmployeeDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string NameSurname { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string ImageUrl { get; set; }

        public bool Status { get; set; }
        public int AboutId { get; set; }
    }
}
