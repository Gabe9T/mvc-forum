using System.ComponentModel.DataAnnotations;

namespace Forum.Models;

public class User
{  
  public int UserId { get; set; }
  [Required]
  public string Username {get; set;}
  public List<UserPostJoinEntity> JoinEntities { get; }
}
