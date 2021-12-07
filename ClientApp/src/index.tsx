import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './app/layout/App';
import registerServiceWorker from './registerServiceWorker';


const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter >
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();
