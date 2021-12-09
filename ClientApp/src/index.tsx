import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './app/layout/App';
import registerServiceWorker from './registerServiceWorker';
import './app/layout/custom.css';
import { HistoryRouter } from "./HistoryRouter"
import { myHistory } from './history';


const rootElement = document.getElementById('root');

ReactDOM.render(
  <HistoryRouter history={myHistory}>
    <App />
    </HistoryRouter>,
  rootElement);

registerServiceWorker();

