using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishBarrier : MonoBehaviour
{
    [SerializeField] private float nextCameraPosX;
    [SerializeField] private float nextCameraPosY;

    [SerializeField] private float nextLevelPos;

    [SerializeField] private PlayerControl player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Next level border
        if (collision.gameObject.CompareTag("Player") && player.isAlive)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            /*gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Camera.main.transform.position = new Vector3(nextCameraPosX, nextCameraPosY, -10.0f);*/
        }
        
    }
}
