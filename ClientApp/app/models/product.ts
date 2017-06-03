
import { Category } from "./category";
import { User } from "./user";

export interface Product {
    id: number;
    category: Category;
    status: boolean;
    reference: string;
    name: string;
    users: User[];
    updatedAt: string;
}

