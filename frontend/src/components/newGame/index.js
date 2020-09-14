import React, { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import AsyncSelect from 'react-select/async';
import api from '../../service';
import axios from 'axios';
import Swal from 'sweetalert2'

const NewGame = (props) => {

  const [name, setName] = useState('');
  const [image, setImage] = useState('');

  const toggle = () => props.onCloseModal();

  const salvar = async () => {
    api.post('/user/game', { name, image }).then((data) => {
      if (data.status === 200)
        toggle();
    }).catch(() => {
      Swal.fire('Atenção', 'Ocorreu um erro ao salvar o jogo! Por favor, tente novamente.', 'error')
    });;
  };

  const promiseOptions = inputValue =>
    new Promise(async resolve => {
      const data = await axios.get(`https://api.rawg.io/api/games?search=${inputValue}`);
      resolve(data.data.results);
    });

  return (
    <Modal isOpen={props.openModal} toggle={toggle} >
      <ModalHeader toggle={toggle}>Novo jogo</ModalHeader>
      <ModalBody>
        <h5 className="mt-2">Nome</h5>
        <AsyncSelect
          cacheOptions
          defaultOptions
          loadOptions={promiseOptions}
          getOptionLabel={item => item.name}
          getOptionValue={item => item.id}
          onChange={(item) => {
            setName(item.name)
            setImage(item.background_image);
          }} />
      </ModalBody>
      <ModalFooter>
        <Button color="primary" onClick={salvar}>Salvar</Button>
        <Button color="secondary" onClick={toggle}>Cancelar</Button>
      </ModalFooter>
    </Modal>
  );
}

export default NewGame;