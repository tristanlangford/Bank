import React, { Component } from 'react';
import './Account.css'

export class Account extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Account: null,
            Loading: true,
        };

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

    renderAccount(account) {
        return (
            <div>
                <h1>Account: {account._Name}</h1>
                <div className="balance">Balance: £{account.balance}</div>
                <div className="actions">
                    <span className="deposit">Deposit: 
                            <input type="number" min='0' />
                            <button value="Confirm" >Confirm</button>
                    </span>
                    <span className="withdraw">Withdraw: 
                            <input type="number" min='0' />
                            <button value="Confirm" >Confirm</button>
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
        console.log(data)
        this.setState({ Account: data, Loading: false });
    }
    //async deposit(event) {
    //    const requestOptions = {
    //        method: 'POST',
    //        headers: { 'Content-Type': 'application/json' },
    //        body: JSON.stringify(this.state.depositValue)
    //    };
    //    const response = await fetch('account/deposit', requestOptions);
    //    const data = await response.json();
    //    this.setState({ balance: data, depositValue: 0 });
    //    this.getStatement()
    //}

    //async withdraw(event) {
    //    const requestOptions = {
    //        method: 'POST',
    //        headers: { 'Content-Type': 'application/json' },
    //        body: JSON.stringify(this.state.withdrawValue)
    //    };
    //    const response = await fetch('account/withdraw', requestOptions);
    //    const data = await response.json();
    //    this.setState({ balance: data, withdrawValue: 0 });
    //    this.getStatement()
    //}

    //async getBalance() {
    //    const response = await fetch('account');
    //    const data = await response.json();
    //    this.setState({ balance: data, loading: false });
    //}

    //async getStatement() {
    //    const response = await fetch('account/statement');
    //    const data = await response.json();
    //    this.setState({ statement: data });
    //}
}
