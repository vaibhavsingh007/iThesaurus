describe('Comm Service', function () {
    var CommSvc;

    // Before each test load our Thesaurus module
    beforeEach(angular.mock.module('Thesaurus'));

    //beforeEach(function (done) {
    //    setTimeout(function () {
            
    //        done();
    //    }, 1);
    //});

    // Before each test set our injected Comm Service to our local CommSvc variable
    beforeEach(inject(function (_CommunicationService_) {
        CommSvc = _CommunicationService_;
    }));

    // A simple test to verify the Service exists
    it('getAllWords should exist', function () {
        expect(CommSvc.getAllWords).toBeDefined();
    });

    // TODO: Will have to explore more on how to make REST calls using Jasmine.
    //it('getAllWords should return an array of words', function (done) {
    //    CommSvc.getAllWords().then(function(result) {
    //        expect(result.length).toBeGreaterThan(1);
    //        done();
    //    });
    //    console.log(result);
    //});
});