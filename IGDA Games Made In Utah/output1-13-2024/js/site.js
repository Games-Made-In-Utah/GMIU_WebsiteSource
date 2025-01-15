// Credits to https://stackoverflow.com/questions/32938168/using-innerhtml-property-to-display-content-of-another-html-file
// HUGE thanks for the assist!

$(function () {
    $("#header").load("header.html");  // Loads page header
    $("#footer").load("footer.html");  // Loads page footer

    $('body').addClass('fade-in');  // Smooth fade-in on page load
});
