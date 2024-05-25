import { useContext } from "react"
import { LoginContextType } from "../models/types/LoginType"
import { LoginContext } from "../state/LoginState"

export const useLogin = (): LoginContextType => {
    const context = useContext(LoginContext);
    if (context === null) {
        throw new Error("useLogin must be used within a ModalProvider");
    }
    return context;
} 