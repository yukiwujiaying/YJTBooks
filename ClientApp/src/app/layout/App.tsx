import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import { Home } from '../../components/home/Home';
import AboutPage from '../../components/about/AboutPage';
import { Container, CssBaseline } from "@mui/material";
import Catalog from "../../components/catalog/Catalog";
import ProductDetails from "../../components/catalog/BookDetails";
import Header from "./Header";
import createTheme from '@mui/material/styles/createTheme';
import ThemeProvider from '@mui/material/styles/ThemeProvider';
import { useState } from "react";
import ServerError from '../errors/ServerError';
import NotFound from '../errors/NotFound';

function App() {
  const [darkMode, setDarkmode] = useState(false);
  const paletteType = darkMode ? 'dark' : 'light';
  const darkTheme = createTheme({
    palette: {
      mode: paletteType,   
      background: {
        default: paletteType==='light'?'#eaeaea' :'#121212'
      }
    }
  })

  function handleThemeChange(){
    setDarkmode(!darkMode);
  }

  return (
   <ThemeProvider theme={darkTheme}>
     <CssBaseline />
     <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
     <Container>
      <Routes>
        <Route path='/' element={<Home/>}/>
        <Route path='/catalog' element={<Catalog/>}/>
        <Route path='/catalog/:Id' element={<ProductDetails/>}/>
        <Route path='/about' element={<AboutPage/>}/>
        <Route path='/server-error' element={<ServerError/>}/>
        <Route  element={<NotFound/>}/>
       
       </Routes>
     </Container>

    </ThemeProvider> 
  
  );
}

export default App;