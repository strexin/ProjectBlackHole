using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishBarrier : MonoBehaviour
{
    [SerializeField] private float nextCameraPosX;
    [SerializeField] private float nextCameraPosY;

    [SerializeField] private float nextLevelPos;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.transform.position.x > nextLevelPos)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            /*gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Camera.main.transform.position = new Vector3(nextCameraPosX, nextCameraPosY, -10.0f);*/
        }
        
    }
}
