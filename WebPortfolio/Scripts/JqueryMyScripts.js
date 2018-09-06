
$('div .articlesAbout').load('/show/articlesabout');
$('div .articlesOur').load('/show/articlesour');
$('div .contactWith').load('/contact/send');

$(document).on('click', '.img_small', function (event) {
    
    var srcCurr = $(this).attr('src');
    var element = $(this).parent().parent().find('.img');
    var _widget = this;
    var el = $('.img');
    //console.log(el.length);
    element.fadeOut('slow', function () {
        console.log(srcCurr);
        $(this).attr('src', srcCurr).fadeIn('slow');
    });
});

$('#more button').click(function () {
    var el = $('.img');
    console.log(el.length);

    $('<div>').addClass('works').load('/show/indexpartial', 'numDrop=' + $('.img').length).insertBefore('#more');
    
});

$(document).on('click', '#send', function (e) {
    var el = $(this).parent().parent().parent().find('#Name');
    console.log(el.val);
    //$('div .contactWith').load('/contact/send', el);
});


$(document).on('mouseenter', '.img_small', function (e) {
    $(this).css("opacity", 0.7);
    
    //$(this).parent().find('.img').each(function (index, elem) {
    //    console.log("Элемент: " + elem.tagName + " " + elem.id);
}).on('mouseout', '.img_small', function (e) {
    $(this).css("opacity", 1.0);
    
});