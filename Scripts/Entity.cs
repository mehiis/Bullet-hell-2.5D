using Godot;
using System;

public partial class Entity : CharacterBody3D
{
	[Export] protected int maxHealth = 100;
	[Export] private int currentHealth;

	public override void _Ready()
	{
		base._Ready();
		RestoreMaxHealth();
	}

	protected virtual void RestoreMaxHealth()
	{
		currentHealth = maxHealth;
	}

	protected virtual void Heal(int healAmount)
	{
		int healthTemp = currentHealth;
		healthTemp += healAmount;
		healthTemp = Math.Clamp(healthTemp, 0, maxHealth);

		GD.Print($"{this.Name} healed +{healAmount}! HP: {healthTemp}/{maxHealth}");

		currentHealth = healthTemp;
	}

	protected virtual void TakeDamage(int damageAmount)
	{
		int healthTemp = currentHealth;
		healthTemp -= damageAmount;
		healthTemp = Math.Clamp(healthTemp, 0, maxHealth);

		GD.Print($"{this.Name} took damage -{damageAmount}! HP: {healthTemp}/{maxHealth}");

		if (healthTemp <= 0)
		{
			Die();
			return;
		}

		currentHealth = healthTemp;
	}

	protected virtual void Die()
	{
		GD.Print($"{this.Name} died/destroyed.");
	}

}
