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
    
    public partial class queue
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdTranslator { get; set; }
        public double cost { get; set; }
    
        public virtual order order { get; set; }
        public virtual translator translator { get; set; }
    }
}
