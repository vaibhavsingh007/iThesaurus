app.directive('displaySynonyms', function () {
    return {
        restrict: 'E',
        replace: true,
        templateUrl: 'Scripts/thesaurus/templates/display-synonyms-template.html',
        scope: {
            synonyms: '=',
            showAddNewSynonym: '=',
            addNewSynonym: '&',
            getSynonyms: '&'
        }
    };
})