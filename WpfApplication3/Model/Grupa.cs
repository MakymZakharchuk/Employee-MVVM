//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApplication3.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grupa
    {
        public Grupa()
        {
            this.Employee = new HashSet<Employee>();
        }
    
        public int Id { get; set; }
        public string Grupa1 { get; set; }
    
        public virtual ICollection<Employee> Employee { get; set; }
    }
}