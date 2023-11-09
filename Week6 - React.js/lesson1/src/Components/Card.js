import React from 'react';
import Data from '../Data/data';

const Card = () => {
  return (
    <div>
      <div>{Data.map((item) => {
        return (
          <div>
            <h1>SINGLE CARD</h1>
            <div>{item.id}</div>
            <div>{item.title}</div>
            <div>{item.description}</div>
          </div>);
      })}</div>
    </div>
  );
};


export default Card;