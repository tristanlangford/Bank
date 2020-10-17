import React, { Component } from 'react';

export class Account extends Component {

    constructor(props) {
        super(props);
        this.state = {
            balance: 0,
            loading: true,
            depositValue: 0,
            withdrawValue: 0,
            statement: "",
        };

        this.setDepositValue = this.setDepositValue.bind(this);
        this.deposit = this.deposit.bind(this);
        this.setWithdrawValue = this.setWithdrawValue.bind(this);
        this.withdraw = this.withdraw.bind(this);
    }

    componentDidMount() {
        this.getStatement();
        this.getBalance();
        
    }

    setDepositValue(event) {
        this.setState({ depositValue: event.target.value })
    }

    setWithdrawValue(event) {
        this.setState({ withdrawValue: event.target.value })
    }

    formatStatement(statement) {
        var formattedStatement = []
        for (let x = 0; x < statement.length; x++) {
            formattedStatement.push(<div>{statement[x]}</div>)
        }
        return formattedStatement
    }

    renderAccount(balance, statement) {
        return (
            <div>
                <div>Balance: {balance}</div>
                <div>Make a Deposit:
                <input type="number" onChange={this.setDepositValue} min='0.01' pattern="^\d*(\.\d{0,2})?$" value={this.state.depositValue}/>
                    <button value="Confirm" onClick={this.deposit} value={this.state.depositValue}>Confirm</button>
                </div>
                <div>Make a Withdrawal:
                <input type="number" onChange={this.setWithdrawValue} min='0.01' pattern="^\d*(\.\d{0,2})?$" value={this.state.withdrawValue} />
                    <button value="Confirm" onClick={this.withdraw} value={this.state.withdrawValue}>Confirm</button>
                </div>
                <div>
                    <span>{this.formatStatement(statement)}</span>
                </div>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Getting Account Details...</em></p>
            : this.renderAccount(this.state.balance, this.state.statement);

        return (
            <div>
                <h1 id="tabelLabel" >Your Bank Account</h1>
                {contents}
            </div>
        );
    }

    async deposit(event) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(event.target.value)
        };
        const response = await fetch('account/deposit', requestOptions);
        const data = await response.json();
        this.setState({ balance: data, depositValue: 0 });
        this.getStatement()
    }

    async withdraw(event) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(event.target.value)
        };
        const response = await fetch('account/withdraw', requestOptions);
        const data = await response.json();
        this.setState({ balance: data, withdrawValue: 0 });
        this.getStatement()
    }

    async getBalance() {
        const response = await fetch('account');
        const data = await response.json();
        this.setState({ balance: data, loading: false });
    }

    async getStatement() {
        const response = await fetch('account/statement');
        const data = await response.json();
        this.setState({ statement: data });
    }
}
