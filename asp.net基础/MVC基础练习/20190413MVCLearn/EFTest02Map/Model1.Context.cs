﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFTest02Map
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sqlPracticeEntities : DbContext
    {
        public sqlPracticeEntities()
            : base("name=sqlPracticeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bank> banks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<@class> classes { get; set; }
        public virtual DbSet<ContentInfo> ContentInfoes { get; set; }
        public virtual DbSet<scoreInfo> scoreInfoes { get; set; }
        public virtual DbSet<studentInfo> studentInfoes { get; set; }
        public virtual DbSet<subJect> subJects { get; set; }
        public virtual DbSet<userInfo> userInfoes { get; set; }
    }
}
