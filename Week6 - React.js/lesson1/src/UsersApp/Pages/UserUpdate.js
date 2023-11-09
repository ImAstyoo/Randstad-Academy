import React from "react";

const UserUpdate = (obj) => {
  let selected = {
    id: null,
    name: null,
    email: null,
  };

  const selectedUser = (value) => {
    selected.id = value.target.value;
  }

  function updateUser() {
    selected.name = document.getElementById("name").value;
    selected.username = document.getElementById("username").value;
    selected.email = document.getElementById("email").value;
    this.callback(selected);
  }

  return (
    <div>
      <label htmlFor="id">id:&nbsp;</label>
      <input type="text" id="id" name="id"/>
      <div className="col order-last">
        <button className="btn btn-primary" onClick={selectedUser}>Select</button>
      </div>
      <div className="col order-first">
        <br></br>
        <label htmlFor="name">name:&nbsp;</label>
        <input type="text" id="name" name="name"/>
        <br></br>
        <label htmlFor="username">username:&nbsp;</label>
        <input type="text" id="username" name="username"/>
        <br></br>
        <label htmlFor="email">email:&nbsp;</label>
        <input type="text" id="email" name="email"/>
      </div>
      <br></br>
      <div className="col order-last">
        <button className="btn btn-primary" onClick={updateUser.bind(obj)}>Update</button>
      </div>
    </div>
  )

}

export default UserUpdate