import { useEffect, useState } from "react";
import { getAllInfo } from "../services/ReportService";

const Report = () => {
  const [_allMaterial, setAllMaterial] = useState(null);
  console.log("_allMaterial", _allMaterial);

  const getAllMaterial = () => {
    const result = getAllInfo();
    console.log("result", result);
    // setAllMaterial();
  };

  useEffect(() => {
    getAllMaterial();
  }, []);

  return (
    <div>
      <div></div>
    </div>
  );
};

export default Report;
