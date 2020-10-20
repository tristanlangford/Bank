import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import { Account } from './Account';

import Enzyme, { shallow, render, mount } from 'enzyme';
import toJson from 'enzyme-to-json';
import Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({ adapter: new Adapter() })

describe("Account", function(){

    const accountMock = {
        _Name: "test",
        _Id: 1,
        balance: 10,
        _Statement: ["date || credit || debit || balance", "22/04/2018 || || 500.00 || 500.00"]
    }

    let wrapper;
        
    beforeEach(() => wrapper = shallow(
            <Account/>
        ));


    it("has correct starting state", async function() {
        expect(wrapper.state('Account')).toEqual(null)
        expect(wrapper.state('Loading')).toBe(true)
        expect(wrapper.state('value')).toEqual(0)
    })

    it("renders the correct account details", function() {
        wrapper.setState({ Account: accountMock, Loading: false })
        expect(wrapper.find('.balance').text()).toEqual("Balance: £10")
    })

})