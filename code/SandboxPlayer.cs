using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox { 
	partial class SandboxPlayer : Player
	{
		private TimeSince timeSinceDropped;
		private TimeSince timeSinceJumpReleased;
	
		private DamageInfo lastDamage;
	
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );
	
			//Because it inherits these controllers and animators you can just call Controller rather than this.controller
			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
	
	
	
			if ( DevController is NoclipController )
			{
				DevController = null;
			}
	
			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
	
	
			CameraMode = new FirstPersonCamera();


			base.Respawn();
		}
		public override void Simulate( Client cl )
		{
			// Because I create an instance of sandbox player after inheriting from Player I have to call base.similate

			//Within this base class simulate, (player in this case) there is a Lifecheck to see if the pawn is alive, if not they will be respawned after 3 seconds
			base.Simulate( cl );

			if ( IsServer && Input.Pressed( InputButton.Attack1 ) )
			{

				var p = new ModelEntity();
				p.SetModel( "weapons/rust_pistol/rust_pistol.vmdl" );
				p.Position = EyePosition + EyeRotation.Forward * 40;
				p.Rotation = Rotation.LookAt( Vector3.Random.Normal );
				p.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
				p.PhysicsGroup.Velocity = EyeRotation.Forward * 1000;

			}

			// The Input.Pressed (InputButton class is linked to the bindings set in the menu, the .View field is linked to the C key in the bindings
			if ( IsServer && Input.Pressed( InputButton.View ))
			{
				if (CameraMode.GetType() == typeof( FirstPersonCamera ) )
				{
					
					CameraMode = new ThirdPersonCamera();
				}
				else
				{
					CameraMode = new FirstPersonCamera();
				}
				Log.Info("Camera mode GetType() is: " + CameraMode.GetType() );
				Log.Info( "Camera mode TypeOf() is: " + typeof(FirstPersonCamera));
			}

		}
	}
}
