(function ($) {
    $.fn.file = function (options) {
        var settings = {
            width: 250
        };

        if (options) {
            $.extend(settings, options);
        }

        this.each(function () {
            var self = this;

            var wrapper = $("<a>").attr("class", "mini-btnsubir");

            var filename = $('<input class="file">').addClass($(self).attr("class")).css({
                "display": "none",
                "width": "0px"
            });

            $(self).before(filename);
            $(self).wrap(wrapper);

            $(self).css({
                "position": "relative",
                "height": "18px",
                "display": "block",
                "cursor": "pointer",
                "margin-bottom": "-18px",
                "opacity": "0.0"
            });

            if ($.browser.mozilla) {
                if (/Win/.test(navigator.platform)) {
                    $(self).css({
                        "right": "0px",
                        "top": "-7px",
                        "z-index": "500",
                        "left": "-5px",
                    });
                } else {
                    $(self).css({
                        "width": settings.width + "px",
                        "right": "0px",
                        "top": "-7px",
                        "z-index": "500",
                        "left": "-5px",
                    });
                };
            } else {
                $(self).css({
                    "width": "100px",
                    "right": "0px",
                    "top": "-7px",
                    "z-index": "500",
                    "left": "-10px",
                });
            };

            $(self).bind("change", function () {
                filename.val($(self).val());
            });
        });

        return this;
    };
})(jQuery);