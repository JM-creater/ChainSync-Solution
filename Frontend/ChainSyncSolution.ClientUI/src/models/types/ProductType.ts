import { FormInstance, FormProps } from "antd";
import { CreateProduct } from "../Product";

export interface ProductContextType {
    form: FormInstance;
    isLoading: boolean;
    onFinishCreateProduct: FormProps<CreateProduct>['onFinish'];
    onFinishFailed: FormProps<CreateProduct>['onFinishFailed'];
}

export interface ProductProps {
    children: React.ReactNode;
}