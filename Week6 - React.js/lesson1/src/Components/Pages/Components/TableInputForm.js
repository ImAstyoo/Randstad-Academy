import React from "react";

const TableInputForm = (obj) => {

  function inserisci(obj) {
    obj.proprietario = document.getElementById("proprietario").value;
    obj.targa = document.getElementById("targa").value;
    document.getElementById("targa").value = ""
    document.getElementById("proprietario").value = ""
    this.callback(obj)
  }

  return (
    <div className="row">
      <br/>
      <div className="col order-first">
        <label htmlFor="targa">Targa:&nbsp;</label>
        <input type="text" id="targa" name="targa"/>
      </div>
      <div className="col">
        <label htmlFor="proprietario">Proprietario:&nbsp;</label>
        <input type="text" id="proprietario" name="proprietario"/></div>
      <div className="col order-last">
        <button onClick={inserisci.bind(obj)}> Inserisci</button>
      </div>
    </div>
  );
}

export default TableInputForm