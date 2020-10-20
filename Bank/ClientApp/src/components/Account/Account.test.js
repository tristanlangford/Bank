import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import { Account } from './Account';

import Enzyme, { shallow, render, mount } from 'enzyme';
import toJson from 'enzyme-to-json';
import Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({ adapter: new Adapter() })

it("sets account to state following api request", async function() {
    const accountList = shallow(<Account />);
    expect(accountList.state('Account')).toEqual(null)
    expect(accountList.state('Loading')).toBe(true)
    expect(accountList.state('value')).toEqual(0)
})