starter.controller('ListagemCtrl', function($scope, $http, MovimentacaoService, $rootScope) {

	$scope.movimentacoes = [];
	$scope.selectedStatus;
	
	$rootScope.$on("RefreshAllData", function(){
       $scope.getAll();
    });

	$scope.getAll = function(){

		$scope.selectedStatus = undefined;
    	MovimentacaoService.all(function(data){
    		$scope.movimentacoes = data;
    		$scope.$broadcast('scroll.refreshComplete');
    	});
	}

	$scope.filter = function (status){

    	$scope.showLoading();
		$scope.selectedStatus = status;

		MovimentacaoService.filterStatus(status, function(data){
    		$scope.movimentacoes = data;
    		$scope.hideLoading();
    	});
	}	

	$scope.getAll();
})