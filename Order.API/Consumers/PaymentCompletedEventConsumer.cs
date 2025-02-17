using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using Shared.Events;

namespace Order.API.Consumers
{
    public class PaymentCompletedEventConsumer : IConsumer<PaymentCompletedEvent>
    {
        private readonly OrderAPIDbContext _orderAPIDBContext;

        public PaymentCompletedEventConsumer(OrderAPIDbContext orderAPIDBContext)
        {
            _orderAPIDBContext = orderAPIDBContext;
        }

        public async Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            Order.API.Models.Entities.Order order=await _orderAPIDBContext.Orders.FirstOrDefaultAsync(o=>o.OrderId==context.Message.OrderId);
            order.OrderStatu = Models.Enums.OrderStatus.Completed;
            await _orderAPIDBContext.SaveChangesAsync();
        }
    }
}
