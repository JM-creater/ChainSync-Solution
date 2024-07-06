import { useContext } from "react";
import { ProductContextType } from "../models/types/ProductType";
import { ProductContext } from "../state/ProductState";

export const useProduct = (): ProductContextType => {
    const context = useContext(ProductContext);
    if (context === null) {
        throw new Error("useProduct must be used within a ProductProvider");
    }
    return context;
} 