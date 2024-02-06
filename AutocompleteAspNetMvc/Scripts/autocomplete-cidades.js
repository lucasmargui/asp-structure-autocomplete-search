$(function () {
    atualizarListaDeCidades("AC");

    $("#select-uf").change(function () {
        var uf = $(this).val();
        atualizarListaDeCidades(uf);
    });
});

function atualizarListaDeCidades(uf) {
    var options = {
        url: function () {
            return "/Cidades/ListarCidadesPorUF?uf=" + uf;
        },

        getValue: "Nome",

        list: {
            match: {
                enabled: true
            },
            onSelectItemEvent: function () {
                var idCidade = $("#txt-cidade").getSelectedItemData().Id;
                
                $("#hidden-cidade").val(idCidade);
            }
        }
    };

    $("#txt-cidade").easyAutocomplete(options);
}