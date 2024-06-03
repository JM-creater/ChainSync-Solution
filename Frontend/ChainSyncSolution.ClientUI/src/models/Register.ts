export interface CustomersRegister {
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    password: string;
    gender: string;
    companyName: string;
    address: string;
}

export interface SuppliersRegister {
    supplierId: string;
    email: string;
    phoneNumber: string;
    password: string;
    companyName: string;
    address: string;
    document: FileType[];
    bizLicenseNumber: string;
}

export interface FileType {
    uid: string;
    name: string;
    status: string;
    originFileObj: File;
}


