"use strict";
//Function 1: Swap Characters
const _swapCharacters = (strs,firstCharacter,secondCharacter) => {
    let swapResult="";
    for (let str of strs) {
        if(str === firstCharacter){
            str = secondCharacter;
        } else if (str === secondCharacter){
            str = firstCharacter;
        }
        swapResult += str;
    }
    return swapResult;
};
//Function 2: Move Capital Letters
const _moveCapitalLetters = (textString) => {
    let normalLetter="", capitalizedLetters="";
    for(let char of textString){
        if(char === char.toUpperCase()){ //Identify capitalize characters
            capitalizedLetters += char;
        } else{
            normalLetter += char;
        }
    }
    return capitalizedLetters + normalLetter;
}
//Function 3: Repeating Characters
const _repeatingCharacters = (textString) => {
    let duplicateChar="";
    for(let text of textString){
        if(textString.indexOf(text) !== textString.lastIndexOf(text)){ //compare the first index and last index of each character to identify duplications
            duplicateChar = text;
            break;
         } else{
            duplicateChar = "-1"; //case no duplication
        }
    }
    return duplicateChar;
}

//Function 4: Capitalize First Letter of Each Word
function _capitalizeFirstLetter(string)
{
    let capitalizeString = string[0].toUpperCase() + ""; //Capitalize first character of first word
    for(let i=1; i<string.length; i++){
        if(string[i] === " "){ //Find the space
            capitalizeString += " " + string[i+1].toUpperCase(); //Capitalize the letter after space
            i += 1;
        } else{
            capitalizeString += string[i];
        }
    }
    return capitalizeString;
}
//Function 5: Remove Duplicates
function _removeDuplicates(array){
    let newArray = [];
    for (let element of array){
        if(newArray.indexOf(element) === -1) { //Check the index of element
            newArray.push(element); //If no duplication, add it to the newArray
            }
        }
    return newArray;
    }



