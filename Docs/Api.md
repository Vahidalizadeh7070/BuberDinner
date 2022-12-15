# Buber Dinner API

- [Bubber Dinner API](#buber-dinner-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register_request)
            - [Register Response](#register_response)
        - [Login](#login)
            - [Login Request](#login_request)
            - [Login Response](#login_response)

## Auth
### Register

```js
POST {{host}}/auth/register
```
#### Register Request
```json
{
    "firstname" : "test",
    "lastname" : "test",
    "email" : "test@test.com",
    "password" : "123456"
}
```
#### Register Response
```js
200 OK
```
```json
{
    "id" : "20fca7a6-1481-452c-8f6e-3fb5a6cbb13e" ,
    "firstname" : "test",
    "lastname" : "test",
    "email" : "test@test.com",
    "token" : "eyJhbGciOiJSUzI1N...."
}
```
### Login
```js
POST {{host}}/auth/login
```
#### Login Request
```json
{
    "email" : "test@test.com",
    "password" : "123456"
}
```
#### Login Response
```js
200 OK
```
```json
{
    "id" : "20fca7a6-1481-452c-8f6e-3fb5a6cbb13e" ,
    "firstname" : "test",
    "lastname" : "test",
    "email" : "test@test.com",
    "token" : "eyJhbGciOiJSUzI1N...." 
}
```



