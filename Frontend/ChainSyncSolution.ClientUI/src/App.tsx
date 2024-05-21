import React from 'react'
import './App.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import LoginScreen from './components/AuthComponents/LoginScreen'
import { ToastContainer, Zoom } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css';

function App() {

  return (
    <React.Fragment>
      <ToastContainer
        position="top-center"
        autoClose={1500}
        hideProgressBar={false}
        newestOnTop
        limit={1}
        transition={Zoom}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable={false}
        pauseOnHover={false}
        theme="light"
      />
      <BrowserRouter> 
        <Routes>
          <Route index element={ <LoginScreen /> } />
        </Routes>
      </BrowserRouter>
    </React.Fragment>
  )
}

export default App
