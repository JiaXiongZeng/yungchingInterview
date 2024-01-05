using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PseudoEstateAPI.Entities;

public partial class YungchingInterviewContext : DbContext
{
    public YungchingInterviewContext()
    {
    }

    public YungchingInterviewContext(DbContextOptions<YungchingInterviewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Estate> Estates { get; set; }

    public virtual DbSet<EstateType> EstateTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=..\\yungchingInterview.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.ToTable("agent");

            entity.HasIndex(e => e.AgentId, "IX_agent_agent_id").IsUnique();

            entity.HasIndex(e => e.AgentId, "idx_agent_agent_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgentId).HasColumnName("agent_id");
            entity.Property(e => e.CreateDtm).HasColumnName("create_dtm");
            entity.Property(e => e.CreateId).HasColumnName("create_id");
            entity.Property(e => e.CreateName).HasColumnName("create_name");
            entity.Property(e => e.DeleteDtm).HasColumnName("delete_dtm");
            entity.Property(e => e.DeleteId).HasColumnName("delete_id");
            entity.Property(e => e.DeleteName).HasColumnName("delete_name");
            entity.Property(e => e.Licenses).HasColumnName("licenses");
            entity.Property(e => e.ModifyDtm).HasColumnName("modify_dtm");
            entity.Property(e => e.ModifyId).HasColumnName("modify_id");
            entity.Property(e => e.ModifyName).HasColumnName("modify_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PhoneNo).HasColumnName("phone_no");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");

            entity.HasIndex(e => e.CustomerId, "IX_customer_customer_id").IsUnique();

            entity.HasIndex(e => e.CustomerId, "idx_customer_customer_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDtm).HasColumnName("create_dtm");
            entity.Property(e => e.CreateId).HasColumnName("create_id");
            entity.Property(e => e.CreateName).HasColumnName("create_name");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DeleteDtm).HasColumnName("delete_dtm");
            entity.Property(e => e.DeleteId).HasColumnName("delete_id");
            entity.Property(e => e.DeleteName).HasColumnName("delete_name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.ModifyDtm).HasColumnName("modify_dtm");
            entity.Property(e => e.ModifyId).HasColumnName("modify_id");
            entity.Property(e => e.ModifyName).HasColumnName("modify_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PhoneNo).HasColumnName("phone_no");
        });

        modelBuilder.Entity<Estate>(entity =>
        {
            entity.ToTable("estate");

            entity.HasIndex(e => e.EstateId, "idx_estate_estate_id").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.AgentId).HasColumnName("agent_id");
            entity.Property(e => e.BuildType).HasColumnName("build_type");
            entity.Property(e => e.CreateDtm).HasColumnName("create_dtm");
            entity.Property(e => e.CreateId).HasColumnName("create_id");
            entity.Property(e => e.CreateName).HasColumnName("create_name");
            entity.Property(e => e.DeleteDtm).HasColumnName("delete_dtm");
            entity.Property(e => e.DeleteId).HasColumnName("delete_id");
            entity.Property(e => e.DeleteName).HasColumnName("delete_name");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EstateId).HasColumnName("estate_id");
            entity.Property(e => e.ModifyDtm).HasColumnName("modify_dtm");
            entity.Property(e => e.ModifyId).HasColumnName("modify_id");
            entity.Property(e => e.ModifyName).HasColumnName("modify_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OnlineDtm).HasColumnName("online_dtm");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.SquareMeters).HasColumnName("square_meters");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
        });

        modelBuilder.Entity<EstateType>(entity =>
        {
            entity.ToTable("estate_type");

            entity.HasIndex(e => e.TypeId, "IX_estate_type_type_id").IsUnique();

            entity.HasIndex(e => e.TypeId, "idx_estate_type_type_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDtm).HasColumnName("create_dtm");
            entity.Property(e => e.CreateId).HasColumnName("create_id");
            entity.Property(e => e.CreateName).HasColumnName("create_name");
            entity.Property(e => e.DeleteDtm).HasColumnName("delete_dtm");
            entity.Property(e => e.DeleteId).HasColumnName("delete_id");
            entity.Property(e => e.DeleteName).HasColumnName("delete_name");
            entity.Property(e => e.Desc).HasColumnName("desc");
            entity.Property(e => e.IsEnable).HasColumnName("is_enable");
            entity.Property(e => e.ModifyDtm).HasColumnName("modify_dtm");
            entity.Property(e => e.ModifyId).HasColumnName("modify_id");
            entity.Property(e => e.ModifyName).HasColumnName("modify_name");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
