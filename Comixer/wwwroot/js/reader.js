function loadApp() {


	// Create the flipbook
	
	let flipbookWidth = $('.container').width();
	console.log(flipbookWidth)

	$('.flipbook').turn({
		// Width

		width: flipbookWidth,

		// Height

		height: flipbookWidth*0.67,

		// Elevation

		elevation: 50,

		// Enable gradients

		gradients: true,

		// Auto center this flipbook

		autoCenter: true

	});
}


// Load the HTML4 version if there's not CSS transform

yepnope({
	test: Modernizr.csstransforms,
	yep: ['../lib/turnjs4/dist/js/turn.js'],
	nope: ['../lib/turnjs4/dist/js/turn.html4.min.js'],
	both: ['../lib/turnjs4/dist/css/basic.css'],
	complete: loadApp
});