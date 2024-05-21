using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public Transform Player { get; private set; }
    //public BulletObjectPool ObjectPool { get; private set; }

    public ObjectPool ObjectPool { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ObjectPool = GetComponent<ObjectPool>();

    }
}
