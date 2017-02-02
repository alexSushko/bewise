$(document).ready(init);
/* Функции для примеров к уроку jqueri10 */
function init(){
  $("#les10_ex1").draggable();
  $("#les10_ex2").draggable({
      axis:'x'
  });
  $("#les10_ex3").draggable({
      containment:'parent'
  });
  $("#les10_ex4").draggable({
   cursor: 'crosshair'
  });
  $("#les10_ex5").draggable({
   delay: 2000
  });
  $("#les10_ex6").draggable({
   distance: 50
  });
 $("#les10_ex7").draggable({
   handle: 'p'
  });
 $("#les10_ex8").draggable({
   revert: true
  });
 $("#les10_ex9").draggable({
   revert: true,
   revertDuration: 3000
  });
 $("#les10_ex10").draggable({
   zIndex: 1
  });
  $("#les10_ex11").draggable({
   zIndex: 2
  });
  $("#les10_ex12").draggable({
   zIndex: 3
  });
  $("#les10_ex13").draggable({
   start: function(event, ui) {
            var a=event.type;
            $('#res').text('Событие: '+a);
        },
   stop: function(event, ui) {
            var a=event.type;
            var c=ui.position.left;
            var d=ui.position.top;
            var e=ui.offset.left;
            var f=ui.offset.top;
            $('#res').text('Событие: '+a+'\nРасстояние слева и сверху относительно родительского элемента: '+c+' '+d+'\nАбсолютные значения расстояния слева и сверху: '+e+' '+f);
        }
  });
  $("#les10_ex14").draggable({
     revert: true,
     cursor: 'crosshair'
  });
  $("#metOpt").click(function(){
    $("#les10_ex14").draggable("option", "revertDuration", [5000]);
  });
  $("#metDis").click(function(){
    $("#les10_ex14").draggable("disable");
  });
  $("#metEn").click(function(){
    $("#les10_ex14").draggable("enable");
  });
}



