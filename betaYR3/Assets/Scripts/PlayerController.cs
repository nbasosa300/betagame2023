using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private int counter;
    public Text cointext;
    public AudioSource asource;
    public AudioClip aclip;
    // public Text cointext;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        counter = 0;
        cointext.text = "COINS: " + counter;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-Vector3.right * speed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-Vector3.forward * speed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            counter = counter + 1;
            cointext.text = "COINS: " + counter;
            asource.PlayOneShot(aclip);

        }
        if (counter == 5)
        {
            SceneManager.LoadScene("gameover");
        }

    }
}
