import { createContext, useState } from "react";
import { DrawerContexType } from "../models/types/DrawerType";
import { DrawerProps } from "antd";

export const DrawerContext = createContext<DrawerContexType | null>(null);

export const DrawerProvider: React.FC<DrawerProps> = ({ children }) => {

    const [drawerOpen, setDrawerOpen] = useState<boolean>(false);

    const showDrawer = () => {
        setDrawerOpen(true);
    };

    const closeDrawer = () => { 
        setDrawerOpen(false);
    };

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