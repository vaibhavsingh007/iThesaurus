var app = angular.module("Thesaurus", []);

app.controller("ThesaurusController", ["$scope", "CommunicationService", function ($scope, commService) {
    $scope.showAddNewSynonym = false;
    $scope.displaySynonyms = false;
    $scope.synonyms = [];

    $scope.getSynonyms = function (word) {
        commService.getSynonyms(word).then(function (result) {
            $scope.displaySynonyms = true;

            if (result.length == 0) {
                alert("No synonyms found!");
                $scope.synonyms = [];
                $scope.showAddNewSynonym = true;
                return;
            }
            $scope.showAddNewSynonym = false;
            $scope.synonyms = result;
            $scope.wordSearch = word;
        });
    }

    $scope.getAllWords = function () {
        commService.getAllWords().then(function (result) {
            $scope.words = result;
        });
    }

    $scope.addSynonym = function (synonym) {
        commService.addSynonyms($scope.wordSearch, [synonym]).then(function (result) {
            if (result === true) {
                $scope.synonyms.push(synonym);
                $scope.showAddNewSynonym = false;
            }
            else {
                alert("Operation failed");
            }
        });
    }
}]);