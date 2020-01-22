<img src="https://raw.githubusercontent.com/charliemccrea/InstrumentalAPI/master/Front-End/src/assets/logo.png" height="128px">

# InstrumentalAPI

InstrumentalAPI is a Web App designed as practice for interacting with an ASP.NET Core API using a front-end interface built on vue.js.  It involves adding various musical instruments to an in-memory sql database using HTTP requests.

## Prerequisites

In order to use the InstrumentAPI, you will need to ensure you have the following installed:

[Visual Studio](https://visualstudio.microsoft.com/)

[Node.js](https://nodejs.org/en/)

[Vue CLI](https://cli.vuejs.org/)

[Git](https://git-scm.com/)

## Installation

To install InstrumentalAPI, clone the repository and install remaining dependencies by running the following commands from your terminal:

```bash
# Clone repository
git clone https://github.com/charliemccrea/InstrumentalAPI.git
# Navigate to the repository
cd InstrumentalAPI\Front-End
# Install Packages
npm install
```

## Usage

To use the API, both components need to be started in order to interact with the data:

### Back-End

1. Open Visual Studio
2. Open the solution (/Back-End/InstrumentalAPI.sln) file
3. Run the solution within Visual Studio to start the ASP.NET Core API service

### Front-End

1. In a terminal, navigate to the /Front-End repository folder
2. Run the following command to start the node service:

```bash
npm run serve
```

3. You can then open the localhost link displayed in your terminal to access the web interface
4. From there you can interact with the database by using the button requests available to you

## License

[MIT](LICENSE)
