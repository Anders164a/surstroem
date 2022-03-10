using API.Dtos;
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
        public int ShippingAddressId { get; set; }
        public int PayingAddressId { get; set; }
        public int DeliveryStateId { get; set; }
        public int DeliveryTypeId { get; set; }

        public virtual UserDto User { get; set; }
        public virtual AddressDto ShippingAddress { get; set; } 
        public virtual AddressDto PayingAddress { get; set; } 
        public virtual DeliveryState DeliveryState { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
