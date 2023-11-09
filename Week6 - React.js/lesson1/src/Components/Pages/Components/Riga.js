import React from "react";
import Pari from "./Constants/Pari";
import Dispari from "./Constants/Dispari";


const Riga = ({proprietario, targa}) => {
  let lastChar = targa.substr(targa.length - 1);
  if (lastChar % 2 === 0) {
    return (
      <tr>
        <td >{proprietario}</td>
        <td>{targa}</td>
      </tr>
    );
  } else {

    return (
      <tr className="table-primary">
        <td>{proprietario}</td>
        <td>{targa}</td>
      </tr>
    )
  }
}

export default Riga