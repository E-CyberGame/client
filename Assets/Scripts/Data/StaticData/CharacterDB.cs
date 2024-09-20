using System.Collections.Generic;

namespace Data
{
    public class CharacterDB
    {
        private Dictionary<CharacterType, CharacterData> _data;
        
        public CharacterDB(Dictionary<CharacterType, CharacterData> data)
        {
            _data = data;
        }

        public CharacterData GetData(CharacterType key)
        {
            return _data[key];
        }
        
        public CharacterData GetData(int key)
        {
            return _data[(CharacterType)key];
        }
        
        public int Count()
        {
            return _data.Count;
        }
    }
}