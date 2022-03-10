﻿using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public AddressDto PayingAddress { get; set; }
        public DeliveryState DeliveryState { get; set; }
        public DeliveryType DeliveryType { get; set; }

        public OrderDto()
        {

        }

        public OrderDto(OrderProduct orderProduct)
        {
            Id = orderProduct.Order.Id;
            User = new UserDto(orderProduct.Order);
            ShippingAddress = new AddressDto(orderProduct.Order);
            PayingAddress = new AddressDto(orderProduct.Order);
            DeliveryState = new DeliveryStateDto(orderProduct.Order);
            DeliveryType = new DeliveryTypeDto(orderProduct.Order);
        }
    }
}
