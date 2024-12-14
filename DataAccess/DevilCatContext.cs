using Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public partial class DevilCatContext : DbContext
{
    public DevilCatContext()
    {
    }

    public DevilCatContext(DbContextOptions<DevilCatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DevilCat;Persist Security Info=True;User ID=sa;Password=1;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Phonenumber).HasName("PK__account__622BF0C34F04D03D");

            entity.ToTable("account");

            entity.HasIndex(e => e.Phonenumber, "UQ__account__622BF0C2F6A54E3D").IsUnique();

            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Password)
                .HasMaxLength(23)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__account__role_id__5812160E");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cart__3213E83F708C7D8A");

            entity.ToTable("cart");

            entity.HasIndex(e => e.Id, "UQ__cart__3213E83EE510E30B").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.ProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UserId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cart__product_id__60A75C0F");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cart__user_id__5FB337D6");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83F4DE57576");

            entity.ToTable("category");

            entity.HasIndex(e => e.Id, "UQ__category__3213E83E35BF0C32").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__conversa__3213E83F052169A5");

            entity.ToTable("conversation");

            entity.HasIndex(e => e.Id, "UQ__conversa__3213E83E183BD383").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Receiver)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("receiver");
            entity.Property(e => e.Sender)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("sender");

            entity.HasOne(d => d.ReceiverNavigation).WithMany(p => p.ConversationReceiverNavigations)
                .HasForeignKey(d => d.Receiver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conversat__recei__6383C8BA");

            entity.HasOne(d => d.SenderNavigation).WithMany(p => p.ConversationSenderNavigations)
                .HasForeignKey(d => d.Sender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conversat__sende__619B8048");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__message__3213E83F6A6595B7");

            entity.ToTable("message");

            entity.HasIndex(e => e.Id, "UQ__message__3213E83EDF833C5F").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Conversation)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("conversation");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("message");

            entity.HasOne(d => d.ConversationNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.Conversation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message__convers__628FA481");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order__3213E83FF44BA2EC");

            entity.ToTable("order");

            entity.HasIndex(e => e.Id, "UQ__order__3213E83EFC048D15").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .HasColumnName("status");
            entity.Property(e => e.UserId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order__product_i__5EBF139D");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order__user_id__5DCAEF64");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83FC41D0364");

            entity.ToTable("product");

            entity.HasIndex(e => e.Id, "UQ__product__3213E83E1C68F4C2").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.InStock).HasColumnName("in_stock");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductImg)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("product_img");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product__categor__59FA5E80");

            entity.HasOne(d => d.ProductImgNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductImg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product__product__5AEE82B9");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F0377B0ED");

            entity.ToTable("product_detail");

            entity.HasIndex(e => e.Id, "UQ__product___3213E83EBEA57ABB").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.BackImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("back_img");
            entity.Property(e => e.DetailImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("detail_img");
            entity.Property(e => e.MainImg)
                .HasMaxLength(255)
                .HasColumnName("main_img");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__review__3213E83F89379A83");

            entity.ToTable("review");

            entity.HasIndex(e => e.Id, "UQ__review__3213E83E5B99B18E").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("product_id");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.UserId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__review__product___5CD6CB2B");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__review__user_id__5BE2A6F2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F37A3034B");

            entity.ToTable("role");

            entity.HasIndex(e => e.Id, "UQ__role__3213E83EF283D65D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FCBA56604");

            entity.ToTable("user");

            entity.HasIndex(e => e.Id, "UQ__user__3213E83EA78B88B9").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__user__B43B145FE0FE0E1E").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .HasColumnName("address");
            entity.Property(e => e.Avatar)
                .HasMaxLength(100)
                .HasColumnName("avatar");
            entity.Property(e => e.Birth).HasColumnName("birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.UAccount).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.Phone)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__phone__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
