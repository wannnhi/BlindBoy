using UnityEngine;


public class LaserControl : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 1.5f; 
    public Transform sprite; 

    void Update()
    {
  
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        Vector3 direction = (mousePosition - player.position).normalized;

        try
        {
            sprite.position = player.position + direction * distanceFromPlayer;
        }
        catch (System.Exception)
        {
            Debug.Log("±è¿¬È£ º´½Å");
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sprite.rotation = Quaternion.Euler(0, 0, angle);
    }
}


