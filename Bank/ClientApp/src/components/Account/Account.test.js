import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import { Account } from './Account';

import Enzyme, { shallow, render, mount } from 'enzyme';
import toJson from 'enzyme-to-json';
import Adapter from 'enzyme-adapter-react-16';
import { isPropertySignature } from 'typescript';

Enzyme.configure({ adapter: new Adapter() })

describe("Account", function(){

    const accountMock = {
        _Name: "test",
        _Id: 1,
        balance: 10,
        _Statement: ["date || credit || debit || balance", "22/04/2018 || || 500.00 || 500.00"]
    }

    let wrapper;

    beforeAll(function() {
        global.fetch = jest.fn();
    })
        
    beforeEach(() => wrapper = shallow(
            <Account match={{params: {id: 1}}}/>, { disableLifecycleMethods: true }
        ));

    afterEach(() => {
        wrapper.unmount();
        });


    it("has correct starting state", async function() {
        expect(wrapper.state('Account')).toEqual(null)
        expect(wrapper.state('Loading')).toBe(true)
        expect(wrapper.state('value')).toEqual(0)
    })

    it("renders the correct account details", function() {
        wrapper.setState({ Account: accountMock, Loading: false })
        expect(wrapper.find('.balance').text()).toEqual("Balance: £10")
    })

    it("update accounts on withdrawal", (done) => {

        const spyDidMount = jest.spyOn(Account.prototype,"withdrawal");
        fetch.mockImplementation(() => {
            return Promise.resolve({
                status: 200,
                json: () => {
                return Promise.resolve(accountMock);
                }
            });
        });
        const didMount = wrapper.instance().withdrawal("event");

        didMount.then(() => {
            wrapper.update();
            expect(wrapper.state('Account')).toEqual(accountMock)
            spyDidMount.mockRestore();
            fetch.mockClear();
            done();
       });
    })

    it("update accounts on deposit", (done) => {

        const spyDidMount = jest.spyOn(Account.prototype,"deposit");
        fetch.mockImplementation(() => {
            return Promise.resolve({
                status: 200,
                json: () => {
                return Promise.resolve(accountMock);
                }
            });
        });
        const didMount = wrapper.instance().deposit("event");

        didMount.then(() => {
            wrapper.update();
            expect(wrapper.state('Account')).toEqual(accountMock)
            spyDidMount.mockRestore();
            fetch.mockClear();
            done();
       });
    })

    it("update accounts on component call", (done) => {

        const spyDidMount = jest.spyOn(Account.prototype,"getAccount");
        fetch.mockImplementation(() => {
            return Promise.resolve({
                status: 200,
                json: () => {
                return Promise.resolve(accountMock);
                }
            });
        });
        const didMount = wrapper.instance().getAccount();

        didMount.then(() => {
            // updating the wrapper
            wrapper.update();
            expect(wrapper.state('Account')).toEqual(accountMock)
            spyDidMount.mockRestore();
            fetch.mockClear();
            done();
       });
    })


})