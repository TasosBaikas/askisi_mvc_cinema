jQuery(window).on('load', function () {
    jQuery('.show-movie').on('click', function () {
        let parentElement = jQuery(this).parent().parent()

        let elementName = parentElement.find('.movie-title-data').text()
        let elementContent = parentElement.find('.movie-content-data').text()
        let elementLength = parentElement.find('.movie-length-data').text()
        let elementType = parentElement.find('.movie-type-data').text()
        let elementDirector = parentElement.find('.movie-director-data').text()
        let elementUser = parentElement.find('.movie-user-data').text()

        let contentContainer = $('#movie-modal')

        contentContainer.find('#movie-title').text(elementName)
        contentContainer.find('#movie-content').text(elementContent)
        contentContainer.find('#movie-length').text(elementLength)
        contentContainer.find('#movie-type').text(elementType)
        contentContainer.find('#movie-director').text(elementDirector)
        contentContainer.find('#movie-user').text(elementUser)
    });

    jQuery('.datepick').dateAndTime();
});