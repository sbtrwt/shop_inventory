using System;
using UnityEngine;

namespace ShopInventory.Sound
{
    [CreateAssetMenu(fileName = "New Sound SO", menuName = "Sound")]
    public class SoundSO : ScriptableObject
    {
        public Sounds[] audioList;
    }

    [Serializable]
    public struct Sounds
    {
        public SoundType soundType;
        public AudioClip audio;
    }
}