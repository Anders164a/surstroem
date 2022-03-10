using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DeliveryStateDto
    {
        public int Id { get; set; }
        public string State { get; set; }

        public DeliveryStateDto()
        { 
        
        }

        public DeliveryStateDto(Order order)
        {
            Id = order.DeliveryStateId;
            State = order.DeliveryState.State;
        }
    }
}
