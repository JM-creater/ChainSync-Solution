import { useContext } from "react";
import { ModalContextType } from "../models/types/ModalType";
import { ModalContext } from "../state/ModalState";

export const useModal = (): ModalContextType => {
    const context = useContext(ModalContext);
    if (context === null) {
        throw new Error("useModal must be used within a ModalProvider");
    }
    return context;
}