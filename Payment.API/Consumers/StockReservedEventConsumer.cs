﻿using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public StockReservedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            if (true)
            {
                PaymentCompletedEvent paymentCompletedEvent = new()
                {
                    OrderId=context.Message.OrderId,
                };

                _publishEndpoint.Publish(paymentCompletedEvent);

                Console.WriteLine("Ödeme Başarılı");
            }
            else
            {
                PaymentFailedEvent paymentFailedEvent = new()
                {
                    OrderId=context.Message.OrderId,
                    Message="Bakiye Yetersiz"
                };

                Console.WriteLine("Ödemee Başarısız");
            }

            return Task.CompletedTask;
        }
    }
}
