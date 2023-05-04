using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class WinController 
    {
      
        private InteractiveObjView _playerView;

        private WinModel _model;

        

        public WinController(WinView view, InteractiveObjView playerView)
        {
            _model = new WinModel(view);
            _playerView = playerView;
            _playerView.nextLevel += ShowWinScreen;
        }

        public void ShowWinScreen() => _model.ShowScore(_playerView._healthBar.value);



        

    }
}
