import { FormInstance, FormProps } from "antd";
import { CustomersRegister, SuppliersRegister } from "../Register";

export interface RegisterContextType {
    HandleCustomerRegister: FormProps<CustomersRegister>['onFinish'];
    HandleSupplierRegister: FormProps<SuppliersRegister>['onFinish'];
    isLoading: boolean;
    form: FormInstance;
}

export interface RegisterProps {
    children: React.ReactNode;
}

export interface SupplierRegisterProps {
    randomNumber: number
}