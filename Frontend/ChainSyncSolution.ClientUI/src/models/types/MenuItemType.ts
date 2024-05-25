export interface MenuItemContextType {
    selectedMenuItem: number;
    HandleChangeItemMenu: () => void;
}

export interface MenuItemProps {
    children: React.ReactNode;
}