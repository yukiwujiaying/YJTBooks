import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import App from './app/layout/App';
import { Provider } from 'react-redux';
import registerServiceWorker from './registerServiceWorker';
import { myHistory } from './history';
import { HistoryRouter } from "./HistoryRouter";
import { store } from './app/store/configureStore';


const rootElement = document.getElementById('root');

ReactDOM.render(
    <HistoryRouter history={myHistory}>
        <Provider store={store}>
            <App />
        </Provider>
    </HistoryRouter>,
  rootElement);

registerServiceWorker();

