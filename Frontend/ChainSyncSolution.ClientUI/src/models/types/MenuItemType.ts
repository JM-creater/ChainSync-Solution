export interface MenuItemContextType {
    selectedMenuItem: number;
    selectedCustomerRegister: number;
    selectedSupplierRegister: number;
    HandleChangeItemMenu: () => void;
    HandleChangeCustomerMenu: () => void;
    HandleChangeSupplierMenu: () => void;
    HandleCustomerRegisterCancel: () => void;
}

export interface MenuItemProps {
    children: React.ReactNode;
}