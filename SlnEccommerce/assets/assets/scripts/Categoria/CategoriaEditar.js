var CategoriaEditar = function () {
    var _componentes = function () {
        $(document).on('click', '.btnCancelar', function () {
            RefrescarVentana();
        });
        $(document).on('click', '.btnVolver', function () {
            RedirigirUrl('Categoria/Index');
        });
        $(document).on('click', '.btnGuardar', function () {
            $("#frmNuevo").submit();
            if (_objetoForm_frmNuevo.valid()) {
                var dataform = $("#frmNuevo").serializeFormJSON();
                EnviarDataPost({
                    url: "Categoria/CategoriaEditarJson",
                    data: dataform,
                    callBackSuccess: function () {
                        setTimeout(function () {
                            RedirigirUrl('Categoria/Index');
                        }, 1000)
                    }
                });
            }
        });
    };
    const _cargarData = function () {
        $("#idCategoria").val(categoria.idCategoria);
        $("#nombre").val(categoria.nombre);
        $("#descripcion").val(categoria.descripcion);
        $("#estado").val(categoria.estado);
    };
    var _metodos_validacion = function () {
        ValidarFormulario({
            contenedor: '#frmNuevo',
            nameVariable: 'frmNuevo',
            rules: {
                nombre: {
                    required: true,
                },
                descripcion: {
                    required: true,
                },
            },
            messages: {
                nombre: {
                    required: 'El campo moneda es requerido',
                },
                descripcion: {
                    required: 'El campo venta es requerido',
                },
            }
        });
    };
    return {
        init: function () {
            _componentes();
            _cargarData();
            _metodos_validacion();
        }
    }
}();

document.addEventListener('DOMContentLoaded', function () {
    CategoriaEditar.init();
});
