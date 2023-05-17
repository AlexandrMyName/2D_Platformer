

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

 GetLang : function() {
	var lang = ysdk.environment.i18n.lang;
	var bufferSize = lengthBytesUTF8(lang) + 1;
	var buffer = _malloc(bufferSize);
      stringToUTF8(lang, buffer, bufferSize);
	return buffer;
	
},

});