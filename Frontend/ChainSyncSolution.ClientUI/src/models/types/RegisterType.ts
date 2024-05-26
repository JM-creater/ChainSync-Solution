import { FormProps } from "antd";
import { Register } from "../Register";

export interface RegisterContextType {
    HandleRegister: FormProps<Register>['onFinish'];
}

export interface RegisterProps {
    children: React.ReactNode;
}