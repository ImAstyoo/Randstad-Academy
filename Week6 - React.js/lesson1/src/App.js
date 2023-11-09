import React, {useState} from 'react';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Paths from "./UsersApp/Resources/Paths";
import Links from "./UsersApp/Resources/Links";
import Navbar from "./UsersApp/Components/Navbar";
import UsersList from "./UsersApp/Pages/UsersList";
import UserCreate from "./UsersApp/Pages/UserCreate";
import UserDelete from "./UsersApp/Pages/UserDelete";
import UserUpdate from "./UsersApp/Pages/UserUpdate";
import data from "./UsersApp/Resources/db.json";

const App = () => {

  const [users, setUsers] = useState([...data["users"]]);

  function createUser(user) {
    setUsers([...users, user]);
  }

  function deleteUser(user) {
    const selectedUser = users.findIndex((obj) => obj.id === user.id);
    users.splice(selectedUser, 1);
    setUsers([...users])
  }

  function editUser(user) {
    const selectedUser = users.findIndex((obj) => obj.id === user.id);
    users[selectedUser] = user;
  }

  return (
    <BrowserRouter>
      <div>
        <Navbar links={Links}></Navbar>
        <Routes>
          <Route path={Paths.default} element={<UsersList users={users}/>}/>
        </Routes>
        <Routes>
          <Route path={Paths.create} element={<UserCreate callback={createUser.bind(Object())}/>}/>
          <Route path={Paths.delete} element={<UserDelete callback={deleteUser.bind(Object())}/>}/>
          <Route path={Paths.update} element={<UserUpdate callback={editUser.bind(Object())}/>}/>
        </Routes>
      </div>
    </BrowserRouter>
  );
};

export default App;
