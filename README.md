# Backend Application

This is a .NET 7 backend application that uses an ApiGateway and 3 microservices hosted on Docker. The front end client should make RESTful requests to the ApiGateway on the port `32770`, which will pass the call to the appropriate microservice based on the Ocelot configuration.

# Microservices 
## LoginApi
The LoginApi microservice is used for authorizing a user. It exposes the following endpoints:

 * /login: POST request that takes in a user's credentials and returns a JWT token and the user profile if the credentials are valid.
     * Request body:
        ```json
        {
          "username": "string",
          "password": "string"
        }
        ```

    * Response body:
    
        ```json
        {
            "username": "string",
            "id": "string",
            "email": "string",
            "token": "string"
        }
        ```
## CarDealershipApi
The CarDealershipApi microservice is used for getting a list of cars and car details. It uses JWT authentication. It exposes the following endpoints:

 * /cars: GET request that returns a list of all cars in the dealership.

    * Response body:
        
        ```json
        [{
            "id": "string",
            "name": "string",
            "picture": "string",
            "details": "string"
        }]
        ```
 * /cars/{id}: GET request that returns the details of a specific car.

    * Path parameter:
      * `id`: The ID of the car.
    
    * Response body:
        ```json
        {
          "id": "string",
          "name": "string",
          "picture": "string",
          "details": "string",
          "make": "string",
          "year": 0,
          "seats": 0,
          "horsepower": 0,
          "engine": "string",
          "kilometers": 0,
          "price": 0
        }
        ```
## OrderApi
The OrderApi microservice is used for sending a mail to the user using SendGrid. It uses JWT authentication. It exposes the following endpoint:

* /order: POST request that takes in an order and sends an email confirmation to the user.

    * Request body:
        ```json
        {
          "car": "string",
          "price": "string",
          "details": "string",
          "name": "string",
          "email": "string"
        }
        ```
## ApiGateway
The ApiGateway is responsible for routing requests from the front end to the appropriate microservice based on the Ocelot configuration. It is exposed on `http://localhost:32770` It exposes the following endpoints:

* /login: POST request that forwards the request to the LoginApi microservice.
* /cars: GET request that forwards the request to the CarDealershipApi microservice.
* /cars/{id}: GET request that forwards the request to the CarDealershipApi microservice.
* /order: POST request that forwards the request to the OrderApi microservice.

## Technologies Used
* .NET 7
* Asp .NET
* Docker
* Ocelot
* JWT authentication
* SendGrid
* Kafka
