import React, { createContext, useState } from "react";
import { MenuItemContextType, MenuItemProps } from "../models/types/MenuItemType";

export const MenuContext = createContext<MenuItemContextType | null>(null);

export const MenuProvider: React.FC<MenuItemProps> = ({ children }) => {
    const [selectedMenuItem, setSelectedMenuItem] = useState<number>(0);
    const [selectedCustomerRegister, setSelectedCustomerRegister] = useState<number>(0);
    const [selectedSupplierRegister, setSelectedSupplierRegister] = useState<number>(1);

    const HandleChangeItemMenu = () => {
        setSelectedMenuItem(1);
    };

    const HandleChangeCustomerMenu = () => {
        setSelectedCustomerRegister(1);
    };

    const HandleChangeSupplierMenu = () => {
        setSelectedSupplierRegister(2);
    };

    const HandleCustomerRegisterCancel = () => {
        setSelectedCustomerRegister(0);
    };

    const HandleValue = {
        HandleChangeItemMenu,
        HandleChangeCustomerMenu,
        HandleChangeSupplierMenu,
        HandleCustomerRegisterCancel,
        selectedMenuItem,
        selectedCustomerRegister,
        selectedSupplierRegister
    };

    return (
        <MenuContext.Provider value={HandleValue}>
            {children}
        </MenuContext.Provider>
    )
}