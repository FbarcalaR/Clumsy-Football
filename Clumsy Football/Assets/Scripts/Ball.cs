using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource soundEffect;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        soundEffect.Play();
    }
}
