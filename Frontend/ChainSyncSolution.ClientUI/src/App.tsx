import React from 'react'
import './App.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import LoginScreen from './components/AuthComponents/LoginScreen'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css';
import { ModalProvider } from './state/ModalState'
import { toastConfig } from './utils/toastConfig'
import { LoginProvider } from './state/LoginState'
import { MenuProvider } from './state/MenuItemState'
import { RegisterProvider } from './state/RegisterState'
import SupplierMainScreen from './components/Dashboard/SupplierMainScreen'
import AdminMainScreen from './components/Dashboard/AdminMainScreen'
import NotFoundScreen from './components/AuthComponents/common/NotFoundScreen'
import MainScreen from './components/Landing/MainScreen'
import { DrawerProvider } from './state/DrawerState'
import { ProductProvider } from './state/ProductState'
import { IdentityProvider } from './state/IdentityState'

const App = () => {

  return (
    <React.Fragment>
      <ToastContainer {...toastConfig} />
      <BrowserRouter>
        <Routes>
          <Route
            index
            element={
              <IdentityProvider>
                <RegisterProvider>
                  <MenuProvider>
                    <LoginProvider>
                      <ModalProvider>
                        <LoginScreen />
                      </ModalProvider>
                    </LoginProvider>
                  </MenuProvider>
                </RegisterProvider>
              </IdentityProvider>
            }
          />
          
          <Route path='/home' element={ 
            <IdentityProvider>
               <ModalProvider>
                <MenuProvider> 
                  <MainScreen/> 
                </MenuProvider> 
              </ModalProvider>
            </IdentityProvider>
            } 
          />

          <Route path='/supplier-dashboard' element={ 
            <IdentityProvider>
              <DrawerProvider>
               <ProductProvider>
                <MenuProvider>
                  <SupplierMainScreen/> 
                </MenuProvider>
              </ProductProvider>
              </DrawerProvider>
            </IdentityProvider>
          } />

          <Route path='/admin-dashboard' element={ <AdminMainScreen/> } />

          <Route path="*" element={<NotFoundScreen />} />
        </Routes>
      </BrowserRouter>
    </React.Fragment>
  )
}

export default App
