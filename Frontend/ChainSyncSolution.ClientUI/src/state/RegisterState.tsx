import React, { createContext } from "react";
import { RegisterContextType, RegisterProps } from "../models/types/RegisterType";
import { FormProps } from "antd";
import { Register } from "../models/Register";

export const RegisterContext = createContext<RegisterContextType | null>(null);

export const RegisterProvider: React.FC<RegisterProps> = ({ children }) => {

    const HandleRegister: FormProps<Register>['onFinish'] = async (values) => {
        console.log('Received values of form: ', values);
    };

    const HandleValues = {
        HandleRegister,
    };

    return (
        <RegisterContext.Provider value={HandleValues}>
            {children}
        </RegisterContext.Provider>
    )

}