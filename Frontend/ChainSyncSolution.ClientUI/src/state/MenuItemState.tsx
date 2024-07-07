import React, { createContext, useEffect, useState } from "react";
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
import SupplierDashboardScreen from "../components/Dashboard/SupplierDashboardScreen";
import ProductsScreen from "../components/Products/ProductsScreen";
import PendingScreen from "../components/Place-Order/Order-Status/Pending-Order/PendingScreen";
import ProcessingScreen from "../components/Place-Order/Order-Status/Processing-Order/ProcessingScreen";
import ReadyForPickUpScreen from "../components/Place-Order/Order-Status/ReadyForPickUp-Order/ReadyForPickUpScreen";
import CompletedScreen from "../components/Place-Order/Order-Status/Completed-Order/CompleteScreen";
import CanceledScreen from "../components/Place-Order/Order-Status/Canceled-Order/CanceledScreen";
import DeniedScreen from "../components/Place-Order/Order-Status/Denied-Order/DeniedScreen";
import InventoryScreen from "../components/Inventories/InventoryScreen";
import ReportsScreen from "../components/Reports/ReportsScreen";
import { useIdentity } from "../hooks/useIdentity";

export const MenuContext = createContext<MenuItemContextType | null>(null);

export const MenuProvider: React.FC<MenuItemProps> = ({ children }) => {
    const [selectedMenuItem, setSelectedMenuItem] = useState<number>(0);
    const [selectedCustomerRegister, setSelectedCustomerRegister] = useState<number>(0);
    const [selectedSupplierRegister, setSelectedSupplierRegister] = useState<number>(1);
    const [selectedSupplierDashboard, setSelectedSupplierDashboard] = useState<number>(0);
    const [randomNumber, setRandomNumber] = useState<number>(0);
    const [selectNavMenu, setSelectedNavMenu] = useState<number>(0);
    const [selectedKeySupplier, setSelectedKeySupplier] = useState<string>('1');
    const navigate = useNavigate();
    const { supplierId } = useIdentity();

    const updateDocumentTitle = (title: string) => {
      document.title = title;
    };

    useEffect(() => {
      const titles: { [key: string]: string } = {
        '1': 'Dashboard - ChainSync',
        '2': 'Products - ChainSync',
        '3': 'Pending Orders - ChainSync',
        '4': 'Processing Orders - ChainSync',
        '5': 'Ready for Pick Up Orders - ChainSync',
        '6': 'Completed Orders - ChainSync',
        '7': 'Canceled Orders - ChainSync',
        '8': 'Denied Orders - ChainSync',
        '9': 'Inventory - ChainSync',
        '10': 'Reports - ChainSync'
      };
      updateDocumentTitle(titles[selectedKeySupplier]);
    }, [selectedKeySupplier]);

    const HandleChangeKeySupplier = (e: { key: string }) => {
      setSelectedKeySupplier(e.key);
    };

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

    const HandleSupplierNavClick = (item: string) => {
      setSelectedKeySupplier(item);
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

    const HandleRenderContentSupplier = () => {
      switch (selectedKeySupplier) {
        case '1':
          return <SupplierDashboardScreen/>;
        case '2':
          return <ProductsScreen supplierId={supplierId} />;
        case '3':
          return <PendingScreen/>;
        case '4':
          return <ProcessingScreen/>;
        case '5':
          return <ReadyForPickUpScreen/>;
        case '6':
          return <CompletedScreen/>;
        case '7':
          return <CanceledScreen/>;
        case '8':
          return <DeniedScreen/>;
        case '9':
          return <InventoryScreen/>;
        case '10':
          return <ReportsScreen/>;
        default:
          return null;
      }
    };
  
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
      HandleChangeKeySupplier,
      HandleRenderContentSupplier,
      HandleSupplierNavClick,
      selectedMenuItem,
      selectedCustomerRegister,
      selectedSupplierRegister,
      randomNumber,
      menuItems,
      selectNavMenu,
      selectedSupplierDashboard,
      selectedKeySupplier
    };
  
    return (
      <MenuContext.Provider value={HandleValue}>
        {children}
      </MenuContext.Provider>
    );
};