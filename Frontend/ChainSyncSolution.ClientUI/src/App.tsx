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
import LandingScreen from './components/Landing/LandingScreen'
import Dashboard_Supplier from './components/Dashboard/Dashboard_Supplier'
import Dashboard_Admin from './components/Dashboard/Dashboard_Admin'
import NotFoundScreen from './components/AuthComponents/common/NotFoundScreen'

const App = () => {

  return (
    <React.Fragment>
      <ToastContainer {...toastConfig} />
      <BrowserRouter>
        <Routes>
          <Route
            index
            element={
             <RegisterProvider>
              <MenuProvider>
                <LoginProvider>
                  <ModalProvider>
                    <LoginScreen />
                  </ModalProvider>
                </LoginProvider>
              </MenuProvider>
             </RegisterProvider>
            }
          />
          <Route path='/home' element={ <LandingScreen/> } />

          <Route path='/supplier-dashboard' element={ <Dashboard_Supplier/> } />

          <Route path='/admin-dashboard' element={ <Dashboard_Admin/> } />

          <Route path="*" element={<NotFoundScreen />} />
        </Routes>
      </BrowserRouter>
    </React.Fragment>
  )
}

export default App
