import React from 'react';
import ReactDOM from 'react-dom';
import Page from './components/page';
import UnauthenticatedPage from './components/unauthenticatedPage';

import './assets/scss/style.css';

ReactDOM.render(localStorage.getItem('token') ? <Page /> : <UnauthenticatedPage />, document.getElementById('root')); 
