import React, { createContext, useState } from "react";
import { MenuItemContextType, MenuItemProps } from "../models/types/MenuItemType";
import { useNavigate } from "react-router-dom";
import OrderScreen from "../components/Place-Order/OrderScreen";
import { 
    BellOutlined, 
    HomeOutlined, 
    LogoutOutlined, 
    ShoppingCartOutlined 
} from "@ant-design/icons";
import NotificationScreen from "../components/Notify/NotificationScreen";
import HomeScreen from "../components/Landing/HomeScreen";

export const MenuContext = createContext<MenuItemContextType | null>(null);

export const MenuProvider: React.FC<MenuItemProps> = ({ children }) => {
    const [selectedMenuItem, setSelectedMenuItem] = useState<number>(0);
    const [selectedCustomerRegister, setSelectedCustomerRegister] = useState<number>(0);
    const [selectedSupplierRegister, setSelectedSupplierRegister] = useState<number>(1);
    const [selectedSupplierDashboard, setSelectedSupplierDashboard] = useState<number>(0);
    const [randomNumber, setRandomNumber] = useState<number>(0);
    const [selectNavMenu, setSelectedNavMenu] = useState<number>(0);
    const navigate = useNavigate();

    const HandleChangeDashboardSupplier = () => {
      setSelectedSupplierDashboard(1);
    }; 
  
    const HandleChangeItemMenu = () => {
      setSelectedMenuItem(1);
    };
  
    const HandleChangeCustomerMenu = () => {
      setSelectedCustomerRegister(1);
    };
  
    const HandleChangeSupplierMenu = () => {
      setSelectedSupplierRegister(2);
      setRandomNumber(Math.floor(1000000000 + Math.random() * 9000000000));
    };
  
    const HandleCustomerRegisterCancel = () => {
      window.location.reload();
    };
  
    const HandleSupplierRegisterCancel = () => {
      window.location.reload();
    };
  
    const HandleNavClick = (item: number) => {
      setSelectedNavMenu(item);
    };
  
    const HandleLogout = () => {
      navigate('/');
    };
  
    const menuItems = [
      {
        key: '0',
        label: <HomeOutlined />,
        onClick: () => HandleNavClick(0),
      },
      {
        key: '1',
        label: <ShoppingCartOutlined />,
        onClick: () => HandleNavClick(1),
      },
      {
        key: '2',
        label: <BellOutlined />,
        onClick: () => HandleNavClick(2),
      },
      {
        key: '3',
        label: <LogoutOutlined />,
        onClick: HandleLogout,
      },
    ];
  
    const HandleRenderComponent = () => {
      switch (selectNavMenu) {
        case 0:
          return <HomeScreen />;
        case 1:
          return <OrderScreen />;
        case 2:
          return <NotificationScreen />;
        default:
          return null;
      }
    };
  
    const HandleValue = {
      HandleChangeItemMenu,
      HandleChangeCustomerMenu,
      HandleChangeSupplierMenu,
      HandleCustomerRegisterCancel,
      HandleSupplierRegisterCancel,
      HandleRenderComponent,
      HandleNavClick,
      HandleChangeDashboardSupplier,
      selectedMenuItem,
      selectedCustomerRegister,
      selectedSupplierRegister,
      randomNumber,
      menuItems,
      selectNavMenu,
      selectedSupplierDashboard
    };
  
    return (
      <MenuContext.Provider value={HandleValue}>
        {children}
      </MenuContext.Provider>
    );
};