starter.controller('ListagemDetailCtrl', function($scope, $stateParams, $http, MovimentacaoService, $rootScope, $ionicNavBarDelegate, $ionicHistory) {
  	
  	$scope.movimentacao = {};
    $scope.status = '';
    $scope.changedData = false;

  	$scope.get = function(){
      $scope.changedData = false;
  		$scope.showLoading();
  		MovimentacaoService.find($stateParams.Id, function(data){
          setStatus(data.StatusMovimentacaoId);
          $scope.movimentacao = data;
          $scope.movimentacao.NumeroConta = parseInt($scope.movimentacao.NumeroConta);
      		$scope.hideLoading();
      	});
  	}

    $scope.save = function(){

      if($scope.movimentacao.Cpf == undefined){
        $scope.showAlert('Falha', 'CPF inválido!');
        return;
      }
      
      $scope.showLoading();
      MovimentacaoService.save($scope.movimentacao, function(data){
        refreshHideAndBack();
      });
    }

    $scope.remove = function(){
      
      $scope.showLoading();

      MovimentacaoService.remove($scope.movimentacao.Id, function(data){
        refreshHideAndBack();
      });
    }

    function refreshHideAndBack(){
      $rootScope.$emit("RefreshAllData", {});
      $scope.hideLoading();
      $backView = $ionicHistory.backView();
      $backView.go();
    }

    $scope.enableEdit = function(){
      $scope.changedData = true;
    }

    function setStatus(statusId){
      switch(statusId) {
        case 1:
            $scope.status = 'Pendente'
            break;
        case 2:
            $scope.status = 'Aprovado'
            break;
        case 3:
            $scope.status = 'Reprovado'
            break;
        default:
            $scope.status = 'Detalhes'
      }
    }

	$scope.get();
})
