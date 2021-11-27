# Geocache API
Created 11.26.21</br>
By _**Jesse Callahan**_</br>
Contact: _**Jessetylercallahan@gmail.com**_</br>

## Setup/Installation Instructions

1. Clone repository
2. Navigate to the 'GeocacheAPI' folder in your terminal use the command 'dotnet restore' to load boilerplate.
3. Use the command 'dotnet ef database update' to run the SQLite database migration. 
4. Use command 'dotnet run' in your terminal to run server
5. Copy the local host 5000 server link into Postman or perferred API testing platform, copy 'http://localhost:5000/swagger/index.html' into your broswer url bar to test API with swagger

## Description
This application simulates the enormously popular Geocache game. 

### GET A LIST OF GEOCACHE LOCATIONS AND ACTIVE ITEMS
### GET /api/Geocaches/

<img src="./geocacheAPI/wwwroot/images/readme1.png" alt="list of get geocache" width="500"/>

### ADD A GEOCACHE LOCATION 
### POST /api/Geocaches/

<img src="./geocacheAPI/wwwroot/images/readme2.png" alt="list of get geocache" width="500"/>

### ADD AN ACTIVE ITEM TO A GEOCACHE LOCATION 
### (ONLY THREE ACTIVE ITEMS PER LOCATION)
### POST /api/Items/8

<p>
<img src="./geocacheAPI/wwwroot/images/readme3.png" alt="post new item" width="300"/>
<img src="./geocacheAPI/wwwroot/images/readme4.png" alt="list of get geocache" width="300"/>
</p>

### MOVE AN ITEM TO NEW LOCATION 
### PATCH /api/Items/8
Make sure to add item id to url bar and add which Geocache Id you want to switch into

<p>
<img src="./geocacheAPI/wwwroot/images/readme5.png" alt="patch geocache id" width="500"/>
<img src="./geocacheAPI/wwwroot/images/readme6.png" alt="list of get geocache" width="300"/>
</p>

### GET LIST OF ALL ITEMS
### GET /api/Items/

<img src="./geocacheAPI/wwwroot/images/readme7.png" alt="list of get items" width="500"/>

### GET LIST OF INACTIVE ITEMS
### GET /api/Items/inactive

<img src="./geocacheAPI/wwwroot/images/readme8.png" alt="list of get inactive items" width="500"/>

Full swagger documentation can found below.

## Specs

![swagger](./geocacheAPI/wwwroot/images/swagger.png)

Visit the swagger docs website [here](https://app.swaggerhub.com/apis/jessetylercallahan/geocache-api/1.0#/)

This is more of a static version of documentation. If you want to interact with the API, run 'dotnet run' in your terminal and copy 'http://localhost:5000/swagger/index.html' into your browser url bar.

One-to-many database relationship:

![schema](./geocacheAPI/wwwroot/images/schema.png)

## Technologies Used
* C#
* SQLite
* Web API
* Entity Framework
* LINQ
* .NET Asp Core


