import React, { useState } from "react";
import { Row, Col, Button, Card, CardBody, Media } from "reactstrap";
import Empty from "../components/empty";
import NewSharing from '../components/newSharing';

import userIcon from "../assets/images/user-icon.png";

const Sharings = props => {

  const [openModal, setOpenModal] = useState(false);

  const sharings = [{
    friend: {
      name: 'Jose Antonio'
    },
    games: [{
      name: 'FIFA',
      since: '12/05/2020',
      elapsedDays: 13
    },
    {
      name: 'Call of Duty',
      since: '12/09/2020',
      elapsedDays: 13
    }]
  },
  {
    friend: {
      name: 'Edivan galindo'
    },
    games: [{
      name: 'FIFA',
      since: '12/05/2020',
      elapsedDays: 13
    }]
  }]



  const newSharing = () => {
    setOpenModal(true);
  }

  return (
    <div>
      <Row>
        <Col sm="8">
          <h3>Empréstimos</h3>
          <h5>Acompanhe aqui os seus empréstimos de jogos</h5>
        </Col>
        <Col sm="4">
          <Button className="mt-3 float-right" color="purple" onClick={newSharing}>novo empréstimo</Button>
        </Col>
      </Row>
      {sharings.length === 0 ? <Empty image="undraw_void_3ggu" description="Nenhum jogo emprestado" /> : <></>}
      {sharings.map((sharing, key) => {
        return (<Card className="bg-primary mt-3" key={key}>
          <CardBody>
            <Row>
              <Col sm="12">
                <Media>
                  <span className="float-left mr-4">
                    <img
                      src={userIcon}
                      style={{ height: "60px" }}
                      alt=""
                      className="rounded-circle img-thumbnail"
                    />
                  </span>
                  <div className="media-body">
                    <h3 className="mt-3 mb-3 text-white">{sharing.friend.name}</h3>
                  </div>
                </Media>
              </Col>
            </Row>
            {sharing.games.map((game, key) => {
              return (
                <Row key={key}>
                  <Col sm={{ size: 10, offset: 1 }}>
                    <Card className="bg-cyan">
                      <CardBody>
                        <Media>
                          <span className="float-right m-2 mr-4">
                            <img
                              src="https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1e.jpg"
                              style={{ height: "70px" }}
                              alt=""
                              className="img-thumbnail"
                            />
                          </span>
                          <div className="media-body">
                            <h4 className="mt-3 mb-1 text-white">{game.name}</h4>
                            <p className="font-13 text-white-50">
                              {" "}
                              Emprestado há {game.elapsedDays} dias ({game.since})
                          </p>
                          </div>
                          <Button className="mt-3" color="purple">devolver</Button>
                        </Media>
                      </CardBody>
                    </Card>
                  </Col>
                </Row>
              )
            })}
          </CardBody>
        </Card>
        )
      }
      )}
      <NewSharing openModal={openModal} onCloseModal={() => setOpenModal(false)} />
    </div>);
};

export default Sharings;
