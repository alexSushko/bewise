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
    
    public partial class document
    {
        public int Id { get; set; }
        public string pathToDoc { get; set; }
        public Nullable<int> conuntOfSymbols { get; set; }
        public Nullable<int> idOrder { get; set; }
        public string pathToDocView { get; set; }
        public Nullable<bool> isTranslate { get; set; }
    
        public virtual order order { get; set; }
    }
}
