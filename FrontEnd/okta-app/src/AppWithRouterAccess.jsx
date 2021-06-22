import React from 'react';
import { Route, useHistory } from 'react-router-dom';
import { Security, SecureRoute, LoginCallback } from '@okta/okta-react';
import { OktaAuth } from '@okta/okta-auth-js';
import Home from './Home';
import SignIn from './SignIn';
import Protected from './Protected';

const AppWithRouterAccess = () => {
  const history = useHistory();
  const onAuthRequired = () => {
    history.push('/login');
  };
  const restoreOriginal = () => {
    
  }

  const oktaAuth = new OktaAuth({
    issuer: 'https://{OktaDomain}/oauth2/default',
    clientId: '{clientId of the app}',
    redirectUri: window.location.origin + '/login/callback',
    onAuthRequired: onAuthRequired,
    pkce: false
  });

  return (
    <Security oktaAuth={oktaAuth} restoreOriginalUri= {restoreOriginal}>
      <Route path='/' exact={true} component={Home} />
      <SecureRoute path='/protected' component={Protected} />
      <Route path='/login' render={() => <SignIn />} />
      <Route path='/login/callback' component={LoginCallback} />
    </Security>
  );
};
export default AppWithRouterAccess;
