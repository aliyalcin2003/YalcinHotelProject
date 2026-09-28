using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_Entity
{
    public class Slider : BaseEntity
    {
        [StringLength(300)]
        public string Title { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }
        public string ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }

        [StringLength(30)]
        public string Page { get; set; }
    }
}
