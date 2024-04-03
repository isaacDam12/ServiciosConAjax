//const { each } = require("jquery");

$(document).ready(function () {
    GetAll();
});


function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5015/api/Usuario/GetAll',
        dataType: 'json',
        success: function (result) {
            $('#SubCategorias tbody').empty();
            $.each(result.usuarios, function (i, usuario) {

                var filas = '<tr>' +
                    '<td><a href="#" class="btn btn-warning" onclick="GetById(' + usuario.idUsuario + ')">Editar</a></td>' +
                    '<td>' + usuario.nombre + '</td>' +
                    '<td>' + usuario.apellidoPaterno + '</td>' +
                    '<td>' + usuario.apellidoMaterno + '</td>' +
                    '<td>' + usuario.edad + '</td>' +
                    '<td><a href="#" class="btn btn-danger" onclick="Delete(' + usuario.idUsuario + ')">Eliminar</a></td>' +
                    '</tr>';

                $("#SubCategorias tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta');
        }
    });
};


function GetById(idUsuario) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5015/api/Usuario/GetById' + '/' + idUsuario,
        dataType: 'json',
        success: function (result) {
            console.log(result);
            var name = document.getElementById('txtNombre');
            name.value = result.nombre;
            var apeP = document.getElementById('txtApeP');
            apeP.value = result.apellidoPaterno;
            var apeM = document.getElementById('txtApeM');
            apeM.value = result.apellidoMaterno;
            var eda = document.getElementById('txtEdad');
            eda.value = result.edad;
            var id = document.getElementById('txtIdUsuario');
            id.value = result.idUsuario;

            ShowModal(true);
        },
        error: function (result) {
            alert('Error en el eliminado');
        }
    });
}


function Delete(idUsuario) {

    $.ajax({
        type: 'Delete',
        url: 'http://localhost:5015/api/Usuario/Delete' + '/' + idUsuario,

        success: function (result) {
            alert('Empleado Eliminado');
            GetAll();
        },
        error: function () {
            alert('Error al eliminar');
        }
    });
}


function Agregar() {
    var objEmpleado = {
        "nombre": $('#txtNombre').val(),
        "apellidoPaterno": $('#txtApeP').val(),
        "apellidoMaterno": $('#txtApeM').val(),
        "edad": $('#txtEdad').val(),
        "usuarios": [
        ]
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5015/api/Usuario/Add',
        contentType: 'application/json',
        data: JSON.stringify(objEmpleado),
        success: function (result) {
            alert('Usuario Agregado');
            GetAll();
        },
        error: function (result) {
            alert('Error en el agregado');
        }
    });
}


function Update(id) {

    var objEmpleado = {
        "idUsuario": id,
        "nombre": $('#txtNombre').val(),
        "apellidoPaterno": $('#txtApeP').val(),
        "apellidoMaterno": $('#txtApeM').val(),
        "edad": $('#txtEdad').val(),
        "usuarios": [
        ]
    }

    $.ajax({
        type: 'PUT',
        url: 'http://localhost:5015/api/Usuario/Update'
        ,
        contentType: 'application/json',
        data: JSON.stringify(objEmpleado),
        success: function (result) {
            alert('Usuario Actualizado');
            GetAll();
        },
        error: function (result) {
            alert('Error en el Actualizado');
        }
    });
}

function ShowModal(isEditing) {
    $('#Form').modal('show');

    var enviarBtn = $('#enviarbtn');
    var idEmple = document.getElementById('txtIdUsuario');

    if (isEditing) {
        enviarBtn.text('Actualizar');
        enviarBtn.off('click');

        enviarBtn.on('click', function () {
            Update(idEmple.value);
        });
    } else {
        enviarBtn.text('Guardar');
        enviarBtn.off('click');

        enviarBtn.on('click', function () {
            Agregar();
        });
    }
}

