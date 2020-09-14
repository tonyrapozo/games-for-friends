import React, { useState } from "react";
import { Input, Row, Col, Label } from "reactstrap";
import Undraw from "../undraw";
import { useHistory } from "react-router-dom";
import api from '../../service';
import undrawAuth from "../../assets/images/undraw/undraw_authentication_fsn5.svg";
import Swal from 'sweetalert2'

const Login = () => {

  const history = useHistory();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const login = async () => {
    api.post('/account/login', { email, password }).then((data) => {
      if (data.status === 200) {
        localStorage.setItem('token', data.data.token);
        window.location = '/';
      }
    }).catch((error) => {
      Swal.fire('Atenção', 'Usuário ou senha inválidos. Tente novamente.', 'error')
    });;
  }

  const keypress = async (key) => {
    if (key.charCode === 13)
      login();
  }

  return (
    <div className="mt-4">
      <Undraw image="undraw_authentication_fsn5" imageSrc={undrawAuth} height='200px' />
      <Row>
        <Col sm={{ size: 4, offset: 4 }}>
          <Label>Email</Label>
          <Input type="text" onChange={(e) => setEmail(e.currentTarget.value)} />

          <Label className="mt-4">Senha</Label>
          <Input type="password" onChange={(e) => setPassword(e.currentTarget.value)} onKeyPress={keypress} />

          <div className="text-center mt-4">
            <button className="btn btn-primary mr-2" onClick={login}>login</button>
            <button className="btn btn-secondary" onClick={() => history.push('/register')}>novo registro</button>
          </div>
        </Col>
      </Row>
    </div>
  );
};
export default Login;
