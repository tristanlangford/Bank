import React, { Component } from 'react';

export class AccountsList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Loading: true,
            Accounts: [],
            NewAccountName: "",
        };

        this.createNewAccount = this.createNewAccount.bind(this);
        this.deleteAccount = this.deleteAccount.bind(this);
    }

    componentDidMount() {
        this.getAccountsList();
    }

    formatAccountsList(accounts) {
        var formattedAccounts = [];
        for (let x = 0; x < accounts.length; x++) {
            formattedAccounts.push(<li key={accounts[x]._Id}><a href={"/account/" + accounts[x]._Id}>{accounts[x]._Name}</a><button value={accounts[x]._Id} onClick={this.deleteAccount}>Delete</button></li>)
        }
        return formattedAccounts
    }

    renderAccountsList(accounts) {
        return (
            <div>
                <form>
                    Create New Account <input type="text" placeholder="Name" onChange={event => this.setState({ NewAccountName: event.target.value }) } />
                    <button onClick={this.createNewAccount}>Create</button>
                </form>
                {this.formatAccountsList(accounts)}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Getting Account Details...</em></p>
            : this.renderAccountsList(this.state.Accounts);

        return (
            <div className="account-container">
                <h1 id="tabelLabel" >Your Bank Accounts</h1>
                {contents}
            </div>
        );
    }

    async getAccountsList() {
        const response = await fetch('accountslist');
        const data = await response.json();
        this.setState({ Accounts: data, Loading: false });
    }

    async createNewAccount(event) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(this.state.NewAccountName)
        };
        const response = await fetch('accountslist', requestOptions);
        const data = await response.json();
        this.setState({ Accounts: data });
    }

    async deleteAccount(event) {
        const requestOptions = {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(event.target.value)
        };
        const response = await fetch('accountslist', requestOptions);
        const data = await response.json();
        this.setState({ Accounts: data });
    }
}
