window.onscroll = function () { scrollFunction() };
function scrollFunction() {
    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 120) {
        document.getElementById("header").style.backgroundColor = "rgb(14, 32, 91)";
        document.getElementById("header").style.boxShadow = "0px 0px 10px 0px rgb(0, 0, 0)";
        document.getElementById("header").style.transition = "all .25s";
    } else {
        document.getElementById("header").style.backgroundColor = "transparent";
        document.getElementById("header").style.boxShadow = "none";
    }

}

$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        items: 4,
        loop: true,
        autoplay: true,
        autoplayTimeout: 7000,
        autoplayHoverPause: false,
        responsive: {
            1000: {
                items: 3
            },

            700: {
                items: 2
            },
            400: {
                items: 1
            },
            0: {
                items: 1
            }
        },
    });
});
