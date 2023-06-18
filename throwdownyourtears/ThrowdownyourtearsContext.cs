using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace throwdownyourtears;

public partial class ThrowdownyourtearsContext : DbContext
{
    public ThrowdownyourtearsContext()
    {
    }

    public ThrowdownyourtearsContext(DbContextOptions<ThrowdownyourtearsContext> options)
        : base(options)
    {
    }


    private static ThrowdownyourtearsContext instance;
    public static ThrowdownyourtearsContext GetInstance()
    {
        if (instance == null)
        {
            instance = new ThrowdownyourtearsContext();
        }
        return instance;
    }


    public virtual DbSet<Generalsale> Generalsales { get; set; }

    public virtual DbSet<Historybuy> Historybuys { get; set; }

    public virtual DbSet<Historysale> Historysales { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Stat> Stats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234512345;database=throwdownyourtears", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Generalsale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("generalsales");

            entity.HasIndex(e => e.Shopid, "FK_generalsales_shop_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Generalbuys).HasColumnName("generalbuys");
            entity.Property(e => e.Generalgain).HasColumnName("generalgain");
            entity.Property(e => e.Generalgain2).HasColumnName("generalgain2");
            entity.Property(e => e.Generalquantity).HasColumnName("generalquantity");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Shop).WithMany(p => p.Generalsales)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("FK_generalsales_shop_id");
        });

        modelBuilder.Entity<Historybuy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("historybuy");

            entity.HasIndex(e => e.Shopid, "FK_historybuy_shop_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Buys).HasColumnName("buys");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Productname)
                .HasMaxLength(255)
                .HasColumnName("productname");
            entity.Property(e => e.Productquantity).HasColumnName("productquantity");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Shop).WithMany(p => p.Historybuys)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("FK_historybuy_shop_id");
        });

        modelBuilder.Entity<Historysale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("historysale");

            entity.HasIndex(e => e.Shopid, "FK_historysale_shop_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Gain).HasColumnName("gain");
            entity.Property(e => e.Productname)
                .HasMaxLength(255)
                .HasColumnName("productname");
            entity.Property(e => e.Productquantity).HasColumnName("productquantity");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Shop).WithMany(p => p.Historysales)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("FK_historysale_shop_id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.Shopid, "FK_products_shop_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Minimum)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("minimum");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Productbuys)
                .HasDefaultValueSql("'0'")
                .HasColumnName("productbuys");
            entity.Property(e => e.Productgain)
                .HasDefaultValueSql("'0'")
                .HasColumnName("productgain");
            entity.Property(e => e.Productgain2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("productgain2");
            entity.Property(e => e.Productsales)
                .HasDefaultValueSql("'0'")
                .HasColumnName("productsales");
            entity.Property(e => e.PurchasePrice).HasDefaultValueSql("'0'");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Shop).WithMany(p => p.Products)
                .HasForeignKey(d => d.Shopid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_products_shop_id");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provider");

            entity.HasIndex(e => e.Productid, "FK_provider_products_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Telegram)
                .HasMaxLength(255)
                .HasColumnName("telegram");

            entity.HasOne(d => d.Product).WithMany(p => p.Providers)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_provider_products_id");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shop");

            entity.HasIndex(e => e.Iduser, "FK_shop_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("name");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Shops)
                .HasForeignKey(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_shop_user_id");
        });

        modelBuilder.Entity<Stat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("stats");

            entity.HasIndex(e => e.Shopid, "FK_stats_shop_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gain).HasColumnName("gain");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Shop).WithMany(p => p.Stats)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("FK_stats_shop_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
