import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout/Layout';
import { Account } from './components/Account/Account';
import { AccountsList } from './components/AccountsList/AccountsList'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={AccountsList} />
            <Route exact path='/account/:id' component={Account} />
      </Layout>
    );
  }
}
