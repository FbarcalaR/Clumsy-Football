using UnityEngine;

public class GoalController : MonoBehaviour
{
    public ParticleSystem goalEffect;
    public AudioSource goalSound;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var ball = collision.gameObject.tag == "Ball";

        if(ball)
        {
            goalSound.Play();
            var effectPosition = transform.position;
            effectPosition.z += -1;
            Instantiate(goalEffect, effectPosition, Quaternion.identity);

            var player1Scored = collision.otherCollider.tag == "Player2Goal";
            FindObjectOfType<GameController>().AddPlayerScore(player1Scored);
        }

    }
}
