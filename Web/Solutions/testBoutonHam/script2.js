// function cliqueHamburger() {

//     var contenu = document.getElementsByClassName("test");
//     var hamburger = document.getElementsByClassName("image");
//     var croissant = document.getElementsByClassName("image2");

//     if (element.addEventListener("click", clickCroissant())) {
//         contenu.className = "open";
//         hamburger.className = "hidden";

//     } else if (element.addEventListener("click", clickHamburger())) {
//         contenu.className = "hidden";
//         hamburger.className = "open";
//     }


// }


function ouvrirFermerHamburger(div){

var divContenu = div.getElementsByTagName('div')[1];
if(divContenu.style.display =='block')
divContenu.style.display =='none';
else
divContenu.style.display =='block';

}
