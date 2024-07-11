import { useContext } from "react";
import { MenuItemContextType } from "../models/types/MenuItemType";
import { MenuContext } from "../state/MenuItemState";

export const useMenuItem = (): MenuItemContextType => {
    const context = useContext(MenuContext);
    if (context === null) {
        throw new Error("useMenuItem must be used within a MenuItemProvider");
    }
    return context;
}