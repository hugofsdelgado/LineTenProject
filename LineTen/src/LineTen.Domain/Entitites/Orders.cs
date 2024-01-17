using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace LineTen.Domain.Entitites
{
  public class Orders
  {
    [Key, Column(Order = 0)]
    public int ProductId { get; set; }
    [Key, Column(Order = 1)] 
    public int CustomerId { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public enum OrderStatus { 
      ordered = 1,
      inProgress = 2,
      Done = 3
    }
    public Orders() { }
    public Orders(int productId, int customerId, OrderStatus status, DateTime createdAt, DateTime updatedAt)
    {
      this.ProductId = productId;
      this.CustomerId = customerId;
      this.Status = status;
      this.CreatedDate = createdAt;
      this.UpdatedDate = updatedAt;
    }
  }


}
