//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NyamNyam.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bludo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bludo()
        {
            this.Rechept = new HashSet<Rechept>();
            this.ZakazAndBludo = new HashSet<ZakazAndBludo>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Name { get; set; }
        public string Opisanie { get; set; }
        public Nullable<double> Sum { get; set; }
        public byte[] Photo { get; set; }
        public string Sslka { get; set; }
        public Nullable<int> BaseServings { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rechept> Rechept { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZakazAndBludo> ZakazAndBludo { get; set; }
    }
}
