import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import App from './app/layout/App';
import registerServiceWorker from './registerServiceWorker';
import { myHistory } from './history';
import { HistoryRouter } from "./HistoryRouter";


const rootElement = document.getElementById('root');

ReactDOM.render(
    <HistoryRouter history={myHistory}>
       <App />
    </HistoryRouter>,
  rootElement);

registerServiceWorker();

