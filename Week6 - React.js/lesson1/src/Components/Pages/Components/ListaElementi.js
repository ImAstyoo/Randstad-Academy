import React from "react";
import Riga from "./Riga";

const ListaElementi = ({data}) => {

  /*function shouldComponentUpdate() {
    return true
  }*/

  /*function componentWillReceiveProps(props) {
    console.log("componentWillReceiveProps" + props)
  }*/


  let dettaglioProprietario = data.map(function (propr) {
    return (
      <Riga proprietario={propr.proprietario} targa={propr.targa} key={propr.id}>
      </Riga>
    );
  });


  return (
    <tbody>{dettaglioProprietario}</tbody>
  );

}

export default ListaElementi