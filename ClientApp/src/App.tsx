import * as React from "react";
import { Route } from "react-router";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Counter from "./components/Counter";
import FetchData from "./components/FetchData";
import Report from "./components/Report";

import "./custom.css";

export default () => (
  <Layout>
    <Route exact path="/" component={Report} />
    <Route path="/import" component={Counter} />
    <Route path="/fetch-data/:startDateIndex?" component={FetchData} />
    <Route path="/report" component={Report} />
  </Layout>
);
