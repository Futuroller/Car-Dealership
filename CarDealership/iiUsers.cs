//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarDealership
{
    using System;
    using System.Collections.Generic;
    
    public partial class iiUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public iiUsers()
        {
            this.iiOrders = new HashSet<iiOrders>();
            this.iiOrders1 = new HashSet<iiOrders>();
        }
    
        public int id { get; set; }
        public string lastname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> id_prestige { get; set; }
        public int id_role { get; set; }
    
        public virtual iiPrestige iiPrestige { get; set; }
        public virtual iiRoles iiRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<iiOrders> iiOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<iiOrders> iiOrders1 { get; set; }
    }
}
