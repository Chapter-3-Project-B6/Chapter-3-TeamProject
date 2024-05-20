using UnityEngine;
using UnityEngine.SceneManagement;

internal class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int characterNum;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this. gameObject);
             
        }
    }
}