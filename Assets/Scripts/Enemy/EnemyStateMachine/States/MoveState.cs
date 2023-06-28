using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _moveSpeed;
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _moveSpeed * Time.deltaTime);
    }
}
