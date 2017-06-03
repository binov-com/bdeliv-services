
import { Category } from "./category";
import { Tag } from "./tag";

export interface Product {
    id: number;
    category: Category;
    status: number;
    reference: string;
    name: string;
    tags: Tag[];
    updatedAt: string;
}

