using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _explosionVfx;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
            var exp = Instantiate(_explosionVfx, transform.position, transform.rotation);

            Destroy(exp, 1f);
            Debug.Log("destroy ");
        }

        Destroy(gameObject);
    }
}

