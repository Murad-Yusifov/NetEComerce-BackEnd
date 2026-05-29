using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

    public DbSet<User> Users { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<Inventory> Inventories { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Wishlist> Wishlists { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<CartItem> CartItems { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Payment> Payments { get; set; }

}