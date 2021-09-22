using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform _playerSpawn;
    private Animator _fadeSystem;
    
    private void Awake()
    {
        _playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        _fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }
    
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        _fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = _playerSpawn.position;
    }
}
