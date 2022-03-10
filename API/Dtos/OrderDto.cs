using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public User User { get; set; }
        public Address ShippingAddress { get; set; }
        public Address PayingAddress { get; set; }
        public DeliveryState DeliveryState { get; set; }
        public DeliveryType DeliveryType { get; set; }

        public OrderDto()
        {

        }

        public OrderDto(OrderProduct orderProduct)
        {
            Id = orderProduct.Order.Id;
            User = orderProduct.Order.User;
            ShippingAddress = orderProduct.Order.ShippingAddress;
            PayingAddress = orderProduct.Order.PayingAddress;
            DeliveryState = orderProduct.Order.DeliveryState;
            DeliveryType = orderProduct.Order.DeliveryType;
        }
    }
}
