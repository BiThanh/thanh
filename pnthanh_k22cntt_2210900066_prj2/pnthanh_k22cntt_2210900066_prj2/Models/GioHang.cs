//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pnthanh_k22cntt_2210900066_prj2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GioHang
    {
        public int id { get; set; }
        public Nullable<int> idKhachHang { get; set; }
        public Nullable<int> idSanPham { get; set; }
        public int soLuong { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
