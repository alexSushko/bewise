function rawurlencode (str)
{
	// discuss at: http://phpjs.org/functions/rawurlencode
	str = (str + '').toString();
	return encodeURIComponent(str).replace(/!/g, '%21').replace(/'/g, '%27').replace(/\(/g, '%28').
	replace(/\)/g, '%29').replace(/\*/g, '%2A');
}

$(document).ready(function()
{
	////////////
	//var ref = document.referrer.replace(new RegExp('&','g'),';');
	var ref = rawurlencode (document.referrer);
	$.ajax({type: 'POST',url: "/ext/php/counter.php",cache:false, data: 'ref='+ref+'&res='+$(window).width()+'x'+$(window).height()});

	$('a[href^="http"]').bind('click', function()
		{
		  extrn_link($(this).attr('href'));
		}
	).each
	(
		function()
		{
			$(this).attr('target','_blank');
		}
	);
	//////////////////
});

// визначення TYPO_FOUND_CONF
var TYPO_FOUND_CONF =
{
	MAX_SELECTION_LENGTH: 127
	,TOO_LONG_SELECTION_MSG: "Ви вибрали занадто довгий текст"
	,THX_MESSAGE: 'Дякуємо за допомогу!'
	,AJAX_URL: '/ext/php/found_error.php'
};
var TypoFound =
{
	init: function()
	{
		var that = this;
		window.document.onkeypress = function(e)
		{
			if (that.checkEvent(e))
			{
				var str = new String( that.getSelection() ).toString();
				if(str.length > 0)
				if (str.length > TYPO_FOUND_CONF.MAX_SELECTION_LENGTH)
				{
					alert(TYPO_FOUND_CONF.TOO_LONG_SELECTION_MSG);
					return;
				}else
				{
					$.post(TYPO_FOUND_CONF.AJAX_URL,
						{
							str: str
							,url: window.location.href
						}
						,function(){$('#thanks').modal();} // on success
					);
				}
				return false;
			}
		};
	}
	,getSelection: function()
	{
		try
		{
			return window.getSelection ?
			window.getSelection()
			: ( window.document.getSelection ?
			window.document.getSelection()
			: window.document.selection.createRange().text
			);
		} catch(e)
		{
			return null;
		}
	}
	,checkEvent: function(e)
	{
		return window.event ?
		(window.event.keyCode == 10 || (window.event.keyCode == 13 && window.event.ctrlKey))
		: ( e ?
		((e.which == 10 && e.modifiers == 2) || (e.keyCode == 0 && e.charCode == 106 && e.ctrlKey) || (e.keyCode == 13 && e.ctrlKey))
		: false
		);
	}
};
TypoFound.init();
// закінчення TypoFound

function extrn_link(url_par)
{
	//url_par = url_par.replace(new RegExp('&','g'),';');
	var url_par = rawurlencode (url_par);
	$.ajax({type: 'POST',url: "/ext/php/extrn_link.php",cache:false, data: 'r='+url_par});
}

(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
})(window,document,'script','//www.google-analytics.com/analytics.js','ga');
ga('create', 'UA-55971630-1', 'auto');
ga('send', 'pageview');