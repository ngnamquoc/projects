"use strict";

$(document).ready(function() {
	//Opt-in checkbox - doOnClick(e)
    $('#optin').click(function(e) {
        doOnClick(e);
    });
	//Body of the HTML - doOnLoad(e)
	$("body").ready(function(e){
		doOnLoad(e);
	});
	//Hyerlink - doOnClick(e)
	$("#mylink").click(function(e){
		doOnClick(e);
	});
	//Block paragraph - doOnMouseOver(e) - doOnMouseOut(e)
	$("#mypara").mouseover(function(e){
		doOnMouseOver(e);
	}).mouseout(function(e){
		doOnMouseOut(e);
	});
	//Form - doOnSubmit(e)
	$("form").submit(function(e){
		doOnSubmit(e);
	});
	//Textfield - doOnFocus(e) - doOnBlur(e)
	$("#myname").focus(function(e){
		doOnFocus(e);
	}).blur(function(e){
		doOnBlur(e);
	});
	//Combox - doOnChange(e)
	$("#mydirection").change(function(e){
		doOnChange(e);
	});

});



//doOnClick()..
function doOnClick() {
	updateStatusBox("images/click.png", "<strong>click</strong> event occured");
}

//updateStatusBox()..
function updateStatusBox(img, msg) {
	document.getElementById('statuscaption').innerHTML = msg;
	document.getElementById('event_image').src = img;
}

//doOnLoad()...
function doOnLoad(){
	updateStatusBox("images/load.png", "<strong>load</strong> event occured");
}
//doOnMouseOver()..
function doOnMouseOver(){
	updateStatusBox("images/mouseover.png", "<strong>mouseover</strong> event occured");
}

//doOnMouseOut..
function doOnMouseOut(){
	updateStatusBox("images/mouseout.png", "<strong>mouseout</strong> event occured");
}

//doOnSubmit()..
function doOnSubmit(){
	event.preventDefault();
	updateStatusBox("images/submit.png", "<strong>submit</strong> event occured");
}
//doOnChange()..
function doOnChange(){
	let status = $("#mydirection option:selected").val();
	if(status === "N"){
		updateStatusBox("images/n.png", "<strong>change</strong> event occured");
	} else if(status === "S"){
		updateStatusBox("images/s.png", "<strong>change</strong> event occured");
	} else if(status === "E"){
		updateStatusBox("images/e.png", "<strong>change</strong> event occured");
	} else if(status === "W"){
		updateStatusBox("images/w.png", "<strong>change</strong> event occured");
	}
}

//doOnBlur()..
function doOnBlur(){
	updateStatusBox("images/blur.png", "<strong>blur</strong> event occured");
}
//doOnFocus()..
function doOnFocus(){
	updateStatusBox("images/focus.png", "<strong>focus</strong> event occured");
}