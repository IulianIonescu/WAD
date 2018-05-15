function BooksAPI() {

    if (typeof BooksAPI.instance === 'object') {
        return BooksAPI.instance;
    }

    var baseURL = "localhost";

    var doAsyncGet = function (partialUrl) {
        var authorityToken = "";//$.cookie("labman_token");
        var fullUrl = baseURL + partialUrl;
        return $.ajax({
            url: fullUrl,
            headers: {
                "Authority": authorityToken
            },
            dataType: "json"
        });
    };

    var doAsyncPost = function (partialURL, jsonDataToPost) {
        var authorityToken = "";//$.cookie("labman_token");
        var fullUrl = baseURL + partialURL;
        return $.ajax({
            url: fullUrl,
            type: "POST",
            headers: {
                "Authority": authorityToken,
                "Content-Type": "application/json"

            },
            data: JSON.stringify(jsonDataToPost),
            dataType: "json"
        });
    };

    var doAsyncDelete = function (partialURL) {
        var authorityToken = "";//$.cookie("labman_token");
        var fullUrl = baseURL + partialURL;
        return $.ajax({
            url: fullUrl,
            type: "DELETE",
            headers: {
                "Authority": authorityToken
            },
            dataType: "json"
        });
    }

    var doAsyncPut = function (partialURL, jsonDataToPut) {
        var authorityToken = "";//$.cookie("labman_token");
        var fullUrl = baseURL + partialURL;
        return $.ajax({
            url: fullUrl,
            type: "PUT",
            headers: {
                "Authority": authorityToken,
                "Content-Type": "application/json"
            },
            data: JSON.stringify(jsonDataToPut),
            dataType: "json"
        });
    };

    this.setBaseURL = function (strBaseURL) {
        baseURL = strBaseURL;
    };

    this.getAllBooks = function () {
        var allBooksReq = "api/Books";
        return doAsyncGet(allBooksReq);
    };


    this.getAllCategories = function () {
        var apiURL = "api/Categories";
        return doAsyncGet(apiURL);
    };


    this.getBooksInCategory = function (categoryId) {
        var apiURL = "api/Categories/" + categoryId + "/Books";
        return doAsyncGet(apiURL);
    };


    BooksAPI.instance = this;
}