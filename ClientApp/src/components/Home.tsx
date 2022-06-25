import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
  <div>
    <h1>Hello, world!</h1>
    <button>Import Excel</button>
  </div>
);

export default connect()(Home);
