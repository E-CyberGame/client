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
        public Sprite SlotImage;
        public Animator Animator;
        
        public CharacterData(CharacterType characterType)
        {
            CharacterType = characterType;
            CardImage = Resources.Load<Sprite>("Arts/Character/card_" + CharacterType.ToString());
            SlotImage = Resources.Load<Sprite>("Arts/Character/slot_" + CharacterType.ToString());
            //Animator = animator;
        }
    }

    public class MapData
    {
        public MapType SceneType;
        public Sprite CardImage;
        //최초 맵 입장 시 플레이어 스폰 위치
        public Dictionary<TeamType, List<Vector3>> PlayerPosition;
        public GameObject BossPrefab;

        public MapData(MapType sceneType, Dictionary<TeamType, List<Vector3>> playerPosition)
        {
            SceneType = sceneType;
            CardImage = Resources.Load<Sprite>("Arts/Map/card_" + sceneType.ToString().ToLower());
            BossPrefab = Resources.Load<GameObject>("Prefabs/Boss/Boss_"+sceneType.ToString());
            PlayerPosition = playerPosition;
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
            {MapType.Cyber, new MapData(MapType.Cyber, new Dictionary<TeamType, List<Vector3>>()
            {
                { TeamType.RedTeam, new List<Vector3> { new Vector3(-1f, 2f, 0), new Vector3(-1f, 2f, 0) } },
                { TeamType.BlueTeam, new List<Vector3> { new Vector3(1f, 2f, 0), new Vector3(1f, 2f, 0) } }
            })},
            {MapType.Subway, new MapData(MapType.Subway, new Dictionary<TeamType, List<Vector3>>()
            {
                { TeamType.RedTeam, new List<Vector3> { new Vector3(-5f, 0f, 0f), new Vector3(-5f, 0f, 0f) } },
                { TeamType.BlueTeam, new List<Vector3> { new Vector3(5f, 0f, 0f), new Vector3(5f, 0f, 0f) } }
            })}
        });
    }
}