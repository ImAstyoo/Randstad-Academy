import React from "react";

const UserDelete = (obj) => {

  function SelectedUser(obj){
    obj.id = document.getElementById("id").value;
    this.callback(obj);
  }

  return (
    <div>
      <div className="col order-first">
        <label htmlFor="id">id:&nbsp;</label>
        <input type="text" id="id" name="id"/>
      </div>
      <div className="col order-last">
        <button className="btn btn-primary" onClick={SelectedUser.bind(obj)}>Delete</button>
      </div>
    </div>
  )
}

export default UserDelete