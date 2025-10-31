using onlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Shared.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public Order OrderId { get; set; }
    public decimal TotalPrice { get; set; }
}
