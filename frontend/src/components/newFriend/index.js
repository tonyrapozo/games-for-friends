import React, { useState, useEffect } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Input } from 'reactstrap';
import api from '../../service';

const NewFriend = (props) => {

  debugger;

  const [id, setId] = useState('');
  const [name, setName] = useState('');

  useEffect(() => {
    debugger;
    if (props.friend) {
      setId(props.friend.id);
      setName(props.friend.name);
    }

  }, [props])

  const toggle = () => props.onCloseModal();

  const salvar = async () => {
    const apiCall = id ? api.put : api.post;
    const data = await apiCall('/user/friend', { id, name });
    if (data.status === 200)
      toggle();
  };

  return (
    <Modal isOpen={props.openModal} toggle={toggle} >
      <ModalHeader toggle={toggle}>Novo amigo</ModalHeader>
      <ModalBody>
        <h5 className="mt-2">Nome</h5>
        <Input type="text" value={name} onChange={(e) => setName(e.currentTarget.value)} />
      </ModalBody>
      <ModalFooter>
        <Button color="primary" onClick={salvar}>Salvar</Button>
        <Button color="secondary" onClick={toggle}>Cancelar</Button>
      </ModalFooter>
    </Modal>
  );
}

export default NewFriend;