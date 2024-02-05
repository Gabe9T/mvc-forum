using System.ComponentModel.DataAnnotations;

namespace Forum.Models;

public class Post
{
  public int PostId { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public int TopicId { get; set; }
  public Topic Topic { get; set; }
  public List<UserPostJoinEntity> JoinEntities { get; }
}
