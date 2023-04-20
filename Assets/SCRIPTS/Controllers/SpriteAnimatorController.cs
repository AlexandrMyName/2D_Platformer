using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace PlatformerMVC
{
    public class SpriteAnimatorController : IDisposable
    {
        private sealed class Animation
        {
            public AnimationState track;
            public List<Sprite> sprites;
            public bool loop;
            public bool sleep;
            public float counter;
            public float speed;

            public void Update()
            {
                if(sleep) return;
                counter += Time.deltaTime * speed;

                if (loop)
                {
                    while(counter > sprites.Count)
                    {
                        counter -= sprites.Count;
                    }
                }
                else if(counter > sprites.Count)
                {
                    counter = sprites.Count;
                    sleep = true;
                }
            }

        }

        private AnimationConfig _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();


        public SpriteAnimatorController(AnimationConfig config)
        {
            _config = config;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimationState track, bool loop, float speed)
        {
            if(_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.loop = loop;
                animation.speed = speed;
                animation.sleep = false;

                if(animation.track != track)
                {
                    animation.track = track;
                    animation.sprites = _config.sequences.Find(sequence => sequence.track == track).sprites;
                    animation.counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new Animation()
                {
                    track = track,
                    loop = loop,
                    speed = speed,
                    sprites = _config.sequences.Find(sequence => sequence.track == track).sprites


                });
            }
        }
        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimations.ContainsKey(spriteRenderer))
            {
                _activeAnimations.Remove(spriteRenderer);
            }
        }
        public void Update()
        {
            foreach(var animation in _activeAnimations)
            {
                animation.Value.Update();

                if(animation.Value.counter < animation.Value.sprites.Count)
                {
                    animation.Key.sprite = animation.Value.sprites[(int)animation.Value.counter];
                }
            }
        }
        public void Dispose()
        {
            _activeAnimations.Clear();
        }

       
    }
}
