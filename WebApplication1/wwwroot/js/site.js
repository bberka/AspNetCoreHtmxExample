$(document).ready(function () {

    document.body.addEventListener("htmx:afterSwap", function (evt) {
        const xhr = evt.detail.xhr;
        const pageTitle =  xhr.getResponseHeader("Override-Page-Title");
        if(pageTitle !== null && pageTitle !== undefined && pageTitle !== ""){
            document.title = pageTitle;
        }
    });
    document.body.addEventListener("htmx:validateUrl", function (evt) {
        if (evt.detail.url.hostname !== "localhost") {
            evt.preventDefault();
        }
    });

})
