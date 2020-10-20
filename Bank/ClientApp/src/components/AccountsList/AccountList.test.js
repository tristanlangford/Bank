import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import { AccountsList } from './AccountsList';

import Enzyme, { shallow, render, mount } from 'enzyme';
import toJson from 'enzyme-to-json';
import Adapter from 'enzyme-adapter-react-16';

Enzyme.configure({ adapter: new Adapter() })

describe("AccountList", function(){

    const accountMock = [{
        _Name: "test",
        _Id: 1,
        balance: 10
    }]

    let wrapper;
    
    beforeAll(function() {
        global.fetch = jest.fn();
    })

    beforeEach(function() {
        wrapper = shallow(
            <AccountsList/>
        )
    });

    afterEach(() => {
        wrapper.unmount();
     });

    it("renders the correct account details", function() {
        wrapper.setState({ Accounts: accountMock, Loading: false })
        expect(wrapper.find('.balance').text()).toContain("10")
        expect(wrapper.find('.account-link').text()).toEqual("test")
    })

    it("starts with the correct state", function() {
        expect(wrapper.state('Accounts')).toEqual([])
        expect(wrapper.state('Loading')).toBe(true)
    })

    it("update accounts on component call", (done) => {

        const spyDidMount = jest.spyOn(AccountsList.prototype,"getAccountsList");
        fetch.mockImplementation(() => {
            return Promise.resolve({
                status: 200,
                json: () => {
                return Promise.resolve(accountMock);
                }
            });
        });
        const didMount = wrapper.instance().getAccountsList();

        expect(spyDidMount).toHaveBeenCalled();

        didMount.then(() => {
            // updating the wrapper
            wrapper.update();
            expect(wrapper.state('Accounts')).toEqual(accountMock)
            spyDidMount.mockRestore();
            fetch.mockClear();
            done();
       });
    })

    it("update accounts on new account creation", (done) => {

        const spyDidMount = jest.spyOn(AccountsList.prototype,"createNewAccount");
        fetch.mockImplementation(() => {
            return Promise.resolve({
                status: 200,
                json: () => {
                return Promise.resolve(accountMock);
                }
            });
        });
        const didMount = wrapper.instance().createNewAccount();

        //expect(spyDidMount).toHaveBeenCalled();

        didMount.then(() => {
            // updating the wrapper
            wrapper.update();
            expect(wrapper.state('Accounts')).toEqual(accountMock)
            spyDidMount.mockRestore();
            fetch.mockClear();
            done();
       });
    })

    it("update accounts on delete", (done) => {

        const spyDidMount = jest.spyOn(AccountsList.prototype,"deleteAccount");
        fetch.mockImplementation(() => {
            return Promise.resolve({
                status: 200,
                json: () => {
                return Promise.resolve(accountMock);
                }
            });
        });
        const didMount = wrapper.instance().deleteAccount({target: {value: 1}});

        //expect(spyDidMount).toHaveBeenCalled();

        didMount.then(() => {
            // updating the wrapper
            wrapper.update();
            expect(wrapper.state('Accounts')).toEqual(accountMock)
            spyDidMount.mockRestore();
            fetch.mockClear();
            done();
       });
    })
    
    
    

})
