import React, { useState, useEffect } from 'react';
import Select from 'react-select';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import api from '../../service';

const NewSharing = (props) => {

  const [games, setGames] = useState([]);
  const [friends, setFriends] = useState([]);
  const [selectedGame, setSelectedGame] = useState({});
  const [selectedFriend, setSelectedFriend] = useState({});

  const loadGames = async () => {
    const data = await api.get('/user/games/free');
    if (data.status === 200) {
      setGames(data.data);
    }
  }

  const loadFriends = async () => {
    const data = await api.get('/user/friends');
    if (data.status === 200) {
      setFriends(data.data);
    }
  }

  const salvar = async () => {
    const data = await api.post('/sharings',
      {
        friendId: selectedFriend.id,
        gameId: selectedGame.id
      });
    if (data.status === 200)
      toggle();
  };

  useEffect(() => {
    loadGames();
    loadFriends();
    setSelectedGame({});
    setSelectedFriend({});
  }, [props.openModal]);

  const toggle = () => props.onCloseModal();

  return (
    <Modal isOpen={props.openModal} toggle={toggle} >
      <ModalHeader toggle={toggle}>Novo empréstimo</ModalHeader>
      <ModalBody>
        <h5 className="mt-2">Jogo</h5>
        <Select
          value={selectedGame}
          onChange={setSelectedGame}
          options={games}
          getOptionLabel={item => item.name}
          getOptionValue={item => item.id}
        />
        <h5 className="mt-2">Amigo</h5>
        <Select
          value={selectedFriend}
          onChange={setSelectedFriend}
          options={friends}
          getOptionLabel={item => item.name}
          getOptionValue={item => item.id}
        />
      </ModalBody>
      <ModalFooter>
        <Button color="primary" onClick={salvar}>Emprestar</Button>
        <Button color="secondary" onClick={toggle}>Cancelar</Button>
      </ModalFooter>
    </Modal>
  );
}

export default NewSharing;