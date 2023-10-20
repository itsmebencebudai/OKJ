
Endpoint: 

GET /user 
what does this endpoint? - Returns every users registration data 
Has parameters? - No
IF has parameter -> returns something

Example:
get /user/1 - Returns the user that has registered and his/her userId = 1 
The response is a JSON, xml

[{ - its an array of objects
    userId: 1,
    name: "",
    .
    .
    .
},{
    userId: 2,
    name: "",
    .
    .
    .
}]

user[0].userId - this is how i can call the above lines (response) 

What will the developer see? - user.userId=1, user.name=""


