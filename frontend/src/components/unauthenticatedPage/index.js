import React from 'react';
import { Route, Switch, BrowserRouter } from 'react-router-dom';

import Footer from '../footer/footer.js';

import Login from "../login";
import Register from "../register";

const UnauthenticatedPage = () => {
  return (

    <BrowserRouter>
      <div id="main-wrapper">
        <div className="page-wrapper d-block">
          <div className="page-content container-fluid">
            <Switch>
              <Route exact path="/login">
                <Login />
              </Route>
              <Route exact path="/">
                <Login />
              </Route>
              <Route exact path="/register">
                <Register />
              </Route>
            </Switch>
          </div>
          <Footer />
        </div>
      </div>
    </BrowserRouter>
  );
}
export default UnauthenticatedPage;
