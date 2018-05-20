function getTemplate(templateName)
{
    return $.ajax({
            url: templateName
        });
}
function fillInBooks(container, books)
{

    var header = $(container).first();
    var headerText = "";
    if (header)
    {
        headerText = $(header).html();
    }

   getTemplate("bookTemplate.html").done(
            function (response)
            {
                var finalHtml="";
                for (var i = 0; i < books.length; i++) {
                        bookHtml = getBookHtml(response, books[i]);
                        finalHtml = finalHtml + bookHtml;
                }
                finalHtml = headerText + finalHtml;
                $(container).html(finalHtml);
            }
        );
}

function fillInCategoriesInMenu(menuContainer, categories)
{
    
    getTemplate("categoryListItemTmpl.html").done(
            function (template)
            {
                var finalHtml="";
                for (var i = 0; i < categories.length; i++) {
                        categoryHtml = getCategoryItemHtml(template, categories[i]);
                        finalHtml = finalHtml + categoryHtml;                        
                    }
                $(menuContainer).html(finalHtml);
            });
}

function showCategoryBooks(categoryId)
{
   // $("#booksContainer").html("<b>Loading books...</b>");   
    var booksApi = new BooksAPI();
    var books;
    booksApi.setBaseURL("");
    if (categoryId === "*")
    {
        books = booksApi.getAllBooks();
    }
    else
    {
        books = booksApi.getBooksInCategory(categoryId);
    }
    
    books.done(
        function (response) {
            fillInBooks($("#booksContainer"), response);           

        });
}

function showCategoriesInMenu(menuContainer)
{
    
    $(menuContainer).html("<b>Loading Categories...</b>");
    var booksApi = new BooksAPI();
    var categories;
    booksApi.setBaseURL("");
    categories = booksApi.getAllCategories();
    
    categories.done(
            function (categoriesList)
            {
                fillInCategoriesInMenu($(menuContainer), categoriesList);
            });
    
}
