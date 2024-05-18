import React from 'react'
import './App.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import LoginScreen from './pages/Authfeatures/LoginScreen'

function App() {

  return (
    <React.Fragment>
      <BrowserRouter>
        <Routes>
          <Route index element={ <LoginScreen /> } />
        </Routes>
      </BrowserRouter>
    </React.Fragment>
  )
}

export default App
