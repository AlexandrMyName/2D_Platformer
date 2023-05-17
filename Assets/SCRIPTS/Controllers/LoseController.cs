using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class LoseController : IDisposable
    {
        private InteractiveObjView _playerView;   
        private LoseModel _model;
        private LoseView _view;

        public LoseView View { get { return _view; } }

        public LoseController(InteractiveObjView _playerView, LoseView view){
            this._playerView = _playerView;
           
            _model = new LoseModel();
            _view = view;
            _playerView.death += ShowLoseScreen;
        }
        public void Dispose() => _playerView.death -= ShowLoseScreen;
        private void ShowLoseScreen() => _model.UpdateCount(_view);      
    }
}
