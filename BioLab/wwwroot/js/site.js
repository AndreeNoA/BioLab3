// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var input;

function othername() {
    var input = document.getElementById("userInput").value;
    document.getElementById("myText").innerHTML = input;
    alert(input);
}