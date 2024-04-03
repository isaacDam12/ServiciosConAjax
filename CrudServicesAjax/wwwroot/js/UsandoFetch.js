$(document).ready(function () {
    GetAll();
});function GetAll() {    fetch('http://localhost:5015/api/Pedido/GetAll')        .then(response => {            if (response.ok) {                return response.json();            } else {                throw new Error('Error en la solicitud');            }        })        .then(data => {            console.log(data);            const tablaBody = document.getElementById('tablaBody');            tablaBody.innerHTML = '';            data.Pedido.pedidos.forEach(pedido => {                const fila = document.createElement('tr');                fila.innerHTML = `      <td><a href="#" class = "btn btn-warning" onclick="GetById(${pedido.idPedido})">Editar</a></td>      <td>${pedido.idPedido}</td>      <td>${pedido.nombre}</td>      <td>${pedido.precio}</td>      <td><a href="#" class = "btn btn-danger" onclick="Delete(${pedido.idPedido})">Eliminar</a></td>    `;                tablaBody.appendChild(fila);            });        })
}function GetById(idUsuario) {    fetch('http://localhost:5015/api/Pedido/GetById/' + idUsuario)        .then(response => {        if (response.ok) {            return response.json();        } else {            throw new Error('Error en la solicitud');        }    })        .then(data => {            console.log(data);
            var name = document.getElementById('txtNombre');
            name.value = data.Pedido.nombre;

            var precio = document.getElementById('txtPre');
            precio.value = data.Pedido.precio;

            var idUsu = document.getElementById('txtId');
            idUsu.value = data.Pedido.usuario.idUsuario;

            var id = document.getElementById('txtIdPedido');
            id.value = data.Pedido.idPedido;
            ShowModal(true);         })
}function Delete(idUsuario) {    fetch('http://localhost:5015/api/Pedido/Delete/' + idUsuario, {        method: 'DELETE',        headers: {            'Content-Type': 'application/json'        }    })        .then(response => {            if (response.ok) {                alert('Pedido eliminado');                GetAll();            } else {                alert('Error al eliminar pedido');                throw new Error('Error en la solicitud');            }        })}function ShowModal(isEditing) {
    $('#Form').modal('show');

    var enviarBtn = $('#enviarbtn');
    var idPedi = document.getElementById('txtIdPedido');

    if (isEditing) {
        enviarBtn.text('Actualizar');
        enviarBtn.off('click');

        enviarBtn.on('click', function () {
            Update(idPedi.value);
        });
    } else {
        enviarBtn.text('Guardar');
        enviarBtn.off('click');

        enviarBtn.on('click', function () {
            Agregar();
        });
    }}function Agregar() {

    var pedido = {
        "nombre": $('#txtNombre').val(),
        "precio": $('#txtPre').val(),
        "usuario": {
            "idUsuario": $('#txtId').val(),
            "nombre": "",
            "apellidoPaterno": "",
            "apellidoMaterno": "",
            "edad": 0,
            "usuarios": [
            ]
        },
        "pedidos": [
        ]
    }
    fetch('http://localhost:5015/api/Pedido/Add/', {        method: 'POST',        headers: {            'Content-Type': 'application/json'        },        body: JSON.stringify(pedido)    })        .then(response => {            if (response.ok) {                alert('Pedido Agregado')                GetAll();                return response.json();            } else {                alert('Pedido no Agregado')                throw new Error('Error en la solicitud');            }        })        .then(data => {            console.log(data);        })        .catch(error => {            console.error('Error:', error);        });
}function Update(id) {

    var pedido = {
        "idPedido" : id,
        "nombre": $('#txtNombre').val(),
        "precio": $('#txtPre').val(),
        "usuario": {
            "idUsuario": $('#txtId').val(),
            "nombre": "",
            "apellidoPaterno": "",
            "apellidoMaterno": "",
            "edad": 0,
            "usuarios": [
            ]
        },
        "pedidos": [
        ]
    }
    fetch('http://localhost:5015/api/Pedido/Update/', {        method: 'PUT',        headers: {            'Content-Type': 'application/json'        },        body: JSON.stringify(pedido)    })        .then(response => {            if (response.ok) {                alert('Pedido Modificado')                GetAll();                return response.json();            } else {                alert('Pedido no Modificado')                throw new Error('Error en la solicitud');            }        })        .then(data => {            console.log(data);        })        .catch(error => {            console.error('Error:', error);        });
}