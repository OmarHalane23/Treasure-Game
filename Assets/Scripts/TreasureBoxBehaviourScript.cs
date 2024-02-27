using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TreasureBoxBehaviourScript : MonoBehaviour
{
    CharacterController controller;
    Vector3 movePos;
    float speed = 3;
    public TMP_Text scoreText; //for the TMP text
    public TMP_Text statusText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        movePos.x = Input.GetAxis("Horizontal") * speed;
        movePos.z = Input.GetAxis("Vertical") * speed;
        controller.Move(movePos);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jem"))
        {
            score++; // Increment score when a gem is collected
            UpdateScoreText(); // Update score text
            statusText.text = "WIN: Jem in the Treasure Box"; // Update status text
        }
        else
        {
            statusText.text = "Clutter collected"; // Update status text for clutter
        }
        Destroy(collision.gameObject);
    }
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); // Update score text
        }
    }
}
