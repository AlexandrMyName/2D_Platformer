using PlatformerMVC;
using UnityEngine;
using Zenject;

namespace PlatformerMVC
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] InteractiveObjView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private CameraView _cameraView;
        [SerializeField] private LoseView _loseView;
        [SerializeField] private MobileController _mobileController;

        [SerializeField] private YandexSDK SDK;
        public override void InstallBindings()
        {
            var _confAnimathionPlayer = Resources.Load<AnimationConfig>("SpriteAnimatorCfg");

           
            Container.Bind<SpriteAnimatorController>().WithId("Player_Configs").FromNew().AsTransient().WithArguments(_confAnimathionPlayer);
            Container.Bind<PlayerController>().WithId("Player_Configs").FromNew().AsCached().WithArguments(_playerView, new ContactPooler(_playerView._collider2D));
            Container.Bind<CannonController>().WithId("Player_Configs").FromNew().AsCached().WithArguments(_cannonView,_playerView._transform);
            Container.Bind<CameraController>().WithId("CameraId").FromNew().AsCached().WithArguments(_cameraView);
            Container.Bind<LoseController>().WithId("LoseId").FromNew().AsCached().WithArguments(_playerView,_loseView);

            Container.Bind<YandexSDK>().FromInstance(SDK).AsCached();
            Container.Bind<MobileController>().FromInstance(_mobileController).AsCached();
        }
    }
}