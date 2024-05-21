import { FormProps } from "antd";
import { User } from "../models/User";
import { loginUser } from "../services/AuthService";
import { showSuccessToast } from "../utils";

export const userLogin = () => {
    const HandleLogin: FormProps<User>['onFinish'] = async (values) => {
        try {
            const response = await loginUser(values);
            showSuccessToast(response.message || "Login successful!"); 
        } catch (error) {
            console.log(error);
        }
    };

    const onFinishFailed: FormProps<User>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    return {
        HandleLogin,
        onFinishFailed
    }
} 