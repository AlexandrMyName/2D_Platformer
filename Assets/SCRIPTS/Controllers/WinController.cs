using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class WinController 
    {
        private InteractiveObjView _playerView;

        private WinModel _model;

        private WinView _view;
        public WinView View { get { return _view; } }

        public WinController(WinView view, InteractiveObjView playerView)
        {
            _view = view;   
            _model = new WinModel(view);
            _playerView = playerView;
            _playerView.nextLevel += ShowWinScreen;
        }

        public void ShowWinScreen() => _model.ShowScore(_playerView._healthBar.value);
    }
}
