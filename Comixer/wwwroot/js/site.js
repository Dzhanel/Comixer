// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function (window, document, $, undefined) {
    "use strict";
    $(() => {
        $('[maxlength]').maxlength();
    });

    var animeInit = {
        i: function (e) {
            animeInit.s();
            animeInit.methods();
        },
        s: function (e) {
            (this._window = $(window)),
                (this._document = $(document)),
                (this._body = $("body")),
                (this._html = $("html"));
        },
        methods: function (e) {
            animeInit.w();
            animeInit.hidepreloader();
            animeInit.animeBackToTop();
            animeInit.passwordHide();
            animeInit.intializeSlick();
            animeInit.countdownInit(".countdown", "2024/12/01");
            animeInit.salActivation();
            animeInit.policies();
            animeInit.weeklyScheduleNav();
            animeInit.videplay();
            animeInit.formValidation();
            animeInit.continueEmail();
            animeInit.trailerModel();
        },
        w: function (e) {
            this._window.on("load", animeInit.l).on("scroll", animeInit.res);
        },
        hidepreloader: function () {
            $('#preloader').hide();
        },
        animeBackToTop: function () {
            var btn = $("#backto-top");
            $(window).on("scroll", function () {
                if ($(window).scrollTop() > 300) {
                    btn.addClass("show");
                } else {
                    btn.removeClass("show");
                }
            });
            btn.on("click", function (e) {
                e.preventDefault();
                $("html, body").animate(
                    {
                        scrollTop: 0,
                    },
                    "300"
                );
            });
        },
        policies: function () {
            if ($('.policy').length) {
                $('.policy-item').on('click', function () {
                    var count = $(this).data('count');
                    $('.policy-item').removeClass('show');
                    $('.policy-content').hide('slow');
                    $('.policy-item p').hide('slow');
                    $('.policy-item .minus').hide();
                    $('.policy-item .plus').show();
                    $(this).addClass('show');
                    $('div.s-' + count).show('slow');
                    $('div.s-' + count + ' p').show('slow');
                    $('div.s-' + count + ' .plus').hide();
                    $('div.s-' + count + ' .minus').show();

                });
            }
        },
        passwordHide: function () {
            $(".toggle-password").on('click', function () {
                var $toggleButton = $(this);
                var $toggleIcon = $toggleButton.find('.toggle-password-i');
                var $inputField = $($toggleButton.attr("toggle"));

                $toggleIcon.toggleClass("d-none");

                var input = $($(this).attr("toggle"));
                console.log(input);
                if (input.attr("type") == "password") {
                    input.attr("type", "text");
                } else {
                    input.attr("type", "password");
                }
            });
        },
        countdownInit: function (countdownSelector, countdownTime) {
            var eventCounter = $(countdownSelector);
            if (eventCounter.length) {
                eventCounter.countdown(countdownTime, function (e) {
                    $(this).html(
                        e.strftime(
                            " <li>%D<small>d</small></li>\
                            <li>%H<small>h</small></li>\
                            <li>%M<small>m</small></li>\
                            <li>%S<small>s</small></li>"
                        )
                    );
                });
            }
        },
        formValidation: function () {
            if ($(".form-validator").length) {
                $(".form-validator").validate();
            }
        },
        salActivation: function () {
            sal({
                threshold: 0.1,
                once: true,
            });
        },
        intializeSlick: function (e) {
            if ($(".banner-slider").length) {
                $(".banner-slider").slick({
                    infinite: true,
                    arrows: true,
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    autoplay: true,
                    autoplaySpeed: 3000,
                    fade: true,
                    responsive: [
                        {
                            breakpoint: 992,
                            settings: {
                                arrows: false,
                            },
                        },
                    ]
                });
            }
            if ($(".date-slider").length) {
                $(".date-slider").slick({
                    infinite: true,
                    arrows: true,
                    slidesToShow: 7,
                    slidesToScroll: 1,
                    autoplay: false,
                    autoplaySpeed: 2000,
                    responsive: [
                        {
                            breakpoint: 991,
                            settings: {
                                arrows: true,
                                slidesToShow: 5,
                            },
                        },
                        {
                            breakpoint: 768,
                            settings: {
                                arrows: true,
                                slidesToShow: 4,
                            },
                        },
                        {
                            breakpoint: 480,
                            settings: {
                                arrows: true,
                                slidesToShow: 3,
                            },
                        },
                    ],
                });
            }
        },
        videplay: function () {
            $(".video .play-btn").on("click", function () {
                $(".video .img-box").hide("slow");
                $(".video .video-box").show("slow");
            });
        },
        weeklyScheduleNav: function () {
            var el = $('.date-slider .nav-item a');
            if (el.length) {
                el.on("click", function () {
                    $('.date-slider .nav-item .nav-link').removeClass('active');
                    $(this).addClass('active');
                });
            }
        },
        continueEmail: function () {
            $('#continue-email').on('click', function () {
                $('.hide-link').hide()
                $('.login-sec').show()
            })
        },
        trailerModel: function () {
            $('#videoModal').on('hidden.bs.modal', function () {
                $("#videoModal iframe").attr("src", $("#videoModal iframe").attr("src"));
            });
        }
    };
    animeInit.i();
    //Add search

    //Add comment
    $("#postCommentForm").on("submit", function (event) {
        event.preventDefault();
        var commentInput = $("#commentInput").val();
        var chapterId = $("#commentChapterId").val();
        $.post({
            url: '/Chapter/PostComment',
            data: {
                Content: commentInput,
                ChapterId: chapterId,
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
            },
            success: function (response) {
                $("#commentInput").val("");
                $("#commentSection").html(response);
            },
            error: function (xhr, status, error) {
                $("#errorAlert").html(`<div class="mt-3 alert alert-danger alert-dismissible fade show" role="alert">
                        Something went wrong!
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>`);
            }
        });
    })
    //Refresh comment section
    $(document).on("click", "#refreshCommentsBtn", function () {
        var chapterId = $("#chapterId").val();

        $.ajax({
            url: "/Comment/GetComments",
            type: "GET",
            data: { chapterId: chapterId },
            success: function (data) {
                // Refresh the comments section
                $("#commentSection").html(data);
            },
            error: function (xhr, status, error) {
                console.error("Error refreshing comments:", error);
            }
        });
    });
    $(document).on("ready", function () {
        $("#chapterImages").fileinput({
            captionUpload: false,
            browseIcon: "<i class=\"bi-file-image\"></i>",
            browseLabel: "Pick Images",
            //allowedFileExtensions: ['jpg', 'jpeg', 'png', 'webp'],
            showUplaod: false
            //uploadUrl: '/Chapter/PostChapter',
            //overwriteInitial: false,
            //uploadAsync: false,
            //uploadExtraData: function () {
            //    var data = {
            //        title: $("#Title").val(),
            //        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
            //    };
            //    return data;
            //}, ajaxSettings: {
            //    contentType: 'application/x-www-form-urlencoded; charset=UTF-8'
            //},
        })
    });
})(window, document, jQuery);
