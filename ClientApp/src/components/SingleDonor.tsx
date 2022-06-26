import Chart from "chart.js/auto";
import { getRelativePosition } from "chart.js/helpers";
import { useEffect, useRef, useState } from "react";
import { groupBy, uniq } from "lodash";

const SingleDonor = ({ data }: { data: any }) => {
  const canvasRef = useRef<any>(null);
  const componentRef = useRef<any>(null);
  const gradeRef = useRef<any>(null);
  const defectsRef = useRef<any>(null);

  console.log("data", data);

  useEffect(() => {
    if (data) {
      // @ts-ignore
      const dateList = data && data.map((d: any) => d.collectionDate);

      const barData = groupBy(data, (d) => d.collectionDate);

      const componentTypes = groupBy(data, (d) => d.type);
      const grades = groupBy(data, (d) => d.grade);
      const defects = groupBy(data, (d) => d.defects.length);

      const chart = new Chart(canvasRef.current, {
        type: "bar",
        data: {
          labels: Object.keys(barData),
          datasets: [
            {
              label: "Amount of donated items per date",
              data: Object.values(barData).map((value) => value.length),
              backgroundColor: data.map((d: any) => {
                const randomColor = Math.floor(
                  Math.random() * 16777215
                ).toString(16);
                return "#" + randomColor;
              }),
            },
          ],
        },
      });

      const componentChart = new Chart(componentRef.current, {
        type: "doughnut",
        data: {
          labels: Object.keys(componentTypes),
          datasets: [
            {
              label: "Type of components",
              data: Object.values(componentTypes).map((value) => value.length),
              backgroundColor: data.map((d: any) => {
                const randomColor = Math.floor(
                  Math.random() * 16777215
                ).toString(16);
                return "#" + randomColor;
              }),
              hoverOffset: 4,
            },
          ],
        },
      });
      const gradeChart = new Chart(gradeRef.current, {
        type: "doughnut",
        data: {
          labels: Object.keys(grades),
          datasets: [
            {
              label: "Type of grade",
              data: Object.values(grades).map((value) => value.length),
              backgroundColor: data.map((d: any) => {
                const randomColor = Math.floor(
                  Math.random() * 16777215
                ).toString(16);
                return "#" + randomColor;
              }),
              hoverOffset: 4,
            },
          ],
        },
      });
      const defectsChart = new Chart(defectsRef.current, {
        type: "doughnut",
        data: {
          labels: Object.keys(defects),
          datasets: [
            {
              label: "Type of grade",
              data: Object.values(defects).map((value) => value.length),
              backgroundColor: data.map((d: any) => {
                const randomColor = Math.floor(
                  Math.random() * 16777215
                ).toString(16);
                return "#" + randomColor;
              }),
              hoverOffset: 4,
            },
          ],
        },
      });
    }
  }, [data]);

  return (
    <div id="single-donor">
      <h1>Donor 7</h1>
      <div>
        <div style={{ display: "flex", gap: "1rem" }}>
          Amount of donated items :
          <span style={{ color: "rgb(242, 148, 46)" }}>
            {data && data.length}
          </span>
        </div>
        <div style={{ marginTop: "2rem" }}>
          <canvas ref={canvasRef}></canvas>
        </div>
        <div
          style={{
            display: "grid",
            gridTemplateColumns: "1fr 1fr 1fr",
            gap: "3rem",
          }}
        >
          <div style={{ marginTop: "2rem" }}>
            <h2>Types of components for total amount</h2>
            <canvas ref={componentRef}></canvas>
          </div>
          <div style={{ marginTop: "2rem" }}>
            <h2>Grades for total amount</h2>
            <canvas ref={gradeRef}></canvas>
          </div>
          <div style={{ marginTop: "2rem" }}>
            <h2>Amount of defective parts</h2>
            <canvas ref={defectsRef}></canvas>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SingleDonor;
