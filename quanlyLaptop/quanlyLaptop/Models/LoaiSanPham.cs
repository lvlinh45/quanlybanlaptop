//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace quanlyLaptop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public int MaLoaiSP { get; set; }
        public string TenLoai { get; set; }
        public string Icon { get; set; }
        public string BiDanh { get; set; }
    
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
