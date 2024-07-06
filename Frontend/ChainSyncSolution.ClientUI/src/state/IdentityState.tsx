import { createContext, useEffect, useState } from "react";
import { IdentityContextType, IdentityProps } from "../models/types/IdentityType";
import { useLocation } from "react-router-dom";

export const IndentityContext = createContext<IdentityContextType | null>(null);

export const IdentityProvider: React.FC<IdentityProps> = ({ children }) => {
    const location = useLocation();
    const [supplierId, setSupplierId] = useState<string>('');

    useEffect(() => {
        const searchParams = new URLSearchParams(location.search);
        const supplierIdFromUrl = searchParams.get('supplierId');
        if (supplierIdFromUrl) {
            setSupplierId(supplierIdFromUrl);
        }
    }, [location]);

    const HandleValue = {
        supplierId,
        setSupplierId
    };

    return (
        <IndentityContext.Provider value={HandleValue}>
            {children}
        </IndentityContext.Provider>
    )
}