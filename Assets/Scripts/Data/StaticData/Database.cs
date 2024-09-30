using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public enum CharacterType
    {
        Worker,
        Youtuber,
    }

    public enum MapType
    {
        Subway,
        Cyber,
    }

    public class CharacterData
    {
        public CharacterType CharacterType;
        public Sprite CardImage;
        public Animator Animator;
        
        public CharacterData(CharacterType characterType)
        {
            CharacterType = characterType;
            CardImage = Resources.Load<Sprite>("Arts/Character/card_" + CharacterType.ToString().ToLower());
            //Animator = animator;
        }
    }

    public class MapData
    {
        public MapType SceneType;
        public Sprite CardImage;
        public MapData(MapType sceneType)
        {
            SceneType = sceneType;
            CardImage = Resources.Load<Sprite>("Arts/Map/card_" + sceneType.ToString().ToLower());
        }
    }

    [Serializable]
    public class PVPData
    {
        public MapType SceneType;
        public bool Decay;
        public bool Crystal;
        
        public PVPData() {}
        public PVPData(MapType sceneType, bool decay, bool crystal)
        {
            SceneType = sceneType;
            Decay = decay;
            Crystal = crystal;
        }
    }
    
    public static class Database
    {
        public static readonly CharacterDB CharacterData = new CharacterDB(new Dictionary<CharacterType, CharacterData>()
        {
            {CharacterType.Worker, new CharacterData(CharacterType.Worker)},
            {CharacterType.Youtuber, new CharacterData(CharacterType.Youtuber)}
        });
        public static readonly MapDB MapData = new MapDB(new Dictionary<MapType, MapData>()
        {
            {MapType.Cyber, new MapData(MapType.Cyber)},
            {MapType.Subway, new MapData(MapType.Subway)}
        });
    }
}