import React from "react";


const UserCreate = (obj) => {

  function createUser(obj){
    obj.id = document.getElementById("id").value;
    obj.name = document.getElementById("name").value;
    obj.username = document.getElementById("username").value;
    obj.email = document.getElementById("email").value;
    this.callback(obj);
  }

  return (
    <div>
      <div className="col order-first">
        <label htmlFor="id">id:&nbsp;</label>
        <input type="text" id="id" name="id"/>
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
        <button className="btn btn-primary" onClick={createUser.bind(obj)}>Create</button>
      </div>
    </div>
  )

}

export default UserCreate