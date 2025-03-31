using TDSPG.API.Domain.Enums;

namespace TDSPG.API.Domain.Entity
{
    internal class Order : Audit, IEntity
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid EstablishmentId { get; private set; }
        public decimal Total { get; private set; }
        public OrderStatus Status { get; private set; }
        public Order(Guid customerId, Guid establishmentId, decimal total)
        {
            CustomerId = customerId;
            EstablishmentId = establishmentId;
            Total = total;
            Status = OrderStatus.Pending;
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }
        public override string GetInfo()
        {
            return $"Pedido criado por {UserCreated} - {CreatedAt}";
        }
        public string GetInfo2()
        {
            return $"Pedido criado por {UserCreated} - {CreatedAt}";
        }
    }
}
