app.service("CommunicationService", function ($http) {
    function extractData(response) {
        return response.data;
    }

    var getAllWords = function () {
        return $http.get('/api/ThesaurusApi').then(extractData);
    }

    var getSynonyms = function (word) {
        return $http.get('/api/ThesaurusApi/' + word).then(extractData);
    }

    var addSynonyms = function (w, s) {
        var data = { word: w, synonyms: s };
        return $http.post('/api/ThesaurusApi/', data).then(extractData);
    }

    return {
        getAllWords: getAllWords,
        getSynonyms: getSynonyms,
        addSynonyms: addSynonyms
    }
});