import React from "react";
import { Row, Col } from "reactstrap";

const Undraw = ({ height, image, imageSrc, description }) => {

  const imageHeight = height || '300px';

  return (
    <Row>
      <Col sm="12" className="text-center">
        <img className="text-center" src={imageSrc} alt={image} height={imageHeight} />
      </Col>
      <Col sm="12" className="text-center mt-5">
        <span>{description}</span>
      </Col>
    </Row>
  );
};

export default Undraw;
