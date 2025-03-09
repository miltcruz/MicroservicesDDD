export interface Orders {
    orders: Order[];
}

export interface Order {
    id: string;
    customerId: string;
    amount: number;
    createdAt: string;
}
