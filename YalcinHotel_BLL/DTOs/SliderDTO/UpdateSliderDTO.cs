using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YalcinHotel_BLL.DTOs.SliderDTO
{
    public class UpdateSliderDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Baslik zorunludur.")]
        [StringLength(300)]
        public string Title { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Ana gorsel icin URL giriniz.")]
        [Url(ErrorMessage = "Gecerli bir gorsel URL'si giriniz.")]
        public string ImageUrl1 { get; set; }

        [Url(ErrorMessage = "Gecerli bir gorsel URL'si giriniz.")]
        public string? ImageUrl2 { get; set; }

        [Required(ErrorMessage = "Sayfa secimi zorunludur.")]
        [StringLength(30)]
        public string Page { get; set; }

    }
}
