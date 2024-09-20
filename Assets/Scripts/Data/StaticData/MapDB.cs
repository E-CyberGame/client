using System.Collections.Generic;

namespace Data
{
    public class MapDB
    {
        private Dictionary<MapType, MapData> _data;

        public MapDB(Dictionary<MapType, MapData> data)
        {
            _data = data;
        }

        public MapData GetData(MapType key)
        {
            return _data[key];
        }

        public MapData GetData(int key)
        {
            return _data[(MapType)key];
        }

        public int Count()
        {
            return _data.Count;
        }
    }
}