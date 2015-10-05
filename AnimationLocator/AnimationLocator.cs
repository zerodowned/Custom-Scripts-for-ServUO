/*

	Original script by Father Time / vermillion2083.
	Link to original: http:www.runuo.com/community/threads/father-times-animation-locator-1-0.78156/


	I edited this script to easily test individual frames of animations. 
	Also made a few changes to make it a little more user friendly.

	- Gump doesn't resend with every loop of animation in cycle setting
	- Added stop animation button
	- Changed buttons to larger ones for easier use
	- Added tiledimage behind the text entry
	- Set limit for animation and frame number, animations can go higher but they just start looping 
	- Added freeze frame section 
	- Switched buttons to enums
	- Housekeeping on the original gump, doesn't effect use but made editing easier

	Edits by zerodowned of Runuo / Playuo / Servuo

*/
/* 
	**************************************
	 feel free to do what ever you choose	
	 with this script. Please just make 	
	 sure to leave this header in place.	
						
	 Made by: Father Time			
	 e-mail: FatherTime@TheHyperCube.net	
	 Server: The HyperCube 2		
	 ICQ: 146563794			
	 MSN: vermillion2083@hotmail.com	
	**************************************	
	
	Animate(int action, int frameCount, int repeatCount, bool forward, bool repeat, int delay) 
*/

using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class AnimationLocator : Item
	{
		public const int Max = 50;
		
		private int m_AnimationNumber;
		public bool m_Active = false;
		private Mobile m_TargetMobile;
		
		private int mFrameNumber;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int AnimationNumber
		{
			get{ return m_AnimationNumber; }
			set{ 
				m_AnimationNumber = value; 
				if( m_AnimationNumber < 0 ) { m_AnimationNumber = 0; }
				if( m_AnimationNumber > Max ) { m_AnimationNumber = Max; }
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int FrameNumber
		{
			get{ return mFrameNumber; }
			set{ 
				mFrameNumber = value; 
				if( mFrameNumber < 0 ) { mFrameNumber = 0; }
				if( mFrameNumber > Max ) { mFrameNumber = Max; }
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool Active{ get{ return m_Active; } set{ m_Active = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile TargetMobile{ get{ return m_TargetMobile; } set{ m_TargetMobile = value; InvalidateProperties(); } }

		[Constructable]
		public AnimationLocator() : base( 0x14F0 )
		{
			Weight = 5.0;
			Name = "Animation locator";
			LootType = LootType.Blessed;
		}

		public AnimationLocator( Serial serial ) : base( serial ){}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			
			writer.Write((int)m_AnimationNumber);
			writer.Write( (bool)m_Active );
			writer.Write((Mobile) m_TargetMobile );
			writer.Write((int)mFrameNumber);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_AnimationNumber = (int)reader.ReadInt();
			m_Active = (bool)reader.ReadBool();
			m_TargetMobile = (Mobile)reader.ReadMobile();
			mFrameNumber = (int)reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( from.AccessLevel < AccessLevel.GameMaster ) {
				from.SendMessage("You cannot use that.");
				return;
			}
			else {
				m_TargetMobile = from;
				from.CloseGump( typeof( AnimationLocatorGump ) );
				from.SendGump( new AnimationLocatorGump( this ) );
			}
		}

		public void StartLoop( Mobile from )
		{
			if( m_AnimationNumber >= Max ) {
				m_TargetMobile.Emote("Max Animation Reached" );
				m_TargetMobile.Emote("Animation locator stopped");
				Active = false;
			}
			if( Active == false ) { return; }
			
			m_AnimationNumber += 1;
			m_TargetMobile.Emote("Animation  " + m_AnimationNumber.ToString() + " " );
			m_TargetMobile.Animate( m_AnimationNumber, mFrameNumber, 1, true, false, 0 );
			
			Timer.DelayCall(TimeSpan.FromSeconds(2.0), AnimationLoopCheck, from); 
		}
		
		public virtual void AnimationLoopCheck( Mobile m )
		{
			if( m_Active == true ) { StartLoop( m ); }
			else{ return; }
		}

		public void Use( Mobile from )
		{		
			from.Target = new ToAnimateTarget( from, this );
		}

		public class ToAnimateTarget : Target
        {
			AnimationLocator m_AnimationLocator;

            public ToAnimateTarget( Mobile from, AnimationLocator AnimationLocator ) : base( 10, false, TargetFlags.None )
            { m_AnimationLocator = AnimationLocator; }

            protected override void OnTarget( Mobile from, object target )
			{
				if ( target is Mobile ) {
					Mobile mob = (Mobile)target;
					m_AnimationLocator.TargetMobile = mob;
					
					from.CloseGump( typeof( AnimationLocatorGump ) );
					from.SendGump( new AnimationLocatorGump( m_AnimationLocator ) );
				}
				else { from.SendMessage("Only mobiles may be animated."); }
			}
		}					
	}

	public class AnimationLocatorGump : Gump
	{
		AnimationLocator m_AnimationLocator;

		public AnimationLocatorGump( AnimationLocator AnimationLocator ) : base( 0, 0 )
		{
			m_AnimationLocator = AnimationLocator;

			Closable=true; Disposable=true; Dragable=true; Resizable=false;
			
			AddPage(0);
			
			AddBackground(32, 49, 241, 395, 3500);
			
			AddLabel(100, 63, 0, @"Animation Locator");
			AddImageTiled(63, 191, 171, 5, 3007);
			
			AddBackground(104, 92, 101, 67, 3500);
			AddImageTiled(133, 115, 42, 20, 9384);
			AddTextEntry(133, 115, 42, 20, 0, (int)Button.AnimationNumberEntry, m_AnimationLocator.AnimationNumber.ToString(), 2);
			AddLabel(97, 151, 0, @"Current Animation");
			
			AddLabel(76, 173, 0, @"Target:");
			AddLabel(137, 173, 0, m_AnimationLocator.TargetMobile.RawName.ToString() );
			AddButton(58, 176, 30008, 30008, (int)Button.TargetMobile, GumpButtonType.Reply, 0);
			AddImageTiled(63, 82, 171, 5, 3007);
			
			
			AddLabel(90, 205, 0, @"Increase");
			AddButton(72, 206, 30008, 30008, (int)Button.IncreaseAnimation, GumpButtonType.Reply, 0);
			AddLabel(90, 228, 0, @"Decrease");
			AddButton(72, 232, 30008, 30008, (int)Button.DecreaseAnimation, GumpButtonType.Reply, 0);
			AddLabel(193, 205, 0, @"Cycle");
			AddButton(175, 206, 11400, 11400, (int)Button.CycleAnimation, GumpButtonType.Reply, 0);
			AddLabel(193, 228, 0, @"Single");
			AddButton(175, 232, 11400, 11400, (int)Button.SingleAnimation, GumpButtonType.Reply, 0);
			
			AddLabel(76, 255, 0, @"Stop Animation");
			AddButton(58, 258, 11410, 11410, (int)Button.StopAnimation, GumpButtonType.Reply, 0);
			
			AddImageTiled(63, 274, 171, 5, 3007);
			AddLabel(101, 286, 0, @"Freeze Frame");
			
			AddLabel(57, 314, 0, @"Animation");
			AddImageTiled(130, 314, 52, 21, 9384);
			AddTextEntry(131, 313, 48, 20, 0, (int)Button.FreezeAnimationNumberEntry, m_AnimationLocator.AnimationNumber.ToString(), 2);
			AddButton(186, 310, 2435, 2435, (int)Button.IncreaseAnimation, GumpButtonType.Reply, 0);
			AddButton(186, 325, 2437, 2437, (int)Button.DecreaseAnimation, GumpButtonType.Reply, 0);
			
			AddLabel(76, 344, 0, @"Frame");
			AddImageTiled(130, 344, 52, 21, 9384);
			AddTextEntry(131, 343, 48, 20, 0, (int)Button.FrameNumberEntry, m_AnimationLocator.FrameNumber.ToString(), 2);
			AddButton(186, 341, 2435, 2435, (int)Button.FrameIncrease, GumpButtonType.Reply, 0);
			AddButton(186, 356, 2437, 2437, (int)Button.FrameDecrease, GumpButtonType.Reply, 0);
			
			AddLabel(64, 379, 0, @"Send freeze to targeted mobile");
			AddButton(47, 383, 30008, 30008, (int)Button.FreezeFrame, GumpButtonType.Reply, 0);
			
			AddButton(215, 326, 11300, 11300, (int)Button.Update, GumpButtonType.Reply, 0);
			AddBackground(209, 323, 49, 25, 9500);
			AddLabel(214, 326, 0, @"Update");

		}
		
		public void ResendGump( Mobile from )
		{
			if (from.HasGump(typeof(AnimationLocatorGump)) ) {
				from.CloseGump( typeof( AnimationLocatorGump ) ); 
			}
			from.SendGump( new AnimationLocatorGump( m_AnimationLocator ) );
		}
		
		public enum Button { AnimationNumberEntry, FreezeAnimationNumberEntry, TargetMobile, DecreaseAnimation, IncreaseAnimation, CycleAnimation, SingleAnimation, StopAnimation, FrameNumberEntry, FreezeFrame, FrameIncrease, FrameDecrease, Update }

		public override void OnResponse( NetState sender, RelayInfo info )
		{
        	Mobile from = sender.Mobile;
			PlayerMobile pm = (PlayerMobile)from;

			if( m_AnimationLocator.Deleted )
			return;
			
			if ( info.ButtonID == (int)Button.IncreaseAnimation ) {
				m_AnimationLocator.AnimationNumber += 1;
				
				ResendGump( pm );
			}

			if ( info.ButtonID == (int)Button.DecreaseAnimation ) {
				m_AnimationLocator.AnimationNumber -= 1;
				
				ResendGump( pm );
			}

			if ( info.ButtonID == (int)Button.CycleAnimation )
			{
				TextRelay tr_AnimationNumber = info.GetTextEntry( (int)Button.AnimationNumberEntry );
				if(tr_AnimationNumber != null)
				{
					int i_MaxAmount = 0;
					try { i_MaxAmount = Convert.ToInt32(tr_AnimationNumber.Text,10); } 
					catch { pm.SendMessage(1161, "Only use numbers that are two digits or less."); }

					m_AnimationLocator.AnimationNumber = i_MaxAmount;
				}


				if( m_AnimationLocator.Active == false ) {
					m_AnimationLocator.Active = true;
					m_AnimationLocator.TargetMobile.Emote(" Animation locator started ");
					m_AnimationLocator.StartLoop( pm );
					
				}

				else {
					m_AnimationLocator.TargetMobile.Emote(" Animation locator stopped ");
					m_AnimationLocator.Active = false;
				}

				ResendGump( pm );
			}

			if ( info.ButtonID == (int)Button.SingleAnimation ) {
				TextRelay tr_AnimationNumber = info.GetTextEntry( 1 );
				int PlayAnim = 0;
				
				if(tr_AnimationNumber != null) {
					try { PlayAnim = Convert.ToInt32(tr_AnimationNumber.Text,10); } 
					catch {
						pm.SendMessage(1161, "Only use numbers that are two digits or less.");
						return;
					}
				}
				
				m_AnimationLocator.TargetMobile.Animate( PlayAnim, 0, 1, true, false, 0 );

				ResendGump( pm );
			}
			
			if ( info.ButtonID == (int)Button.TargetMobile ) {
				pm.SendMessage("Please target the mobile you wish to animate.");
				m_AnimationLocator.Use( pm );

				ResendGump( pm );
			}
			
			if ( info.ButtonID == (int)Button.FreezeFrame ) {
				TextRelay AnimationEntry = info.GetTextEntry( (int)Button.FreezeAnimationNumberEntry );
				TextRelay FrameEntry = info.GetTextEntry( (int)Button.FrameNumberEntry );
				
				int AnimEnt = 0;
				int FramEnt = 0;
				
				if(AnimationEntry != null) {
					try { AnimEnt = Convert.ToInt32(AnimationEntry.Text,10);
					} 
					catch { 
						pm.SendMessage(1161, "Only use numbers that are two digits or less.");
						return;
					}
				}
				
				if(FrameEntry != null) {
					try { FramEnt = Convert.ToInt32(FrameEntry.Text,10);
					} 
					catch { 
						pm.SendMessage(1161, "Only use numbers that are two digits or less.");
						return;
					}
				}
				
				ResendGump( pm );
				
				m_AnimationLocator.TargetMobile.Animate( AnimEnt, FramEnt, 1, true, false, 255 );
			}
			if ( info.ButtonID == (int)Button.StopAnimation ) {
				m_AnimationLocator.Active = false;
				m_AnimationLocator.TargetMobile.Emote(" Animation locator stopped ");
				ResendGump( pm );
			}
			if ( info.ButtonID == (int)Button.FrameIncrease ) {
				m_AnimationLocator.FrameNumber += 1;
				
				ResendGump( pm );
			}
			if ( info.ButtonID == (int)Button.FrameDecrease ) {
				m_AnimationLocator.FrameNumber -= 1;
				
				ResendGump( pm );
			}
			if ( info.ButtonID == (int)Button.Update ) {
			
				TextRelay AnimationEntry = info.GetTextEntry( (int)Button.FreezeAnimationNumberEntry );
				TextRelay FrameEntry = info.GetTextEntry( (int)Button.FrameNumberEntry );
				
				int AnimEnt = 0;
				int FramEnt = 0;
				
				if(AnimationEntry != null) {
					try { AnimEnt = Convert.ToInt32(AnimationEntry.Text,10);
					} 
					catch { 
						pm.SendMessage(1161, "Only use numbers that are two digits or less.");
						return;
					}
				}
				
				if(FrameEntry != null) {
					try { FramEnt = Convert.ToInt32(FrameEntry.Text,10);
					} 
					catch { 
						pm.SendMessage(1161, "Only use numbers that are two digits or less.");
						return;
					}
				}
				
				m_AnimationLocator.AnimationNumber = AnimEnt;
				m_AnimationLocator.FrameNumber = FramEnt;
				ResendGump( pm );
			}
		}
	}
}