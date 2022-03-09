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
        public Address ShipAddress { get; set; }
        public Address PayAddress { get; set; }
        public DeliveryState DeliveryState { get; set; }
        public DeliveryType DeliveryType { get; set; }

        public OrderDto()
        {

        }

        public OrderDto(OrderProduct orderProduct)
        {
            Id = orderProduct.Order.;
            StreetName = user.Address.StreetName;
            HouseNumber = user.Address.HouseNumber;
            Floor = user.Address.Floor;
            Additional = user.Address.Additional;
            PostalCode = new PostalCodeDto(user.Address);
        }
    }
}
