﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PHDS.Entities.Edmx
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PinhuaEntities : DbContext
    {
        public PinhuaEntities()
            : base("name=PinhuaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<发货> 发货 { get; set; }
        public virtual DbSet<人员档案> 人员档案 { get; set; }
        public virtual DbSet<考勤卡号变动> 考勤卡号变动 { get; set; }
        public virtual DbSet<打卡登记> 打卡登记 { get; set; }
        public virtual DbSet<ES_Tmp> ES_Tmp { get; set; }
        public virtual DbSet<ES_RepCase> ES_RepCase { get; set; }
        public virtual DbSet<发货_DETAIL> 发货_DETAIL { get; set; }
        public virtual DbSet<往来单位> 往来单位 { get; set; }
        public virtual DbSet<物料登记> 物料登记 { get; set; }
        public virtual DbSet<业务类型> 业务类型 { get; set; }
        public virtual DbSet<对账结算_主表> 对账结算_主表 { get; set; }
        public virtual DbSet<收款单> 收款单 { get; set; }
        public virtual DbSet<收货> 收货 { get; set; }
        public virtual DbSet<收货_D> 收货_D { get; set; }
        public virtual DbSet<付款单> 付款单 { get; set; }
    }
}
