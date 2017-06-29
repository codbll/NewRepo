/*
Name: 			Shortcodes - Image Gallery - Examples
Written by: 	Okler Themes - (http://www.okler.net)
Theme Version:	4.7.0
*/
(function($) {

	'use strict';

	/*
	Thumb Gallery
	*/
	var $thumbGalleryDetail1 = $('#thumbGalleryDetail'),
		$thumbGalleryThumbs1 = $('#thumbGalleryThumbs'),
		flag = false,
		duration = 300;

	$thumbGalleryDetail1
		.owlCarousel({
			items: 1,
			margin: 10,
			nav: true,
			dots: false,
			loop: true,
			navText: []
		})
		.on('changed.owl.carousel', function(e) {
			if (!flag) {
				flag = true;
				$thumbGalleryThumbs1.trigger('to.owl.carousel', [e.item.index, duration, true]);
				flag = false;
			}
		});

	$thumbGalleryThumbs1
		.owlCarousel({
			margin: 15,
			items: 4,
			nav: false,
			center: false,
			dots: false
		})
		.on('click', '.owl-item', function() {
			$thumbGalleryDetail1.trigger('to.owl.carousel', [$(this).index(), duration, true]);

		})
		.on('changed.owl.carousel', function(e) {
			console.log(e);
		})
		.on('changed.owl.carousel', function(e) {
			if (!flag) {
				flag = true;
				$thumbGalleryDetail1.trigger('to.owl.carousel', [e.item.index, duration, true]);
				flag = false;
			}
		});

    /*
	Thumb Gallery
	*/
    var $thumbGalleryDetail3 = $('#thumbGalleryDetail3'),
        $thumbGalleryThumbs3 = $('#thumbGalleryThumbs3'),
        flag = false,
        duration = 300;

    $thumbGalleryDetail3
        .owlCarousel({
            items: 1,
            margin: 10,
            nav: true,
            dots: false,
            loop: true,
            navText: []
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryThumbs3.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    $thumbGalleryThumbs3
        .owlCarousel({
            margin: 15,
            items: 4,
            nav: false,
            center: false,
            dots: false
        })
        .on('click', '.owl-item', function () {
            $thumbGalleryDetail3.trigger('to.owl.carousel', [$(this).index(), duration, true]);

        })
        .on('changed.owl.carousel', function (e) {
            console.log(e);
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryDetail3.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

	/*
	Thumb Gallery 2
	*/
	var $thumbGalleryDetail2 = $('#thumbGalleryDetail2'),
		$thumbGalleryThumbs2 = $('#thumbGalleryThumbs2'),
		flag = false,
		duration = 300;

	$thumbGalleryDetail2
		.owlCarousel({
			items: 1,
			margin: 10,
			nav: false,
			dots: false
		})
		.on('changed.owl.carousel', function(e) {
			if (!flag) {
				flag = true;
				$thumbGalleryThumbs2.trigger('to.owl.carousel', [e.item.index, duration, true]);
				flag = false;
			}
		});

	$thumbGalleryThumbs2
		.owlCarousel({
			margin: 15,
			items: 4,
			nav: false,
			center: true,
			dots: true
		})
		.on('click', '.owl-item', function() {
			$thumbGalleryDetail2.trigger('to.owl.carousel', [$(this).index(), duration, true]);

		})
		.on('changed.owl.carousel', function(e) {
			if (!flag) {
				flag = true;
				$thumbGalleryDetail2.trigger('to.owl.carousel', [e.item.index, duration, true]);
				flag = false;
			}
		});


    /*
	Thumb Gallery - S1
	*/
    var $thumbGalleryDetailS1 = $('#thumbGalleryDetailS1'),
        $thumbGalleryThumbsS1 = $('#thumbGalleryThumbsS1'),
        flag = false,
        duration = 300;

    $thumbGalleryDetailS1
        .owlCarousel({
            items: 1,
            margin: 10,
            nav: true,
            dots: false,
            loop: true,
            navText: []
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryThumbsS1.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    $thumbGalleryThumbsS1
        .owlCarousel({
            margin: 15,
            items: 4,
            nav: false,
            center: false,
            dots: false
        })
        .on('click', '.owl-item', function () {
            $thumbGalleryDetailS1.trigger('to.owl.carousel', [$(this).index(), duration, true]);

        })
        .on('changed.owl.carousel', function (e) {
            console.log(e);
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryDetailS1.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    /*
	Thumb Gallery - S2
	*/
    var $thumbGalleryDetailS2 = $('#thumbGalleryDetailS2'),
        $thumbGalleryThumbsS2 = $('#thumbGalleryThumbsS2'),
        flag = false,
        duration = 300;

    $thumbGalleryDetailS2
        .owlCarousel({
            items: 1,
            margin: 10,
            nav: true,
            dots: false,
            loop: true,
            navText: []
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryThumbsS2.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    $thumbGalleryThumbsS2
        .owlCarousel({
            margin: 15,
            items: 4,
            nav: false,
            center: false,
            dots: false
        })
        .on('click', '.owl-item', function () {
            $thumbGalleryDetailS2.trigger('to.owl.carousel', [$(this).index(), duration, true]);

        })
        .on('changed.owl.carousel', function (e) {
            console.log(e);
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryDetailS2.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    /*
   Thumb Gallery - S3
   */
    var $thumbGalleryDetailS3 = $('#thumbGalleryDetailS3'),
        $thumbGalleryThumbsS3 = $('#thumbGalleryThumbsS3'),
        flag = false,
        duration = 300;

    $thumbGalleryDetailS3
        .owlCarousel({
            items: 1,
            margin: 10,
            nav: true,
            dots: false,
            loop: true,
            navText: []
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryThumbsS3.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    $thumbGalleryThumbsS3
        .owlCarousel({
            margin: 15,
            items: 4,
            nav: false,
            center: false,
            dots: false
        })
        .on('click', '.owl-item', function () {
            $thumbGalleryDetailS3.trigger('to.owl.carousel', [$(this).index(), duration, true]);

        })
        .on('changed.owl.carousel', function (e) {
            console.log(e);
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryDetailS3.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });


    /*
   Thumb Gallery - S4
   */
    var $thumbGalleryDetailS4 = $('#thumbGalleryDetailS4'),
        $thumbGalleryThumbsS4 = $('#thumbGalleryThumbsS4'),
        flag = false,
        duration = 300;

    $thumbGalleryDetailS4
        .owlCarousel({
            items: 1,
            margin: 10,
            nav: true,
            dots: false,
            loop: true,
            navText: []
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryThumbsS4.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    $thumbGalleryThumbsS4
        .owlCarousel({
            margin: 15,
            items: 4,
            nav: false,
            center: false,
            dots: false
        })
        .on('click', '.owl-item', function () {
            $thumbGalleryDetailS4.trigger('to.owl.carousel', [$(this).index(), duration, true]);

        })
        .on('changed.owl.carousel', function (e) {
            console.log(e);
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryDetailS4.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });


    /*
  Thumb Gallery - S5
  */
    var $thumbGalleryDetailS5 = $('#thumbGalleryDetailS5'),
        $thumbGalleryThumbsS5 = $('#thumbGalleryThumbsS5'),
        flag = false,
        duration = 300;

    $thumbGalleryDetailS5
        .owlCarousel({
            items: 1,
            margin: 10,
            nav: true,
            dots: false,
            loop: true,
            navText: []
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryThumbsS5.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    $thumbGalleryThumbsS5
        .owlCarousel({
            margin: 15,
            items: 4,
            nav: false,
            center: false,
            dots: false
        })
        .on('click', '.owl-item', function () {
            $thumbGalleryDetailS5.trigger('to.owl.carousel', [$(this).index(), duration, true]);

        })
        .on('changed.owl.carousel', function (e) {
            console.log(e);
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryDetailS5.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });


    /*
 Thumb Gallery - S6
 */
    var $thumbGalleryDetailS6 = $('#thumbGalleryDetailS6'),
        $thumbGalleryThumbsS6 = $('#thumbGalleryThumbsS6'),
        flag = false,
        duration = 300;

    $thumbGalleryDetailS6
        .owlCarousel({
            items: 1,
            margin: 10,
            nav: true,
            dots: false,
            loop: true,
            navText: []
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryThumbsS6.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

    $thumbGalleryThumbsS6
        .owlCarousel({
            margin: 15,
            items: 4,
            nav: false,
            center: false,
            dots: false
        })
        .on('click', '.owl-item', function () {
            $thumbGalleryDetailS6.trigger('to.owl.carousel', [$(this).index(), duration, true]);

        })
        .on('changed.owl.carousel', function (e) {
            console.log(e);
        })
        .on('changed.owl.carousel', function (e) {
            if (!flag) {
                flag = true;
                $thumbGalleryDetailS6.trigger('to.owl.carousel', [e.item.index, duration, true]);
                flag = false;
            }
        });

}).apply(this, [jQuery]);