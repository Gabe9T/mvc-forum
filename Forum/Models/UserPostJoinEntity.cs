namespace Forum.Models;

public class UserPostJoinEntity
{
  public int UserPostJoinEntityId { get; set;}
  public int PostId { get; set; }
  public Post Post { get; set; }
  public int UserId { get; set; }
  public User User { get; set; }
}
