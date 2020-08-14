EstadoVigencia = 1;
var CategoriaListar = function () {
    var _componentes = function () {
        $(document).on('click', '.btnEditar', function () {
            var idCategoria = $(this).data('id');
            RedirigirUrl("Categoria/CategoriaEditar?idCategoria="+idCategoria);
        });
        $(document).on('click', '.btnNuevo', function () {
            RedirigirUrl('Categoria/CategoriaRegistrar');
        });
    };
    var ListarCategorias = function () {
        CargarTablaDatatable({
            uniform: true,
            ajaxUrl: "Categoria/CategoriaListarJson",
            table: "#table",
            tableOrdering: false,
            tableColumns: [
                { data: "idCategoria", title: "ID" },
                { data: "nombre", title: "CATEGORIA" },
                { data: "descripcion", title: "DESCRIPCION" },
                {
                    data: null, title: "OPCIONES",
                    "render": function (value) {
                        var editar = '<button class="btn btn-sm btn-success btnEditar" data-popup="tooltip" title="Editar" data-id="' + value.idCategoria + '"><i class="icon icon-pencil"></i></button>';
                        return editar;
                    }, class: "text-center"
                },
            ],
            tabledrawCallback: function () {
                $('.btnEditar').tooltip();                
            }
        })
    };
    return {
        init: function () {
            _componentes();
            ListarCategorias();
        }
    }
}();

document.addEventListener('DOMContentLoaded', function () {
    CategoriaListar.init();
});
