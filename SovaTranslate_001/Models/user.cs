//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SovaTranslate_001.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.translators = new HashSet<translator>();
            this.orders = new HashSet<order>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int roleid { get; set; }
        public string password { get; set; }
        public string cookies { get; set; }
        public string phoneNumber { get; set; }
    
        public virtual ICollection<translator> translators { get; set; }
        public virtual ICollection<order> orders { get; set; }
    }
}