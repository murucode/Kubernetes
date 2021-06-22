
# Steps to run the application

- Go to FronEnd/okta-app folder and run the below commands

```sh
npm install
```

- Update client id and okta domain in AppWithRouterAccess.jsx file.

```sh
npm start
```

- It uses implicit flow to get the ID and access token.
- Configure your app in the OKTA dev account to support implicit flow.

# references

<https://developer.okta.com/code/react/okta_react/#add-an-openid-connect-client-in-okta>
