import { useContext } from "react";
import { RegisterContextType } from "../models/types/RegisterType";
import { RegisterContext } from "../state/RegisterState";

export const useRegister = (): RegisterContextType => {
    const context = useContext(RegisterContext);
    if (context === null) {
        throw new Error("useRegister must be used within a ModalProvider");
    }
    return context;
}