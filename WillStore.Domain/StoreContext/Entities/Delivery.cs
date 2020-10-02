using System;
using FluentValidator;
using WillStore.Domain.StoreContext.Enums;

namespace WillStore.Domain.StoreContext.Entities
{
    public class Delivery : Notifiable
    {
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }
        public Delivery(DateTime estimatedDeliveryDate)
        {
            this.CreateDate = DateTime.Now;
            this.EstimatedDate = estimatedDeliveryDate;
            this.Status = EDeliveryStatus.Waiting;
        }
        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;
        }
        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}