using UnityEngine;

namespace Managers
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        public GameObject Instantiate(GameObject go, Vector3 vec)
        {
            return Object.Instantiate(go, vec, Quaternion.identity);
        }
        
        public GameObject Instantiate(GameObject go, Transform parent)
        {
            return Object.Instantiate(go, parent);
        }

        public void Destroy(GameObject go, float delay = 0.0f)
        {
            Object.Destroy(go, delay);
        }
    }
}