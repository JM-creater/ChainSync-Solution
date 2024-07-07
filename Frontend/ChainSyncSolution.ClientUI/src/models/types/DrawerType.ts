export interface DrawerContexType {
    drawerOpen: boolean;
    editDrawerOpen: boolean;
    showDrawer: () => void;
    closeDrawer: () => void;
    showEditDrawer: () => void;
    closeEditDrawer: () => void;
}

export interface DrawerContextProps {
    children: React.ReactNode;
}