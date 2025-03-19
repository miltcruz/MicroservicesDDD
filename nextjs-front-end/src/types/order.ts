export interface Orders {
    orders: Order[];
}

export interface Order {
    id: string;
    customerId: string;
    amount: number;
    isPaymentSuccessful: boolean;
    createdAt: Date;
    updateddAt: Date;
}