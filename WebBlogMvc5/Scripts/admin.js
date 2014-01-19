$(document).ready(function () {

    //window.sessionStorage.clear();
    
    $("#btnAddArticle").click(function () {

        var newArticle_Titre = $("#Titre").val();
        var newArticle_Libelle = $("#Libelle").val();
        var newArticle_DatePublication = Date(2014, 01, 01, 10, 10, 10, 10);

        var obj = {
            "Id": 5,
            "Titre": newArticle_Titre,
            "Libelle": newArticle_Libelle,
            "DatePublication": newArticle_DatePublication,
            "Commentaire": 'Bla bla'
        };

        // convertie le json n objet (ici en tableau) // $.parseJSON(
        var listArticles = JSON.parse(window.sessionStorage['listArticles']);

        listArticles.push(obj);

        // stockage en json
        window.sessionStorage['listArticles'] = JSON.stringify(listArticles);

        $.each($.parseJSON(window.sessionStorage['listArticles']), function (i, val) {
            console.log(val);
        });

    });
});