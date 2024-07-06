export interface DrawerContexType {
    drawerOpen: boolean;
    showDrawer: () => void;
    closeDrawer: () => void;
}

export interface DrawerContextProps {
    children: React.ReactNode;
}