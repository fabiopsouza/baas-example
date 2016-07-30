starter.controller('AppCtrl', function($scope, $ionicLoading, $ionicPopup) {

	$scope.TreePercentOfScreenWidth = ((window.screen.width / 100) * 3);

	$scope.showLoading = function() {
	    $ionicLoading.show({
	      content: '<i class="ion-loading-c"></i>'
	    });
	};
	  
	$scope.hideLoading = function(){
	    $ionicLoading.hide().then(function(){});
	};

	$scope.showAlert = function(title, message, error) {
	    var alertPopup = $ionicPopup.alert({
	      title: title,
	      template: message
	    });

	    alertPopup.then(function(res) {
	      if (error != undefined)
	        console.log(error);
	    });
	  };

	function doOnOrientationChange(){
		//3% do tamanho da tela
		$scope.TreePercentOfScreenWidth = ((window.screen.width / 100) * 3);
		$scope.$apply();
	}

    window.addEventListener('orientationchange', doOnOrientationChange);

})