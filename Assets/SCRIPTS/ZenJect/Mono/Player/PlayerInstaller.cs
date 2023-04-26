using PlatformerMVC;
using UnityEngine;
using Zenject;

namespace PlatformerMVC
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        public override void InstallBindings()
        {
            var _confAnimathionPlayer = Resources.Load<AnimationConfig>("SpriteAnimatorCfg");
            Container.Bind<AnimationConfig>().WithId("Player_Configs"). FromInstance(_confAnimathionPlayer);
            Container.Bind<SpriteAnimatorController>().WithId("Player_Configs").FromNew().AsTransient().WithArguments(_confAnimathionPlayer);
            Container.Bind<PlayerController>().WithId("Player_Configs").FromNew().AsCached().WithArguments(_playerView, new ContactPooler(_playerView._collider2D));
            Container.Bind<CannonController>().WithId("Player_Configs").FromNew().AsCached().WithArguments(_cannonView._muzzleTransform,_playerView._transform);
           


        }
    }
}