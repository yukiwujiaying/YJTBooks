import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import App from './app/layout/App';
import registerServiceWorker from './registerServiceWorker';
import './app/layout/custom.css';
import { HistoryRouter } from "./HistoryRouter"
import { myHistory } from './history';
import { StoreProvider } from './app/context/StoreContext';
import { Provider } from 'react-redux';
import { store } from './app/store/configureStore';


const rootElement = document.getElementById('root');

ReactDOM.render(
  <HistoryRouter history={myHistory}>
    <StoreProvider>
      <Provider store={store}>
        <App />
      </Provider>
    </StoreProvider>
  </HistoryRouter>,
  rootElement);

registerServiceWorker();

