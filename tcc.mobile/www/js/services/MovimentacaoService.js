services.factory('MovimentacaoService', function($http) {

  var api = 'http://localhost:8083/api/';

  return {
    
    all: function(success) {
      $http.get(api + 'movimentacao')
      .success(function(response) {

        if(response.IsSuccess)
          success(response.Data);
      })
      .error(function(error){
        console.log(error);
      });
    },

    filterStatus: function(status, success){
      $http.get(api + 'movimentacao/status/' + status)
      .success(function(response) {

        if(response.IsSuccess)
          success(response.Data);
      })
      .error(function(error){
        console.log(error);
      });
    },

    statusCount: function(success){
      $http.get(api + 'movimentacao/status/counts')
      .success(function(response) {

        if(response.IsSuccess)
          success(response.Data);
      })
      .error(function(error){
        console.log(error);
      });
    },

    find: function(id, success){
      $http.get(api + 'movimentacao/' + id)
      .success(function(response) {
        if(response.IsSuccess)
          success(response.Data[0]);
      })
      .error(function(error){
        console.log(error);
      });
    },

    save: function(data, success){
      $http({
       method: 'POST',
       url: api + 'movimentacao',
       headers: {'Content-Type': 'application/json' },
       data: data
      }).then(function(response){
          if(response.data.IsSuccess){
            success();
          }
        },
        function(error){
          $scope.showAlert('Erro', 'Houve um erro ao salvar movimentacao', error);
        });
    },

    remove: function(id, success){
      $http({
       method: 'POST',
       url: api + 'movimentacao/delete/' + id,
       headers: {'Content-Type': 'application/json' }
      }).then(function(response){
          if(response.data.IsSuccess){
            success();
          }
        },
        function(error){
          $scope.showAlert('Erro', 'Houve um erro remover movimentacao', error);
        });
    }
  };

});

