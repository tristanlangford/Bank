import React, { Component } from 'react';

export class Account extends Component {

    constructor(props) {
        super(props);
        this.state = { balance: 0, loading: true };
    }

    componentDidMount() {
        this.getBalance();
    }

    static renderAccount(balance) {
        return (
            <div>
                Balance: {balance}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Getting Account Details...</em></p>
            : Account.renderAccount(this.state.balance);

        return (
            <div>
                <h1 id="tabelLabel" >Your Bank Account</h1>
                {contents}
            </div>
        );
    }

    async getBalance() {
        const response = await fetch('account');
        const data = await response.json();
        this.setState({ balance: data, loading: false });
    }
}
