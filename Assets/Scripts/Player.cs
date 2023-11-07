using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
	[SerializeField] private Transform _castPoint;

	[SerializeField] private int _maxHealth;
	[SerializeField] private Inventory _inventory;

	public event UnityAction<int, int> HealthChanged;
	public event UnityAction<int> CoinsChanged;

	public int Coins { get; private set; }

	private int _currentHealth;
	private bool _isAttack = false;
	private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_currentHealth = _maxHealth;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !_isAttack)
			Attack();
	}

	public void BuyAbility(Ability ability)
	{
		Coins -= ability.Price;
		CoinsChanged?.Invoke(Coins);
		_inventory.AddAbility(ability);
	}

	public void ApplyDamage(int damage)
	{
		_currentHealth -= damage;
		HealthChanged?.Invoke(_currentHealth, _maxHealth);
		if (_currentHealth < 0)
			Destroy(gameObject);
	}

	public void AddCoins(int coins)
	{
		Coins += coins;
		CoinsChanged?.Invoke(Coins);
	}

	private void Attack()
	{
		_animator.SetTrigger("Attack");
		StartCoroutine(AttackWithDelay());
	}

	private IEnumerator AttackWithDelay()
	{
		_isAttack = true;
		var waitForSeconds = new WaitForSeconds(0.5f);
		yield return waitForSeconds;

		_inventory.currentAbility.CastAbility(_castPoint);
		yield return waitForSeconds;

		_isAttack = false;
	}
}