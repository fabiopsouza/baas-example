starter.controller('DashCtrl', function($scope, MovimentacaoService, $rootScope) {
  
	$scope.total = 0;
	$scope.percents = [];

	$scope.chart = {
		labels: ['Pendentes', 'Aprovados', 'Reprovados'],
		data: [],
		colors: ['#886aea', '#33cd5f', '#ef473a']
	};

	$rootScope.$on("RefreshAllData", function(){
       $scope.fillChartAndPanels();
    });

	$scope.fillChartAndPanels = function(){

		$scope.chart.data = [];
    	MovimentacaoService.statusCount(function(data){

    		for(var property in data){
    			$scope.chart.data.push(data[property]);
    			$scope.total += data[property];
			}

			$scope.chart.data.forEach(function(data){
				$scope.percents.push(((data * 100) / $scope.total).toFixed(2));
			});

    		$scope.$broadcast('scroll.refreshComplete');
    	});
	}

	$scope.fillChartAndPanels();
})