import React from 'react';
import { Link, useHistory } from 'react-router-dom';
import { useOktaAuth } from '@okta/okta-react';

const Home = () => {
  const { authState, oktaAuth } = useOktaAuth();
  const history = useHistory();

  if ( authState!= null && authState.isPending) {
    return <div>Loading...</div>;
  }

  const button = authState!= null && authState.isAuthenticated ?
    <button onClick={() => {oktaAuth.signOut()}}>Logout</button> :
    <button onClick={() => {history.push('/login')}}>Login</button>;

  return (
    <div>
      <Link to='/'>Home</Link><br/>
      <Link to='/protected'>Protected</Link><br/>
      {button}
    </div>
  );
};
export default Home;
