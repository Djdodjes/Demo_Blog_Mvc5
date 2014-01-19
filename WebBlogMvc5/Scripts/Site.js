$(document).ready(function () {

    if (window.sessionStorage.length == 0 ) {
        var listArticles =
            [
                {
                    "Id": 1,
                    "Titre": "mon pur Article",
                    "Libelle": "lorem impsn",
                    "DatePublication": '10/01/2013',
                    "Commentaire": 'Test en prod'
                },
                {
                    "Id": 2,
                    "Titre": "mon article 2",
                    "Libelle": "lorem impsn",
                    "DatePublication": '10/13/2013',
                    "Commentaire": 'Test en prod'
                }
            ];

        var listArticles_json = JSON.stringify(listArticles);
        sessionStorage.setItem('listArticles', listArticles_json);
    }
    // ajaut dynamique d'articles contenu dans le sessionStorage
    $.each($.parseJSON(sessionStorage['listArticles']), function (i, val) {
        var articleTemplate = "<article class=\"articleMain\"><header><h3>" + val.Titre + "</h3></header><p>" + val.Libelle + "</p><footer>" + val.DatePublication + "</footer></article>";
        $("#articleContainer").append(articleTemplate);
    });

    //window.sessionStorage.clear();
  
});