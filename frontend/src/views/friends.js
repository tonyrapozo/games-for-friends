import React from "react";
import { Row, Col, Button, Table, ButtonGroup } from "reactstrap";
import userIcon from "../assets/images/user-icon.png";

const Friends = () => {
  return (
    <div>
      <Row>
        <Col sm="8">
          <h3>Amigos</h3>
          <h5>Sua lista de amigos para compartilhar jogos</h5>
        </Col>
        <Col sm="4">
          <Button className="mt-3 float-right" color="purple">novo amigo</Button>
        </Col>
      </Row>
      <Row>
        <Col md="12">
          <Table className="no-wrap v-middle" responsive>
            <thead>
              <tr className="border-0">
                <th style={{ width: '80%' }} className="border-0"></th>
                <th style={{ width: '20%' }} className="border-0"></th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td >
                  <div className="d-flex no-block align-items-center">
                    <div className="mr-2"><img src={userIcon} alt="Jose Antonio" className="rounded-circle" width="45" /></div>
                    <div className="ml-4">
                      <h5 className="mb-0 font-16 font-medium">Jose Antonio</h5><span>amigo desde 10/05/2020</span></div>
                  </div>
                </td>
                <td>
                  <ButtonGroup className="pull-right">
                    <Button>editar</Button>
                    <Button>remover</Button>
                  </ButtonGroup>
                </td>
              </tr>
              <tr>
                <td>
                  <div className="d-flex no-block align-items-center">
                    <div className="mr-2"><img src={userIcon} alt="Jose Antonio" className="rounded-circle" width="45" /></div>
                    <div className="ml-4">
                      <h5 className="mb-0 font-16 font-medium">Jose Antonio</h5><span>amigo desde 10/05/2020</span></div>
                  </div>
                </td>
                <td>
                  <ButtonGroup className="pull-right">
                    <Button>editar</Button>
                    <Button>remover</Button>
                  </ButtonGroup>
                </td>
              </tr>
            </tbody>
          </Table>
        </Col>
      </Row>
    </div>
  );
};

export default Friends;
