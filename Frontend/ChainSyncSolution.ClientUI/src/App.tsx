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

const App = () => {

  return (
    <React.Fragment>
      <ToastContainer {...toastConfig} />
      <BrowserRouter> 
        <Routes>
        <Route
          index
          element={
            <MenuProvider>
              <LoginProvider>
                <ModalProvider>
                  <LoginScreen />
                </ModalProvider>
              </LoginProvider>
            </MenuProvider>
          }
        />
        </Routes>
      </BrowserRouter>
    </React.Fragment>
  )
}

export default App
