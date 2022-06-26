import { useEffect, useState } from "react";
import { getAllInfo } from "../services/ReportService";

import {
  Card,
  CardBody,
  CardTitle,
  CardSubtitle,
  CardText,
  Button,
  Container,
} from "reactstrap";
import SingleDonor from "./SingleDonor";
const Report = () => {
  const [_showDonor, setShowDonor] = useState(false);
  const [_allMaterial, setAllMaterial] = useState(null);

  const getAllMaterial = () => {
    getAllInfo().then((value) => setAllMaterial(value));
  };

  useEffect(() => {
    getAllMaterial();
  }, []);

  const showDonor = () => {
    setShowDonor(true);
  };

  const renderDonorList = () => {
    return (
      <>
        {[1, 2, 3, 4, 5, 6, 7, 8, 9, 10].map((donor) => (
          <Card onClick={showDonor}>
            <CardBody className="f-flex">
              <CardTitle
                className="mb-0"
                tag="h5"
                style={{
                  display: "flex",
                  justifyContent: "space-between",
                  alignItems: "center",
                }}
              >
                <div
                  style={{ display: "flex", gap: "1rem", alignItems: "center" }}
                >
                  <div
                    style={{
                      height: 40,
                      width: 40,
                      borderRadius: 50,
                      backgroundColor: "#0058a4",
                      display: "flex",
                      justifyContent: "center",
                      alignItems: "center",
                      color: "white",
                      fontSize: 20,
                    }}
                  >
                    <div style={{ marginBottom: 3 }}>D{donor}</div>
                  </div>
                  Donor {donor}
                </div>
                <div>See report &rsaquo;</div>
              </CardTitle>
            </CardBody>
          </Card>
        ))}
      </>
    );
  };

  const renderSingleDonor = () => {
    return <SingleDonor data={_allMaterial} />;
  };

  return (
    <div style={{ flexGrow: 1, display: "flex" }}>
      <Container
        className="p-4 d-flex flex-column gap-2"
        style={{ gap: ".5rem", flexGrow: 1 }}
      >
        {_showDonor ? renderSingleDonor() : renderDonorList()}
      </Container>
    </div>
  );
};

export default Report;
