export interface Product {
    productName: string;
    description: string;
    supplierId: string;
    phoneNumber: string;
    price: number;
    productImage: string;
    quantityOnHand: number;
    isActive: boolean;
}

export interface CreateProduct {
    productName: string;
    description: string;
    supplierId: string;
    phoneNumber: string;
    price: number;
    productImage: FileType[];
    quantityOnHand: number;
}

export interface FileType {
    uid: string;
    name: string;
    status: string;
    originFileObj: File;
}
