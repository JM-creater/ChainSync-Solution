import { createContext, useState } from "react";
import { Login, LoginProps } from "../models/Login";
import { Form, FormProps } from "antd";
import { loginUser } from "../services/AuthService";
import { showFailedToast } from "../utils";
import { LoginContextType } from "../models/types/LoginType";
import { useNavigate } from "react-router-dom";

export const LoginContext = createContext<LoginContextType | null>(null);

export const LoginProvider: React.FC<LoginProps> = ({ children }) => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [form] = Form.useForm();
    const navigate = useNavigate();

    const HandleLogin: FormProps<Login>['onFinish'] = async (values) => {
        setIsLoading(true);
        try {
            const response = await loginUser(values);
            if (response.status === 200) {
                switch(response.data.role) {
                    case 10: 
                        navigate('/home');
                        break
                    case 20:
                        navigate('/supplier-dashboard');
                        break
                    case 30:
                        navigate('/admin-dashboard');
                        break
                    default:
                        console.log("Unknown Role");
                        break
                }
                form.resetFields();
            } else {
                showFailedToast(response.data.message || "Failed to Login.");
            }
           
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };

    const onFinishFailed: FormProps<Login>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    const HandleValue = {
        HandleLogin, 
        onFinishFailed, 
        isLoading, 
        form
    };

    return (
        <LoginContext.Provider value={HandleValue}>
            {children}
        </LoginContext.Provider>
    )
}