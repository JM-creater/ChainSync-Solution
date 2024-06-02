import React, { createContext, useState } from "react";
import { RegisterContextType, RegisterProps } from "../models/types/RegisterType";
import { Form, FormProps } from "antd";
import { CustomersRegister, SuppliersRegister } from "../models/Register";
import { registerCstmr, registerSplr } from "../services/AuthService";
import { showFailedToast, showSuccessToast } from "../utils";

export const RegisterContext = createContext<RegisterContextType | null>(null);

export const RegisterProvider: React.FC<RegisterProps> = ({ children }) => {
    
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [form] = Form.useForm();

    const HandleCustomerRegister: FormProps<CustomersRegister>['onFinish'] = async (values) => {
        setIsLoading(true);
        
        try {
            const response = await registerCstmr(values);
            if (response.status === 200) {
                form.resetFields();
                showSuccessToast("Register successful!");
            } else  {
                showFailedToast(response.data.message || "Failed to Register.");
            }
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };

    const HandleSupplierRegister: FormProps<SuppliersRegister>['onFinish'] = async (values) => {
        setIsLoading(true);
        
        try {
            const formData = new FormData();

            Object.entries(values).forEach(([key, value]) => {
                if (key !== 'document' && value !== undefined) {
                    formData.append(key, value.toString());
                }
            })

            if (values.document && values.document.length > 0) {
                const file = values.document[0].originFileObj;
                if (file) {
                    formData.append('document', file);
                }
            }

            const response = await registerSplr(formData);
            
            if (response.status === 200) {
                form.resetFields();
                showSuccessToast("Register successful!");
            } else  {
                showFailedToast(response.data.message || "Failed to Register.");
            }
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };

    const HandleValues = {
        HandleCustomerRegister,
        HandleSupplierRegister,
        isLoading,
        form
    };

    return (
        <RegisterContext.Provider value={HandleValues}>
            {children}
        </RegisterContext.Provider>
    )

}