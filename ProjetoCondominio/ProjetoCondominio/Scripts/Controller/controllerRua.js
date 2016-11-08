var app = angular.module('app', []);

app.controller('CasaController', function ($scope, $http) {
    $scope.Casas = [];
    $scope.casa = "";
    $scope.Ruas = [];
    $scope.rua = "";

    $scope.ListarCasas = function () {        
        $http.post("/Casa/Listar", { id_rua: $scope.casa.Id_Rua }).then(function (response) {
            $scope.Casas = response.data;
        });    
    }
    $scope.ListarTodos = function () {
        $http.get("/Casa/ListarTodos").then(function (response) {
            $scope.Casas = response.data;
        });
    }

    $scope.ListarRuas = function () {
        $http.get("/Rua/Listar").then(function (response) {
            $scope.Ruas = response.data;
        });
    }

    $scope.DeletarCasa = function (id) {
        $http.post("/Casa/Deletar", { id: id }).then(function (response) {
            $scope.ListarCasas();
        });
    }
    $scope.SalvarCasa = function () {
        if ($scope.casa.ID) {
            $http.post("/Casa/Editar", { casa: $scope.casa }).success(function (response) {
                if (!response) {
                    alert("Erro: Essa casa ja existe!")
                }
                $scope.casa = null;
                $scope.ListarCasas();
            })
        }
        else {
            alert($scope.casa.Casa)
            $http.post("/Casa/Salvar", { casa: $scope.casa }).success(function (response) {
                if (!response) {
                    alert("Erro: Essa casa ja existe!")
                }
                $scope.ListarCasas();
            })
        }
    }
    $scope.EditarCasa = function (objeto) {
        $scope.casa = objeto;
    }
    
    $scope.init = function () {
        $scope.ListarCasas();
        $scope.ListarRuas();
    }

    $scope.init();

});

app.controller('RuaController', function ($scope, $http) {
    $scope.Ruas = [];
    $scope.rua = "";

    $scope.ListarRuas = function () {
        $http.get("/Rua/Listar").then(function (response) {
            $scope.Ruas = response.data;
        });
    }

    $scope.DeletarRua = function (id) {
        $http.post("/Rua/Deletar", {id:id}).sucess(function (response) {
            $scope.ListarRuas();
        });
    }

    $scope.SalvarRua = function () {
        if ($scope.rua.ID) {
            $http.post("/Rua/Editar", { rua: $scope.rua }).success(function (response) {
                $scope.ListarRuas();
            })
        }
        else {
            alert($scope.rua.Rua)
            $http.post("/Rua/Salvar", { rua: $scope.rua , nome : $scope.rua.Rua}).success(function (response) {
                $scope.ListarRuas();
            })
        }
    }

    $scope.EditarRua = function (objeto) {
        $scope.rua = objeto;
    }


    $scope.init = function () {
        $scope.ListarRuas();
    }

    $scope.init();
    });