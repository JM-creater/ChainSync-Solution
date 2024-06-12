export interface ModalContextType {
    isModalOpen: boolean;
    setIsModalOpen: React.Dispatch<React.SetStateAction<boolean>>
    showModal: () => void; 
    closeModal: () => void;
}

export interface ModalContextProps {
    children: React.ReactNode;
}
