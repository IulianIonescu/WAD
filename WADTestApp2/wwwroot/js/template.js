function getBookHtml(initialTemplate, book) {
    var template = initialTemplate;
    var done = false;
    var currentTemplate = template;
    do {
        currentTemplate = template;
        template = template.replace("{BookName}", book.name);
    } while (template !== currentTemplate);

    template = template.replace("{productDesc}", product.description);
    template = template.replace("{productPrice}", product.price);

    return template;

}

function getCategoryItemHtml(initialTemplate, category) {
    var template = initialTemplate;

    template = template.replace("{categoryId}", "" + category.id);
    template = template.replace("{categoryName}", category.name);
    return '<li>' + template + '</li>';
}