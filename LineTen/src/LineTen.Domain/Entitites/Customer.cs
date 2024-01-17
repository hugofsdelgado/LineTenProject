using System.ComponentModel.DataAnnotations;

namespace LineTen.Domain.Entitites
{
  public class Customer
  {
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public Customer() { }
    public Customer(int id, string firstName, string lastName, string phone, string email)
    {
      this.Id = id;
      this.FirstName = firstName; 
      this.LastName = lastName; 
      this.Phone = phone;
      this.Email = email;
    }
    public Customer(string firstName, string lastName, string phone, string email)
    {
      this.FirstName = firstName;
      this.LastName = lastName;
      this.Phone = phone;
      this.Email = email;

    }
  }
}
