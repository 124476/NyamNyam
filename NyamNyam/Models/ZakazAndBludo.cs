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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class ZakazAndBludo
    {
        public int Id { get; set; }
        public Nullable<int> BludoId { get; set; }
        public Nullable<int> ZakazId { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }

        [JsonIgnore]
        public virtual Bludo Bludo { get; set; }
        [JsonIgnore]
        public virtual Zakaz Zakaz { get; set; }
    }
}
