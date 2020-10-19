import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import { AccountsList } from './AccountsList';

describe('AccountList', function() {

    let accountList;
    const account1 = {
        _Name: "test",
        _Id: 1,
        balance: 10
    }
    const account2 = {
        _Name: "test2",
        _Id: 2,
        balance: 3
    }
    const accountArray = [account1, account2]

    beforeEach(function() {
        
    })

    it('formats Accounts', function() {
        var expectedOutcome = [<div><li><a href="/account/1">test</a><span className="balance">Balance: £10</span><button className="delete" value={1}>Delete</button></li></div>, (<div key={2} >
                <li>
                    <a href={"/account/2"}>
                        {"test2"}
                    </a>
                    <span className="balance" >
                        Balance: £{3}
                    </span>
                    <button className="delete" onClick={this.deleteAccount} value={2}>
                        Delete
                    </button>
                </li>
            </div>)]
        
        expect(new AccountsList().formatAccountsList(accountArray)[0]).toEqual(expectedOutcome[0])
    })
})
