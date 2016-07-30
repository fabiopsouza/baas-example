starter.controller('EnvioCtrl', function($scope, $http, MovimentacaoService, $rootScope) {
  
  $scope.movimentacao = {};
  
  $scope.clear = function(){
  	$scope.movimentacao.Cpf = '';
  	$scope.movimentacao.NomeTitular = '';
  	$scope.movimentacao.NumeroConta = '';
  	$scope.movimentacao.TotalCreditos = '';
  	$scope.movimentacao.TotalDebitos = '';
  }

  $scope.send = function(){

    if($scope.movimentacao.Cpf == undefined ||
      $scope.movimentacao.NomeTitular == undefined ||
      $scope.movimentacao.NumeroConta == undefined ||
      $scope.movimentacao.TotalCreditos == undefined ||
      $scope.movimentacao.TotalDebitos == undefined){
      
      $scope.showAlert('Falha', 'Favor preencher todos os campos!');
      return;
    }

  	if($scope.movimentacao.Cpf == undefined){
  		$scope.showAlert('Falha', 'CPF inválido!');
  		return;
  	}

  	//Pendente de aprovação
  	$scope.movimentacao.StatusMovimentacaoId = 1;

  	$scope.showLoading();
  	MovimentacaoService.save($scope.movimentacao, function(data){
  	  $scope.clear();
      $rootScope.$emit("RefreshAllData", {});
      $scope.hideLoading();
      $scope.showAlert('Sucesso', 'Movimentação enviada com sucesso');
    });

  }  
})