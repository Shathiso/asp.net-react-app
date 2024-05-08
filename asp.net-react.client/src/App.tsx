import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';

import UsersList from './components/UsersList'

interface Employees {
    id:	number,
    first_name:	string,
    last_name:	string,
    contact_number:	number,
    birth_date:	string,
    street_address:	string,
    city:	string,
    postal_code:string,
    country: string,
    user: Users
}

interface Users {
    id: number,
    username: string,
    email:string,
    employee: Employees
}

const options = {
    baseURL: 'https://localhost:7105/api/',
    method: 'GET',
    mode: "cors"
}

function App() {
    const [employees, setEmployees] = useState<Employees[]>();
    const [users, setUsers] = useState<Users[]>();

    useEffect(() => {
        populateEmployeeData();
        populateUserData();
    }, []);

    const employeeContents = employees === undefined 
        ? <p><em>Loading...</em></p>
        : 
        <>
            <table className="table table-striped" aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>City</th>
                        <th>Country</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.map(employee =>
                        <tr key={employee.id}>
                            <td>{employee.first_name}</td>
                            <td>{employee.city}</td>
                            <td>{employee.country}</td>
                        </tr>
                    )}
                </tbody>
            </table>
            
        </>
        ;
    const userContents = users === undefined ? <p><em>Loading...</em></p> : <UsersList users={users} />;

    return (
        <div>
            {employeeContents}
            {userContents}
        </div>
    );

    async function populateEmployeeData() {
        await axios.get('Employee', options)
            .then(function (response) {

                console.log(response)
                setEmployees(response.data)
            })
            .catch(function (err) {
                console.log(err);
            })
    }

    async function populateUserData() {

        await axios.get('User', options)
            .then(function (response) {

                setUsers(response.data)
            })
            .catch(function (err) {
                console.log(err);
             })
    }
}

export default App;