import { Category } from "./category.model";
import { Picture } from "./picture.model";
import { Supplier } from "./supplier.model";

export interface Product{
    id: number,
    name: string,
    price: number,
    priceInput: number,
    sale: number,
    inventory: number,
    insurance: number,
    accessory: string,
    sensor: string,
    imageProcessor: string,
    screen: string,
    iso: string,
    shutterSpeed: string,
    description: string,
    categoryId: number,
    supplierId: number,
    countSaleProduct: number,
    supplier: Supplier,
    category: Category,
    pictures: Picture[]
}