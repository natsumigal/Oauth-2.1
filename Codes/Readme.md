# Application Usage (OAuth)

## Identity Server
Provides Client Credentials flow and Auth code flow with PKCE disable:
- **Download and Run**: Use Visual Studio, works on .NET Core latest version. Access at https://localhost:5001/
- **Documentation**: Read the quickstart guides [here](https://github.com/IdentityServer/IdentityServer4.Samples/tree/master/Quickstarts/).
- **Postman Testing**: Check the Postman Collection folder and read the docs for testing instructions.

## Web Client
- **Setup**: Download and run with Visual Studio. It uses Razor for authentication code flow.

## Demo API (.NET Core API) / Demo Web (React)
Both use authentication code flow:
- **Setup for Demo Web**:
  - Open the `identity-server-demo-web` project in Visual Studio Code.
  - Run `yarn install` to get all necessary packages.
  - Run `yarn start` to launch the app on http://localhost:3006.

## Client/API
- **Client Credentials Flow**: Explore the Client console app to see how it works. Test and read the documentation for more details.

# References
The reference codes and documentation are available at the following links:
- [Duende Software Documentation](https://docs.duendesoftware.com/)
- [Identity Server Demo on GitHub](https://github.com/krisravishankar/identity-server-demo)
    
    
