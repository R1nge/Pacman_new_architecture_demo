using System;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class SoundService : MonoBehaviour
    {
        [SerializeField] private AudioSource pacmanEatingSound;
        [SerializeField] private AudioSource music;

        public void Play(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.None:
                    break;
                case SoundType.PacmanEating:
                    if (!pacmanEatingSound.isPlaying)
                    {
                        pacmanEatingSound.Play();
                        Debug.Log("Play pacman eating sound");
                    }


                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null);
            }
        }

        public void PlayMusic()
        {
            music.Play();
        }

        public enum SoundType : byte
        {
            None = 0,
            PacmanEating = 1
        }
    }
}