import React, { useState, useEffect } from "react";
import { Row, Col, Button, Table, ButtonGroup } from "reactstrap";
import NewFriend from "../components/newFriend";
import userIcon from "../assets/images/user-icon.png";
import * as moment from 'moment';
import api from '../service';

const Friends = () => {
  const [friends, setFriends] = useState([]);
  const [friend, setFriend] = useState([]);
  const [openModal, setOpenModal] = useState(false);

  const onClose = () => {
    loadData();
  }

  const loadData = async () => {
    const data = await api.get('/user/friends');
    if (data.status === 200) {
      setFriends(data.data);
      setOpenModal(false);
    }
  }

  const removeFriend = async (friend) => {
    const data = await api.delete(`/user/friend/${friend.id}`);
    if (data.status === 200) {
      loadData();
    }
  }

  const editFriend = async (friend) => {
    setFriend(friend);
    setOpenModal(true);
  }

  const newFriend = () => {
    setFriend({});
    setOpenModal(true);
  }

  useEffect(() => {
    loadData()
  }, [])

  return (
    <div>
      <Row>
        <Col sm="8">
          <h3>Amigos</h3>
          <h5>Sua lista de amigos para compartilhar jogos</h5>
        </Col>
        <Col sm="4">
          <Button className="mt-3 float-right" color="purple" onClick={() => newFriend()}>novo amigo</Button>
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
              {friends.map((friend, key) => {
                return (<tr key={key}>
                  <td >
                    <div className="d-flex no-block align-items-center">
                      <div className="mr-2"><img src={userIcon} alt="Jose Antonio" className="rounded-circle" width="45" /></div>
                      <div className="ml-4">
                        <h5 className="mb-0 font-16 font-medium">{friend.name}</h5><span>amigo desde {moment(friend.friendshipDate).format('DD/MM/YYYY')}</span></div>
                    </div>
                  </td>
                  <td>
                    <ButtonGroup className="pull-right">
                      <Button onClick={() => editFriend(friend)}>editar</Button>
                      <Button onClick={() => removeFriend(friend)}>remover</Button>
                    </ButtonGroup>
                  </td>
                </tr>
                )
              })}
            </tbody>
          </Table>
        </Col>
      </Row>
      <NewFriend openModal={openModal} onCloseModal={onClose} friend={friend} />
    </div>
  );
};

export default Friends;
