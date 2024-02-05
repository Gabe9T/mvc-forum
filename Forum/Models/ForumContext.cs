using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Forum.Models;
public class ForumContext : DbContext
{
  public DbSet<Topic> Topics { get; set; }
  public DbSet<User> Users { get; set; }

  public DbSet<Post> Posts { get; set; }

  public ForumContext(DbContextOptions options) : base(options) { }

}
