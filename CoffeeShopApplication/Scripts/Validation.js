﻿var regexFirst = /[a-zA-Z]{2,}/g;
var regexLast = /[a-zA-Z]{2,}/g;
var regexEmail = /[A-z0-9]{4,}@[A-z0-9]{2,}\.[A-z0-9]{1,}/g;
var regexPhone = /(\+?1?[0-9]{10})|([0-9]{3}[- ][0-9]{3}[- ][0-9]{4})|(\(\d{3}\)\d{3}[- ]\d{4})/g;
var regexPassword = /[A-z]{2,}/g;  //TODO: change this for actual regex for password

function ValidateFirstName() {
    if (regexFirst.test(document.getElementById("FirstName").value)) {
        document.getElementById("empty1").style.color = "green";
        document.getElementById("empty1").innerHTML = "Valid";
    }
    else {
        document.getElementById("empty1").style.color = "red";
        document.getElementById("empty1").innerHTML = "Invalid";
    }
}

function ValidateLastName() {
    if (regexLast.test(document.getElementById("LastName").value)) {
        document.getElementById("empty2").style.color = "green";
        document.getElementById("empty2").innerHTML = "Valid";
    }
    else {
        document.getElementById("empty2").style.color = "red";
        document.getElementById("empty2").innerHTML = "Invalid";
    }
}

function ValidateEmail() {
    if (regexEmail.test(document.getElementById("Email").value)) {
        document.getElementById("empty3").style.color = "green";
        document.getElementById("empty3").innerHTML = "Valid";
    }
    else {
        document.getElementById("empty3").style.color = "red";
        document.getElementById("empty3").innerHTML = "Invalid";
    }
}

function ValidatePhone() {
    if (regexPhone.test(document.getElementById("YoDigits").value)) {
        document.getElementById("empty4").style.color = "green";
        document.getElementById("empty4").innerHTML = "Valid";
    }
    else {
        document.getElementById("empty4").style.color = "red";
        document.getElementById("empty4").innerHTML = "Invalid";
    }
}

function ValidatePassword() {
    if (regexPassword.test(document.getElementById("Password").value)) {
        document.getElementById("empty5").style.color = "green";
        document.getElementById("empty5").innerHTML = "Valid";
    }
    else {
        document.getElementById("empty5").style.color = "red";
        document.getElementById("empty5").innerHTML = "Invalid";
    }
}

