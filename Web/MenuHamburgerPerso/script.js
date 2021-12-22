var accueil = document.getElementsByClassName("accueil");
for(let i=0; i<accueil.length; i++)
{

    accueil[i].addEventListener('click', function () {
        test(accueil[i]);
    });

 }

 /*
    document.getElementsByClassName("accueil")[0].addEventListener('click', test);
 function test(event){
    var SousMenu = event.target.getElementsByClassName("sousMenu")[0].style.display ="block";
}
 
*/
function test(input){
   input.getElementsByClassName("sousMenu")[0].style.display ="block";
}
