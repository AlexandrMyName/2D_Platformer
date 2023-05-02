using UnityEngine;

namespace PlatformerMVC
{
    public class BulletView : LevelObjectView
    {
        private int damagePoint = 10;

        public int DamagePoint { get => damagePoint; set => damagePoint = value; }
    }
}
