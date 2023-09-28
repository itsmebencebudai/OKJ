
var http = require('http');
var sd = require('./sajatmodule');


//create a server object:
http.createServer(function (req, res) {
  res.writeHead(201,{'Content-Type': 'text/html'})
  res.write('Hello World!' + sd.sajatDatum()); //write a response to the client
  res.write(req.url);
  res.end(); //end the response
}).listen(8080); //the server object listens on port 8080