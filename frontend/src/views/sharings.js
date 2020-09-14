import React, { useState, useEffect } from "react";
import { Row, Col, Button, Card, CardBody, Media } from "reactstrap";
import Undraw from "../components/undraw";
import NewSharing from '../components/newSharing';
import userIcon from "../assets/images/user-icon.png";
import * as moment from 'moment';
import api from '../service';
import undrawVoid from "../assets/images/undraw/undraw_void_3ggu.svg";

const Sharings = () => {

  const [sharings, setSharings] = useState([]);
  const [openModal, setOpenModal] = useState(false);

  const onClose = () => {
    loadData();
  }

  const loadData = async () => {
    const data = await api.get('/sharings');
    if (data.status === 200) {
      setSharings(data.data);
      setOpenModal(false);
    }
  }

  const returnGame = async (sharing) => {
    const data = await api.delete(`/sharings/return/${sharing.id}`);
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
          <h3>Empréstimos</h3>
          <h5>Acompanhe aqui os seus empréstimos de jogos</h5>
        </Col>
        <Col sm="4">
          <Button className="mt-3 float-right" color="purple" onClick={() => setOpenModal(true)}>novo empréstimo</Button>
        </Col>
      </Row>
      {sharings.length === 0 ? <Undraw image="undraw_void_3ggu" imageSrc={undrawVoid} description="Nenhum jogo emprestado" /> : <></>}
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
            <Row >
              <Col sm={{ size: 10, offset: 1 }}>
                <Card className="bg-cyan">
                  <CardBody>
                    <Media>
                      <span className="float-right m-2 mr-4">
                        <img
                          src={sharing.game.image}
                          style={{ height: "70px" }}
                          alt=""
                          className="img-thumbnail"
                        />
                      </span>
                      <div className="media-body">
                        <h4 className="mt-3 mb-1 text-white">{sharing.game.name}</h4>
                        <p className="font-13 text-white-50">
                          {" "}
                          Emprestado há {moment().diff(moment(sharing.sharingDate), 'days')} dia(s) ({moment(sharing.sharingDate).format('DD/MM/YYYY')})
                          </p>
                      </div>
                      <Button className="mt-3" color="purple" onClick={() => returnGame(sharing)}>devolver</Button>
                    </Media>
                  </CardBody>
                </Card>
              </Col>
            </Row>
          </CardBody>
        </Card>
        )
      })}
      <NewSharing openModal={openModal} onCloseModal={onClose} />
    </div>);
};

export default Sharings;
