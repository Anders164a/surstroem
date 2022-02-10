using System;
using System.Collections.Generic;

#nullable disable

namespace surstroem.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShippingAddress { get; set; }
        public int PayingAddress { get; set; }
        public int DeliveryStateId { get; set; }
        public int DeliveryTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual DeliveryState DeliveryState { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
