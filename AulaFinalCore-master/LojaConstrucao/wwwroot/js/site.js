
    // Função para mostrar o modal de criação de tarefa
    //function mostrarModal() {
    //    $('#myModal').modal('show'); // Mostra o modal
    //console.log("Modal sendo mostrado");
    //}

    //// Função para ocultar o modal de criação de tarefa
    //function ocultarModal() {
    //    $('#myModal').modal('hide'); // Oculta o modal
    //}
document.addEventListener("DOMContentLoaded", function () {
    $(".clicadoooo").click(function () {
        mostrarModal();
    });

    function mostrarModal() {
        $('#vtncModal').modal('show');
        console.log("vtnc");
    }

    $(".btnSalvar").click(function () {
        console.log("pegouuuu")
        var tarefa = {
            NomeTarefa: $('.NomeTarefa').val(),
            Descricao: $('.Descricao').val()
        };
        criarTarefa(tarefa)
        //if (validarFormulario(tarefa)) {
        //    criarTarefa(tarefa);
        //}
    });

    function criarTarefa(tarefa) {
        $.ajax({
            url: "Tarefas/Create",
            method: 'POST',
            data: {
                tarefa: tarefa
            },
            success: function (tarefaCriada) {
                $('#vtncModal').modal('hide');
                window.location.reload();
            }
        });
    }
    $(document).ready(function () {
        $('[data-bs-toggle="popover"]').popover();
    });

});

    //function validarFormulario(tarefa) {
    //        let nomeValido = validarNome(tarefa.NomeTarefa);
    //        let DescricaoValida = validarDescricao(tarefa.Descricao);

    //        if (nomeValido == true) {
    //            return false;
    //        }

    //    return true;

    //    }

//        function validarNome(nome) {
//            let nomeValido = true;

//            if (nome.trim() == '' || nome == underfined) {
//               /* $(".NomeTarefa").addClass('is-invalid');*/
//                nomeValido = false;
//            }
//            else {
//                nomeValido = true;
//            }
//        }


