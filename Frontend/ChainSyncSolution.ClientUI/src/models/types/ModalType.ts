export interface ModalContextType {
    isModalOpen: boolean;
    showModal: () => void; 
    closeModal: () => void;
}

export interface ModalContextProps {
    children: React.ReactNode;
}
