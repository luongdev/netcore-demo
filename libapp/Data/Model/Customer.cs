using System.Collections.Generic;

namespace libapp.Data.Model
{
  public class Customer
  {
    public int CustomerId {get; set;}
    public string Name {get; set;}
    public virtual ICollection<Book> Books {get; set;}
  }
}