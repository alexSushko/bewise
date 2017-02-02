$(document).ready(init);
/* Функции для примеров к уроку jqueri7 */
function init(){
  $('#lesson').bind('change', desc);
  init1();
  $("#les9_ex1").corner("round");
  $("#les9_ex2").corner("bevel");
  $("#les9_ex3").corner("notch");
  $("#les9_ex4").corner("dog");
  $("#les9_ex5").corner("dog2");
  $("#les9_ex6").corner("bite");
  $("#les9_ex7").corner("cool");
  $("#les9_ex8").corner("sharp");
  $("#les9_ex9").corner("slide");
  $("#les9_ex10").corner("jut");
  $("#les9_ex11").corner("curl");
  $("#les9_ex12").corner("tear");
  $("#les9_ex13").corner("fray");
  $("#les9_ex14").corner("wicked");
  $("#les9_ex15").corner("sculpt");
  $("#les9_ex16").corner("dog tl br");
  $("#les9_ex17").corner("30px");  
  
}
function desc(){
var op=$('#lesson').val();
switch (op)
 {
 case '1': $('#desc').text('Первый урок по jQuery знакомит с основными понятиями и возможностями этой библиотеки.'); break;
 case '2': $('#desc').text('Второй урок по jQuery знакомит с таким понятием, как селекторы.'); break;
 case '3': $('#desc').text('Третий урок по jQuery знакомит с таким понятием, как фильтры.'); break;
 }
}
function init1(){
    $('p').hover(
        function(){
            $(this).css("background-color", "blue");
        },
        function(){
            $(this).css("background-color", "white");
        }
        );
   $('div.nov').click(
     function(){$(this).css("background-color", "blue");}
  );
  $('div.nov:first').click();
}
/* Функции для примеров к уроку jqueri8 */
function hideDiv(){
    $('#les8_ex1').hide();
}
function showDiv(){
    $('#les8_ex1').show();
}
function hideShowDiv(){
      $('#les8_ex2').toggle('slow');
}
function slideUpDiv(){
    $('#les8_ex3').slideUp();
}
function slideDownDiv(){
    $('#les8_ex3').slideDown();
}
function slideToggleDiv(){
      $('#les8_ex4').slideToggle(7000);
}
function fadeOutDiv(){
      $('#les8_ex5').fadeOut(5000);
}
function fadeInDiv(){
      $('#les8_ex5').fadeIn(5000);
}
function fadeToDiv(){
      $('#les8_ex6').fadeTo(5000, 0.5);
}
function animateDiv(){
      $('#les8_ex7').animate({
          width:"400px",
          height:"200px"
      }, 3000 );
      $('#les8_ex8').animate({
          width:"100px",
          height:"100px"
      }, 3000 );
}
function stopDiv(){
      $('#les8_ex7').stop();
      $('#les8_ex8').stop();
}
function animateDiv2(){
      $('#les8_ex9').animate({
          "height": "toggle"
      }, 1000 );
      
}
/* Функции для примеров к уроку jqueri9 */
