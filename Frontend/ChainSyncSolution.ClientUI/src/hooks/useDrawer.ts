import { useContext } from "react";
import { DrawerContexType } from "../models/types/DrawerType";
import { DrawerContext } from "../state/DrawerState";

export const useDrawer = (): DrawerContexType => {
    const context = useContext(DrawerContext);
    if (context === null) {
        throw new Error("useDrawer must be used within a DrawerProvider");
    }
    return context;
}