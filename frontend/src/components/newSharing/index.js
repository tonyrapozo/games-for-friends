import React, { useState } from 'react';
import Select from 'react-select';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

const NewSharing = (props) => {

  const [selectedGame, setSelectedGame] = useState({});
  const [selectedFriend, setSelectedFriend] = useState({});

  const games = [
    { value: '78c973c0-a989-4970-83b2-330f2d35cb6b', label: 'Fifa 12' },
    { value: '039095fd-92b1-4e32-8dce-b4767c669af2', label: 'Red Dead' },
    { value: 'c8d5b305-5b38-47e0-8c0c-d2c732cd11d5', label: 'Last of Us' },
  ];

  const friends = [
    { value: '8a4d4201-465e-48f2-96cb-f52942f46e5d', label: 'João' },
    { value: '3423e2f0-5ddc-4778-acf2-941a889f6c1e', label: 'José' },
    { value: '534b545c-f79e-49be-9987-3937bf4e6fb5', label: 'Roberval' },
  ];

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
        />
        <h5 className="mt-2">Amigo</h5>
        <Select
          value={selectedFriend}
          onChange={setSelectedFriend}
          options={friends}
        />
      </ModalBody>
      <ModalFooter>
        <Button color="primary" onClick={toggle}>Emprestar</Button>
        <Button color="secondary" onClick={toggle}>Cancelar</Button>
      </ModalFooter>
    </Modal>
  );
}

export default NewSharing;