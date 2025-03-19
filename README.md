# Microservices DDD

## Overview

This project demonstrates a microservices-based architecture using Domain-Driven Design (DDD) principles. It includes two services: OrderService and PaymentService, communicating via an event-driven approach with MassTransit and RabbitMQ.

##  Technologies Used

- C# .NET (Minimal APIs)
- Entity Framework Core (In-Memory DB)
- MassTransit (Message Broker Integration)
- RabbitMQ (Event Bus)
- SignalR (Real-time Communication)
- Microsoft Azure (Cloud Services)
- Redis (Caching)
- Git & CI/CD Pipelines (Version Control & Deployment)


## Setup & Running

Clone the Repository

      git clone https://github.com/miltcruz/MicroservicesDDD
      cd microservices-ddd

Start Dependencies (RabbitMQ & Redis) with Docker

      docker compose up -d --build

Verify Communication

Once running, create an order by making a POST request:

      curl -X POST "http:http://localhost:5001/api/order/create" -H "Content-Type: application/json" -d '{"customerId":"123", "amount": 100.50}'


## License

This project is licensed under the MIT License.
