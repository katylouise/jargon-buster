function ParlJargonBusterParliamentUK(options) {
    var _options = options;
    var _jargonBuster;

    function build() {
        _jargonBuster = new ParlJargonBuster(_options);

        addDefinitionsToggleLink();

        _jargonBuster.Build();
    }

    function addDefinitionsToggleLink() {
        $("#navigation #level-1").append("<li class='parl-definitions'>Definitions</li>");
    }

    this.Build = build;
}