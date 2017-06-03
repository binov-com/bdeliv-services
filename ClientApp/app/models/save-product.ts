
export interface SaveProduct {
    id: number;
    categoryId: number;
    status: boolean;
    reference: string;
    name: string;
    users: number[];
}