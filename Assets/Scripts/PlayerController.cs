using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    private Animator playerAmmin;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    public bool gameOver = true;
    private int doubleJump = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAmmin = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump != 0 && !gameOver)
        {
            doubleJump--;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAmmin.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound,1.0f);
            dirtParticle.Stop();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            doubleJump = 2;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstancle"))
        {
            Debug.Log("GameOver");
            gameOver = true;
            playerAmmin.SetBool("Death_b", true);
            playerAmmin.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound,1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
}
