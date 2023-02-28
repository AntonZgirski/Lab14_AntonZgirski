using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CodeFirst.Models
{
  public class Person
  {
    [Key]
    public int PersonId{ get; set; }
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string SecondName { get; set; }
    [DataMember]
    public DateTime  Birthday { get; set; }
  }
}
