import React from 'react';
import { Route, Switch, BrowserRouter } from 'react-router-dom';

import Header from '../header/header.js';
import Sidebar from '../sidebar/sidebar.js';
import Footer from '../footer/footer.js';

import Sharings from "../../views/sharings.js";
import Friends from "../../views/friends.js";
import Games from "../../views/games.js";


const Page = () => {
    return (
        <BrowserRouter>
            <div
                id="main-wrapper"
                data-theme="light"
                data-layout="vertical"
                data-sidebartype="full"
                data-sidebar-position="fixed"
            >
                <Header />
                <Sidebar />
                <div className="page-wrapper d-block">
                    <div className="page-content container-fluid">
                        <Switch>
                            <Route exact path="/">
                                <Sharings />
                            </Route>
                            <Route exact path="/friends">
                                <Friends />
                            </Route>
                            <Route exact path="/games">
                                <Games />
                            </Route>
                        </Switch>
                    </div>
                    <Footer />
                </div>
            </div>
        </BrowserRouter>
    );
}
export default Page;
