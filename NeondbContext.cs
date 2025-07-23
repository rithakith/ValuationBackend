using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ValuationBackend;

public partial class NeondbContext : DbContext
{
    public NeondbContext(DbContextOptions<NeondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PastValuationsLa> PastValuationsLas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PastValuationsLa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PastValuationsLA_temp");

            entity.ToTable("PastValuationsLA");

            entity.HasIndex(e => e.MasterFileId, "IX_PastValuationsLA_MasterFileId");

            entity.HasIndex(e => e.ReportId, "IX_PastValuationsLA_ReportId");

            entity.Property(e => e.FileNoGndivision).HasColumnName("FileNoGNDivision");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
