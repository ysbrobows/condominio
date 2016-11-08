var app = angular.module('app', []);

app.controller('FuncionarioController', function ($scope, $http) {
    $scope.Casas = [];
    $scope.casa = "";
    $scope.Ruas = [];
    $scope.Funcionarios = [];
    $scope.funcionario = "";


    $scope.ListarCasas = function () {
        $http.post("/Casa/Listar", { id_rua: $scope.funcionario.Id_Rua }).then(function (response) {
            $scope.Casas = response.data;
        });
    }

    $scope.ListarRuas = function () {
        $http.get("/Rua/Listar").then(function (response) {
            $scope.Ruas = response.data;
        });
    }
    //---- funçoes funcionarios ---- 
    $scope.ListarFuncionarios = function () {
        $http.get("/Funcionario/Listar").then(function (response) {
            $scope.Funcionarios = response.data;
        });
    }

    $scope.DeletarFuncionario = function (id) {
        $http.post("/Funcionario/Deletar", { id: id }).then(function (response) {
            $scope.ListarFuncionarios();
        });
        
    }
    $scope.SalvarFuncionario = function () {
        if ($scope.funcionario.ID) {
            $http.post("/Funcionario/Editar", { funcionario: $scope.funcionario }).success(function (response) {
                if (!response) {
                    alert("Erro: Esse funcionario ja existe!")
                }
                $scope.morador = null;
                $scope.ListarFuncionarios();
            })
        }
        else {
            $http.post("/Funcionario/Salvar", { funcionario: $scope.funcionario }).success(function (response) {
                if (!response) {
                    alert("Erro: Esse funcionario ja existe!")
                }
                $scope.ListarFuncionarios();
            })
        }
    }
    $scope.EditarFuncionario = function (objeto) {
        $scope.funcionario = objeto;
        $scope.ListarFuncionarios();

    }

    $scope.init = function () {
        $scope.ListarFuncionarios();
        $scope.ListarCasas();
        $scope.ListarRuas();
    }

    $scope.init();

});