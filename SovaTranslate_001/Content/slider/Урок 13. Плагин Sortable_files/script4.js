$(document).ready(init);
/* Функции для примеров к уроку jqueri13 */
function init(){
    $(function(){
        $("#authors").sortable();
    });
    $(function(){
        $("#les13_ex3").sortable({
            appendTo: '#resalt'
        });
    });
    $(function(){
        $("#les13_ex4").sortable({
            axis: 'y'
        });
    });
    $(function(){
        $("#les13_ex5").sortable({
            cancel: '.les13'
        });
    });
    $(function(){
        $("#les13_ex6").sortable();
    });
    $(function(){
        $("#les13_ex7").sortable({
            connectWith: '#les13_ex6'
        });
    });
    $(function(){
        $("#les13_ex8").sortable({
            containment: 'parent'
        });
    });
    $(function(){
        $("#les13_ex9").sortable({
            cursor: 'e-resize'
        });
    });
    $(function(){
        $("#les13_ex10").sortable({
            delay: 1000 
        });
    });
    $(function(){
        $("#les13_ex11").sortable({
            distance: 20
        });
    });
    $(function(){
        $("#les13_ex12").sortable();
    });
    $(function(){
        $("#les13_ex13").sortable({
            connectWith: '#les13_ex12',
            dropOnEmpty: false
        });
    });
}

