

mergeInto(LibraryManager.library, {

  

  ShowAdv : function() {
ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          sendRequest.SendMessage('YandexSDK','AdvClosed')
        },
        onError: function(error) {
         sendRequest.SendMessage('YandexSDK','AdvClosed')
        }
    }
})},

});