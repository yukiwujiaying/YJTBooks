import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import './styles.css'
import  Catalog  from "../../components/catalog/Catalog";
import HomePage from '../../components/home/HomePage';
import BookDetails from '../../components/catalog/BookDetails';
import AboutPage from '../../components/about/AboutPage';
import Contact from '../../components/contact/Contact';
import { ThemeProvider } from '@emotion/react';
import { createTheme, CssBaseline } from '@material-ui/core';
import Header from './Header';

export default function App() {
    const theme = createTheme({
        palette: {
            background: {
                default:  'light' ? '#eaeaea' : '#121212'
            }
        }
    })

      return (
          <ThemeProvider theme={theme}>
              <CssBaseline />
                 <Header />
            <Routes>
            <Route path='/' element={<HomePage />} />
            <Route path='/catalog' element={<Catalog />} />
            <Route path='/catalog/:id' element={<BookDetails />} />
            <Route path='/about' element={<AboutPage />} />
            <Route path='/contact' element={<Contact />} />
              </Routes>
          </ThemeProvider>
    );
  }

