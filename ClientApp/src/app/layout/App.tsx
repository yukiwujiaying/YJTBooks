import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import { FetchData } from '../../components/FetchData';
import { Counter } from '../../components/Counter';
import './styles.css'
import  Catalog  from "../../components/catalog/Catalog";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
            <Routes>
                <Route path='/' element={<Catalog />} />
                <Route path='/counter' element={<Counter />} />
                <Route path='/fetch-data' element={<FetchData />} />
            </Routes>
    );
  }
}
