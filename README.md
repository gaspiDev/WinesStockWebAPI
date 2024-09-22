## Wines Stock Web API
 
###### Estas son la tecnologias utilizadas para el desarrollo de la aplicacion:
- **C#** (Lenguaje de programación OOP, desarrollado por Microsoft)
- **ASP .NET Core** (Web Framework util para la creación y manejo de APIs)
- **Entity Framework** (ORM necesario para mapear las  entidades de nuestra API con los recursos de nuestra base de datos)
- **SQLite** (Sistema de Gestion de base de datos no tradicional, es autocontenido y ligero ya que gestiona todo en un unico archivo)

#### Estas son las solicitudes HTTP que se pueden realizar hasta el momento:
POST) Registrar un nuevo *Wine*  
  URL = https://localhost:7186/api/WineStock/Wine  
  BODY    
  {  
    "name": "string",  
    "variety": "string",  
    "year": 0,  
    "region": "string",  
    "stock": 0  
  }  
  ... Procesa la solicitud ...  
  RESPONSE   
  = Status Code 201 Created -> representacion del recurso creado.  
  = Staus Code 400 Bad Request -> el nombre del vino ya existe y no se admiten duplicados.   
  
POST) Registrar un nuevo *User*
  URL = https://localhost:7186/api/WineStock/User
  BODY 
  {
    "username": "string",
    "password": "stringstri"
  }
  ... Procesa la solicitud ...
  RESPONSE = Status Code 201 Created -> representacion del recurso creado.
                                        o
           = Staus Code 400 Bad Request -> el nombre de usuario ya existe y no se admiten duplicados

GET) Obtener el stock de todos los *Wine*
  URL = https://localhost:7186/api/WineStock/WineStock
  ... Procesa la solicitud ...
  RESPONSE = Status Code 200 Ok -> Diccionario {
                                                  "WineName": StockQuantity
                                                  "WineName": StockQuantity
                                                  "WineName": StockQuantity
                                                  "WineName": StockQuantity
                                                  "WineName": StockQuantity
                                               }

