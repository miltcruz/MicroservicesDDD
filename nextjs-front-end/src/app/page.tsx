'use client';

import { useState } from "react";
import { createOrder, getOrders } from "@/services/api";
import { Order } from "../types/order";

export default function Home() {
  const [customerId, setCustomerId] = useState("");
  const [amount, setAmount] = useState(0);
  const [orders, setOrders] = useState<Order[]>([]);

  const handleCreateOrder = async () => {
    const data = await createOrder(customerId, amount);

    if (data.error) {
      return alert(data.error);
    }

    alert("Order created!");
    fetchOrders();
  };

  const fetchOrders = async () => {
    const data = await getOrders();
    console.log("fetchOrders", data);

    // Ensure orders is an array before setting state
    if (data && Array.isArray(data.orders)) {
      setOrders(data.orders);
    } else {
      setOrders([]);
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center py-10">
      <div className="bg-white p-6 rounded-lg shadow-md w-full max-w-md">
        <h1 className="text-2xl font-bold text-center mb-4">Order System</h1>

        <input
          type="text"
          placeholder="Customer ID"
          className="w-full p-2 border border-gray-300 rounded mb-2"
          onChange={(e) => setCustomerId(e.target.value)}
        />

        <input
          type="number"
          placeholder="Amount"
          className="w-full p-2 border border-gray-300 rounded mb-4"
          onChange={(e) => setAmount(Number(e.target.value))}
        />

        <button
          onClick={handleCreateOrder}
          className="w-full bg-blue-500 text-white p-2 rounded hover:bg-blue-600 transition mb-2"
        >
          Create Order
        </button>

        <button
          onClick={fetchOrders}
          className="w-full bg-green-500 text-white p-2 rounded hover:bg-green-600 transition"
        >
          Load Orders
        </button>
      </div>

      <div className="mt-6 w-full max-w-md">
        <h2 className="text-xl font-semibold mb-3">Orders</h2>
        <ul className="bg-white shadow-md rounded-lg p-4">
          {orders.length > 0 ? (
            orders.map((order) => (
              <li
                key={order.id}
                className="border-b last:border-b-0 p-2 text-gray-700"
              >
                <span className="font-medium">{order.customerId}</span> -
                <span className="text-green-600 font-semibold"> ${order.amount}</span>
              </li>
            ))
          ) : (
            <p className="text-gray-500 text-center">No orders found.</p>
          )}
        </ul>
      </div>
    </div>
  );
}
