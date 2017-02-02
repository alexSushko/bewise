$(document).ready(init);
/* Функции для примеров к уроку jqueri11, 12 */
function init(){
    addBoard();
    addDraughts();
$(function(){
  $("#les12_ex1").resizable();
});
$(function(){
  $("#les12_ex2").resizable({
              animate: true
            });
});
$(function(){
  $("#les12_ex3").resizable({
              animate: true,
              animateDuration: 'slow'
            });
});
$(function(){
  $("#les12_ex4").resizable({
              aspectRatio: true
            });
});
$(function(){
  $("#les12_ex5").resizable({
              cancel: '#les12_ex5'
            });
});
$(function(){
  $("#les12_ex6").resizable({
              containment: 'parent' 
            });
});
$(function(){
  $("#les12_ex7").resizable({
             delay: 1000
            });
});
$(function(){
  $("#les12_ex8").resizable({
             distance: 100
            });
});
$(function(){
  $("#les12_ex9").resizable({
             ghost:true
            });
});
$(function(){
  $("#les12_ex10").resizable({
             helper: 'ramka_green'
            });
});
$(function(){
  $("#les12_ex11").resizable({
             maxHeight: 200,
             maxWidth: 400,
             minWidth: 100,
             minHeight:50
            });
});
$(function(){
  $("#les12_ex12").resizable({
             stop:  function(event, ui) {
                  $("#les12_res").text('Итоговые размеры: '+ui.size.width+', '+ui.size.height);
                    }
            });
});
  $(".s_sh").draggable();
  $(".t_sh").draggable();
  $("#lotok1").droppable({
     accept: '.t_sh',
     activeClass: "active",
  	 hoverClass: "hover",
     drop: function(){
            var m=$('#res1').text();
            var n=parseInt(m);
            n=n+1;
            $('#res1').text(n);
        }
  });
  $("#lotok2").droppable({
     accept: '.s_sh',
     activeClass: 'active',
     drop: function(){
            var m=$('#res2').text();
            var n=parseInt(m);
            n=n+1;
            $('#res2').text(n);
        }
     
  });
  
  
}

function addBoard(){
   for (var i = 0; i < 8; i++) {
        for (var j = 0; j <=7; j++) {
            if ((i%2==0 && j%2==0)|| (i%2!=0 && j%2!=0)){
                $("#board3").append('<div class="s_kl1" id="'+i+j+'"></div>');
            }
            else $("#board3").append('<div class="t_kl1" id="'+i+j+'"></div>');
        }
    }
}
function addDraughts(){
  $("div").filter(".t_kl1").slice(0,12).append('<img src="../images/tem_shashka.gif" class="t_sh">');
  $("div").filter(".t_kl1").slice(20,32).append('<img src="../images/sv_shashka.gif" class="s_sh">');
}
/* Функции для примеров к уроку jqueri12 */
