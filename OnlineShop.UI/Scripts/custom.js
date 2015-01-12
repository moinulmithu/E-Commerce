$(document).ready(function(){

/******** Accordion **********/
$('.accordion-heading, .checkout-heading').live('click', function() {
	$('.accordion-content, .checkout-content').slideUp('slow');
	$(this).parent().find('.accordion-content, .checkout-content').slideDown('slow');
});

/*`Scroll to top */
$(function () {
		$(window).scroll(function () {
			if ($(this).scrollTop() > 150) {
				$('#back-top').fadeIn();
			} else {
				$('#back-top').fadeOut();
			}
		});
		});
jQuery('.backtotop').click(function(){
	jQuery('html, body').animate({scrollTop:0}, 'slow');
});

/******** Navigation Menu ********/
$('#menu > span').click(function () {
	  $(this).toggleClass("active");  
	  $(this).parent().find("> ul").slideToggle('medium');
	});

$('#menu.m-menu > ul > li.categories > div > .column > div').before('<span class="more"></span>');
		$('span.more').click(function () {
			$(this).next().slideToggle('fast');
			$(this).toggleClass('plus');
			
				});

/******** Footer Link ********/
$("#footer h3").click(function () {
			$screensize = $(window).width();
			if ($screensize < 801) {
				$(this).toggleClass("active");  
				$(this).parent().find("ul").slideToggle('medium');
			}
		});
/******** plus mines button in qty ********/
$(".qtyBtn").click(function(){
		if($(this).hasClass("plus")){
			var qty = $("#qty").val();
			qty++;
			$("#qty").val(qty);
		}else{
			var qty = $("#qty").val();
			qty--;
			if(qty>0){
				$("#qty").val(qty);
			}
		}
	});	

/******** Language and Currency Dropdowns ********/
$('#currency, #language').mouseover(function() {
			$(this).find('> ul').slideDown('fast');
			$(this).bind('mouseleave', function() {
				$(this).find('> ul').slideUp('fast');
			});
		});

/******** Ajax Cart **********/
	$('#cart > .heading a').live('click', function() {
		$('#cart').addClass('active');		
		$('#cart').live('mouseleave', function() {
			$(this).removeClass('active');
		});
	});
	
/******** Mega Menu **********/
	$('#menu ul > li > a + div').each(function(index, element) {
		// IE6 & IE7 Fixes
		if ($.browser.msie && ($.browser.version == 7 || $.browser.version == 6)) {
			var category = $(element).find('a');
			var columns = $(element).find('ul').length;
			
			$(element).css('width', (columns * 143) + 'px');
			$(element).find('ul').css('float', 'left');
		}		
		
		var menu = $('#menu').offset();
		var dropdown = $(this).parent().offset();
		
		i = (dropdown.left + $(this).outerWidth()) - (menu.left + $('#menu').outerWidth());
		
		if (i > 0) {
			$(this).css('margin-left', '-' + (i + 5) + 'px');
		}
	});
	
/********Category Accordion **********/
$(document).ready(function() {
	$('#cat_accordion').cutomAccordion({
		classExpand : 'custom_id20',
		menuClose: false,
		autoClose: true,
		saveState: false,
		disableLink: false,		
		autoExpand: true
	});
});



/******** Carousel **********/
$('#carousel ul').jcarousel({
	vertical: false,
	visible: 5,
	scroll: 3
});

/******** Tabs 
$('#tabs a').tabs();**********/

/******** Colorbox **********/

$('.colorbox').colorbox({
			overlayClose: true,
			opacity: 0.8,
			maxHeight: 550,
			maxWidth: 550,
			width:'100%'
		});
/******** ================= ********/
});