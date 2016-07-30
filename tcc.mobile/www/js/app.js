// Ionic Starter App

angular.module('starter', ['ionic', 'starter.controllers', 'starter.directives','starter.services'])

.run(function($ionicPlatform) {
  $ionicPlatform.ready(function() {
    
    if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
      cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
      cordova.plugins.Keyboard.disableScroll(true);

    }
    if (window.StatusBar) {
      StatusBar.styleDefault();
    }
  });
})

.config(function($stateProvider, $urlRouterProvider, $ionicConfigProvider) {

  $ionicConfigProvider.tabs.position('bottom');

  $stateProvider

  // setup an abstract state for the tabs directive
  .state('tab', {
    url: '/tab',
    abstract: true,
    templateUrl: 'templates/tabs.html',
    controller: 'AppCtrl'
  })

  // Each tab has its own nav history stack:

  .state('tab.dash', {
    url: '/dash',
    views: {
      'tab-dash': {
        templateUrl: 'templates/tab-dash.html',
        controller: 'DashCtrl'
      }
    }
  })

  .state('tab.movimentacoes', {
    url: '/movimentacoes',
    views: {
      'tab-movimentacoes': {
        templateUrl: 'templates/tab-movimentacoes.html',
        controller: 'ListagemCtrl'
      }
    }
  })
  
  .state('tab.movimentacoes-detail', {
    url: '/movimentacoes/:Id',
    views: {
      'tab-movimentacoes': {
        templateUrl: 'templates/movimentacoes-detail.html',
        controller: 'ListagemDetailCtrl'
      }
    }
  })

  .state('tab.envio', {
    url: '/envio',
    views: {
      'tab-envio': {
        templateUrl: 'templates/tab-envio.html',
        controller: 'EnvioCtrl'
      }
    }
  });

  // if none of the above states are matched, use this as the fallback
  $urlRouterProvider.otherwise('/tab/dash');

});
