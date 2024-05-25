import { createContext, useState } from "react";
import { Login, LoginProps } from "../models/Login";
import { Form, FormProps } from "antd";
import { loginUser } from "../services/AuthService";
import { showSuccessToast } from "../utils";
import { LoginContextType } from "../models/types/LoginType";

export const LoginContext = createContext<LoginContextType | null>(null);

export const LoginProvider: React.FC<LoginProps> = ({ children }) => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [form] = Form.useForm();

    const HandleLogin: FormProps<Login>['onFinish'] = async (values) => {
        setIsLoading(true);
        try {
            const response = await loginUser(values);
            form.resetFields();
            showSuccessToast(response.message || "Login successful!"); 
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };

    const onFinishFailed: FormProps<Login>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return (
        <LoginContext.Provider value={{ HandleLogin, onFinishFailed, isLoading, form }}>
            {children}
        </LoginContext.Provider>
    )
}