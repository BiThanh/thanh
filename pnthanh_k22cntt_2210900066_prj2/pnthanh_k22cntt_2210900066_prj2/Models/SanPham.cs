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
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.GioHang = new HashSet<GioHang>();
        }
    
        public int id { get; set; }
        public string tenSanPham { get; set; }
        public double gia { get; set; }
        public int soLuong { get; set; }
        public string moTa { get; set; }
        public Nullable<int> idDanhMuc { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }
    }
}
