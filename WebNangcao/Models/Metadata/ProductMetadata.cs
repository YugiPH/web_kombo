using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNangcao.Models.Metadata
{
    public class ProductMetadata
    {
        public int Id { get; set; }
        public string Anh { get; set; }
        [Required(ErrorMessage ="Tên không được để trống ")]
        public string TenSP { get; set; }
        
        public Nullable<int> DanhMucId { get; set; }
        [Required(ErrorMessage = "Đơn giá không được để trống ")]
        public Nullable<double> DonGia { get; set; }
        public Nullable<System.DateTime> NgayBan { get; set; }
    }
}