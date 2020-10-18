import React, { Component } from 'react';
import './Account.css'

export class Account extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Account: null,
            Loading: true,
            value: 0,
        };

        this.withdrawal = this.withdrawal.bind(this)
        this.deposit = this.deposit.bind(this)
    }

    componentDidMount() {
        this.getAccount()
    }

    formatStatement(statement) {
        var formattedStatement = [];
        for (let x = 0; x < statement.length; x++) {
            var brokenLine = statement[x].split("||");
            var tableRow = []
            brokenLine.forEach(i => tableRow.push(<td> {i}</td >));
            formattedStatement.push(<tr>{tableRow}</tr>)
        }
        return formattedStatement
    }

    async withdrawal(event) {
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(this.state.value)
        };
        const response = await fetch(`accountslist/withdraw/${this.props.match.params.id}`, requestOptions);
        const data = await response.json();
        this.setState({ Account: data });
    }

    async deposit(event) {
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(this.state.value)
        };
        const response = await fetch(`accountslist/deposit/${this.props.match.params.id}`, requestOptions);
        const data = await response.json();
        this.setState({ Account: data });
    }
 
    renderAccount(account) {
        return (
            <div>
                <h1>Account: {account._Name}</h1>
                <div className="balance">Balance: £{account.balance}</div>
                <div className="actions">
                    <span className="deposit"> 
                            <button onClick={this.deposit}>Deposit</button>
                    </span>
                    <span>
                        <input type="number" min='0' onChange={event => this.setState({ value: event.target.value })} />
                    </span>
                    <span className="withdraw">
                            <button onClick={this.withdrawal}>Withdraw</button>
                    </span>
                    </div>
                <div>
                    <table>
                        <tbody>
                            {this.formatStatement(account._Statement)}
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }

    render() {
        let contents = this.state.Loading
            ? <p><em>Getting Account Details...</em></p>
            : this.renderAccount(this.state.Account);

        return (
            <div className="account-container">
                {contents}
            </div>
        );
    }

    async getAccount() {
        var id = this.props.match.params.id
        const response = await fetch(`accountslist/${id}`);
        const data = await response.json();
        this.setState({ Account: data, Loading: false });
    }
}
