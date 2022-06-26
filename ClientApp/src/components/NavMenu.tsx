import * as React from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import logo from "../assets/ctg-logo.png";
import "./NavMenu.css";

export default class NavMenu extends React.PureComponent<
  {},
  { isOpen: boolean }
> {
  public state = {
    isOpen: false,
  };

  public render() {
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow"
          light
        >
          <Container>
            <NavbarBrand tag={Link} to="/">
              <img
                height="30px"
                src={logo}
                alt=""
                style={{ marginRight: "1rem" }}
              />
              Close the gap
            </NavbarBrand>
            <NavbarToggler onClick={this.toggle} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={this.state.isOpen}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                {/* <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">
                    Home
                  </NavLink>
                </NavItem> */}
                {/* <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/import">
                    Import
                  </NavLink>
                </NavItem> */}
                {/* <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/inventory">
                    Inventory
                  </NavLink>
                </NavItem> */}
                {/* <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/report">
                    Report
                  </NavLink>
                </NavItem> */}
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }

  private toggle = () => {
    this.setState({
      isOpen: !this.state.isOpen,
    });
  };
}
