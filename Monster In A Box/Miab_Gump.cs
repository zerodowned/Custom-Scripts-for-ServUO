using System;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;


namespace Server.Gumps
{
	public class Miab_Gump : Gump
	{
		public MonsterInABox_Item _Box;
		
		public enum Buttons { Name, Create, BodyValueIncrease, BodyValueSelection, BodyValueDecrease,  Hue, AiUp, AiDown, FightModeUp, FightModeDown, PageUP, PageDOWN,
		}
		
		public enum TextEntries { HueEntry, RangePerceptionEntry, RangeFightEntry, ActiveSpeedEntry, PassiveSpeedEntry, HitsEntry, StamEntry, ManaEntry, FameEntry,
			FameEntry, KarmaEntry, DamageEntry, DmgPhyEntry, DmgFireEntry, DmgColdEntry, DmgPoisonEntry, DmgEnergyEntry, ResPhyEntry, ResFireEntry, 
			ResColdEntry, ResPoisonEntry, ResEnergyEntry, VirtualArmorEntry, StrEnrtryMin, StrEnrtryMax, DexEnrtryMin, DexEnrtryMax, IntEnrtryMin, IntEnrtryMax, 
			HitsEnrtryMin, HitsEnrtryMax, StamEnrtryMin, StamEnrtryMax, ManaEnrtryMin, ManaEnrtryMax,
		}
		
		private Mobile m_From;
		
		
	
		public Miab_Gump( Mobile from, MonsterInABox_Item box ) : base( 100, 100 )
		{
			_Box = box;
			m_From = from;
			
			Closable=true; Disposable=true; Dragable=true; Resizable=false;
			
			AddPage(0);
			
			AddBackground(0, 0, 400, 540, 9200);
			AddImageTiled(14, 15, 375, 500, 3504);

			PreFabGump.AddHtmlOutlined( this, 18, 17, 234, 22, "<center><big>Boxed Mobile", "<BASEFONT COLOR= #FFFFFF><center><big>Boxed Mobile", false, false);
			
			AddImageTiled(264, 16, 124, 94, 1416);
			AddItem(276, 23, _Box.ItemValue );
			AddHtml( 264, 87,  90,  20,  "<BASEFONT COLOR= #FFFFFF>  Body Value",  false,  false);
			AddButton(359, 30, 2084, 2084, (int)Buttons.BodyValueIncrease, GumpButtonType.Reply, 0);
			AddButton(363, 55, 2118, 248, (int)Buttons.BodyValueSelection, GumpButtonType.Reply, 0);
			AddButton(359, 80, 2085, 248, (int)Buttons.BodyValueDecrease, GumpButtonType.Reply, 0);
			
			AddLabel(276, 120, 0, @"Hue");
			// as of now, max hue # is 3000. so size limit is 4
			PreFabGump.AddTextEntryPreFab( this, 2524, 308, 120, 34, 20, 0, (int)TextEntries.HueEntry, @"", 4, null); 
			
			AddButton(354, 120, 210, 210, (int)Buttons.Hue, GumpButtonType.Reply, 0);
			AddItem(341, 118, 4009); // Dyes
			
			//Name
			AddLabel(22, 50, 0, @"Name");
			PreFabGump.AddTextEntryPreFab( this, 2524, 62, 50, 125, 20, 0, (int)Buttons.Name, @"", 50, null);
			
		//Ai Type
			AddLabel(22, 75, 0, @"AI Type");
			AddButton(71, 78, 9766, 248, (int)Buttons.AiUp, GumpButtonType.Reply, 0);
			AddButton(91, 78, 9762, 248, (int)Buttons.AiDown, GumpButtonType.Reply, 0);
			AddLabel(116, 75, 0, @"mAiType");
			
		//Fight Mode
			AddLabel(22, 104, 0, @"Fight Mode");
			AddButton(92, 107, 9766, 248, (int)Buttons.FightModeUp, GumpButtonType.Reply, 0);
			AddButton(112, 107, 9762, 248, (int)Buttons.FightModeDown, GumpButtonType.Reply, 0);
			AddLabel(133, 104, 0, @"mFightMode");
			

		//RangePerception
			AddLabel(20, 150, 0, @"RangePerception");
			PreFabGump.AddTextEntryPreFab( this, 2524, 134, 149, 35, 20, 0, (int)TextEntries.RangePerceptionEntry, @"", 5, null);
		//RangeFight
			AddLabel(177, 150, 0, @"RangeFight");
			PreFabGump.AddTextEntryPreFab( this, 2524, 255, 149, 35, 20, 0, (int)TextEntries.RangeFightEntry, @"", 5, null);
		//MobileSpeed	
			AddLabel(22, 180, 0, @"Active Speed");
			PreFabGump.AddTextEntryPreFab( this, 2524, 111, 179, 35, 20, 0, (int)TextEntries.ActiveSpeedEntry, @"", 5, null);
			AddLabel(161, 180, 0, @"Passive Speed");
			PreFabGump.AddTextEntryPreFab( this, 2524, 258, 179, 35, 20, 0, (int)TextEntries.PassiveSpeedEntry, @"", 5, null);
			
			PreFabGump.AddTextEntryMinMax( this, "STR", 2524, 22, 57, 210, 0, (int)TextEntries.StrEnrtryMin, (int)TextEntries.StrEnrtryMax, _Box._Str.ToString(), 7, null);
			
			PreFabGump.AddTextEntryMinMax( this, "DEX", 2524, 22, 57, 240, 0, (int)TextEntries.DexEnrtryMin, (int)TextEntries.DexEnrtryMax, _Box._Str.ToString(), 7, null);
			
			PreFabGump.AddTextEntryMinMax( this, "INT", 2524, 22, 57, 270, 0, (int)TextEntries.IntEnrtryMin, (int)TextEntries.IntEnrtryMax, _Box._Str.ToString(), 7, null);
			
			AddLabel(200, 210, 0, @"Hits");
			PreFabGump.AddTextEntryPreFab( this, 2524, 245, 209, 52, 20, 0, (int)TextEntries.HitsEntry, @"", 7, null);
			
			AddLabel(200, 240, 0, @"Stam");
			PreFabGump.AddTextEntryPreFab( this, 2524, 245, 239, 52, 20, 0, (int)TextEntries.StamEntry, @"", 7, null);
			
			AddLabel(200, 270, 0, @"Mana");
			PreFabGump.AddTextEntryPreFab( this, 2524, 245, 269, 52, 20, 0, (int)TextEntries.ManaEntry, @"", 7, null);
			
			
			AddLabel(22, 300, 0, @"Fame");
			PreFabGump.AddTextEntryPreFab( this, 2524, 61, 299, 53, 20, 0, (int)TextEntries.FameEntry, @"", 6, null);
			AddLabel(135, 300, 0, @"Karma");
			PreFabGump.AddTextEntryPreFab( this, 2524, 182, 299, 49, 20, 0, (int)TextEntries.KarmaEntry, @"", 6, null);
			AddLabel(251, 300, 0, @"Damage");
			PreFabGump.AddTextEntryPreFab( this, 2524, 306, 299, 51, 20, 0, (int)TextEntries.DamageEntry, @"", 6, null);
			
			AddLabel(30, 330, 0, @"DAMAGE TYPE - Must equal a total of 100");
			AddLabel(22, 356, 0, @"Phy");
			PreFabGump.AddTextEntryPreFab( this, 2524, 50, 355, 23, 20, 0, (int)TextEntries.DmgPhyEntry, @"", 4, null);
			AddLabel(85, 356, 0, @"Fire");
			PreFabGump.AddTextEntryPreFab( this, 2524, 115, 355, 23, 20, 0, (int)TextEntries.DmgFireEntry, @"", 4, null);
			AddLabel(151, 356, 0, @"Cold");
			PreFabGump.AddTextEntryPreFab( this, 2524, 184, 355, 23, 20, 0, (int)TextEntries.DmgColdEntry, @"", 4, null);
			AddLabel(218, 356, 0, @"Poison");
			PreFabGump.AddTextEntryPreFab( this, 2524, 265, 355, 23, 20, 0, (int)TextEntries.DmgPoisonEntry, @"", 4, null);
			AddLabel(299, 356, 0, @"Enrgy");
			PreFabGump.AddTextEntryPreFab( this, 2524, 340, 355, 23, 20, 0, (int)TextEntries.DmgEnergyEntry, @"", 4, null);
			
			AddLabel(30, 386, 0, @"RESIST TYPE");
			AddLabel(22, 412, 0, @"Phy");
			PreFabGump.AddTextEntryPreFab( this, 2524, 50, 411, 23, 20, 0, (int)TextEntries.ResPhyEntry, @"", 4, null);
			AddLabel(85, 412, 0, @"Fire");
			PreFabGump.AddTextEntryPreFab( this, 2524, 115, 411, 23, 20, 0, (int)TextEntries.ResFireEntry, @"", 4, null);
			AddLabel(151, 412, 0, @"Cold");
			PreFabGump.AddTextEntryPreFab( this, 2524, 184, 411, 23, 20, 0, (int)TextEntries.ResColdEntry, @"", 4, null);
			AddLabel(218, 412, 0, @"Poison");
			PreFabGump.AddTextEntryPreFab( this, 2524, 265, 411, 23, 20, 0, (int)TextEntries.ResPoisonEntry, @"", 4, null);
			AddLabel(299, 412, 0, @"Enrgy");
			PreFabGump.AddTextEntryPreFab( this, 2524, 340, 411, 23, 20, 0, (int)TextEntries.ResEnergyEntry, @"", 4, null);
			
			AddLabel(22, 444, 0, @"Virtual Armor");
			PreFabGump.AddTextEntryPreFab( this, 2524, 118, 442, 50, 20, 0, (int)TextEntries.VirtualArmorEntry, @"", 4, null);
		
			AddButton(305, 466, 2252, 2252, (int)Buttons.Create, GumpButtonType.Reply, 0);
			AddButton(340, 466, 2252, 2252, (int)Buttons.Create, GumpButtonType.Reply, 0);
			AddBackground(302, 462, 84, 51, 9500);
			//AddLabel(318, 478, 0, @"Refresh");
			PreFabGump.AddHtmlOutlined( this, 309, 477, 70, 22, "<center><big>Refresh", "<BASEFONT COLOR= #FFFFFF><center><big>Refresh", false, false);
			
			AddLabel(62, 484, 0, @"Page");
			AddButton(24, 484, 9910, 248, (int)Buttons.PageUP, GumpButtonType.Reply, 0);
			AddButton(114, 484, 9904, 248, (int)Buttons.PageDOWN, GumpButtonType.Reply, 0);
		}
		
		public void ResendGump()
		{
			if (m_From.HasGump(typeof(Miab_Gump)) ) {
				m_From.CloseGump( typeof( Miab_Gump ) ); 
			}
			m_From.SendGump( new Miab_Gump( m_From, _Box ) );
		}
		
		public override void OnResponse( NetState sender, RelayInfo info )
        	{
        		Mobile from = sender.Mobile;
            		PlayerMobile player = (PlayerMobile)from;
			
			if ( info.ButtonID == (int)Buttons.BodyValueIncrease ) {
				_Box.ValueIndex++;
				ResendGump();
			}
			if ( info.ButtonID == (int)Buttons.AiUp ) {
				 _Box._AI++;
				 ResendGump();
			}
			if ( info.ButtonID == (int)Buttons.Create ) {
				TextRelay nameRelay = info.GetTextEntry( (int)Buttons.Name );
				string name = nameRelay.Text.Trim();
				
				if( ResPhyEntry + ResFireEntry + ResColdEntry + ResPoisonEntry + ResEnergyEntry != 100) {
					from.SendMessage("Resistance amounts must total 100!");
				}
				//CreateMobile( player, name );
			}
			
		}
		
		
		public void CreateMobile( Mobile from, string name )
		{
			//Mobile miab = new MonsterInABox_Mobile( name, 1, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 );
			//miab.MoveToWorld( new Point3D( from.X , from.Y , from.Z ), from.Map );
		}

	}
}
