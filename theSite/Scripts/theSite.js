/*$(document).ready(function () {
    $("#slideshow > div:gt(0)").hide();

    setInterval(function () {
        $('#slideshow > div:first')
            .hover(function () { $(this).stop(true, true); })
            .fadeOut(1000)
            // .animate({ opacity: 1.0 }, 100, function () { $(this).hide();})
            // .fadeOut(100, function () { $(this).hide(0);})
            // .mouseover(function () { $('#slideshow > div:gt(0)').stop(true, true).fadeOut(); })
            // .hover(function () { $('#slideshow > div:gt(0)').stop(true, true).fadeOut(); })
            .hide() // image blink with this line
            // .delay(1000)
            .next()
            .fadeIn(1000)
            .end()
            // .ready(function () { $('#slideshow > div:first').appendTo('#slideshow').show() });
            .appendTo('#slideshow').show();
    }, 3000);
});
*/
/*
$(document).ready(function () {
    $("#slideshow > div:gt(0)").hide();

    setInterval(function () {
        var curImg = $('#slideshow > div ').find(;
        var nextImg = curImg.next();
        curImg.fadeOut(1000);
        curImg.hide();
        nextImg.fadeIn(1000);
    }, 3000);
});
*/

/*
$(document).ready(function () {
    $("#slideshow > div:gt(0)").hide();
    setInterval(function () {

        var $active = $('#slideshow IMG.active');
        var $next = $active.next();

        $active.addClass('last-active');

        $next.css({ opacity: 0.0 })
            .addClass('active')
            .animate({ opacity: 1.0 }, 1000, function () {
                $active.removeClass('active last-active');
            });
    }, 3000);
});
*/

function showslide()
{
    $('#slideshow > div:first')
        .fadeOut(1000)
        .next()
        .fadeIn(1000)
        .end()
        .appendTo('#slideshow');
}

$(document).ready(function () {
    $("#slideshow > div:gt(0)").hide();

    var v = setInterval(showslide, 3000);

    $('#slideshow > div > img').hover(function (ev) { clearInterval(v); },
        function (ev) { v = setInterval(showslide, 3000); }
        );
});