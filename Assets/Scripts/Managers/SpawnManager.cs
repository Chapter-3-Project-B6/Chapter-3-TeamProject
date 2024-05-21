using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public Transform Player { get; private set; }
    public BulletObjectPool ObjectPool { get; private set; }

    public EnemyObjectPool EnemyObjectPool { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        ObjectPool = GetComponent<BulletObjectPool>();
        EnemyObjectPool = GetComponent<EnemyObjectPool>();
    }
}
