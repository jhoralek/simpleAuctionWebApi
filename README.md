### Main technologies

ASP.NET CORE v2.0
EF6 Core with CodeFirst db and migrations
Kestrel
MySql

This WebApi will be used for consumig by Vue+Vuex app, some Phone aps etc.

# Automobile auction house

Simple web application for auctions of cars or heavy machinery.
We were asked to create a web portal with the option of auctioning heavy machinery and cars.

## Technologies we used

### Backend

- [MySQL 8.0.11](https://dev.mysql.com/doc/refman/8.0/en/) - Database

- [ASP .NET Core 2.0](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.0) - WebApi

  - ### Patterns we used

    - [Repository](https://dotnettutorials.net/lesson/repository-design-pattern-csharp/)
    - [Dependency Injection](https://dotnettutorials.net/lesson/dependency-injection-design-pattern-csharp/)
    - [Singleton](https://dotnettutorials.net/lesson/singleton-design-pattern/)

  - Poco classes to minimalise data transfere from backend to frontend
  - All WebApi comunication is in **_async mode_**
  - WebApi authentication is based on [JwTBearer Tokens](https://jwt.io/introduction/) supported by [Auth0](https://auth0.com/docs/api-auth)

- [Entity Framework Core 2.0.1](https://www.entityframeworktutorial.net/efcore/install-entity-framework-core.aspx)

  - Code First type with Migrations

- ### Tools and libraries
  - [Automapper](http://docs.automapper.org/en/stable/Getting-started.html) - Object to Object mapper
  - [Newtonsoft.Json](https://www.newtonsoft.com/json) - work with Json data structure
  - [MailKit](https://www.nuget.org/packages/MailKit/) - handling emails

### Frontend

- [ASP .NET Core 2 MVC](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-2.0&tabs=visual-studio) - used as default platform for [SPA](https://en.wikipedia.org/wiki/Single-page_application) application.
- [Kestrel](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.1) web server - it is cross-platform web server.
- [VUE.js](https://vuejs.org/v2/guide/) - progresive framework for building user interfaces.
- ### Programing languages

  - [TypeScript](https://www.typescriptlang.org/) - strongly typed javascript by Microsoft
  - [Less](http://lesscss.org/) - it's css with just a little more.
  - [CSS](https://www.w3schools.com/css/) - styling of HTML documents.
  - [HTML5](https://www.w3schools.com/html/html5_intro.asp)

- ### Tools and libraries
  - [Webpack](https://webpack.js.org/) - bundling all code and images to final application
  - [tslint](https://palantir.github.io/tslint/) - analysis tool that check TypeScript
  - [cypress](https://www.cypress.io/) - fast and easy testing anything that runs in a browser
  - [babel](https://babeljs.io/) - javascript compiler
  - [vuex](https://vuex.vuejs.org/) - state management pattern. It's neccesary when doing some bigger in VUE then only one page.
  - [vuetify](https://vuetifyjs.com/en/) - it is design component framework.
  - [axios](https://github.com/axios/axios) - promise based HTTP client for node.js
  - [crypto-js](https://www.npmjs.com/package/crypto-js) - crypto standards.
  - [material icons](https://material.io/resources/icons/?style=baseline) - icons and nice crafted symbols.

### Developing environment and tools

For that purposes we used only a few tools to develope this application. First of all is [Visual Studo Code](https://code.visualstudio.com/), it is one of the most lightweight and open tool ever. Especially with their extension and big community. It's super easy to download neccessary extensions for you project and basically immediately start to develop.

Second one is [git](https://git-scm.com/) - distributed version control system. [NPM](https://www.npmjs.com/) is a world largest software registry.

### Destination platform

All of this is because we wanted an application that would run in a [docker](https://www.docker.com/) container. Docker is a platform for digital transformation. We wanted application that will be able to run accros hybrid platorms. It enable us to achive end-to-end application from developing and scaling appliction over testing with customer to publisihing. All stages of developing, testing and publishing has the same environment, so there is no to have a trouble with any settings.
Provisioning all environments is done by same initiating scripts.

## Getting Started

For starting this project on your local machine is neccesary download or clone from github.com

clone in console into your favorite directory

```
git clone https://github.com/jhoralek/simpleAuctionWebApi.git
```

### Prerequisites

Before you compile and start the application you need to have some software installed.

- [.NET Core 2.0](https://dotnet.microsoft.com/download/dotnet-core/2.0) - Download and install Runtime for your operation system.
- [MySQL database](https://dev.mysql.com/downloads/mysql/) - Download and isntall server for you operation system.
- [Node.js and NPM](https://nodejs.org/en/download/) - Download and isntall for your operation system. When is installed.

Test if all is installed and set successfuly. Open command prompt and write:

```
node --verson
```

should give you v.8.4.0 or above

```
npm --verson
```

should give you 6.4.1 or above

### Installing

To run the application you need do two things.
You will need two command prompts. First for starting the MVC application with WebApi and second one for SPA application which will be commpiled and prepared to load.

In the first command prompt go to into the SA.Web directory of the project and write

```
dotnet run --project SA.Web.csproj
```

It will compile and start the kestrel web server on url address http://localhost:5000. Open the browser and navigate to that url.

In the same directory as above write and run this command

```
npm run build-dev
```

This will compile and copy SPA application into the wwwroot directory inside of the SA.Web project.

Now it is ready to use.

## Authors

- **Jiri Horalek** - _Initial work_ - [jhoralek](https://github.com/jhoralek)

See also the list of [contributors](https://github.com/jhoralek/simpleAuctionWebApi/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
