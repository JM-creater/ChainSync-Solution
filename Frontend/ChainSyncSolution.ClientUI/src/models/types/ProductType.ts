import { FormInstance, FormProps } from "antd";
import { CreateProduct, Product } from "../Product";

export interface ProductContextType {
    form: FormInstance;
    isLoading: boolean;
    products: Product[];
    onFinishCreateProduct: FormProps<CreateProduct>['onFinish'];
    onFinishFailed: FormProps<CreateProduct>['onFinishFailed'];
    fetchProductBySupplierId: (supplierId: string) => Promise<void>;
}

export interface ProductProps {
    children: React.ReactNode;
}

