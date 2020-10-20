import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import { AccountsList } from './AccountsList';

import Enzyme, { shallow, render, mount } from 'enzyme';
import toJson from 'enzyme-to-json';
import Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({ adapter: new Adapter() })

const accountMock = [{
    _Name: "test",
    _Id: 1,
    balance: 10
}]

// global.fetch = jest.fn(() =>
//   Promise.resolve({
//     json: () => Promise.resolve(accountMock),
//   })
// );

it("sets account to state following api request", function() {
    const accountList = shallow(<AccountsList />);
    expect(accountList.state('Accounts')).toEqual([])
    expect(accountList.state('Loading')).toBe(true)
})

// describe('AccountList', function() {

//     let accountList;
//     const account1 = {
//         _Name: "test",
//         _Id: 1,
//         balance: 10
//     }
//     const accountArray = [account1]

//     beforeEach(function() {
        
//     })

//     it('formats Accounts', function() {
//         var expectedOutcome = [<div><li><a href="/account/1">test</a><span className="balance">Balance: £10</span><button className="delete" value={1}>Delete</button></li></div>, (<div key={2} >
//                 <li>
//                     <a href={"/account/2"}>
//                         {"test2"}
//                     </a>
//                     <span className="balance" >
//                         Balance: £{3}
//                     </span>
//                     <button className="delete" onClick={this.deleteAccount} value={2}>
//                         Delete
//                     </button>
//                 </li>
//             </div>)]
        
//         expect(new AccountsList().formatAccountsList(accountArray)[0]).toEqual(expectedOutcome[0])
//     })
// })
