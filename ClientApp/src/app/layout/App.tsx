import React, { Component, useEffect } from 'react';
import { Route, Routes } from 'react-router';
import { Home } from '../../components/home/Home';
import AboutPage from '../../components/about/AboutPage';
import { Container, CssBaseline } from "@mui/material";
import Catalog from "../../components/catalog/Catalog";
import BookDetails from "../../components/catalog/BookDetails";
import Header from "./Header";
import createTheme from '@mui/material/styles/createTheme';
import ThemeProvider from '@mui/material/styles/ThemeProvider';
import { useState } from "react";
import ServerError from '../errors/ServerError';
import NotFound from '../errors/NotFound';
import FavouriteBookListPage from '../../components/FavouriteBookList/FavouriteBookListPage';
import { useStoreContext } from '../context/StoreContext';
import { getCookie } from './util/util';
import agent from '../api/agent';
import LoadingComponent from './LoadingComponent';


function App() {
  const {setFavouriteBookList} = useStoreContext();
  const[loading, setloading]= useState(true);
  
  useEffect(()=>{
    
    console.log("setFavouriteBookList changed");

    const userId = getCookie('userId');
    if (userId){
      agent.FavouriteBookList.get()
           .then(favouriteBookList => setFavouriteBookList(favouriteBookList))
           .catch(error => console.log(error))
           .finally(() => setloading(false))
    } else {
      setloading(false);
    }
  },[setFavouriteBookList])

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
  if (loading) return <LoadingComponent message='Initialising app...'/>
  return (
   <ThemeProvider theme={darkTheme}>
     <CssBaseline />
     <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
     <Container>
      <Routes>
        <Route path='/' element={<Home/>}/>
        <Route path='/catalog' element={<Catalog/>}/>
        <Route path='/catalog/:Id' element={<BookDetails/>}/>
        <Route path='/about' element={<AboutPage/>}/>
        <Route path='/server-error' element={<ServerError/>}/>
        <Route path='/FavouriteBookList' element={<FavouriteBookListPage/>} />
        <Route  element={<NotFound/>}/>     
       </Routes>
     </Container>

    </ThemeProvider> 
  
  );
}

export default App;