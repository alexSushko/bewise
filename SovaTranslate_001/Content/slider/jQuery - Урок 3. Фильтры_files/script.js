


/* Функции для примеров */
function showMessage(){
  alert ("Вы щелкнули по div-у.");
}
function areaRectangle(){
  var a=document.forma1.t1.value;
  var b=document.forma1.t2.value;
  var s=a*b;
  document.forma1.res.value=s;
}
/* Функции для примеров к уроку css13 */
function books(){
  document.getElementById("book").style.visibility='visible';
  document.getElementById("movie").style.visibility='hidden';
  document.getElementById("musik").style.visibility='hidden';
  document.getElementById("game").style.visibility='hidden';
}
function movies(){
  document.getElementById("book").style.visibility='hidden';
  document.getElementById("movie").style.visibility='visible';
  document.getElementById("musik").style.visibility='hidden';
  document.getElementById("game").style.visibility='hidden';
}
function musiks(){
  document.getElementById("book").style.visibility='hidden';
  document.getElementById("movie").style.visibility='hidden';
  document.getElementById("musik").style.visibility='visible';
  document.getElementById("game").style.visibility='hidden';
}
function games(){
  document.getElementById("book").style.visibility='hidden';
  document.getElementById("movie").style.visibility='hidden';
  document.getElementById("musik").style.visibility='hidden';
  document.getElementById("game").style.visibility='visible';
}
function hid(){
  document.getElementById("book").style.visibility='hidden';
  document.getElementById("movie").style.visibility='hidden';
  document.getElementById("musik").style.visibility='hidden';
  document.getElementById("game").style.visibility='hidden';
}
/* Функции для примеров к уроку js5 */
function message(m){
  alert (m);
}
function showDesc(obj, n){
  obj.desc.value=n;
}
function delet(obj){
  obj.desc.value=' ';
}
/* Функции для примеров к уроку js6 */
function areaOfTriangle(obj){
  var a=1*obj.st1.value;
  var b=1*obj.st2.value;
  var c=1*obj.st3.value;
  var p=(a+b+c)/2;  
  var s=Math.sqrt(p*(p-a)*(p-b)*(p-c));
  obj.res.value=s;
}
function areaOfTriangle1(obj){
  var a=1*obj.st1.value;
  var b=1*obj.st2.value;
  var c=1*obj.st3.value;
  var p=(a+b+c)/2;
  var s=Math.sqrt(p*(p-a)*(p-b)*(p-c));
  s=s.toFixed(2);
  obj.res.value=s;
}
/* Функции для примеров к уроку js7 */
function maxZnach(obj){
  var a=1*obj.zn1.value;
  var b=1*obj.zn2.value;
  var c=1*obj.zn3.value;
  var m=a;
  if (b>m) m=b;
  if (c>m) m=c;
  obj.res.value=m;
}
function bigPict(){
    var w=document.tigr.width;
    if (w<302){
    document.tigr.width=w+10;
    document.tigr.src="../images/tigrenok.jpg"
    setTimeout("bigPict()", 500)
    }
    
}
  /* Функции для примеров к уроку js8 */
function Vday(obj){    
  if (obj.elements[0][0].selected)  obj.res.value="В понедельник будет ветрено, температура воздуха поднимется до +20 градусов";
  if (obj.elements[0][1].selected)  obj.res.value="Во вторник будет солнечно, температура воздуха поднимется до +25 градусов";
  if (obj.elements[0][2].selected)  obj.res.value="В среду будет прохладно, температура воздуха опустится до +17 градусов";
  if (obj.elements[0][3].selected)  obj.res.value="В четверг будет пасмурно, температура воздуха опустится до +10 градусов";
  if (obj.elements[0][4].selected)  obj.res.value="В пятницу будет облачно, температура воздуха поднимется до +15 градусов";
  if (obj.elements[0][5].selected)  obj.res.value="В субботу будет ветрено, температура воздуха поднимется до +27 градусов";
  if (obj.elements[0][6].selected)  obj.res.value="В воскресенье будет ясно, температура воздуха поднимется до +30 градусов";
}
function Vday1(obj){
  var a=obj.zn.value;
  var s;
  switch (a)
  {
   case 'понедельник': s="В понедельник будет ветрено, температура воздуха поднимется до +20 градусов"; break;
   case 'вторник': s="Во вторник будет солнечно, температура воздуха поднимется до +25 градусов"; break;
   case 'среда': s="В среду будет прохладно, температура воздуха опустится до +17 градусов"; break;
   case 'четверг': s="В четверг будет пасмурно, температура воздуха опустится до +10 градусов"; break;
   case 'пятница': s="В пятницу будет облачно, температура воздуха поднимется до +15 градусов"; break;
   case 'суббота': s="В субботу будет ветрено, температура воздуха поднимется до +27 градусов"; break;
   case 'воскресенье': s="В воскресенье будет ясно, температура воздуха поднимется до +30 градусов"; break;
   default: s='Укажите правильно день недели'
  }
  obj.res.value=s;
}

function prov(){
     if (document.forma1.elements[4].checked && document.forma1.elements[6][3].selected){
      alert ("Мужчина, который любит животных заслуживает уважения.");
     }
     else if (document.forma1.elements[5].checked && document.forma1.elements[6][4].selected)
     {
      alert ("Женщина за рулем всегда вызывает интерес.");
     }
     else
     {
      alert ("Отличное увлечение.");
     }
}
 /* Функции для примеров к уроку js10 */
function summa(obj) {
    var summa=0;
    var a1=1*obj.a1.value;
    var a2=1*obj.a2.value;
    if (a2>a1){
     for (var i = a1; i <= a2; i++) {
        summa+=i;
     }
     obj.result.value = summa;
    }
    else
        alert("Значение ОТ должно быть меньше значения ДО")
}
/* Функции для примеров к уроку js12 */
function proverka(obj) {
    var k;
    var users = new Array("Artem", "Irina", "Sergey", "Boris", "Olga", "Viktor");
    var n=obj.name.value;
    for (var i=0; i<=users.length-1; i++){
    if (users[i]==n)
    {k=0; break	}
    }
    if (k==0){alert("Это имя присутствует в массиве.")}
    else {alert("Такого имени в массиве нет.")}
    }
 /* Функции для примеров к уроку js13 */
function numword(obj) {
  var t=obj.textin.value;
  var s=obj.slovo.value;
  var m=s.length;
  var res=0;
  var i=0;
  while (i<t.length-1)
  {var ch=t.substr(i,m)
   if (ch==s){
   res+=1;
   i=i+m
   }
   else
   i++
  }
  obj.res.value=res
}

 /* Функции для примеров к уроку js14 */
 function prov_adress(obj) {
  var adr=obj.mail.value;
  var par=obj.pas.value;
  var adr_pattern=/[0-9a-z_]+@[0-9a-z_]+\.[a-z]{2,5}/i;
  var par_pattern=/[0-9a-z]+/i;
  var prov=adr_pattern.test(adr);
  var prov1=par_pattern.test(par);
  if (prov==true &&  prov1==true) {
        alert("Вы зарегистрированы!");
  }
  else {
        alert("Введенные данные некорректны!");
  }
}

/* Функции для примеров к уроку js15 */
function open_ford() {
  ford=window.open("../example/ford.html", "display_ford",
    "width=400,height=300,status=no,toolbar=no,menubar=no");
}
function open_mazda() {
  mazda=window.open("../example/mazda.html", "display_mazda",
    "width=400,height=300,status=no,toolbar=no,menubar=no");
}
function open_volvo() {
  volvo=window.open("../example/volvo.html", "display_volvo",
    "width=400,height=300,status=no,toolbar=no,menubar=no");
}
function close_pict() {
  window.close();
}
function choiceOf(){
    if (confirm("Вы действительно хотите открыть окно?")) {
      volvo=window.open("../example/volvo.html", "display_volvo",
            "width=400,height=300,status=no,toolbar=no,menubar=no");
   }
}
function acquaintance(){
   var YouName=prompt("Как тебя зовут?", "Напиши здесь свое имя.");
   alert("Привет "+YouName);
}
function startMessage(){
   alert("Начинайте!")
}
/* Функции для примеров к уроку jqueri1 */
function addEffect1(){
  $("#kv1:hidden").show();
}
function addEffect2(){
  $("#kv2:hidden").slideDown("slow");
}
function addEffect3(){
  $("#kv3:hidden").show().animate( {
                fontSize:"36px"
                } , 3000 );
}
/* Функции для примеров к уроку jqueri2 */
function addStyle1(){
  $("#st1").css("background", "red");
}
function addStyle2(){
  $("p.withBorder").css("border", "1px solid blue");
}
function addStyle3(){
  $("#st1, #st3").css("fontWeight", "bold");
}
function addColor1(){
  $(":text, :password").css("background", "red");  
}
function addColor2(){
  $(":button").css("background", "blue");
}
/* Функции для примеров к уроку jqueri2 */
function addColor3(){
  $("tr:even").css("background-color", "grey");
  $("tr:odd").css("background-color", "blue");
  $("td:gt(5)").css("color", "yellow");
}
/* Функции для примеров к уроку jqueri4 */
function chang(s){
    $('.selected').removeClass('selected');
    $(s).addClass('selected');
}
/* Функции для примеров к уроку jqueri5 */
function addHtml(){
    var tp1=$("#p1").text();
    $("#p2").text(tp1);
}
function addYellowSquare(){
    $("#red_sk").prepend("<div class='yellow_square'></div>");
}
function addSpisok(){
    var jq=$('#user_text').val();   
    $('#jq').append('<li>'+jq+'</li>');
}
/* Функции для примеров к уроку jqueri6 */
function addBoard(){
   for (var i = 0; i < 8; i++) {
        for (var j = 0; j <=7; j++) {
            if ((i%2==0 && j%2==0)|| (i%2!=0 && j%2!=0)){
                $("#board").append('<div class="s_kl" id="'+i+j+'"></div>');
            }
            else $("#board").append('<div class="t_kl" id="'+i+j+'"></div>');
        }
    }    
}
function addBoard1(){
   for (var i = 0; i < 8; i++) {
        for (var j = 0; j <=7; j++) {
            if ((i%2==0 && j%2==0)|| (i%2!=0 && j%2!=0)){
                $("#board1").append('<div class="s_kl1" id="'+i+j+'"></div>');
            }
            else $("#board1").append('<div class="t_kl1" id="'+i+j+'"></div>');
        }
    }
}
function addDraughts(){
  $("div").filter(".t_kl1").slice(0,12).append('<img src="../images/tem_shashka.gif" class="sh">');
  $("div").filter(".t_kl1").slice(20,32).append('<img src="../images/sv_shashka.gif" class="sh">');
}