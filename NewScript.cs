// Ignore Spelling: Melee

using Godot;
using System;

public class NewScript : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

public class Player
{
	public Weapon Weapon;
}

public class Weapon
{
	public string Name;
	public float Damage;
	public Module[] ModuleSlots;

	public void EquipModule(Module Mod, int slot)
	{
		if (slot < 0 || slot >= ModuleSlots.Length)
			return;
		Module oldMod = ModuleSlots[slot];
		if (oldMod != null)
			oldMod.OnModuleUnSlotted(this);
		ModuleSlots[slot] = Mod;
		Mod.OnModuleSlotted();
	}
}

public class Gun : Weapon
{
	public float FireRate;
	public float ProjectileVelocity;

	public Projectile Fire() 
	{
		Projectile P = new Projectile();
		for (int i = 0; i < ModuleSlots.Length; i++)
		{
			Module Mod = ModuleSlots[i];
			if (Mod != null) 
			{
				Mod.OnModuleUsed(P);
			}
		}
	}
}

public class Melee : Weapon
{

}

public class Projectile
{
	public float speed;
	public float damage;
	
	
}

public class Module
{
	public string Name;
	public virtual void OnModuleSlotted(Weapon W);
	public virtual void OnModuleUnSlotted(Weapon W);
	public virtual void OnModuleUsed(Projectile P);
}

public class Status
{
	public string Name;
}
