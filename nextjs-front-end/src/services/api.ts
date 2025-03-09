import axios from "axios";
import { Orders } from "../types/order";

const ORDER_ENDPOINT = "/order";
const CREATE_ORDER = "/create";
const GET_ORDERS = "/read";
const api = axios.create({
    baseURL: 'http://localhost:5041/api', // base URL
    headers: {
        'Content-Type': 'application/json', // content type
    }
});

export const createOrder = async (customerId: string, amount: number) => {
    const response = await api.post(`${ORDER_ENDPOINT}${CREATE_ORDER}`, { customerId, amount });
    return response.data;
};

export const getOrders = async (): Promise<Orders> => {
    const response = await api.get<Orders>(`${ORDER_ENDPOINT}${GET_ORDERS}`);
    return response.data;
};