import React from "react";
import { Row, Col } from "reactstrap";
import undrawVoid from "../../assets/images/undraw/undraw_void_3ggu.svg";

const Empty = ({ image, description }) => {
    return (
        <Row>
            <Col sm="12" className="text-center">
                <img className="text-center" src={undrawVoid} alt={image} height="300px" />
            </Col>
            <Col sm="12" className="text-center mt-5">
                <span>{description}</span>
            </Col>
        </Row>
    );
};

export default Empty;
