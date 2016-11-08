var app = angular.module('app', []);

app.controller('MoradorController', function ($scope, $http) {
    $scope.Casas = [];
    $scope.casa = "";
    $scope.Ruas = [];
    $scope.Moradores = [];
    $scope.morador = "";


    $scope.ListarCasas = function () {
        $http.post("/Casa/Listar", { id_rua: $scope.morador.Id_Rua }).then(function (response) {
            $scope.Casas = response.data;
        });
    }

    $scope.ListarRuas = function () {
        $http.get("/Rua/Listar").then(function (response) {
            $scope.Ruas = response.data;
        });
    }
     //---- funçoes moradores ---- 
    $scope.ListarMoradores = function () {
        $http.get("/Morador/Listar").then(function (response) {
            $scope.Moradores = response.data;
        });
    }

    $scope.DeletarMorador = function (id) {
        $http.post("/Morador/Deletar", { id: id }).sucess(function (response) {
            $scope.ListarMoradores();
        });
    }
    $scope.SalvarMorador = function () {
        if ($scope.morador.ID) {
            $http.post("/Morador/Editar", { morador: $scope.morador }).success(function (response) {
                if (!response) {
                    alert("Erro: Esse morador ja existe!")
                }
                $scope.morador = null;
                $scope.ListarMoradores();
            })
        }
        else {
            $http.post("/Morador/Salvar", { morador: $scope.morador }).success(function (response) {
                if (!response) {
                    alert("Erro: Esse morador ja existe!")
                }
                $scope.ListarMoradores();
            })
        }
    }
    $scope.EditarMorador = function (objeto) {
        $scope.morador = objeto;
        $scope.ListarCasas();

    }

    $scope.init = function () {
        $scope.ListarMoradores();
        $scope.ListarCasas();
        $scope.ListarRuas();
    }

    $scope.init();

});