import { createContext, useState } from "react";
import { ModalContextProps, ModalContextType } from "../models/types/ModalType";

export const ModalContext = createContext<ModalContextType | null>(null);

export const ModalProvider: React.FC<ModalContextProps> = ({ children }) => {
    const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

    const showModal = () => setIsModalOpen(true);

    const closeModal = () => setIsModalOpen(false);

    const HandleValue = {
        closeModal, 
        showModal, 
        isModalOpen,
        setIsModalOpen
    };

    return (
        <ModalContext.Provider value={HandleValue}>
            {children}
        </ModalContext.Provider>
    );
};