export interface IdentityContextType {
    supplierId: string;
    setSupplierId: React.Dispatch<React.SetStateAction<string>>
}

export interface IdentitySupplierProps {
    supplierId: string;
}

export interface IdentityProps {
    children: React.ReactNode;
}