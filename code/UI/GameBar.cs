﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.UI
{
	//Attaches html and css automatically with this attribute
	[UseTemplate]
	public class GameBar : Panel
	{
		private TimeSince timeSincePointerActivated;

		//The names of these properties MUST MATCH the names of the @ref classes in the HTML file
		//The GET AND SET IS 100% NECESSARY OTHERWISE IT WILL NOT BIND TO THE HTML CORRECTLY.
		public Label Header { get; set; }

		//This property has the same names as the @ref in the html. BUT THE CLASS NAME CAN BE DIFFERENT IN THE HTML AS THAT CAN BE CUSTOMISED IN SCSS
		public Button btn { get; set; }
		public GameBar()
		{
			
			Log.Info( "Setting Template" );

		}

		public override void Tick()
		{
			base.Tick();

			timeSincePointerActivated += Time.Delta;


			
			Header.Text = "Tanks!";
			
			if (Input.Pressed(InputButton.Flashlight) && timeSincePointerActivated > 0.2f )
			{
				TogglePointer();
			}

			
		}
		public void TogglePointer()
		{
			//Because I imported my Utilities class in my GameBar.scss, I can use the enablePointer class I set
			timeSincePointerActivated = 0f;

			if ( HasClass( "enablePointer" )) 
			{
				RemoveClass( "enablePointer" );
			}
			else
			{
				AddClass( "enablePointer" );
			}
		}
		public void DisplayAMessage()
		{
			Log.Info( "Button Worked" );
		}
		
	}
}
