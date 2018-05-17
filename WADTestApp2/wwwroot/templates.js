function getBookHtml(initialTemplate, book) {
    var template = initialTemplate;
    var done = false;
    var currentTemplate = template;
    do {
        currentTemplate = template;
        template = template.replace("{bookName}", book.name);
    } while (template !== currentTemplate);

    template = template.replace("{bookDesc}", book.description);
    template = template.replace("{bookPrice}", book.price);
    var mainAuthor = "";
    if (book.authorsLinks.length > 0)
    {
        mainAuthor = book.authorsLinks[0].author.name;
    }
    template = template.replace("{bookAuthor}", mainAuthor);

    return template;

}

function getCategoryItemHtml(initialTemplate, category) {
    var template = initialTemplate;

    template = template.replace("{categoryId}", "" + category.id);
    template = template.replace("{categoryName}", category.name);
    return '<li>' + template + '</li>';
}