import React from "react";
import {
  Nav,
  Navbar,
  NavbarBrand,
  Collapse,
  DropdownItem,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
} from "reactstrap";

import userIcon from "../../assets/images/user-icon.png";
import logoicon from "../../assets/images/logo-icon.png";

const Header = () => {

  const logout = () => {
    localStorage.setItem('token', '');
    window.location = '/login';
  }

  return (
    <header className="topbar navbarbg" data-navbarbg="skin1">
      <Navbar className="top-navbar" expand="md">
        <div className="navbar-header" id="logobg" data-logobg="skin2">
          <NavbarBrand href="/">
            <b className="logo-icon">
              <img src={logoicon} alt="homepage" />
            </b>
          </NavbarBrand>
        </div>
        <Collapse className="navbarbg" navbar data-navbarbg="skin1">
          <Nav className="ml-auto float-right" navbar>
            <UncontrolledDropdown nav inNavbar>
              <DropdownToggle nav caret className="pro-pic">
                <img src={userIcon} alt="user" className="rounded-circle" width="31" />
              </DropdownToggle>
              <DropdownMenu right className="user-dd">
                <DropdownItem divider />
                <DropdownItem onClick={logout}>
                  <i className="fa fa-power-off mr-1 ml-1" /> Sair
                </DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
          </Nav>
        </Collapse>
      </Navbar>
    </header>
  );
};
export default Header;
