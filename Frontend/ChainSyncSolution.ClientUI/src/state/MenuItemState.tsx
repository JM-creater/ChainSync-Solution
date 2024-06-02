import React, { createContext, useState } from "react";
import { MenuItemContextType, MenuItemProps } from "../models/types/MenuItemType";

export const MenuContext = createContext<MenuItemContextType | null>(null);

export const MenuProvider: React.FC<MenuItemProps> = ({ children }) => {
    const [selectedMenuItem, setSelectedMenuItem] = useState<number>(0);
    const [selectedCustomerRegister, setSelectedCustomerRegister] = useState<number>(0);
    const [selectedSupplierRegister, setSelectedSupplierRegister] = useState<number>(1);
    const [randomNumber, setRandomNumber] = useState<number>(0);

    const HandleChangeItemMenu = () => {
        setSelectedMenuItem(1);
    };

    const HandleChangeCustomerMenu = () => {
        setSelectedCustomerRegister(1);
    };

    const HandleChangeSupplierMenu = () => {
        setSelectedSupplierRegister(2);
        setRandomNumber(Math.floor(1000000000 + Math.random() * 9000000000));
    };

    const HandleCustomerRegisterCancel = () => {
        window.location.reload();
    };

    const HandleSupplierRegisterCancel = () => {
        window.location.reload();
    };


    const HandleValue = {
        HandleChangeItemMenu,
        HandleChangeCustomerMenu,
        HandleChangeSupplierMenu,
        HandleCustomerRegisterCancel,
        HandleSupplierRegisterCancel,
        selectedMenuItem,
        selectedCustomerRegister,
        selectedSupplierRegister,
        randomNumber
    };

    return (
        <MenuContext.Provider value={HandleValue}>
            {children}
        </MenuContext.Provider>
    )
}