"use strict";

const chai = window.chai;
const expect = chai.expect;


describe('_swapCharacters', () =>  {
    it('please enter your function description here',  () => {
        expect(_swapCharacters("aabbccc","a","b")).to.deep.equal("bbaaccc");
        expect(_swapCharacters("random w#rds writt&n h&r&","#","&")).to.deep.equal("random w&rds writt#n h#r#");
        expect(_swapCharacters("128 895 556 788 999", "8", "9")).to.deep.equal("129 985 556 799 888");
    })
})

describe('_moveCapitalLetters', () =>  {
    it('please enter your function description here',  () => {
        expect(_moveCapitalLetters("hApPy")).to.deep.equal("APhpy");
        expect(_moveCapitalLetters("moveMENT")).to.deep.equal("MENTmove");
        expect(_moveCapitalLetters("shOrtCAKE")).to.deep.equal("OCAKEshrt");
    })
})

describe('_repeatingCharacters', () =>  {
    it('please enter your function description here',  () => {
        expect(_repeatingCharacters("legolas")).to.deep.equal("l");
        expect(_repeatingCharacters("Gandalf")).to.deep.equal("a");
        expect(_repeatingCharacters("Balrog")).to.deep.equal("-1");
        expect(_repeatingCharacters("Isildur")).to.deep.equal("-1");
    })
})

describe('_capitalizeFirstLetter', () =>  {
    it('please enter your function description here',  () => {
        expect(_capitalizeFirstLetter("This is a title")).to.deep.equal("This Is A Title");
        expect(_capitalizeFirstLetter("capitalize every word")).to.deep.equal("Capitalize Every Word");
        expect(_capitalizeFirstLetter("I Like Pizza")).to.deep.equal("I Like Pizza");
        expect(_capitalizeFirstLetter("PIZZA PIZZA PIZZA")).to.deep.equal("PIZZA PIZZA PIZZA");
    })
})

describe('_removeDuplicates', () =>  {
    it('please enter your function description here',  () => {
        expect(_removeDuplicates([1, 0, 1, 0])).to.deep.equal([1, 0]);
        expect(_removeDuplicates(["The", "big", "cat"])).to.deep.equal(["The", "big", "cat"]);
        expect(_removeDuplicates(["John", "Taylor", "John"])).to.deep.equal(["John", "Taylor"]);
    })
})