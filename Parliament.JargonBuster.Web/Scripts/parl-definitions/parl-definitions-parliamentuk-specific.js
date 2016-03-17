$(document).ready(function () {
    var options = {
        wordFrequency: 3,
        contentSelectors: ["#content"]
    }
    var jargonBuster = new ParlJargonBusterParliamentUK(options);

    jargonBuster.Build();
});

function ParlJargonBusterParliamentUK(options) {
    var _options = options;
    var _jargonBuster;

    function build() {
        _jargonBuster = new ParlJargonBuster(_options);

        addDefinitionsToggleLink();

        _jargonBuster.Build();
    }

    function addDefinitionsToggleLink() {
        $("#navigation #level-1").append("<li class='parl-definitions-toggle-list'><a class='parl-definitions' data-style='toggle'>Definitions</a></li>");
    }

    this.Build = build;
}