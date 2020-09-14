import React, { useState } from "react";
import { Input, Row, Col, Label } from "reactstrap";
import Undraw from "../undraw";
import { useHistory } from "react-router-dom";
import api from '../../service';

const Register = () => {
  const history = useHistory();
  const [email, setEmail] = useState('');
  const [name, setName] = useState('');
  const [password, setPassword] = useState('');

  const register = async () => {
    const data = await api.post('/account/new', { name, email, password });
    if (data.status === 200) {
      history.push('/login');
    }
  }

  const keypress = async (key) => {
    if (key.charCode === 13)
      register();
  }

  return (

    <div className="mt-4">
      <Undraw image="undraw_authentication_fsn5" height='200px' />
      <Row>
        <Col sm={{ size: 4, offset: 4 }}>

          <Label>Name</Label>
          <Input type="text" onChange={(e) => setName(e.currentTarget.value)} />

          <Label className="mt-4">Email</Label>
          <Input type="text" onChange={(e) => setEmail(e.currentTarget.value)} />

          <Label className="mt-4">Senha</Label>
          <Input type="password" onChange={(e) => setPassword(e.currentTarget.value)} keypress={keypress} />

          <div className="text-center mt-4">
            <button className="btn btn-primary mr-2" onClick={register}>registrar</button>
            <button className="btn btn-secondary" onClick={() => history.push('/login')}>ir para login</button>
          </div>
        </Col>
      </Row>
    </div>
  );
};
export default Register;
