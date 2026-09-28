using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.AboutDTO
{
    public class ResultAboutDTO
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(250)]
        public string ImageUrl { get; set; }
    }
}
