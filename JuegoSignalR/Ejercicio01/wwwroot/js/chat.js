"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//class clsMensajeUsuario{
//    constructor(Usuario, Mensaje) {
//        this.Usuario = Usuario;
//        this.Mensaje = Mensaje;
//    }
//}

////Disable the send button until connection is established.
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (objMensajeUsuario) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    // We can assign user-supplied strings to an element's textContent because it
//    // is not interpreted as markup. If you're assigning in any other way, you
//    // should be aware of possible script injection concerns.
//    li.textContent = `${objMensajeUsuario.Usuario} says ${objMensajeUsuario.Mensaje}`;
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {

//    let objMensajeUsuario = new clsMensajeUsuario();
//    objMensajeUsuario.Usuario = document.getElementById("userInput").value;
//    objMensajeUsuario.Mensaje = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", objMensajeUsuario).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});

document.addEventListener("DOMContentLoaded", function () {
    setInterval(createButton, 4000);
});

function createButton() {
    var button = document.createElement("button");
    button.innerHTML = "Click Me";
    button.className = "button";
    setRandomPosition(button);
    document.querySelector(".container").appendChild(button);

    setTimeout(function () {
        button.remove();
    }, 4000);
}

function setRandomPosition(element) {
    var maxWidth = window.innerWidth - 100; // Width of the window minus button width
    var maxHeight = window.innerHeight - 40; // Height of the window minus button height

    var randomX = Math.floor(Math.random() * maxWidth);
    var randomY = Math.floor(Math.random() * maxHeight);

    element.style.left = randomX + "px";
    element.style.top = randomY + "px";
}