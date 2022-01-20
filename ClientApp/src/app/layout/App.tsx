import React, { useCallback, useEffect } from 'react';
import { Route, Routes } from 'react-router';
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
import LoadingComponent from './LoadingComponent';
import Register from '../../components/account/Register';
import Login from '../../components/account/Login';
import { useAppDispatch } from '../store/configureStore';
import { fetchCurrentUser } from '../../components/account/accountSlice';
import { fetchFavouriteBookListAsync } from '../../components/FavouriteBookList/FavouriteBookListSlice';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Home from '../../components/home/Home';
import PrivateRoute from './PrivateRoute';


function App() {
  const dispatch= useAppDispatch();
  
  const[loading, setloading]= useState(true);
  const initApp= useCallback(async () =>{
    try
    {
      await dispatch(fetchCurrentUser());
      await dispatch(fetchFavouriteBookListAsync());
      
    }
    catch(error)
    {
      console.log(error);
    }
  }, [dispatch])

  useEffect(()=>{
    initApp().then(()=>setloading(false));
  },[initApp])
  
  // useEffect(()=>{
    
  //   console.log("setFavouriteBookList changed");

  //   const userId = getCookie('userId');
  //   if (userId){
  //     agent.FavouriteBookList.get()
  //          .then(favouriteBookList => setFavouriteBookList(favouriteBookList))
  //          .catch(error => console.log(error))
  //          .finally(() => setloading(false))
      
  //   } else {
  //     setloading(false);
  //   }
  // },[setFavouriteBookList])

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
     <ToastContainer position='bottom-right' hideProgressBar />
     <CssBaseline />
     <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
     <Container>
      <Routes>
        <Route path='/' element={<Home/>}/>
        <Route path='/catalog' element={<Catalog/>}/>
        <Route path='/catalog/:Id' element={<BookDetails/>}/>
        <Route path='/about' element={<AboutPage/>}/>
        <Route path='/server-error' element={<ServerError/>}/>
        <Route path='/FavouriteBookList' element={<PrivateRoute><FavouriteBookListPage/></PrivateRoute>} />
        <Route path='/login' element={<Login/>} />
        <Route path='/register' element={<Register/>} />
        <Route  element={<NotFound/>}/> 

       </Routes>
     </Container>

    </ThemeProvider> 
  
  );
}

export default App;