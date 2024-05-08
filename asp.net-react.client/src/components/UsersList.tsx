interface Employees {
    id: number,
    first_name: string,
    last_name: string,
    contact_number: number,
    birth_date: string,
    street_address: string,
    city: string,
    postal_code: string,
    country: string
}
interface Users {

    users: [{
        id: number,
        username: string,
        email: string,
        employee: Employees
    }]
}

function UsersList({ users }: Users) {
    return (
        <>
            <table className="table table-striped" aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Username</th>
                        <th>Matching Employee</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.id}>
                            <td>{user.username}</td>
                            <td>{user.employee.id}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </>
    )

}

export default UsersList;