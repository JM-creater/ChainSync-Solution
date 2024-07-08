import { FormInstance, FormProps } from "antd";
import { CreateProduct, Product, UpdateProduct } from "../Product";

export interface ProductContextType {
    form: FormInstance;
    isLoading: boolean;
    products: Product[];
    selectedProducts: Product | null;
    onFinishCreateProduct: FormProps<CreateProduct>['onFinish'];
    onFinishUpdateProduct: FormProps<UpdateProduct>['onFinish'];
    onFinishFailed: FormProps<CreateProduct>['onFinishFailed'];
    onFinishUpdateFailed: FormProps<UpdateProduct>['onFinishFailed']
    fetchProductBySupplierId: (supplierId: string) => Promise<void>;
    fetchProductById: (productId: string) => Promise<void>;
    deleteProduct: (productId: string) => Promise<void>;
    searchProductByName: (productName: string) => Promise<void>;
    handleDeactivateActivateProduct: (productId: string, currentStatus: boolean) => Promise<void>;
}

export interface ProductProps {
    children: React.ReactNode;
}

