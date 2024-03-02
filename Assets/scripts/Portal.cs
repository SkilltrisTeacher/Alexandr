using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    [SerializeField] private string playerLayer = "Player";
    [SerializeField] private string nextLevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask .NameToLayer(playerLayer))
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
