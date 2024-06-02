export interface MenuItemContextType {
    selectedMenuItem: number;
    selectedCustomerRegister: number;
    selectedSupplierRegister: number;
    randomNumber: number;
    HandleChangeItemMenu: () => void;
    HandleChangeCustomerMenu: () => void;
    HandleChangeSupplierMenu: () => void;
    HandleCustomerRegisterCancel: () => void;
    HandleSupplierRegisterCancel: () => void;
}

export interface MenuItemProps {
    children: React.ReactNode;
}