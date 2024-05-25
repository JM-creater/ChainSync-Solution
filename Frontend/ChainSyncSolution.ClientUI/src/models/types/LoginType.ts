import { FormInstance, FormProps } from "antd";
import { Login } from "../Login";

export interface LoginContextType {
    isLoading: boolean;
    HandleLogin: FormProps<Login>['onFinish'];
    onFinishFailed: FormProps<Login>['onFinishFailed'];
    form: FormInstance;
}