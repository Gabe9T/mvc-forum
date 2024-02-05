using System.ComponentModel.DataAnnotations;

namespace Forum.Models;

public class Topic
{ 
public string Title {get; set;}
public int TopicId {get; set;}
public List<Post> Posts{ get; set; }
}
