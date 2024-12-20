﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendExamHub.Models;

public partial class BackendExamHubContext : DbContext
{
    public BackendExamHubContext(DbContextOptions<BackendExamHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MyOfficeAcpd> MyOfficeAcpds { get; set; }

    public virtual DbSet<MyOfficeExcuteionLog> MyOfficeExcuteionLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyOfficeAcpd>(entity =>
        {
            entity.HasKey(e => e.AcpdSid);

            entity.ToTable("MyOffice_ACPD");

            entity.Property(e => e.AcpdSid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACPD_SID");
            entity.Property(e => e.AcpdCname)
                .HasMaxLength(60)
                .HasColumnName("ACPD_Cname");
            entity.Property(e => e.AcpdEmail)
                .HasMaxLength(60)
                .HasColumnName("ACPD_Email");
            entity.Property(e => e.AcpdEname)
                .HasMaxLength(40)
                .HasColumnName("ACPD_Ename");
            entity.Property(e => e.AcpdLoginId)
                .HasMaxLength(30)
                .HasColumnName("ACPD_LoginID");
            entity.Property(e => e.AcpdLoginPwd)
                .HasMaxLength(60)
                .HasColumnName("ACPD_LoginPWD");
            entity.Property(e => e.AcpdMemo)
                .HasMaxLength(600)
                .HasColumnName("ACPD_Memo");
            entity.Property(e => e.AcpdNowDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ACPD_NowDateTime");
            entity.Property(e => e.AcpdNowId)
                .HasMaxLength(20)
                .HasColumnName("ACPD_NowID");
            entity.Property(e => e.AcpdSname)
                .HasMaxLength(40)
                .HasColumnName("ACPD_Sname");
            entity.Property(e => e.AcpdStatus)
                .HasDefaultValue((byte)0)
                .HasColumnName("ACPD_Status");
            entity.Property(e => e.AcpdStop)
                .HasDefaultValue(false)
                .HasColumnName("ACPD_Stop");
            entity.Property(e => e.AcpdStopMemo)
                .HasMaxLength(60)
                .HasColumnName("ACPD_StopMemo");
            entity.Property(e => e.AcpdUpddateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ACPD_UPDDateTime");
            entity.Property(e => e.AcpdUpdid)
                .HasMaxLength(20)
                .HasColumnName("ACPD_UPDID");
        });

        modelBuilder.Entity<MyOfficeExcuteionLog>(entity =>
        {
            entity.HasKey(e => e.DeLogAutoId).HasName("PK_MOTC_DataExchangeLog");

            entity.ToTable("MyOffice_ExcuteionLog");

            entity.Property(e => e.DeLogAutoId).HasColumnName("DeLog_AutoID");
            entity.Property(e => e.DeLogExDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DeLog_ExDateTime");
            entity.Property(e => e.DeLogExecutionInfo).HasColumnName("DeLog_ExecutionInfo");
            entity.Property(e => e.DeLogExecutionProgram)
                .HasMaxLength(120)
                .HasColumnName("DeLog_ExecutionProgram");
            entity.Property(e => e.DeLogGroupId).HasColumnName("DeLog_GroupID");
            entity.Property(e => e.DeLogIsCustomDebug).HasColumnName("DeLog_isCustomDebug");
            entity.Property(e => e.DeLogStoredPrograms)
                .HasMaxLength(120)
                .HasColumnName("DeLog_StoredPrograms");
            entity.Property(e => e.DeLogVerifyNeeded)
                .HasDefaultValue(false)
                .HasColumnName("DeLog_verifyNeeded");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
