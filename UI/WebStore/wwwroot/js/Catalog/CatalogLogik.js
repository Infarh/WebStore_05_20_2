Catalog = {
    _properties: {
        getUrl: ""
    },

    init: properties => {
        $.extend(Catalog._properties, properties);
        $(".pagination li a").click(Catalog.clickOnPage);
    },

    clickOnPage: function(event) {
        event.preventDefault();

        const button = $(this);


    }
}