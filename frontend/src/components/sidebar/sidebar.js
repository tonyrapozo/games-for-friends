import React from "react";
import { NavLink } from "react-router-dom";
import { Nav } from "reactstrap";

const Sidebar = ({ routes }) => {
  const activeRoute = (routeName) => {
    return window.location.pathname.indexOf(routeName) > -1 ? "selected" : "";
  };

  return (
    <aside
      className="left-sidebar mt-3"
      id="sidebarbg"
      data-sidebarbg="skin5" >
      <div className="scroll-sidebar">
        <div className="sidebar-nav">
          <Nav id="sidebarnav">
            <li className={activeRoute.bind("/") + " sidebar-item"} >
              <NavLink to="/" className="sidebar-link" activeClassName="active">
                <i className="mdi mdi-view-dashboard" />
                <span className="hide-menu">Meus empréstimos</span>
              </NavLink>
            </li>

            <li className={activeRoute.bind("/friends") + " sidebar-item"}>
              <NavLink to="/friends" className="sidebar-link" activeClassName="active" >
                <i className="mdi mdi-account-multiple" />
                <span className="hide-menu">Meus amigos</span>
              </NavLink>
            </li>

            <li className={activeRoute.bind("/games") + " sidebar-item"}>
              <NavLink to="/games" className="sidebar-link" activeClassName="active" >
                <i className="mdi mdi-gamepad-variant" />
                <span className="hide-menu">Meus jogos</span>
              </NavLink>
            </li>

          </Nav>
        </div>
      </div>
    </aside>
  );
};
export default Sidebar;
