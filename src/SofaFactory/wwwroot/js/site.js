if ($(window).width() < 768) {
    $(document).ready(function() {
        $(".nav .active").css("border-bottom-color", "#C25462");
        $("body").css({ 'margin-top': ($(".navbar").outerHeight() + 'px') });
        $(".faq-image-direction").html("Please refer to the photos below");
        $(".image-mobile").show();
        $(".image-non-mobile").hide();
    });
} else {
    if (window.location.pathname === 'home' || window.location.pathname === '/') {
        $(document).ready(function () {
            $(window).scroll(function () {
                if ($(document).scrollTop() > 1) {
                    $(".navbar").addClass("scrolled");
                    $(".navbar").removeClass("unscrolled");
                    $(".active").css("border-bottom-color", "gray");
                    $(".navbar-header .brand").css("color", "gray");
                } else {
                    $(".navbar").addClass("unscrolled");
                    $(".navbar").removeClass("scrolled");
                    $(".active").css("border-bottom-color", "white");
                    $(".navbar-header .brand").css("color", "white");
                }
            });
        });
    } else {
        $(document).ready(function() {
            $("body").css({ 'margin-top': ($(".navbar").outerHeight() + 'px') });
            $(".navbar").removeClass("unscrolled");
            $(".navbar-header .brand").css("color", "gray");
            $(".active").css("border-bottom-color", "#C25462");
            $(".image-non-mobile").show();
            if (window.location.pathname === '/Home/FAQ') {
                $(".image-non-mobile").css("margin-top", "18em");
            } else if (window.location.pathname === '/Home/Contact') {
                $(".image-non-mobile").css("margin-top", "9em");
            }
            $(".image-mobile").hide();
        });
    }
}

if (window.location.pathname !== 'home' && window.location.pathname !== '/') {
    $(".footer").css("margin-top", "1.2em");
}

$('a[href="' + this.location.pathname + '"]').parents('li').addClass('active').removeClass("inactive");

(function (document, history, location) {
    var HISTORY_SUPPORT = !!(history && history.pushState);

    var anchorScrolls = {
        ANCHOR_REGEX: /^#[^ ]+$/,
        OFFSET_HEIGHT_PX: $(".navbar").outerHeight(),
        
        // Establish events, and fix initial scroll position if a hash is provided.
         
        init: function () {
            this.scrollToCurrent();
            $(window).on('hashchange', $.proxy(this, 'scrollToCurrent'));
            $('body').on('click', 'a', $.proxy(this, 'delegateAnchors'));
        },

        // Return the offset amount to deduct from the normal scroll position.
        // Modify as appropriate to allow for dynamic calculations

        getFixedOffset: function () {
            return this.OFFSET_HEIGHT_PX;
        },
        
        // If the provided href is an anchor which resolves to an element on the
        // page, scroll to it.
        // @param  {String} href
        // @return {Boolean} - Was the href an anchor.
        
        scrollIfAnchor: function (href, pushToHistory) {
            var match, anchorOffset;

            if (!this.ANCHOR_REGEX.test(href)) {
                return false;
            }

            match = document.getElementById(href.slice(1));

            if (match) {
                anchorOffset = $(match).offset().top - this.getFixedOffset();
                $('html, body').animate({ scrollTop: anchorOffset });

                // Add the state to history as-per normal anchor links
                if (HISTORY_SUPPORT && pushToHistory) {
                    history.pushState({}, document.title, location.pathname + href);
                }
            }

            return !!match;
        },
        
        // Attempt to scroll to the current location's hash.
         
        scrollToCurrent: function (e) {
            if (this.scrollIfAnchor(window.location.hash) && e) {
                e.preventDefault();
            }
        },
        
        // If the click event's target was an anchor, fix the scroll position.
         
        delegateAnchors: function (e) {
            var elem = e.target;

            if (this.scrollIfAnchor(elem.getAttribute('href'), true)) {
                e.preventDefault();
            }
        }
    };

    $(document).ready($.proxy(anchorScrolls, 'init'));
})(window.document, window.history, window.location);