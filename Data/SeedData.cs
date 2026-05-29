using Backend.Models;

namespace Backend.Data;

public class SeedData
{
    public static async Task Initialize(AppDbContext context)
    {
        if (context.Users.Any())
            return;

        // Categories

        var shoesCategory = new Category
        {
            Name = "Shoes",
            Description = "Sports shoes"
        };

        var phonesCategory = new Category
        {
            Name = "Phones",
            Description = "Smartphones"
        };

        context.Categories.AddRange(
            shoesCategory,
            phonesCategory
        );

        await context.SaveChangesAsync();

        // Users

        var user1 = new User
        {
            Username = "murad",
            Email = "murad@test.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(
            "123456"
        ),
            Role = "Customer"
        };

        var user2 = new User
        {
            Username = "john",
            Email = "john@test.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(
            "123456"
        ),
            Role = "Customer"
        };

        var user3 = new User
        {
            Username = "john",
            Email = "alley@test.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(
          "123456"
      ),
            Role = "Admin"
        };


        context.Users.AddRange(user1, user2, user3);

        await context.SaveChangesAsync();

        // Addresses

        var address1 = new Address
        {
            Country = "Azerbaijan",
            City = "Baku",
            Street = "Nizami Street",
            ZipCode = "AZ1000",
            UserId = user1.Id
        };

        var address2 = new Address
        {
            Country = "USA",
            City = "New York",
            Street = "5th Avenue",
            ZipCode = "10001",
            UserId = user2.Id
        };

        context.Addresses.AddRange(address1, address2);

        await context.SaveChangesAsync();

        // Products

        var product1 = new Product
        {
            Title = "Nike Air Max",
            Description = "Running shoes",
            Price = 300,
            Brand = "Nike",
            CategoryId = shoesCategory.Id
        };

        var product2 = new Product
        {
            Title = "iPhone 15",
            Description = "Apple smartphone",
            Price = 2500,
            Brand = "Apple",
            CategoryId = phonesCategory.Id
        };

        context.Products.AddRange(product1, product2);

        await context.SaveChangesAsync();

        // Product Images

        var image1 = new ProductImage
        {
            ImageUrl = "https://example.com/nike.jpg",
            ProductId = product1.Id
        };

        var image2 = new ProductImage
        {
            ImageUrl = "https://example.com/iphone.jpg",
            ProductId = product2.Id
        };

        context.ProductImages.AddRange(image1, image2);

        await context.SaveChangesAsync();

        // Inventory

        var inventory1 = new Inventory
        {
            Quantity = 50,
            ProductId = product1.Id
        };

        var inventory2 = new Inventory
        {
            Quantity = 20,
            ProductId = product2.Id
        };

        context.Inventories.AddRange(
            inventory1,
            inventory2
        );

        await context.SaveChangesAsync();

        // Reviews

        var review1 = new Review
        {
            Rating = 5,
            Comment = "Very comfortable shoes",
            UserId = user1.Id,
            ProductId = product1.Id
        };

        var review2 = new Review
        {
            Rating = 4,
            Comment = "Excellent phone",
            UserId = user2.Id,
            ProductId = product2.Id
        };

        context.Reviews.AddRange(review1, review2);

        await context.SaveChangesAsync();

        // Wishlist

        var wishlist1 = new Wishlist
        {
            UserId = user1.Id,
            ProductId = product2.Id
        };

        context.Wishlists.Add(wishlist1);

        await context.SaveChangesAsync();

        // Cart

        var cart1 = new Cart
        {
            UserId = user1.Id
        };

        context.Carts.Add(cart1);

        await context.SaveChangesAsync();

        // Cart Items

        var cartItem1 = new CartItem
        {
            Quantity = 2,
            CartId = cart1.Id,
            ProductId = product1.Id
        };

        context.CartItems.Add(cartItem1);

        await context.SaveChangesAsync();

        // Orders

        var order1 = new Order
        {
            UserId = user1.Id,
            TotalPrice = 600,
            Status = "Pending"
        };

        context.Orders.Add(order1);

        await context.SaveChangesAsync();

        // Order Items

        var orderItem1 = new OrderItem
        {
            Quantity = 2,
            Price = 300,
            OrderId = order1.Id,
            ProductId = product1.Id
        };

        context.OrderItems.Add(orderItem1);

        await context.SaveChangesAsync();

        // Payments

        var payment1 = new Payment
        {
            PaymentMethod = "Card",
            PaymentStatus = "Paid",
            TransactionId = Guid.NewGuid().ToString(),
            OrderId = order1.Id
        };

        context.Payments.Add(payment1);

        await context.SaveChangesAsync();
    }
}