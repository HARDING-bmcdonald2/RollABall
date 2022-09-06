using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public int totalPickups = 8;
    public TextMeshProUGUI timerText;

    private float startTime;
    private bool finished = false;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        SetCountText();

        winTextObject.SetActive(false);
        if (startTime <= 0)
        {
            startTime = 30;
        }
    }

    private void Update()
    {
        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        if (startTime >= 60)
        {
            timerText.text = minutes + ":" + seconds;
        }
        else
        {
            timerText.text = seconds;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count;

        if (count == totalPickups)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
