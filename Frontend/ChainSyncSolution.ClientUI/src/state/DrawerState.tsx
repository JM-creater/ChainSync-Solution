import { createContext, useState } from "react";
import { DrawerContexType } from "../models/types/DrawerType";
import { DrawerProps, Form } from "antd";

export const DrawerContext = createContext<DrawerContexType | null>(null);

export const DrawerProvider: React.FC<DrawerProps> = ({ children }) => {

    const [drawerOpen, setDrawerOpen] = useState<boolean>(false);
    const [formDrawer] = Form.useForm(); 

    const showDrawer = () => {
        setDrawerOpen(true);
    }

    const closeDrawer = () => { 
        setDrawerOpen(false);
        formDrawer.resetFields();
    }

    const HandleValue = {
        drawerOpen,
        showDrawer,
        closeDrawer
    };

    return (
        <DrawerContext.Provider value={HandleValue}>
            {children}
        </DrawerContext.Provider>
    )
}