import React, { createContext, useState } from "react";
import { MenuItemContextType, MenuItemProps } from "../models/types/MenuItemType";

export const MenuContext = createContext<MenuItemContextType | null>(null);

export const MenuProvider: React.FC<MenuItemProps> = ({ children }) => {
    const [selectedMenuItem, setSelectedMenuItem] = useState<number>(0);

    const HandleChangeItemMenu = () => {
        setSelectedMenuItem(1);
    };

    return (
        <MenuContext.Provider value={{ HandleChangeItemMenu, selectedMenuItem }}>
            {children}
        </MenuContext.Provider>
    )
}