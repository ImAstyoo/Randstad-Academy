import React, {useState} from "react";
import {Link} from "react-router-dom";

const Navbar = ({links}) => {

  const [routes] = useState([...links]);

  // Takes links and maps them as button in a navbar
  let result = routes.map((route, index) => {
      return (
        <li className="nav-item active" key={index}>
          <Link to={`/${route}`} className={"nav-link"}>{route}</Link>
        </li>
      )
    }
  )

  //returns a navbar completed with links
  return <nav className="navbar navbar-expand-lg navbar-light bg-light">
    <ul className="navbar-nav mr-auto">
      {result}
    </ul>
  </nav>
}

export default Navbar