import React, {useState} from "react";
import TableInputForm from "./TableInputForm";
import ListaElementi from "./ListaElementi";

const GestioneParcheggio = () => {
  let dataarr = [
    {id: 1, proprietario: "Pippo", targa: "AA123412"},
    {id: 2, proprietario: "Pluto", targa: "CC567712"},
    {id: 3, proprietario: "Paperino", targa: "DD123132"},
    {id: 4, proprietario: "Qui", targa: "FF123131"},
    {id: 5, proprietario: "Quo", targa: "GG435353"}
  ];

  const [data, setData] = useState(dataarr);

  function updateShared(obj) {
    let trovato = false;
    data.forEach(function (in_macchina) {
      if (obj.targa === in_macchina.targa)
        trovato = true
    });

    if (trovato) {
      alert("La macchina e' già presente nel parcheggio")
    } else {
      obj.id = data.length + 1;
      setData([...data, obj])
      alert("Macchina inserita")
    }
  }

  return <div>
    <table
      className="table table-bordered table-striped-col nomargin"
      id="table-data">
      <thead>
      <tr>
        <td>Proprietario</td>
        <td>Targa</td>
      </tr>
      </thead>
      <ListaElementi data={data}/>
    </table>
    <TableInputForm callback={updateShared.bind(Object())}/>
  </div>

}

export default GestioneParcheggio