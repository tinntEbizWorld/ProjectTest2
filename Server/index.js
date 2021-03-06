var io = require('socket.io')(process.env.PORT || 53200);

const spawn = require('nodemon/lib/spawn');
//Custom Classes
var Player = require('./Class/Player.js');


console.log('Server has started');

var players=[];
var sockets=[];


io.on('connection',function(socket){
    console.log('connection made!');

    var player = new Player();
    var thisPlayerID =player.id;

    players[thisPlayerID]=player;
    socket[thisPlayerID]=socket;

    //Tell the client that this is our id for the server
    socket.emit('register',{id:thisPlayerID});
    socket.emit('spawn', player);//Tell myseft have spawned
    socket.broadcast.emit('spawn',player);//Tell other I have spawned

    
    //Tell myself about everyone else in game
    for(var playerID in players){
        if(playerID !=thisPlayerID){
            socket.emit('spawn',players[playerID]);
        }
    }

    //Positional Data from client
    socket.on('updatePosition',function(data){
        player.position.x = data.position.x;
        player.position.y = data.position.y;
        
        socket.broadcast.emit('updatePosition',player);
    });

    socket.on('updateRotation',function(data){
        player.tankRotation = data.tankRotation;
        player.barrelRotation = data.barrelRotation;

        socket.broadcast.emit('updateRotation',player);
    });

    socket.on('disconnect', function(){
        console.log('A player has disconnected');
        delete players[thisPlayerID];
        delete sockets[thisPlayerID];

        socket.broadcast.emit("disconnected",player);
    });
});