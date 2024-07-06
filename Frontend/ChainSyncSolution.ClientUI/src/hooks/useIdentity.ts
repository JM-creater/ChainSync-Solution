import { useContext } from "react";
import { IdentityContextType } from "../models/types/IdentityType";
import { IndentityContext } from "../state/IdentityState";

export const useIdentity = (): IdentityContextType => {
    const context = useContext(IndentityContext);
    if (context === null) {
        throw new Error("useIdentity must be used within a IdentityProvider");
    }
    return context;
}