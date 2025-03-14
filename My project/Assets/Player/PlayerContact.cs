using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class PlayerContact : MonoBehaviour
{

    public Image ItemImage;

    public PlayerAudioController audioController;

    bool CanWinLevel = false;

    public string NextLevel = "Level 1";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Player pegou o item");
            Destroy(collision.gameObject);
            ItemImage.color = Color.white;
            CanWinLevel = true;
            audioController.PlayGetItem();
        }

        if (collision.gameObject.CompareTag("FinalPoint"))
        {
            if (CanWinLevel)
            {
                SceneManager.LoadScene(NextLevel);
            }
            else
            {
                Debug.Log("Player Não Chocou o Ovo");
            }
        }
    }

}
