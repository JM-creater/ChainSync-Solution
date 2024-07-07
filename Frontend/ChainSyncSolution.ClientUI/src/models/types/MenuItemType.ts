export interface MenuItemContextType {
    selectedMenuItem: number;
    selectedCustomerRegister: number;
    selectedSupplierRegister: number;
    randomNumber: number;
    menuItems: MenuItem[];
    selectNavMenu: number;
    selectedSupplierDashboard: number;
    selectedKeySupplier: string;
    HandleChangeItemMenu: () => void;
    HandleChangeCustomerMenu: () => void;
    HandleChangeSupplierMenu: () => void;
    HandleCustomerRegisterCancel: () => void;
    HandleSupplierRegisterCancel: () => void;
    HandleRenderComponent: () => JSX.Element | null;
    HandleNavClick: (item: number) => void;
    HandleSupplierNavClick: (item: string) => void;
    HandleChangeDashboardSupplier: () => void;
    HandleChangeKeySupplier: (e: { key: string }) => void; 
    HandleRenderContentSupplier: () => JSX.Element | null;
}

export interface MenuItemProps {
    children: React.ReactNode;
}

export interface MenuItem {
    key: string;
    label: React.ReactNode;
    onClick: () => void;
}