//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dogmaAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class dog
    {
        public int id { get; set; }
        public int OwnerId { get; set; }
        public string breed { get; set; }
        public string vetOffice { get; set; }
        public string vetPhone { get; set; }
        public string photos { get; set; }
        public string privateNotes { get; set; }
        public string sharedNotes { get; set; }
        public string etype { get; set; }
        public bool altered { get; set; }
    }
}
