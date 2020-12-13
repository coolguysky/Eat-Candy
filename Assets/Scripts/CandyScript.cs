using UnityEngine;

public class CandyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncrementScore();
            Destroy(gameObject);
        } 
        else if(collider.gameObject.CompareTag("Boundary"))
        {
            GameManager.instance.DecrementLives();
            Destroy(gameObject);
        }
    }
}
