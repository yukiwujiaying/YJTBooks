import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import { Layout } from '../../components/Layout';
import { Home } from '../../components/home/Home';


import './custom.css'
import AboutPage from '../../components/about/AboutPage';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Routes>
          <Route  path='/' element={<Home/>} />
          <Route path='/about' element={<AboutPage/>} />
        </Routes>
      </Layout>
    );
  }
}
