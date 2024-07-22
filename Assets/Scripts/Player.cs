using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float SetBound = 1f;
    private UnityEngine.Vector2 minBound;
    private UnityEngine.Vector2 maxBound;
    private Shooter shooter;

    void Start()
    {
        InitBound();
        shooter = GetComponent<Shooter>();
    }

    void Update()
    {
        Movement();
        HandleFiring();
    }

    void InitBound()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new UnityEngine.Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new UnityEngine.Vector2(1, 1));
    }

    void Movement()
    {
        UnityEngine.Vector3 axis = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            axis.x = Mathf.Clamp(axis.x - Speed * Time.deltaTime, minBound.x + SetBound, maxBound.x - SetBound);
            transform.position = axis;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            axis.x = Mathf.Clamp(axis.x + Speed * Time.deltaTime, minBound.x + SetBound, maxBound.x - SetBound);
            transform.position = axis;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            axis.y = Mathf.Clamp(axis.y + Speed * Time.deltaTime, minBound.y + SetBound, maxBound.y - SetBound);
            transform.position = axis;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            axis.y = Mathf.Clamp(axis.y - Speed * Time.deltaTime, minBound.y + SetBound, maxBound.y - SetBound);
            transform.position = axis;
        }
    }

    void HandleFiring()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shooter.isFiring = true;
        }
        else
        {
            shooter.isFiring = false;
        }
    }
}
