﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LIS.v10.Areas.Core.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CoreDBContainer : DbContext
    {
        public CoreDBContainer()
            : base("name=CoreDBContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ModInformation> ModInformations { get; set; }
        public virtual DbSet<userGroup> userGroups { get; set; }
        public virtual DbSet<userGroupAdmin> userGroupAdmins { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<userType> userTypes { get; set; }
        public virtual DbSet<userUserType> userUserTypes { get; set; }
        public virtual DbSet<userUserGroup> userUserGroups { get; set; }

        public System.Data.Entity.DbSet<LIS.v10.Areas.HIS10.Models.HisPhysician> HisPhysicians { get; set; }
    }
}
