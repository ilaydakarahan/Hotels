using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class CreateRoomDto
    {
        [Required(ErrorMessage ="Lütfen oda numarası giriniz")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen fiyat bilgisini yazınız.")]
        public int Price { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısını yazınız.")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen banyo sayısını yazınız.")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
