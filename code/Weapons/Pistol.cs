﻿using Sandbox;


[Library( "dm_pistol", Title = "Pistol" )]
[Hammer.EditorModel( "weapons/rust_pistol/rust_pistol.vmdl" )]
partial class Pistol : BaseTGWeapon
{
	public override string ViewModelPath => "weapons/rust_pistol/v_rust_pistol.vmdl";

	public override float PrimaryRate => 15.0f;
	public override float SecondaryRate => 1.0f;
	public override float ReloadTime => 3.0f;

	public override int Bucket => 1;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "weapons/rust_pistol/rust_pistol.vmdl" );
		AmmoClip = 12;
					//	ragdoll.SetModel( "models/citizen/citizen.vmdl" );
			//	ragdoll.Position = EyePosition + EyeRotation.Forward * 40;
			//	ragdoll.Rotation = Rotation.LookAt( Vector3.Random.Normal );
			//	ragdoll.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
			//	ragdoll.PhysicsGroup.Velocity = EyeRotation.Forward * 1000;
	}

	public override bool CanPrimaryAttack()
	{
		return base.CanPrimaryAttack() && Input.Pressed( InputButton.Attack1 );
	}

	public override void AttackPrimary()
	{
		TimeSincePrimaryAttack = 0;
		TimeSinceSecondaryAttack = 0;

		if ( !TakeAmmo( 1 ) )
		{
			DryFire();
			return;
		}


		//
		// Tell the clients to play the shoot effects
		//
		ShootEffects();
		PlaySound( "rust_pistol.shoot" );

		//
		// Shoot the bullets
		//
		ShootBullet( 0.2f, 1.5f, 9.0f, 3.0f );

	}
}
