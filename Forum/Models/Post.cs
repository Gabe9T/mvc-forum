using System.ComponentModel.DataAnnotations;

namespace Forum.Models;

public class Post
{
  public int PostId { get; set; }
  [Required]
  public string Title { get; set; }
  [Required]
  public string Body { get; set; }
  [Required]
  public int TopicId { get; set; }
  public Topic Topic { get; set; }
  public List<UserPostJoinEntity> JoinEntities { get; }
}
