(function () {
    'use strict';

    angular
        .module('Ceiss')
        .directive('ceissArticle', directive);

    directive.$inject = ['$window'];

    function directive($window) {
        debugger;
        // Usage:
        //     <ceiss-article></ceiss-article>
        // Creates:
        // 
        var directive = {
            template: `
            <div class="col-md-4 my-3">
                <div class="card">
                    <div class="card-header bg-primary text-white text-center"> #1 ${article.title}</div>
                    <img class="img-fluid" src="https://pingendo.github.io/templates/sections/assets/features_mac.jpg" alt="Card image">
                    <div class="card-body">
                        <h6 class="card-subtitle text-muted">Support card subtitle</h6>
                        <p class="card-text p-y-1">Some quick example text to build on the card title .</p>
                        <a href="#" class="card-link">link</a>
                        <a href="#" class="card-link">Second link</a>
                    </div>
                </div>
            </div>
         `
        };
        return directive;

        function link(article, element, attrs) {
          

        }
    }

})();