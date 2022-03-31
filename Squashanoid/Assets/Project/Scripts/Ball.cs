using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Racket racket;
    [SerializeField] float xLaunchVelocity = 2f;
    [SerializeField] float yLaunchVelocity = 10f;
    [SerializeField] float randomFactor = 0.2f;

    [SerializeField] AudioClip[] ballSounds;

    bool hasStarted = false;

    AudioSource ballAudioSource;
    Rigidbody2D myRigidbody2D;

    private void Awake()
    {
        ballAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted) {
            LockRacketToBall();
            LaunchBallOnMouseClick();
        }
    }

    private void LockRacketToBall()
    {
        Vector3 racketPosition = racket.transform.position;
        float yOffset = 0.5f;
        transform.position = new Vector2(racketPosition.x, racketPosition.y + yOffset);
    }

    private void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButton(0)) {
            myRigidbody2D.velocity = new Vector2(xLaunchVelocity, yLaunchVelocity);
            hasStarted = true;
        }
    }

    #region Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted) {
            PlayCollisionSFX();
            ApplyRandomForce();
        }
    }

    private void PlayCollisionSFX()
    {
        int clipIndex = Random.Range(0, ballSounds.Length);
        AudioClip clip = ballSounds[clipIndex];
        ballAudioSource.PlayOneShot(clip);
    }

    private void ApplyRandomForce()
    {
        var randomForceX = Random.Range(-randomFactor, randomFactor);
        var randomForceY = Random.Range(-randomFactor, randomFactor);
        myRigidbody2D.velocity += new Vector2(randomForceX, randomForceY);
    }
    #endregion
}
