using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float TopPosition { get; private set; }
    public float BottomPosition { get; private set; }
    public float RightPosition { get; private set; }
    public float LeftPosition { get; private set; }
    
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Start()
    {
        TopPosition = _camera.ViewportToWorldPoint(new Vector3 (0.5f, 1, _camera.nearClipPlane)).y;
        RightPosition = _camera.ViewportToWorldPoint(new Vector3(1, 0.5f, _camera.nearClipPlane)).x;
        BottomPosition = -TopPosition;
        LeftPosition = -RightPosition;
    }
}
