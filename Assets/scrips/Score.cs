using UnityEngine;

public class Score : MonoBehaviour
{

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "score")
        {
            GameManager.Instance.IncreaseScore();
        }
    }
}
