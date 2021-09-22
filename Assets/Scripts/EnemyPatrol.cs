using System;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    private Transform _target;
    private int _destPoint = 0;
    void Start() 
    {
        _target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, _target.position) < 0.3f)
        {
            _destPoint = (_destPoint + 1) % waypoints.Length;
            _target = waypoints[_destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth.Instance.TakeDamage(damageOnCollision);
        }
    }
}