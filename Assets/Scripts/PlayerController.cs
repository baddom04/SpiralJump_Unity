using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector3 jumpForce = Vector3.up * 5;
    private bool hasCollide = false;
    private Rigidbody rb;
    public Text levelText;
    public Text bestLevelText;
    private static int level = 1;
    private static int bestLevel = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateTexts();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!hasCollide)
        {
            if(other.gameObject.tag == "badPlatform"){
                level = 1;
                UpdateTexts();
                SceneManager.LoadScene("SampleScene");
            }
            if(other.gameObject.name == "platform_full"){
                level++;
                UpdateTexts();
                SceneManager.LoadScene("SampleScene");
            }
            hasCollide = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(jumpForce, ForceMode.Impulse);
            StartCoroutine(Reset());
        }
    }
    IEnumerator Reset(){
        yield return new WaitForSeconds(0.1f);
        hasCollide = false;
    }

    private void UpdateTexts(){
        if(bestLevel < level) bestLevel = level;
        levelText.text = "Level: " + level;
        bestLevelText.text = "Best Level: " + bestLevel;
    }
}
