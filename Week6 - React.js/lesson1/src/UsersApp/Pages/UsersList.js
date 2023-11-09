import React from "react";

const UsersList = ({users}) => {

  return (
    <div>
      <table className="table">
        <thead>
        <tr>
          <th scope="col">id</th>
          <th scope="col">name</th>
          <th scope="col">username</th>
          <th scope="col">email</th>
        </tr>
        </thead>
        <tbody>
        {users.map((user,index) =>
          <tr key={index}>
            <th scope="row">{user.id}</th>
            <td>{user.name}</td>
            <td>{user.username}</td>
            <td>{user.email}</td>
          </tr>
        )}
        </tbody>
      </table>
    </div>
  )


}

export default UsersList