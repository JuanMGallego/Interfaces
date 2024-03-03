"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/juegoHub").build();

document.addEventListener("DOMContentLoaded", function () {
    setInterval(createButton, 4000);
});

function createButton() {
    var button = document.createElement("button");
    button.innerHTML = "Click Me";
    button.id = "button";
    setRandomPosition(button);
    button.addEventListener("click", function () {
        button.remove(); // Remover el botón al hacer clic en él
        connection.invoke("ClickedButton")
    });
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

connection.on("ButtonClicked", function () {
    document.getElementById("button").style.display = "none";
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
