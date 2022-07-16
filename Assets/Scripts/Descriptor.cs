using UnityEngine;

public class Descriptor : MonoBehaviour
{
    public string Name = "";
    public string Author = "";
    public string Description = "";
    public bool leftHand = false;
    public bool customColours = false;

    public bool gunEnabled = false;
    public bool audioMode;
    public AudioClip shootSound;
    public float bulletSpeed;
    public float bulletCooldown;
    public GameObject bulletObject;

    public bool vibra;
    public float strenth = 0.25f;
    public float sTime = 0.5f;

    public float bulletMultiply;
}
