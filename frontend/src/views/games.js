import React, { useState, useEffect } from "react";
import { Row, Col, Button, Table, ButtonGroup } from "reactstrap";
import userIcon from "../assets/images/user-icon.png";
import NewGame from "../components/newGame";
import api from '../service';

const Games = () => {
  const [games, setGames] = useState([]);
  const [openModal, setOpenModal] = useState(false);

  const onClose = () => {
    loadData();
  }

  const loadData = async () => {
    const data = await api.get('/user/games');
    if (data.status === 200) {
      setGames(data.data);
      setOpenModal(false);
    }
  }

  const removeGame = async (game) => {
    const data = await api.delete(`/user/game/${game.id}`);
    if (data.status === 200) {
      loadData();
    }
  }

  useEffect(() => {
    loadData()
  }, [])

  return (
    <div>
      <Row>
        <Col sm="8">
          <h3>Jogos</h3>
          <h5>Sua lista de jogos para se divertir e compartilhar</h5>
        </Col>
        <Col sm="4">
          <Button className="mt-3 float-right" color="purple" onClick={() => setOpenModal(true)}>novo jogo</Button>
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
              {games.map((game, key) => {
                return (<tr key={key}>
                  <td >
                    <div className="d-flex no-block align-items-center">
                      <div className="mr-2"><img src={userIcon} alt="Jose Antonio" className="rounded-circle" width="45" /></div>
                      <div className="ml-4">
                        <h5 className="mb-0 font-16 font-medium">{game.name}</h5></div>
                    </div>
                  </td>
                  <td>
                    <ButtonGroup className="pull-right">
                      <Button onClick={() => removeGame(game)}>remover</Button>
                    </ButtonGroup>
                  </td>
                </tr>)
              })}
            </tbody>
          </Table>
        </Col>
      </Row>
      <NewGame openModal={openModal} onCloseModal={onClose} />
    </div>
  );
};

export default Games;
