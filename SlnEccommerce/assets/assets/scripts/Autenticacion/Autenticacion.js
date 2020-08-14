const AutenticacionVista = function () {
    const eventos = () => {
        $("input").keydown(function (e) {
            if (e.keyCode == 13) {
                e.preventDefault();
                $('#btnSesion').click();
            }
        });
        $(document).on('click', '#btnSesion', function () {
            $("#frmNuevo").submit();
            if (_objetoForm_frmNuevo.valid()) {
                let dataForm = $("#frmNuevo").serializeFormJSON();
                let url = basePath + "Autenticacion/UsuarioAutenticarJson";
                $.LoadingOverlay("show");
                axios({
                    method: 'POST',
                    url: url,
                    data: dataForm
                }).then(function (response) {
                    let mensaje = response.data.mensaje;
                    if (response.data.respuesta) {
                        $("#btnLogin").hide();
                        swalInit({
                            title: mensaje,
                            text: 'Ingresando',
                            type: 'success',
                            allowOutsideClick: false
                        }).then(function (result) {
                            if (result.value) {
                                window.location.replace(basePath + "Categoria/Index");
                            }
                        });
                        setTimeout(function () {
                            window.location.replace(basePath + "Categoria/Index")
                        }, 1000);
                    } else {
                        ShowAlert({
                            message: mensaje,
                            type: "warning",
                            custom_option: {
                                allowOutsideClick: false
                            }
                        });
                    }
                }).finally(function () {
                    $.LoadingOverlay("hide");
                });
            }
        })
    };
    const validarFormulario = () => {
        ValidarFormulario({
            contenedor: '#frmNuevo',
            nameVariable: 'frmNuevo',
            rules: {
                email: {
                    required: true,
                    email: true,
                },
                password: {
                    required: true
                },
            },
            messages: {
                email: {
                    required: 'El campo es requerido',
                    email: 'El formato ingresado no es el correcto'
                },
                password: {
                    required: 'El campo es requerido'
                },
            }
        });
    }


    return {
        init: function () {
            eventos();
            validarFormulario();
        }
    }
}();

document.addEventListener('DOMContentLoaded', function () {
    AutenticacionVista.init();
});



