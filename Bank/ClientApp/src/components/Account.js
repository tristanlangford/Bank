import React, { Component } from 'react';

export class Account extends Component {

    constructor(props) {
        super(props);
        this.state = { balance: 0, loading: true, value: 1 };

        this.setValue = this.setValue.bind(this);
        this.deposit = this.deposit.bind(this);
    }

    componentDidMount() {
        this.getBalance();
    }

    setValue(event) {
        console.log(event.target.value)
        this.setState({ value: event.target.value })
    }

    renderAccount(balance) {
        return (
            <div>
                <div>Balance: {balance}</div>
                <div>Make a Deposit:
                <input type="number" onChange={this.setValue} />
                    <button value="Confirm" onClick={this.deposit} value={this.state.value}>Confirm</button>
                </div>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Getting Account Details...</em></p>
            : this.renderAccount(this.state.balance);

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
        this.setState({ balance: data, value: 0 });
    }

    async getBalance() {
        const response = await fetch('account');
        const data = await response.json();
        this.setState({ balance: data, loading: false });
    }
}
