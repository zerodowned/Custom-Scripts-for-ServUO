/*
Original script by Djeryv: Spell toolbars. Link: http://www.runuo.com/community/threads/spell-toolbars.522805/

I have edited his original script to add Spellweaving and Mysticism, and then pack all 7 magic types into a single item/gump. Allowing players to have a "mixed bar" of spells.

In order to make this gump function correctly I used haazen's gump format ( found here: http://www.runuo.com/community/threads/calling-gumps.88093/ )
The normal gump format will revert back to Page 0 if you press a button on say Page 1. Whereas haazen's format will call the gump page that each button is coded to call.
*/
/*
 Tresdni Tresdni:
XmlAttach.AttachTo(newChar, new XmlYourAttachment());
zerodowned zerodowned:
awesome ty :)
Tresdni Tresdni:
attach like this in charactercreation before welcome timer
Tresdni Tresdni:
exactly
Tresdni Tresdni:
yep
zerodowned zerodowned:
and checking an int in it? youratt.intname ?
Tresdni Tresdni:
and it gets it's own set of properties on it's own attachment
Tresdni Tresdni:
you can attach it to the mobile on charactercreation
Tresdni Tresdni:
and boom, your attachment stores anything you want, like an item would
Tresdni Tresdni:
then check if youratt is null
Tresdni Tresdni:
XmlYourAttachment youratt = (XmlYourAttachment)XmlAttach.FindAttachment(pm, typeof(XmlYourAttachment));




*/



using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Spells;
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Spells.Eighth;
using Server.Spells.Necromancy;
using Server.Spells.Chivalry;
using Server.Spells.Bushido;
using Server.Spells.Ninjitsu;
using Server.Spells.Spellweaving;
using Server.Spells.Mystic;
using System.Xml;
using Server.Engines.XmlSpawner2;

namespace Server.Gumps
{
    public class SpellBarGump : Gump
    {
       
		 public static bool HasSpell( Mobile from, int spellID )
        {
            Spellbook book = Spellbook.Find( from, spellID );
            return ( book != null && book.HasSpell( spellID ) );
        }
       
        Mobile caller;
        public int m_Page;
		public int page = 0;
		
	
		 
		 public SpellBarScroll m_Scroll;
		 
		
		
       
   

        public SpellBarGump( Mobile from, int page, SpellBarScroll scroll ) : base( 0 , 0  )
        {
            m_Scroll = scroll;
			
   
			int mW00_ClumsySpell = m_Scroll.W00_ClumsySpell;
            int mW01_CreateFoodSpell = m_Scroll.W01_CreateFoodSpell;
            int mW02_FeeblemindSpell = m_Scroll.W02_FeeblemindSpell;
            int mW03_HealSpell = m_Scroll.W03_HealSpell;
            int mW04_MagicArrowSpell = m_Scroll.W04_MagicArrowSpell;
            int mW05_NightSightSpell = m_Scroll.W05_NightSightSpell;
            int mW06_ReactiveArmorSpell = m_Scroll.W06_ReactiveArmorSpell;
            int mW07_WeakenSpell = m_Scroll.W07_WeakenSpell;
            int mW08_AgilitySpell = m_Scroll.W08_AgilitySpell;
            int mW09_CunningSpell = m_Scroll.W09_CunningSpell;
            int mW10_CureSpell = m_Scroll.W10_CureSpell;
            int mW11_HarmSpell = m_Scroll.W11_HarmSpell;
            int mW12_MagicTrapSpell = m_Scroll.W12_MagicTrapSpell;
            int mW13_RemoveTrapSpell = m_Scroll.W13_RemoveTrapSpell;
            int mW14_ProtectionSpell = m_Scroll.W14_ProtectionSpell;
            int mW15_StrengthSpell = m_Scroll.W15_StrengthSpell;
            int mW16_BlessSpell = m_Scroll.W16_BlessSpell;
            int mW17_FireballSpell = m_Scroll.W17_FireballSpell;
            int mW18_MagicLockSpell = m_Scroll.W18_MagicLockSpell;
            int mW19_PoisonSpell = m_Scroll.W19_PoisonSpell;
            int mW20_TelekinesisSpell = m_Scroll.W20_TelekinesisSpell;
            int mW21_TeleportSpell = m_Scroll.W21_TeleportSpell;
            int mW22_UnlockSpell = m_Scroll.W22_UnlockSpell;
            int mW23_WallOfStoneSpell = m_Scroll.W23_WallOfStoneSpell;
            int mW24_ArchCureSpell = m_Scroll.W24_ArchCureSpell;
            int mW25_ArchProtectionSpell = m_Scroll.W25_ArchProtectionSpell;
            int mW26_CurseSpell = m_Scroll.W26_CurseSpell;
            int mW27_FireFieldSpell = m_Scroll.W27_FireFieldSpell;
            int mW28_GreaterHealSpell = m_Scroll.W28_GreaterHealSpell;
            int mW29_LightningSpell = m_Scroll.W29_LightningSpell;
            int mW30_ManaDrainSpell = m_Scroll.W30_ManaDrainSpell;
            int mW31_RecallSpell = m_Scroll.W31_RecallSpell;
            int mW32_BladeSpiritsSpell = m_Scroll.W32_BladeSpiritsSpell;
            int mW33_DispelFieldSpell = m_Scroll.W33_DispelFieldSpell;
            int mW34_IncognitoSpell = m_Scroll.W34_IncognitoSpell;
            int mW35_MagicReflectSpell = m_Scroll.W35_MagicReflectSpell;
            int mW36_MindBlastSpell = m_Scroll.W36_MindBlastSpell;
            int mW37_ParalyzeSpell = m_Scroll.W37_ParalyzeSpell;
            int mW38_PoisonFieldSpell = m_Scroll.W38_PoisonFieldSpell;
            int mW39_SummonCreatureSpell = m_Scroll.W39_SummonCreatureSpell;
            int mW40_DispelSpell = m_Scroll.W40_DispelSpell;
            int mW41_EnergyBoltSpell = m_Scroll.W41_EnergyBoltSpell;
            int mW42_ExplosionSpell = m_Scroll.W42_ExplosionSpell;
            int mW43_InvisibilitySpell = m_Scroll.W43_InvisibilitySpell;
            int mW44_MarkSpell = m_Scroll.W44_MarkSpell;
            int mW45_MassCurseSpell = m_Scroll.W45_MassCurseSpell;
            int mW46_ParalyzeFieldSpell = m_Scroll.W46_ParalyzeFieldSpell;
            int mW47_RevealSpell = m_Scroll.W47_RevealSpell;
            int mW48_ChainLightningSpell = m_Scroll.W48_ChainLightningSpell;
            int mW49_EnergyFieldSpell = m_Scroll.W49_EnergyFieldSpell;
            int mW50_FlameStrikeSpell = m_Scroll.W50_FlameStrikeSpell;
            int mW51_GateTravelSpell = m_Scroll.W51_GateTravelSpell;
            int mW52_ManaVampireSpell = m_Scroll.W52_ManaVampireSpell;
            int mW53_MassDispelSpell = m_Scroll.W53_MassDispelSpell;
            int mW54_MeteorSwarmSpell = m_Scroll.W54_MeteorSwarmSpell;
            int mW55_PolymorphSpell = m_Scroll.W55_PolymorphSpell;
            int mW56_EarthquakeSpell = m_Scroll.W56_EarthquakeSpell;
            int mW57_EnergyVortexSpell = m_Scroll.W57_EnergyVortexSpell;
            int mW58_ResurrectionSpell = m_Scroll.W58_ResurrectionSpell;
            int mW59_AirElementalSpell = m_Scroll.W59_AirElementalSpell;
            int mW60_SummonDaemonSpell = m_Scroll.W60_SummonDaemonSpell;
            int mW61_EarthElementalSpell = m_Scroll.W61_EarthElementalSpell;
            int mW62_FireElementalSpell = m_Scroll.W62_FireElementalSpell;
            int mW63_WaterElementalSpell = m_Scroll.W63_WaterElementalSpell;

/// NECROMANCY
            int mN01AnimateDeadSpell = m_Scroll.N01AnimateDeadSpell;
            int mN02BloodOathSpell = m_Scroll.N02BloodOathSpell;
            int mN03CorpseSkinSpell = m_Scroll.N03CorpseSkinSpell;
            int mN04CurseWeaponSpell = m_Scroll.N04CurseWeaponSpell;
            int mN05EvilOmenSpell = m_Scroll.N05EvilOmenSpell;
            int mN06HorrificBeastSpell = m_Scroll.N06HorrificBeastSpell;
            int mN07LichFormSpell = m_Scroll.N07LichFormSpell;
            int mN08MindRotSpell = m_Scroll.N08MindRotSpell;
            int mN09PainSpikeSpell = m_Scroll.N09PainSpikeSpell;
            int mN10PoisonStrikeSpell = m_Scroll.N10PoisonStrikeSpell;
            int mN11StrangleSpell = m_Scroll.N11StrangleSpell;
            int mN12SummonFamiliarSpell = m_Scroll.N12SummonFamiliarSpell;
            int mN13VampiricEmbraceSpell = m_Scroll.N13VampiricEmbraceSpell;
            int mN14VengefulSpiritSpell = m_Scroll.N14VengefulSpiritSpell;
            int mN15WitherSpell = m_Scroll.N15WitherSpell;
            int mN16WraithFormSpell = m_Scroll.N16WraithFormSpell;
            int mN17ExorcismSpell = m_Scroll.N17ExorcismSpell;

    // CHIVALRY
            int mC01CleanseByFireSpell = m_Scroll.C01CleanseByFireSpell;
            int mC02CloseWoundsSpell = m_Scroll.C02CloseWoundsSpell;
            int mC03ConsecrateWeaponSpell = m_Scroll.C03ConsecrateWeaponSpell;
            int mC04DispelEvilSpell = m_Scroll.C04DispelEvilSpell;
            int mC05DivineFurySpell = m_Scroll.C05DivineFurySpell;
            int mC06EnemyOfOneSpell = m_Scroll.C06EnemyOfOneSpell;
            int mC07HolyLightSpell = m_Scroll.C07HolyLightSpell;
            int mC08NobleSacrificeSpell = m_Scroll.C08NobleSacrificeSpell;
            int mC09RemoveCurseSpell = m_Scroll.C09RemoveCurseSpell;
            int mC10SacredJourneySpell = m_Scroll.C10SacredJourneySpell;

// BUSHIDO
			int mB01Confidence = m_Scroll.B01Confidence;
			int mB02CounterAttack = m_Scroll.B02CounterAttack;
			int mB03Evasion = m_Scroll.B03Evasion;
			int mB04LightningStrike = m_Scroll.B04LightningStrike;
			int mB05MomentumStrike = m_Scroll.B05MomentumStrike;
			int mB06HonorableExecution = m_Scroll.B06HonorableExecution;

// NINJITSU
            int mI01DeathStrike = m_Scroll.I01DeathStrike;
            int mI02AnimalForm = m_Scroll.I02AnimalForm;
            int mI03KiAttack = m_Scroll.I03KiAttack;
            int mI04SurpriseAttack = m_Scroll.I04SurpriseAttack;
            int mI05Backstab = m_Scroll.I05Backstab;
			//
            int mI06Shadowjump = m_Scroll.I06Shadowjump; //changed to 06
            int mI07MirrorImage = m_Scroll.I07MirrorImage; // to 07
			int mI08FocusAttack = m_Scroll.I08FocusAttack; // to 08

// SPELLWEAVING
            int mS01ArcaneCircleSpell = m_Scroll.S01ArcaneCircleSpell;
            int mS02GiftOfRenewalSpell = m_Scroll.S02GiftOfRenewalSpell;
            int mS03ImmolatingWeaponSpell = m_Scroll.S03ImmolatingWeaponSpell;
            int mS04AttuneWeaponSpell = m_Scroll.S04AttuneWeaponSpell;
            int mS05ThunderstormSpell = m_Scroll.S05ThunderstormSpell;
            int mS06NatureFurySpell = m_Scroll.S06NatureFurySpell;
            int mS07SummonFeySpell = m_Scroll.S07SummonFeySpell;
            int mS08SummonFiendSpell = m_Scroll.S08SummonFiendSpell;
            int mS09ReaperFormSpell = m_Scroll.S09ReaperFormSpell;
            int mS10WildfireSpell = m_Scroll.S10WildfireSpell;
            int mS11EssenceOfWindSpell = m_Scroll.S11EssenceOfWindSpell;
            int mS12DryadAllureSpell = m_Scroll.S12DryadAllureSpell;
            int mS13EtherealVoyageSpell = m_Scroll.S13EtherealVoyageSpell;
            int mS14WordOfDeathSpell = m_Scroll.S14WordOfDeathSpell;
            int mS15GiftOfLifeSpell = m_Scroll.S15GiftOfLifeSpell;
            int mS16ArcaneEmpowermentSpell = m_Scroll.S16ArcaneEmpowermentSpell;

// MYSTICISM
			int mM01NetherBoltSpell = m_Scroll.M01NetherBoltSpell;
			int mM02HealingStoneSpell = m_Scroll.M02HealingStoneSpell;
			int mM03PurgeMagicSpell = m_Scroll.M03PurgeMagicSpell;
			int mM04EnchantSpell = m_Scroll.M04EnchantSpell;
			int mM05SleepSpell = m_Scroll.M05SleepSpell;
			int mM06EagleStrikeSpell = m_Scroll.M06EagleStrikeSpell;
			int mM07AnimatedWeaponSpell = m_Scroll.M07AnimatedWeaponSpell;
			int mM08SpellTriggerSpell = m_Scroll.M08SpellTriggerSpell;
			int mM09MassSleepSpell = m_Scroll.M09MassSleepSpell;
			int mM10CleansingWindsSpell = m_Scroll.M10CleansingWindsSpell;
			int mM11BombardSpell = m_Scroll.M11BombardSpell;
			int mM12SpellPlagueSpell = m_Scroll.M12SpellPlagueSpell;
			int mM13HailStormSpell = m_Scroll.M13HailStormSpell;
			int mM14NetherCycloneSpell = m_Scroll.M14NetherCycloneSpell;
			int mM15RisingColossusSpell = m_Scroll.M15RisingColossusSpell;
			int mM16StoneFormSpell = m_Scroll.M16StoneFormSpell;
			
			int mSwitch = m_Scroll.Switch;
			int mCount = m_Scroll.Count;
			int mXselect_10 = m_Scroll.Xselect_10;
			int mXselect_15 = m_Scroll.Xselect_15;
			int mXselect_20 = m_Scroll.Xselect_20;
			int mXselect_30 = m_Scroll.Xselect_30;
			
		//	 
			
			int mYselect_1 = m_Scroll.Yselect_1;
			int mYselect_2 = m_Scroll.Yselect_2;
			int mYselect_3 = m_Scroll.Yselect_3;
			int mYselect_4 = m_Scroll.Yselect_4;
			
			
			int mOpen = m_Scroll.Open;
			
			
			int yselect_var = 0; 
			int xselect_num = 0;
			//int open = 0;
			
			if ( m_Scroll.Xselect_10 == 1) { xselect_num = 10; } 
			if ( m_Scroll.Xselect_15 == 1) { xselect_num = 15; } 
			if ( m_Scroll.Xselect_20 == 1) { xselect_num = 20; } 
			if ( m_Scroll.Xselect_30 == 1) { xselect_num = 30; }
			if ( m_Scroll.Yselect_1 == 1) { yselect_var = 1; }
			if ( m_Scroll.Yselect_2 == 1) { yselect_var = 2; }
			if ( m_Scroll.Yselect_3 == 1) { yselect_var = 3; }
			if ( m_Scroll.Yselect_4 == 1) { yselect_var = 4; }
			

            m_Page = page;
            caller = from;
            this.Closable=true;
            this.Disposable=false;
            this.Dragable=true;
            this.Resizable=false;
           
            from.CloseGump(typeof(SpellBarGump));
			
			
			
            AddPage(0);
           
            
            AddBackground(0, 0, 165, 500, 9200);
            AddImageTiled(10, 10, 145, 480, 2624);
            AddAlphaRegion(10, 10, 145, 480);

//////////////		 
		Spellbook book = Spellbook.FindRegular(from);
		if (book != null)
		{
            AddButton(12, 20, 4005, 4006, (int)Buttons.Button1, GumpButtonType.Reply, 0);//magery
			AddLabel(50, 20, 1153, @"Magery");
		}
		if (book == null)
		{
			AddImage(12, 20, 4018 );//magery
		  //AddHtml(50, 200, 155, 20, @"<basefont color=#0000FF>TextGoesHere</basefont>", (bool)false, (bool)false); 
			AddLabel(50, 20, 33, @"Magery");
		}
//////////////		
		Spellbook necrobook = Spellbook.FindNecromancer(from);
		if (necrobook != null)
		{
			AddButton(12, 50, 4005, 4006, (int)Buttons.Button2, GumpButtonType.Reply, 0);//necro
			AddLabel(50, 50, 1153, @"Necromancy");
		}
		if (necrobook == null)
		{
			AddImage(12, 50, 4018 );
			AddLabel(50, 50, 33, @"Necromancy");
		}
///////////		
		Spellbook chivbook = Spellbook.FindPaladin(from);
		if (chivbook != null)
		{
            AddButton(12, 80, 4005, 4006, (int)Buttons.Button3, GumpButtonType.Reply, 0);//chiv
			AddLabel(50, 80, 1153, @"Chivalry");
		}
		if (chivbook == null)
		{
			AddImage(12, 80, 4018 );
			AddLabel( 50, 80, 33, @"Chivalry");
		}
////////////////
		Spellbook bushidobook = Spellbook.FindSamurai(from);
		if (bushidobook != null)
		{
            AddButton(12, 110, 4005, 4006, (int)Buttons.Button4, GumpButtonType.Reply, 0);//bushido
			 AddLabel(50, 110, 1153, @"Bushido");
		}
		if (bushidobook == null)
		{
			AddImage(12, 110, 4018 );
			AddLabel( 50, 110, 33, @"Bushido");
		}
///////////////////////
		Spellbook ninbook = Spellbook.FindNinja(from);
		if (ninbook != null)
		{
            AddButton(12, 140, 4005, 4006, (int)Buttons.Button5, GumpButtonType.Reply, 0);//nin
			AddLabel(50, 140, 1153, @"Ninjitsu");
		}
		if (ninbook == null)
		{
			AddImage(12, 140, 4018 );
			AddLabel( 50, 140, 33, @"Ninjitsu");
		}
/////////////////
		Spellbook spellweaverbook = Spellbook.FindArcanist(from);
		if (spellweaverbook != null)
		{
            AddButton(12, 170, 4005, 4006, (int)Buttons.Button6, GumpButtonType.Reply, 0);//weave
			AddLabel(50, 170, 1153, @"Spellweaving");
		}
		if (spellweaverbook == null)
		{
			AddImage(12, 170, 4018 );
			AddLabel( 50, 170, 33, @"Spellweaving");
		}
/////////////
        Spellbook mystbook = Spellbook.FindMystic(from);
		if (mystbook != null)
		{
            AddButton(12, 200, 4005, 4006, (int)Buttons.Button7, GumpButtonType.Reply, 0);//myst
			AddLabel(50, 200, 1153, @"Mysticism");
		}
		if (mystbook == null)
		{
			AddImage(12, 200, 4018 );
			AddLabel( 50, 200, 33, @"Mysticism" );
			
		}
//////////////

            
/// end magic selection

			AddButton(12, 230, 4011, 4012, (int)Buttons.Button148, GumpButtonType.Reply, 0); // options
            AddLabel(50, 230, 93, @"Options Menu");
   
            AddButton(15, 275, 2152, 2152, (int)Buttons.Button8, GumpButtonType.Reply, 1); // TOOLBAR
            AddLabel(50, 278, 52, @"Open Toolbar");
			
			AddButton(16, 420, 2033, 2032, (int)Buttons.Button146, GumpButtonType.Reply, 1); // help
			
            AddButton( 19, 450, 2453, 2454, (int)Buttons.Button0, GumpButtonType.Reply, 1); // Cancel
           
		    AddLabel( 25, 336, 1153, "You have selected" );
			AddLabel( 35, 356, 1153, String.Format("{0} of {1} spells", mCount, xselect_num * yselect_var ) );
			
			

		
/////////////////////////////////////
/// each case represents a "page"///
////////////////////////////////////		   
            switch (page)
            {
				case 1: /// magery
                    {
						AddBackground(170, 0, 570, 500, 9200);
						AddImageTiled(180, 10, 550, 480, 2624);
						AddAlphaRegion(180, 10, 550, 480);
					
						if ( HasSpell( from, 0 ) ) { AddLabel(205, 13, 1153, @"Clumsy"); }
						else if ( !HasSpell( from, 0 ) ) { AddLabel(205, 13, 33, @"Clumsy"); }
						
						if ( HasSpell( from, 1 ) ) { AddLabel(205, 43, 1153, @"Create Food");}
						else if ( !HasSpell( from, 1 ) ) { AddLabel(205, 43, 33, @"Create Food"); }
						
						if ( HasSpell( from, 2 ) ) {  AddLabel(205, 73, 1153, @"Feeblemind"); }
						else if ( !HasSpell( from, 2 ) ) { AddLabel(205, 73, 33, @"Feeblemind"); }
						
						if ( HasSpell( from, 3 ) ) { AddLabel(205, 103, 1153, @"Heal"); }
						else if ( !HasSpell( from, 3 ) ) { AddLabel(205, 103, 33, @"Heal"); }
					
                        if ( HasSpell( from, 4) ) { AddLabel(205, 133, 1153, @"Magic Arrow"); }
						else if ( !HasSpell( from, 4 ) ) { AddLabel(205, 133, 33, @"Magic Arrow"); }
						 
                        if ( HasSpell( from, 5) ) {AddLabel(205, 163, 1153, @"Night Sight");}
						else if ( !HasSpell( from, 5 ) ) {AddLabel(205, 163, 33, @"Night Sight");}
						
                        if (HasSpell(from, 6)) { AddLabel(205, 193, 1153, @"Reactive Armor"); }
                        else if (!HasSpell(from, 6)) { AddLabel(205, 193, 33, @"Reactive Armor"); }

                        if (HasSpell(from, 7)) { AddLabel(205, 223, 1153, @"Weaken"); }
                        else if (!HasSpell(from, 7)) { AddLabel(205, 223, 33, @"Weaken"); }
                  ////////////////
                        if (HasSpell(from, 8)) { AddLabel(205, 253, 1153, @"Agility"); }
						else if (!HasSpell(from, 8)) { AddLabel(205, 253, 33, @"Agility"); }
						
                        if (HasSpell(from, 9)) { AddLabel(205, 283, 1153, @"Cunning"); }
						else if (!HasSpell(from, 9)) { AddLabel(205, 283, 33, @"Cunning"); }
						
                        if (HasSpell(from, 10)) { AddLabel(205, 313, 1153, @"Cure"); }
						else if (!HasSpell(from, 10)) { AddLabel(205, 313, 33, @"Cure"); } 
						
                        if (HasSpell(from, 11)) { AddLabel(205, 343, 1153, @"Harm"); }
						else if (!HasSpell(from, 11)) { AddLabel(205, 343, 33, @"Harm"); }
						
                        if (HasSpell(from, 12)) { AddLabel(205, 373, 1153, @"Magic Trap"); }
						else if (!HasSpell(from, 12)) { AddLabel(205, 373, 33, @"Magic Trap"); }
						
                        if (HasSpell(from, 13)) { AddLabel(205, 403, 1153, @"Remove Trap"); }
						else if (!HasSpell(from, 13)) { AddLabel(205, 403, 33, @"Remove Trap"); }
						
                        if (HasSpell(from, 14)) { AddLabel(205, 434, 1153, @"Protection"); }
						else if (!HasSpell(from, 14)) { AddLabel(205, 434, 33, @"Protection"); }
						
                        if (HasSpell(from, 15)) { AddLabel(205, 463, 1153, @"Strength"); }
						else if (!HasSpell(from, 15)) { AddLabel(205, 463, 33, @"Strength"); }
						
            /// row 2
                        if (HasSpell(from, 16)) { AddLabel(336, 13, 1153, @"Bless"); }
						else if (!HasSpell(from, 16)) { AddLabel(336, 13, 33, @"Bless"); }
						
                        if (HasSpell(from, 17)) { AddLabel(336, 43, 1153, @"Fireball"); }
						else if (!HasSpell(from, 17)) { AddLabel(336, 43, 33, @"Fireball"); }
						
                        if (HasSpell(from, 18)) { AddLabel(336, 73, 1153, @"Magic Lock"); }
						else if (!HasSpell(from, 18)){ AddLabel(336, 73, 33, @"Magic Lock"); }
						
                        if (HasSpell(from, 19)) { AddLabel(336, 103, 1153, @"Poison"); }
						else if (!HasSpell(from, 19)){ AddLabel(336, 103, 33, @"Poison"); }
						
                        if (HasSpell(from, 20)) { AddLabel(336, 133, 1153, @"Telekinesis"); }
						else if (!HasSpell(from, 20)){ AddLabel(336, 133, 33, @"Telekinesis"); }
						
                        if (HasSpell(from, 21)) { AddLabel(336, 163, 1153, @"Teleport"); }
						else if (!HasSpell(from, 21)){ AddLabel(336, 163, 33, @"Teleport"); }
						
                        if (HasSpell(from, 22)) { AddLabel(336, 193, 1153, @"Unlock"); }
						else if (!HasSpell(from, 22)){ AddLabel(336, 193, 33, @"Unlock"); }
						
                        if (HasSpell(from, 23)) { AddLabel(336, 223, 1153, @"Wall of Stone"); }
						else if (!HasSpell(from, 23)){ AddLabel(336, 223, 33, @"Wall of Stone"); }
						
                        if (HasSpell(from, 24)) { AddLabel(336, 253, 1153, @"Arch Cure"); }
						else if (!HasSpell(from, 24)){ AddLabel(336, 253, 33, @"Arch Cure"); }
						
                        if (HasSpell(from, 25)) { AddLabel(336, 283, 1153, @"Arch Protect"); }
						else if (!HasSpell(from, 25)){ AddLabel(336, 283, 33, @"Arch Protect"); }
						
                        if (HasSpell(from, 26)) { AddLabel(336, 313, 1153, @"Curse"); }
						else if (!HasSpell(from, 26)){ AddLabel(336, 313, 33, @"Curse"); }
						
                        if (HasSpell(from, 27)) { AddLabel(336, 343, 1153, @"Fire Field"); }
						else if (!HasSpell(from, 27)){ AddLabel(336, 343, 33, @"Fire Field"); }
						
                        if (HasSpell(from, 28)) { AddLabel(336, 373, 1153, @"Greater Heal"); }
						else if (!HasSpell(from, 28)){ AddLabel(336, 373, 33, @"Greater Heal"); }
						
                        if (HasSpell(from, 29)) { AddLabel(336, 403, 1153, @"Lightning"); }
						else if (!HasSpell(from, 29)){ AddLabel(336, 403, 33, @"Lightning"); }
						
                        if (HasSpell(from, 30)) { AddLabel(336, 434, 1153, @"Mana Drain"); }
						else if (!HasSpell(from, 30)){ AddLabel(336, 434, 33, @"Mana Drain"); }
						
                        if (HasSpell(from, 31)) { AddLabel(336, 463, 1153, @"Recall"); }
						else if (!HasSpell(from, 31)){ AddLabel(336, 463, 33, @"Recall"); }
						
            ///row 3//////////////////////////////////////////////
                        if (HasSpell(from, 32)) { AddLabel(465, 13, 1153, @"Blade Spirit"); }
						else if (!HasSpell(from, 32)){ AddLabel(465, 13, 33, @"Blade Spirit"); }
						
                        if (HasSpell(from, 33)) { AddLabel(465, 43, 1153, @"Dispel Field"); }
						else if (!HasSpell(from, 33)){ AddLabel(465, 43, 33, @"Dispel Field"); }
						
                        if (HasSpell(from, 34)) { AddLabel(465, 73, 1153, @"Incognito"); }
						else if (!HasSpell(from, 34)){ AddLabel(465, 73, 33, @"Incognito"); }
						
                        if (HasSpell(from, 35)) { AddLabel(465, 103, 1153, @"Magic Reflection"); }
						else if (!HasSpell(from, 35)){ AddLabel(465, 103, 33, @"Magic Reflection"); }
						
                        if (HasSpell(from, 36)) { AddLabel(465, 133, 1153, @"Mind Blast"); }
						else if (!HasSpell(from, 36)){ AddLabel(465, 133, 33, @"Mind Blast"); }
						
                        if (HasSpell(from, 37)) { AddLabel(465, 163, 1153, @"Paralyze"); }
						else if (!HasSpell(from, 37)){ AddLabel(465, 163, 33, @"Paralyze"); }
						
                        if (HasSpell(from, 38)) { AddLabel(465, 193, 1153, @"Poison Field"); }
						else if (!HasSpell(from, 38)){ AddLabel(465, 193, 33, @"Poison Field"); }
						
                        if (HasSpell(from, 39)) { AddLabel(465, 223, 1153, @"Summ. Creature"); }
						else if (!HasSpell(from, 39)){ AddLabel(465, 223, 33, @"Summ. Creature"); }
						
                        if (HasSpell(from, 40)) { AddLabel(465, 253, 1153, @"Dispel"); }
						else if (!HasSpell(from, 40)){ AddLabel(465, 253, 33, @"Dispel"); }
						
                        if (HasSpell(from, 41)) { AddLabel(465, 283, 1153, @"Energy Bolt"); }
						else if (!HasSpell(from, 41)){ AddLabel(465, 283, 33, @"Energy Bolt"); }
						
                        if (HasSpell(from, 42)) { AddLabel(465, 313, 1153, @"Explosion"); }
						else if (!HasSpell(from, 42)){ AddLabel(465, 313, 33, @"Explosion"); }
						
                        if (HasSpell(from, 43)) { AddLabel(465, 343, 1153, @"Invisibility"); }
						else if (!HasSpell(from, 43)){ AddLabel(465, 343, 33, @"Invisibility"); }
						
                        if (HasSpell(from, 44)) { AddLabel(465, 373, 1153, @"Mark"); }
						else if (!HasSpell(from, 44)){ AddLabel(465, 373, 33, @"Mark"); }
						
                        if (HasSpell(from, 45)) { AddLabel(465, 403, 1153, @"Mass Curse"); }
						else if (!HasSpell(from, 45)){ AddLabel(465, 403, 33, @"Mass Curse"); }
						
                        if (HasSpell(from, 46)) { AddLabel(465, 434, 1153, @"Paralyze Field"); }
						else if (!HasSpell(from, 46)){ AddLabel(465, 434, 33, @"Paralyze Field"); }
						
                        if (HasSpell(from, 47)) { AddLabel(465, 463, 1153, @"Reveal"); }
						else if (!HasSpell(from, 47)){ AddLabel(465, 463, 33, @"Reveal"); }
						
            ///row 4
                        if (HasSpell(from, 48)) { AddLabel(597, 12, 1153, @"Chain Lightning"); }
						else if (!HasSpell(from, 48)){ AddLabel(597, 12, 33, @"Chain Lightning"); }
						
                        if (HasSpell(from, 49)) { AddLabel(597, 42, 1153, @"Energy Field"); }
						else if (!HasSpell(from, 49)){ AddLabel(597, 42, 33, @"Energy Field"); }
						
                        if (HasSpell(from, 50)) { AddLabel(597, 72, 1153, @"Flame Strike"); }
						else if (!HasSpell(from, 50)){ AddLabel(597, 72, 33, @"Flame Strike"); }
						
                        if (HasSpell(from, 51)) { AddLabel(597, 102, 1153, @"Gate Travel"); }
						else if (!HasSpell(from, 51)){ AddLabel(597, 102, 33, @"Gate Travel"); }
						
                        if (HasSpell(from, 52)) { AddLabel(597, 132, 1153, @"Mana Vampire"); }
						else if (!HasSpell(from, 52)){ AddLabel(597, 132, 33, @"Mana Vampire"); }
						
                        if (HasSpell(from, 53)) { AddLabel(597, 162, 1153, @"Mass Dispel"); }
						else if (!HasSpell(from, 53)){ AddLabel(597, 162, 33, @"Mass Dispel"); }
						
                        if (HasSpell(from, 54)) { AddLabel(597, 192, 1153, @"Meteor Swarm"); }
						else if (!HasSpell(from, 54)) { AddLabel(597, 192, 33, @"Meteor Swarm"); }
						
                        if (HasSpell(from, 55)) { AddLabel(597, 222, 1153, @"Polymorph"); }
						else if (!HasSpell(from, 55)){ AddLabel(597, 222, 33, @"Polymorph"); }
						
                        if (HasSpell(from, 56)) { AddLabel(597, 252, 1153, @"Earthquake"); }
						else if (!HasSpell(from, 56)){ AddLabel(597, 252, 33, @"Earthquake"); }
						
                        if (HasSpell(from, 57)) { AddLabel(597, 282, 1153, @"Energy Vortex"); }
						else if (!HasSpell(from, 57)){ AddLabel(597, 282, 33, @"Energy Vortex"); }
						
                        if (HasSpell(from, 58)) { AddLabel(597, 312, 1153, @"Resurrection"); }
						else if (!HasSpell(from, 58)){ AddLabel(597, 312, 33, @"Resurrection"); }
						
                        if (HasSpell(from, 59)) { AddLabel(597, 342, 1153, @"Air Elemental"); }
						else if (!HasSpell(from, 59)){ AddLabel(597, 342, 33, @"Air Elemental"); }
						
                        if (HasSpell(from, 60)) { AddLabel(597, 372, 1153, @"Summon Daemon"); }
						else if (!HasSpell(from, 60)){ AddLabel(597, 372, 33, @"Summon Daemon"); }
						
                        if (HasSpell(from, 61)) { AddLabel(597, 402, 1153, @"Earth Elemental"); }
						else if (!HasSpell(from, 61)){ AddLabel(597, 402, 33, @"Earth Elemental"); }
						
                        if (HasSpell(from, 62)) { AddLabel(597, 433, 1153, @"Fire Elemental"); }
						else if (!HasSpell(from, 62)){ AddLabel(597, 433, 33, @"Fire Elemental"); }
						
                        if (HasSpell(from, 63)) { AddLabel(597, 462, 1153, @"Water Elemental"); }
						else if (!HasSpell(from, 63)){ AddLabel(597, 462, 33, @"Water Elemental"); }
						
                       
                       
                        AddButton(12, 20, 4006, 4006, (int)Buttons.Button1, GumpButtonType.Reply, 0);//magery selected

           
                        if ( mW00_ClumsySpell == 1 ) {AddButton(190, 20, 2361, 2360, (int)Buttons.Button9, GumpButtonType.Reply, 1); }//clumsy
                        if ( mW00_ClumsySpell == 0 ) {AddButton(190, 20, 2360, 2361, (int)Buttons.Button9, GumpButtonType.Reply, 1);}//clumsy
                       
                        if ( mW01_CreateFoodSpell == 1 ) { this.AddButton(190, 50, 2361, 2361, (int)Buttons.Button10, GumpButtonType.Reply, 1); }
                        if ( mW01_CreateFoodSpell == 0 ) { this.AddButton(190, 50, 2360, 2360, (int)Buttons.Button10, GumpButtonType.Reply, 1); }
                       
                        if ( mW02_FeeblemindSpell == 1 ) { this.AddButton(190, 80, 2361, 2361, (int)Buttons.Button11, GumpButtonType.Reply, 1); }
                        if ( mW02_FeeblemindSpell == 0 ) { this.AddButton(190, 80, 2360, 2360, (int)Buttons.Button11, GumpButtonType.Reply, 1); }
                       
                        if ( mW03_HealSpell == 1 ) { this.AddButton(190, 110, 2361, 2361, (int)Buttons.Button12, GumpButtonType.Reply, 1); }
                        if ( mW03_HealSpell == 0 ) { this.AddButton(190, 110, 2360, 2360, (int)Buttons.Button12, GumpButtonType.Reply, 1); }
                       
                        if ( mW04_MagicArrowSpell == 1 ) { this.AddButton(190, 140, 2361, 2361, (int)Buttons.Button13, GumpButtonType.Reply, 1); }
                        if ( mW04_MagicArrowSpell == 0 ) { this.AddButton(190, 140, 2360, 2360, (int)Buttons.Button13, GumpButtonType.Reply, 1); }
                       
                        if ( mW05_NightSightSpell == 1 ) { this.AddButton(190, 170, 2361, 2361, (int)Buttons.Button14, GumpButtonType.Reply, 1); }
                        if ( mW05_NightSightSpell == 0 ) { this.AddButton(190, 170, 2360, 2360, (int)Buttons.Button14, GumpButtonType.Reply, 1); }
                       
                        if ( mW06_ReactiveArmorSpell == 1 ) { this.AddButton(190, 200, 2361, 2361, (int)Buttons.Button15, GumpButtonType.Reply, 1); }
                        if ( mW06_ReactiveArmorSpell == 0 ) { this.AddButton(190, 200, 2360, 2360, (int)Buttons.Button15, GumpButtonType.Reply, 1); }
                       
                        if ( mW07_WeakenSpell == 1 ) { this.AddButton(190, 230, 2361, 2361, (int)Buttons.Button16, GumpButtonType.Reply, 1); }
                        if ( mW07_WeakenSpell == 0 ) { this.AddButton(190, 230, 2360, 2360, (int)Buttons.Button16, GumpButtonType.Reply, 1); }
       
                        if ( mW08_AgilitySpell == 1 ) { this.AddButton(190, 260,  2361, 2361, (int)Buttons.Button17, GumpButtonType.Reply, 1); }
                        if ( mW08_AgilitySpell == 0 ) { this.AddButton(190, 260,  2360, 2360, (int)Buttons.Button17, GumpButtonType.Reply, 1); }
                       
                        if ( mW09_CunningSpell == 1 ) { this.AddButton(190, 290, 2361, 2361, (int)Buttons.Button18, GumpButtonType.Reply, 1); }
                        if ( mW09_CunningSpell == 0 ) { this.AddButton(190, 290, 2360, 2360, (int)Buttons.Button18, GumpButtonType.Reply, 1); }
                       
                        if ( mW10_CureSpell == 1 ) { this.AddButton(190, 320, 2361, 2361, (int)Buttons.Button19, GumpButtonType.Reply, 1); }
                        if ( mW10_CureSpell == 0 ) { this.AddButton(190, 320, 2360, 2360, (int)Buttons.Button19, GumpButtonType.Reply, 1); }
                       
                        if ( mW11_HarmSpell == 1 ) { this.AddButton(190, 350, 2361, 2361, (int)Buttons.Button20, GumpButtonType.Reply, 1); }
                        if ( mW11_HarmSpell == 0 ) { this.AddButton(190, 350, 2360, 2360, (int)Buttons.Button20, GumpButtonType.Reply, 1); }
                       
                        if ( mW12_MagicTrapSpell == 1 ) { this.AddButton(190, 380, 2361, 2361, (int)Buttons.Button21, GumpButtonType.Reply, 1); }
                        if ( mW12_MagicTrapSpell == 0 ) { this.AddButton(190, 380, 2360, 2360, (int)Buttons.Button21, GumpButtonType.Reply, 1); }
                       
                        if ( mW13_RemoveTrapSpell == 1 ) { this.AddButton(190, 410, 2361, 2361, (int)Buttons.Button22, GumpButtonType.Reply, 1); }
                        if ( mW13_RemoveTrapSpell == 0 ) { this.AddButton(190, 410, 2360, 2360, (int)Buttons.Button22, GumpButtonType.Reply, 1); }
                       
                        if ( mW14_ProtectionSpell == 1 ) { this.AddButton(190, 440, 2361, 2361, (int)Buttons.Button23, GumpButtonType.Reply, 1); }
                        if ( mW14_ProtectionSpell == 0 ) { this.AddButton(190, 440, 2360, 2360, (int)Buttons.Button23, GumpButtonType.Reply, 1); }
                       
                        if ( mW15_StrengthSpell == 1 ) { this.AddButton(190, 470, 2361, 2361, (int)Buttons.Button24, GumpButtonType.Reply, 1); }
                        if ( mW15_StrengthSpell == 0 ) { this.AddButton(190, 470, 2360, 2360, (int)Buttons.Button24, GumpButtonType.Reply, 1); }    
            ///row 2
                        if ( mW16_BlessSpell == 1 ) { this.AddButton(321, 20,  2361, 2361,  (int)Buttons.Button25, GumpButtonType.Reply, 1); }
                        if ( mW16_BlessSpell == 0 ) { this.AddButton(321, 20,  2360, 2360,  (int)Buttons.Button25, GumpButtonType.Reply, 1); }
                       
                        if ( mW17_FireballSpell == 1 ) { this.AddButton(321, 50, 2361, 2361,  (int)Buttons.Button26, GumpButtonType.Reply, 1); }
                        if ( mW17_FireballSpell == 0 ) { this.AddButton(321, 50, 2360, 2360,  (int)Buttons.Button26, GumpButtonType.Reply, 1); }
                       
                        if ( mW18_MagicLockSpell == 1 ) { this.AddButton(321, 80, 2361, 2361,  (int)Buttons.Button27, GumpButtonType.Reply, 1); }
                        if ( mW18_MagicLockSpell == 0 ) { this.AddButton(321, 80, 2360, 2360,  (int)Buttons.Button27, GumpButtonType.Reply, 1); }
                       
                        if ( mW19_PoisonSpell == 1 ) { this.AddButton(321, 110, 2361, 2361,  (int)Buttons.Button28, GumpButtonType.Reply, 1); }
                        if ( mW19_PoisonSpell == 0 ) { this.AddButton(321, 110, 2360, 2360,  (int)Buttons.Button28, GumpButtonType.Reply, 1); }
                       
                        if ( mW20_TelekinesisSpell == 1 ) { this.AddButton(321, 140, 2361, 2361,  (int)Buttons.Button29, GumpButtonType.Reply, 1); }
                        if ( mW20_TelekinesisSpell == 0 ) { this.AddButton(321, 140, 2360, 2360,  (int)Buttons.Button29, GumpButtonType.Reply, 1); }

                        if ( mW21_TeleportSpell == 1 ) { this.AddButton(321, 170, 2361, 2361,  (int)Buttons.Button30, GumpButtonType.Reply, 1); }
                        if ( mW21_TeleportSpell == 0 ) { this.AddButton(321, 170, 2360, 2360,   (int)Buttons.Button30, GumpButtonType.Reply, 1); }
                       
                        if ( mW22_UnlockSpell == 1 ) { this.AddButton(321, 200, 2361, 2361,   (int)Buttons.Button31, GumpButtonType.Reply, 1); }
                        if ( mW22_UnlockSpell == 0 ) { this.AddButton(321, 200, 2360, 2360,   (int)Buttons.Button31, GumpButtonType.Reply, 1); }
                       
                        if ( mW23_WallOfStoneSpell == 1 ) { this.AddButton(321, 230, 2361, 2361,   (int)Buttons.Button32, GumpButtonType.Reply, 1); }
                        if ( mW23_WallOfStoneSpell == 0 ) { this.AddButton(321, 230, 2360, 2360,   (int)Buttons.Button32, GumpButtonType.Reply, 1); }
                       
                        if ( mW24_ArchCureSpell == 1 ) { this.AddButton(321, 260,  2361, 2361,   (int)Buttons.Button33, GumpButtonType.Reply, 1); }
                        if ( mW24_ArchCureSpell == 0 ) { this.AddButton(321, 260,  2360, 2360,   (int)Buttons.Button33, GumpButtonType.Reply, 1); }
                       
                        if ( mW25_ArchProtectionSpell == 1 ) { this.AddButton(321, 290, 2361, 2361,   (int)Buttons.Button34, GumpButtonType.Reply, 1); }
                        if ( mW25_ArchProtectionSpell == 0 ) { this.AddButton(321, 290, 2360, 2360,   (int)Buttons.Button34, GumpButtonType.Reply, 1); }
                       
                        if ( mW26_CurseSpell == 1 ) { this.AddButton(321, 320, 2361, 2361,   (int)Buttons.Button35, GumpButtonType.Reply, 1); }
                        if ( mW26_CurseSpell == 0 ) { this.AddButton(321, 320, 2360, 2360,   (int)Buttons.Button35, GumpButtonType.Reply, 1); }
                       
                        if ( mW27_FireFieldSpell == 1 ) { this.AddButton(321, 350, 2361, 2361,   (int)Buttons.Button36, GumpButtonType.Reply, 1); }
                        if ( mW27_FireFieldSpell == 0 ) { this.AddButton(321, 350, 2360, 2360,   (int)Buttons.Button36, GumpButtonType.Reply, 1); }
                       
                        if ( mW28_GreaterHealSpell == 1 ) { this.AddButton(321, 380, 2361, 2361,   (int)Buttons.Button37, GumpButtonType.Reply, 1); }
                        if ( mW28_GreaterHealSpell == 0 ) { this.AddButton(321, 380, 2360, 2360,   (int)Buttons.Button37, GumpButtonType.Reply, 1); }
                       
                        if ( mW29_LightningSpell == 1 ) { this.AddButton(321, 410, 2361, 2361,   (int)Buttons.Button38, GumpButtonType.Reply, 1); }
                        if ( mW29_LightningSpell == 0 ) { this.AddButton(321, 410, 2360, 2360,   (int)Buttons.Button38, GumpButtonType.Reply, 1); }
                       
                        if ( mW30_ManaDrainSpell == 1 ) { this.AddButton(321, 440, 2361, 2361,   (int)Buttons.Button39, GumpButtonType.Reply, 1); }
                        if ( mW30_ManaDrainSpell == 0 ) { this.AddButton(321, 440, 2360, 2360,   (int)Buttons.Button39, GumpButtonType.Reply, 1); }
                       
                        if ( mW31_RecallSpell == 1 ) { this.AddButton(321, 470, 2361, 2361, (int)Buttons.Button40, GumpButtonType.Reply, 1); }
                        if ( mW31_RecallSpell == 0 ) { this.AddButton(321, 470, 2360, 2360,   (int)Buttons.Button40, GumpButtonType.Reply, 1); }
                       
                       
            /// 3RD ROW            
                        if ( mW32_BladeSpiritsSpell == 1 ) { this.AddButton(450, 20,  2361, 2361, (int)Buttons.Button41, GumpButtonType.Reply, 1); }
                        if ( mW32_BladeSpiritsSpell == 0 ) { this.AddButton(450, 20,  2360, 2360,  (int)Buttons.Button41, GumpButtonType.Reply, 1); }
                       
                        if ( mW33_DispelFieldSpell == 1 ) { this.AddButton(450, 50,  2361, 2361,  (int)Buttons.Button42, GumpButtonType.Reply, 1); }
                        if ( mW33_DispelFieldSpell == 0 ) { this.AddButton(450, 50,  2360, 2360,  (int)Buttons.Button42, GumpButtonType.Reply, 1); }
                       
                        if ( mW34_IncognitoSpell == 1 ) { this.AddButton(450, 80, 2361, 2361,  (int)Buttons.Button43, GumpButtonType.Reply, 1); }
                        if ( mW34_IncognitoSpell == 0 ) { this.AddButton(450, 80, 2360, 2360,  (int)Buttons.Button43, GumpButtonType.Reply, 1); }
                       
                        if ( mW35_MagicReflectSpell == 1 ) { this.AddButton(450, 110, 2361, 2361,  (int)Buttons.Button44, GumpButtonType.Reply, 1); }
                        if ( mW35_MagicReflectSpell == 0 ) { this.AddButton(450, 110, 2360, 2360,  (int)Buttons.Button44, GumpButtonType.Reply, 1); }
                       
                        if ( mW36_MindBlastSpell == 1 ) { this.AddButton(450, 140, 2361, 2361,  (int)Buttons.Button45, GumpButtonType.Reply, 1); }
                        if ( mW36_MindBlastSpell == 0 ) { this.AddButton(450, 140, 2360, 2360,  (int)Buttons.Button45, GumpButtonType.Reply, 1); }
                       
                        if ( mW37_ParalyzeSpell == 1 ) { this.AddButton(450, 170, 2361, 2361,  (int)Buttons.Button46, GumpButtonType.Reply, 1); }
                        if ( mW37_ParalyzeSpell == 0 ) { this.AddButton(450, 170, 2360, 2360,  (int)Buttons.Button46, GumpButtonType.Reply, 1); }
                       
                        if ( mW38_PoisonFieldSpell == 1 ) { this.AddButton(450, 200, 2361, 2361,  (int)Buttons.Button47, GumpButtonType.Reply, 1); }
                        if ( mW38_PoisonFieldSpell == 0 ) { this.AddButton(450, 200, 2360, 2360,  (int)Buttons.Button47, GumpButtonType.Reply, 1); }
                       
                        if ( mW39_SummonCreatureSpell == 1 ) { this.AddButton(450, 230, 2361, 2361,  (int)Buttons.Button48, GumpButtonType.Reply, 1); }
                        if ( mW39_SummonCreatureSpell == 0 ) { this.AddButton(450, 230, 2360, 2360,  (int)Buttons.Button48, GumpButtonType.Reply, 1); }
                       
                        if ( mW40_DispelSpell == 1 ) { this.AddButton(450, 260,  2361, 2361,  (int)Buttons.Button49, GumpButtonType.Reply, 1); }
                        if ( mW40_DispelSpell == 0 ) { this.AddButton(450, 260,  2360, 2360,  (int)Buttons.Button49, GumpButtonType.Reply, 1); }
                       
                        if ( mW41_EnergyBoltSpell == 1 ) { this.AddButton(450, 290,  2361, 2361, (int)Buttons.Button50, GumpButtonType.Reply, 1); }
                        if ( mW41_EnergyBoltSpell == 0 ) { this.AddButton(450, 290,  2360, 2360,  (int)Buttons.Button50, GumpButtonType.Reply, 1); }
                       
                        if ( mW42_ExplosionSpell == 1 ) { this.AddButton(450, 320, 2361, 2361,  (int)Buttons.Button51, GumpButtonType.Reply, 1); }
                        if ( mW42_ExplosionSpell == 0 ) { this.AddButton(450, 320, 2360, 2360,  (int)Buttons.Button51, GumpButtonType.Reply, 1); }
                       
                        if ( mW43_InvisibilitySpell == 1 ) { this.AddButton(450, 350, 2361, 2361,  (int)Buttons.Button52, GumpButtonType.Reply, 1); }
                        if ( mW43_InvisibilitySpell == 0 ) { this.AddButton(450, 350, 2360, 2360,  (int)Buttons.Button52, GumpButtonType.Reply, 1); }
                       
                        if ( mW44_MarkSpell == 1 ) { this.AddButton(450, 380, 2361, 2361,  (int)Buttons.Button53, GumpButtonType.Reply, 1); }
                        if ( mW44_MarkSpell == 0 ) { this.AddButton(450, 380, 2360, 2360,  (int)Buttons.Button53, GumpButtonType.Reply, 1); }
                       
                        if ( mW45_MassCurseSpell == 1 ) { this.AddButton(450, 410, 2361, 2361,  (int)Buttons.Button54, GumpButtonType.Reply, 1); }
                        if ( mW45_MassCurseSpell == 0 ) { this.AddButton(450, 410, 2360, 2360,  (int)Buttons.Button54, GumpButtonType.Reply, 1); }
                       
                        if ( mW46_ParalyzeFieldSpell == 1 ) { this.AddButton(450, 440, 2361, 2361,  (int)Buttons.Button55, GumpButtonType.Reply, 1); }
                        if ( mW46_ParalyzeFieldSpell == 0 ) { this.AddButton(450, 440, 2360, 2360,  (int)Buttons.Button55, GumpButtonType.Reply, 1); }
                       
                        if ( mW47_RevealSpell == 1 ) { this.AddButton(450, 470, 2361, 2361,  (int)Buttons.Button56, GumpButtonType.Reply, 1); }
                        if ( mW47_RevealSpell == 0 ) { this.AddButton(450, 470, 2360, 2360,  (int)Buttons.Button56, GumpButtonType.Reply, 1); }
                       
        ///4th row                
                        if ( mW48_ChainLightningSpell == 1 ) { this.AddButton(582, 20,  2361, 2361, (int)Buttons.Button57, GumpButtonType.Reply, 1); }
                        if ( mW48_ChainLightningSpell == 0 ) { this.AddButton(582, 20,  2360, 2360, (int)Buttons.Button57, GumpButtonType.Reply, 1); }
                       
                        if ( mW49_EnergyFieldSpell == 1 ) { this.AddButton(582, 50,  2361, 2361, (int)Buttons.Button58, GumpButtonType.Reply, 1); }
                        if ( mW49_EnergyFieldSpell == 0 ) { this.AddButton(582, 50,  2360, 2360, (int)Buttons.Button58, GumpButtonType.Reply, 1); }
                       
                        if ( mW50_FlameStrikeSpell == 1 ) { this.AddButton(582, 80, 2361, 2361, (int)Buttons.Button59, GumpButtonType.Reply, 1); }
                        if ( mW50_FlameStrikeSpell == 0 ) { this.AddButton(582, 80, 2360, 2360, (int)Buttons.Button59, GumpButtonType.Reply, 1); }
                       
                        if ( mW51_GateTravelSpell == 1 ) { this.AddButton(582, 110, 2361, 2361, (int)Buttons.Button60, GumpButtonType.Reply, 1); }
                        if ( mW51_GateTravelSpell == 0 ) { this.AddButton(582, 110, 2360, 2360, (int)Buttons.Button60, GumpButtonType.Reply, 1); }
                       
                        if ( mW52_ManaVampireSpell == 1 ) { this.AddButton(582, 140, 2361, 2361, (int)Buttons.Button61, GumpButtonType.Reply, 1); }
                        if ( mW52_ManaVampireSpell == 0 ) { this.AddButton(582, 140, 2360, 2360, (int)Buttons.Button61, GumpButtonType.Reply, 1); }
                       
                        if ( mW53_MassDispelSpell == 1 ) { this.AddButton(582, 170, 2361, 2361, (int)Buttons.Button62, GumpButtonType.Reply, 1); }
                        if ( mW53_MassDispelSpell == 0 ) { this.AddButton(582, 170, 2360, 2360, (int)Buttons.Button62, GumpButtonType.Reply, 1); }
                       
                        if ( mW54_MeteorSwarmSpell == 1 ) { this.AddButton(582, 200, 2361, 2361, (int)Buttons.Button63, GumpButtonType.Reply, 1); }
                        if ( mW54_MeteorSwarmSpell == 0 ) { this.AddButton(582, 200, 2360, 2360, (int)Buttons.Button63, GumpButtonType.Reply, 1); }
                       
                        if ( mW55_PolymorphSpell == 1 ) { this.AddButton(582, 230, 2361, 2361, (int)Buttons.Button64, GumpButtonType.Reply, 1); }
                        if ( mW55_PolymorphSpell == 0 ) { this.AddButton(582, 230, 2360, 2360, (int)Buttons.Button64, GumpButtonType.Reply, 1); }
                       
                        if ( mW56_EarthquakeSpell == 1 ) { this.AddButton(582, 260,  2361, 2361, (int)Buttons.Button65, GumpButtonType.Reply, 1); }
                        if ( mW56_EarthquakeSpell == 0 ) { this.AddButton(582, 260,  2360, 2360, (int)Buttons.Button65, GumpButtonType.Reply, 1); }
                       
                        if ( mW57_EnergyVortexSpell == 1 ) { this.AddButton(582, 290,  2361, 2361, (int)Buttons.Button66, GumpButtonType.Reply, 1); }
                        if ( mW57_EnergyVortexSpell == 0 ) { this.AddButton(582, 290,  2360, 2360, (int)Buttons.Button66, GumpButtonType.Reply, 1); }
                       
                        if ( mW58_ResurrectionSpell == 1 ) { this.AddButton(582, 320, 2361, 2361, (int)Buttons.Button67, GumpButtonType.Reply, 1); }
                        if ( mW58_ResurrectionSpell == 0 ) { this.AddButton(582, 320, 2360, 2360, (int)Buttons.Button67, GumpButtonType.Reply, 1); }
                       
                        if ( mW59_AirElementalSpell == 1 ) { this.AddButton(582, 350, 2361, 2361, (int)Buttons.Button68, GumpButtonType.Reply, 1); }
                        if ( mW59_AirElementalSpell == 0 ) { this.AddButton(582, 350, 2360, 2360, (int)Buttons.Button68, GumpButtonType.Reply, 1); }
                       
                        if ( mW60_SummonDaemonSpell == 1 ) { this.AddButton(582, 380, 2361, 2361, (int)Buttons.Button69, GumpButtonType.Reply, 1); }
                        if ( mW60_SummonDaemonSpell == 0 ) { this.AddButton(582, 380, 2360, 2360, (int)Buttons.Button69, GumpButtonType.Reply, 1); }
                       
                        if ( mW61_EarthElementalSpell == 1 ) { this.AddButton(582, 410, 2361, 2361, (int)Buttons.Button70, GumpButtonType.Reply, 1); }
                        if ( mW61_EarthElementalSpell == 0 ) { this.AddButton(582, 410, 2360, 2360, (int)Buttons.Button70, GumpButtonType.Reply, 1); }
                       
                        if ( mW62_FireElementalSpell == 1 ) { this.AddButton(582, 440, 2361, 2361, (int)Buttons.Button71, GumpButtonType.Reply, 1); }
                        if ( mW62_FireElementalSpell == 0 ) { this.AddButton(582, 440, 2360, 2360, (int)Buttons.Button71, GumpButtonType.Reply, 1); }
                       
                        if ( mW63_WaterElementalSpell == 1 ) { this.AddButton(582, 470, 2361, 2361, (int)Buttons.Button72, GumpButtonType.Reply, 1); }
                        if ( mW63_WaterElementalSpell == 0 ) { this.AddButton(582, 470, 2360, 2360, (int)Buttons.Button72, GumpButtonType.Reply, 1); }
           
                           
                        break;
                    }
                case 2: /// necromancy
                    {
						AddBackground(170, 0, 300, 500, 9200);
						AddImageTiled(180, 10, 280, 480, 2624);
						AddAlphaRegion(180, 10, 280, 480);
						
						//if ( HasSpell( from, 0 ) ) { AddLabel(205, 13, 1153, @"Clumsy"); }
						//else if ( !HasSpell( from, 0 ) ) { AddLabel(205, 13, 33, @"Clumsy"); }
					
                        if( HasSpell ( from, 100) ) { AddLabel(205, 13, 1153, @"Animated Dead"); }
						else if ( !HasSpell( from, 100 ) ){ AddLabel(205, 13, 33, @"Animated Dead"); }
						
                        if( HasSpell ( from, 101) ) { AddLabel(205, 43, 1153, @"Blood Oath"); }
						else if ( !HasSpell( from, 101 ) ){ AddLabel(205, 43, 33, @"Blood Oath"); }
						
                        if( HasSpell ( from, 102) ) { AddLabel(205, 73, 1153, @"Corpse Skin"); }
						else if ( !HasSpell( from, 102 ) ){ AddLabel(205, 73, 33, @"Corpse Skin"); }
						
                        if( HasSpell ( from, 103) ) { AddLabel(205, 103, 1153, @"Curse Weapon"); }
						else if ( !HasSpell( from, 103 ) ){ AddLabel(205, 103, 33, @"Curse Weapon"); }
						
                        if( HasSpell (from, 104) ) { AddLabel(205, 133, 1153, @"Evil Omen"); }
						else if ( !HasSpell( from, 104 ) ) { AddLabel(205, 133, 33, @"Evil Omen"); }
						
                        if( HasSpell (from, 105) ) { AddLabel(205, 163, 1153, @"Horrific Beast"); }
						else if ( !HasSpell( from, 105 ) ){ AddLabel(205, 163, 33, @"Horrific Beast"); }
						
                        if( HasSpell (from, 106) ) { AddLabel(205, 193, 1153, @"Lich Form"); }
						else if ( !HasSpell( from, 106 ) ){ AddLabel(205, 193, 33, @"Lich Form"); }
						
                        if ( HasSpell( from, 107 ) ) { AddLabel(205, 223, 1153, @"Mind Rot"); }
						else if ( !HasSpell( from, 107 ) ){ AddLabel(205, 223, 33, @"Mind Rot"); }
						
                        if( HasSpell (from, 108) ) { AddLabel(205, 253, 1153, @"Pain Spike"); }
						else if ( !HasSpell( from, 108 ) ){ AddLabel(205, 253, 33, @"Pain Spike"); }
						
                        if( HasSpell (from, 109) ) { AddLabel(205, 283, 1153, @"Poison Strike"); }
						else if ( !HasSpell( from, 109 ) ){ AddLabel(205, 283, 33, @"Poison Strike"); }
						
                        if( HasSpell (from, 110) ) { AddLabel(205, 313, 1153, @"Strangle"); }
						else if ( !HasSpell( from, 110 ) ){ AddLabel(205, 313, 33, @"Strangle"); }
						
                        if( HasSpell (from, 111) ) { AddLabel(205, 343, 1153, @"Summon Familiar"); }
						else if ( !HasSpell( from, 111 ) ){ AddLabel(205, 343, 33, @"Summon Familiar"); }
						
                        if( HasSpell (from, 112) ) { AddLabel(205, 373, 1153, @"Vampiric Embrace"); }
						else if ( !HasSpell( from, 112 ) ){ AddLabel(205, 373, 33, @"Vampiric Embrace"); }
						
                        if( HasSpell (from, 113) ) { AddLabel(205, 403, 1153, @"Vengeful Spirit"); }
						else if ( !HasSpell( from, 113 ) ){ AddLabel(205, 403, 33, @"Vengeful Spirit"); }
						
                        if( HasSpell (from, 114) ) { AddLabel(205, 434, 1153, @"Wither"); }
						else if ( !HasSpell( from, 114 ) ){ AddLabel(205, 434, 33, @"Wither"); }
						
                        if( HasSpell (from, 115) ) { AddLabel(205, 463, 1153, @"Wraith Form"); }
						else if ( !HasSpell( from, 115 ) ){ AddLabel(205, 463, 33, @"Wraith Form"); }
						
                        if( HasSpell (from, 116) ) { AddLabel(336, 13, 1153, @"Exorcism"); }
						else if ( !HasSpell( from, 116 ) ){ AddLabel(336, 13, 33, @"Exorcism"); }
						
						
                   
                        AddButton(12, 50, 4006, 4006, (int)Buttons.Button2, GumpButtonType.Reply, 0);//necro selected
                       
                        if ( mN01AnimateDeadSpell == 1 ) { this.AddButton( 190, 20,  2361, 2361, (int)Buttons.Button73, GumpButtonType.Reply, 1); }
                        if ( mN01AnimateDeadSpell == 0 ) { this.AddButton( 190, 20,  2360, 2360, (int)Buttons.Button73, GumpButtonType.Reply, 1); }
                       
                        if ( mN02BloodOathSpell == 1 ) { this.AddButton( 190, 50,  2361, 2361, (int)Buttons.Button74, GumpButtonType.Reply, 1); }
                        if ( mN02BloodOathSpell == 0 ) { this.AddButton( 190, 50,  2360, 2360, (int)Buttons.Button74, GumpButtonType.Reply, 1); }
                       
                        if ( mN03CorpseSkinSpell == 1 ) { this.AddButton( 190, 80,  2361, 2361, (int)Buttons.Button75, GumpButtonType.Reply, 1); }
                        if ( mN03CorpseSkinSpell == 0 ) { this.AddButton( 190, 80,  2360, 2360, (int)Buttons.Button75, GumpButtonType.Reply, 1); }
                       
                        if ( mN04CurseWeaponSpell == 1 ) { this.AddButton( 190, 110,  2361, 2361, (int)Buttons.Button76, GumpButtonType.Reply, 1); }
                        if ( mN04CurseWeaponSpell == 0 ) { this.AddButton( 190, 110,  2360, 2360, (int)Buttons.Button76, GumpButtonType.Reply, 1); }
                       
                        if ( mN05EvilOmenSpell == 1 ) { this.AddButton( 190, 140,  2361, 2361, (int)Buttons.Button77, GumpButtonType.Reply, 1); }
                        if ( mN05EvilOmenSpell == 0 ) { this.AddButton( 190, 140,  2360, 2360, (int)Buttons.Button77, GumpButtonType.Reply, 1); }
                       
                        if ( mN06HorrificBeastSpell == 1 ) { this.AddButton( 190, 170,  2361, 2361, (int)Buttons.Button78, GumpButtonType.Reply, 1); }
                        if ( mN06HorrificBeastSpell == 0 ) { this.AddButton( 190, 170,  2360, 2360, (int)Buttons.Button78, GumpButtonType.Reply, 1); }
                       
                        if ( mN07LichFormSpell == 1 ) { this.AddButton( 190, 200,  2361, 2361, (int)Buttons.Button79, GumpButtonType.Reply, 1); }
                        if ( mN07LichFormSpell == 0 ) { this.AddButton( 190, 200,  2360, 2360, (int)Buttons.Button79, GumpButtonType.Reply, 1); }
                       
                        if ( mN08MindRotSpell == 1 ) { this.AddButton( 190, 230,  2361, 2361, (int)Buttons.Button80, GumpButtonType.Reply, 1); }
                        if ( mN08MindRotSpell == 0 ) { this.AddButton( 190, 230,  2360, 2360, (int)Buttons.Button80, GumpButtonType.Reply, 1); }
                       
                        if ( mN09PainSpikeSpell == 1 ) { this.AddButton( 190, 260,  2361, 2361, (int)Buttons.Button81, GumpButtonType.Reply, 1); }
                        if ( mN09PainSpikeSpell == 0 ) { this.AddButton( 190, 260,  2360, 2360, (int)Buttons.Button81, GumpButtonType.Reply, 1); }
                       
                        if ( mN10PoisonStrikeSpell == 1 ) { this.AddButton( 190, 290,  2361, 2361, (int)Buttons.Button82, GumpButtonType.Reply, 1); }
                        if ( mN10PoisonStrikeSpell == 0 ) { this.AddButton( 190, 290,  2360, 2360, (int)Buttons.Button82, GumpButtonType.Reply, 1); }
                       
                        if ( mN11StrangleSpell == 1 ) { this.AddButton( 190, 320,  2361, 2361, (int)Buttons.Button83, GumpButtonType.Reply, 1); }
                        if ( mN11StrangleSpell == 0 ) { this.AddButton( 190, 320,  2360, 2360, (int)Buttons.Button83, GumpButtonType.Reply, 1); }
                       
                        if ( mN12SummonFamiliarSpell == 1 ) { this.AddButton( 190, 350,  2361, 2361, (int)Buttons.Button84, GumpButtonType.Reply, 1); }
                        if ( mN12SummonFamiliarSpell == 0 ) { this.AddButton( 190, 350,  2360, 2360, (int)Buttons.Button84, GumpButtonType.Reply, 1); }
                       
                        if ( mN13VampiricEmbraceSpell == 1 ) { this.AddButton( 190, 380,  2361, 2361, (int)Buttons.Button85, GumpButtonType.Reply, 1); }
                        if ( mN13VampiricEmbraceSpell == 0 ) { this.AddButton( 190, 380,  2360, 2360, (int)Buttons.Button85, GumpButtonType.Reply, 1); }
                       
                        if ( mN14VengefulSpiritSpell == 1 ) { this.AddButton( 190, 410,  2361, 2361, (int)Buttons.Button86, GumpButtonType.Reply, 1); }
                        if ( mN14VengefulSpiritSpell == 0 ) { this.AddButton( 190, 410,  2360, 2360, (int)Buttons.Button86, GumpButtonType.Reply, 1); }
                       
                        if ( mN15WitherSpell == 1 ) { this.AddButton( 190, 440,  2361, 2361, (int)Buttons.Button87, GumpButtonType.Reply, 1); }
                        if ( mN15WitherSpell == 0 ) { this.AddButton( 190, 440,  2360, 2360, (int)Buttons.Button87, GumpButtonType.Reply, 1); }
                       
                        if ( mN16WraithFormSpell == 1 ) { this.AddButton( 190, 470,  2361, 2361, (int)Buttons.Button88, GumpButtonType.Reply, 1); }
                        if ( mN16WraithFormSpell == 0 ) { this.AddButton( 190, 470,  2360, 2360, (int)Buttons.Button88, GumpButtonType.Reply, 1); }
                       
                        if ( mN17ExorcismSpell == 1 ) { this.AddButton( 321, 20,  2361, 2361, (int)Buttons.Button89, GumpButtonType.Reply, 1); }
                        if ( mN17ExorcismSpell == 0 ) { this.AddButton( 321, 20,  2360, 2360, (int)Buttons.Button89, GumpButtonType.Reply, 1); }
                       
                        break;
                    }
                case 3: /// chivalry
                    {
					
						AddBackground(170, 0, 250, 500, 9200);
						AddImageTiled(180, 10, 230, 480, 2624);
						AddAlphaRegion(180, 10, 230, 480);
						
					
                        AddLabel(205, 13, 1153, @"Cleanse by Fire");
                        AddLabel(205, 43, 1153, @"Close Wounds");
                        AddLabel(205, 73, 1153, @"Consecrate Weapon");
                        AddLabel(205, 103, 1153, @"Dispel Evil");
                        AddLabel(205, 133, 1153, @"Divine Fury");
                        AddLabel(205, 163, 1153, @"Enemy of One");
                        AddLabel(205, 193, 1153, @"Holy Light");
                        AddLabel(205, 223, 1153, @"Noble Sacrifice");
                        AddLabel(205, 253, 1153, @"Remove Curse");
                        AddLabel(205, 283, 1153, @"Sacred Journey");
                   
                        AddButton(12, 80, 4006, 4006, (int)Buttons.Button3, GumpButtonType.Reply, 0);//chiv selected
                   
                        if ( mC01CleanseByFireSpell == 1 ) { this.AddButton( 190, 20,  2361, 2361, (int)Buttons.Button90, GumpButtonType.Reply, 1); }
                        if ( mC01CleanseByFireSpell == 0 ) { this.AddButton( 190, 20,  2360, 2360, (int)Buttons.Button90, GumpButtonType.Reply, 1); }
                       
                        if ( mC02CloseWoundsSpell == 1 ) { this.AddButton( 190, 50,  2361, 2361, (int)Buttons.Button91, GumpButtonType.Reply, 1); }
                        if ( mC02CloseWoundsSpell == 0 ) { this.AddButton( 190, 50,  2360, 2360, (int)Buttons.Button91, GumpButtonType.Reply, 1); }
                       
                        if ( mC03ConsecrateWeaponSpell == 1 ) { this.AddButton( 190, 80,  2361, 2361, (int)Buttons.Button92, GumpButtonType.Reply, 1); }
                        if ( mC03ConsecrateWeaponSpell == 0 ) { this.AddButton( 190, 80,  2360, 2360, (int)Buttons.Button92, GumpButtonType.Reply, 1); }
                       
                        if ( mC04DispelEvilSpell == 1 ) { this.AddButton( 190, 110,  2361, 2361, (int)Buttons.Button93, GumpButtonType.Reply, 1); }
                        if ( mC04DispelEvilSpell == 0 ) { this.AddButton( 190, 110,  2360, 2360, (int)Buttons.Button93, GumpButtonType.Reply, 1); }
                       
                        if ( mC05DivineFurySpell == 1 ) { this.AddButton( 190, 140,  2361, 2361, (int)Buttons.Button94, GumpButtonType.Reply, 1); }
                        if ( mC05DivineFurySpell == 0 ) { this.AddButton( 190, 140,  2360, 2360, (int)Buttons.Button94, GumpButtonType.Reply, 1); }
                       
                        if ( mC06EnemyOfOneSpell == 1 ) { this.AddButton( 190, 170,  2361, 2361, (int)Buttons.Button95, GumpButtonType.Reply, 1); }
                        if ( mC06EnemyOfOneSpell == 0 ) { this.AddButton( 190, 170,  2360, 2360, (int)Buttons.Button95, GumpButtonType.Reply, 1); }
                       
                        if ( mC07HolyLightSpell == 1 ) { this.AddButton( 190, 200,  2361, 2361, (int)Buttons.Button96, GumpButtonType.Reply, 1); }
                        if ( mC07HolyLightSpell == 0 ) { this.AddButton( 190, 200,  2360, 2360, (int)Buttons.Button96, GumpButtonType.Reply, 1); }
                       
                        if ( mC08NobleSacrificeSpell == 1 ) { this.AddButton( 190, 230,  2361, 2361, (int)Buttons.Button97, GumpButtonType.Reply, 1); }
                        if ( mC08NobleSacrificeSpell == 0 ) { this.AddButton( 190, 230,  2360, 2360, (int)Buttons.Button97, GumpButtonType.Reply, 1); }
                       
                        if ( mC09RemoveCurseSpell == 1 ) { this.AddButton( 190, 260,  2361, 2361, (int)Buttons.Button98, GumpButtonType.Reply, 1); }
                        if ( mC09RemoveCurseSpell == 0 ) { this.AddButton( 190, 260,  2360, 2360, (int)Buttons.Button98, GumpButtonType.Reply, 1); }
                       
                        if ( mC10SacredJourneySpell == 1 ) { this.AddButton( 190, 290,  2361, 2361, (int)Buttons.Button99, GumpButtonType.Reply, 1); }
                        if ( mC10SacredJourneySpell == 0 ) { this.AddButton( 190, 290,  2360, 2360, (int)Buttons.Button99, GumpButtonType.Reply, 1); }
                        break;
                    }
                case 4: /// bushido
                    {
						AddBackground(170, 0, 250, 500, 9200);
						AddImageTiled(180, 10, 230, 480, 2624);
						AddAlphaRegion(180, 10, 230, 480);
						
						AddButton(12, 110, 4006, 4006, (int)Buttons.Button4, GumpButtonType.Reply, 0);//nin
					
						AddLabel(205, 13, 1153, @"Honorable Execution");
                        AddLabel(205, 43, 1153, @"Confidence");
                        AddLabel(205, 73, 1153, @"Counter Attack");
                        AddLabel(205, 103, 1153, @"Evasion");
                        AddLabel(205, 133, 1153, @"Lightning Stike");
                        AddLabel(205, 163, 1153, @"Momentum Strike");
                        /*
						if (mB06HonorableExecution == 1 ) { this.AddButton( 190, 20,  2361, 2361, (int)Buttons.Button144, GumpButtonType.Reply, 1); }
                        if (mB06HonorableExecution == 0 ) { this.AddButton( 190, 20,  2360, 2360, (int)Buttons.Button144, GumpButtonType.Reply, 1); }
						*/
                        if (mB01Confidence == 1 ) { this.AddButton( 190, 50,  2361, 2361, (int)Buttons.Button100, GumpButtonType.Reply, 1); }
                        if (mB01Confidence == 0 ) { this.AddButton( 190, 50,  2360, 2360, (int)Buttons.Button100, GumpButtonType.Reply, 1); }

                        if (mB02CounterAttack == 1 ) { this.AddButton( 190, 80,  2361, 2361, (int)Buttons.Button101, GumpButtonType.Reply, 1); }
                        if (mB02CounterAttack == 0 ) { this.AddButton( 190, 80,  2360, 2360, (int)Buttons.Button101, GumpButtonType.Reply, 1); }

                        if (mB03Evasion == 1 ) { this.AddButton( 190, 110,  2361, 2361, (int)Buttons.Button102, GumpButtonType.Reply, 1); }
                        if (mB03Evasion == 0 ) { this.AddButton( 190, 110,  2360, 2360, (int)Buttons.Button102, GumpButtonType.Reply, 1); }

                        if (mB04LightningStrike == 1 ) { this.AddButton( 190, 140,  2361, 2361, (int)Buttons.Button103, GumpButtonType.Reply, 1); }
                        if (mB04LightningStrike == 0 ) { this.AddButton( 190, 140,  2360, 2360, (int)Buttons.Button103, GumpButtonType.Reply, 1); }

                        if (mB05MomentumStrike == 1 ) { this.AddButton( 190, 170,  2361, 2361, (int)Buttons.Button104, GumpButtonType.Reply, 1); }
                        if (mB05MomentumStrike == 0 ) { this.AddButton( 190, 170,  2360, 2360, (int)Buttons.Button104, GumpButtonType.Reply, 1); }
						
						if (mB06HonorableExecution == 1 ) { this.AddButton( 190, 20,  2361, 2361, (int)Buttons.Button144, GumpButtonType.Reply, 1); }
                        if (mB06HonorableExecution == 0 ) { this.AddButton( 190, 20,  2360, 2360, (int)Buttons.Button144, GumpButtonType.Reply, 1); }

                       
                        break;
                    }    
                case 5: /// ninjitsu
                    {
						AddBackground(170, 0, 250, 500, 9200);
						AddImageTiled(180, 10, 230, 480, 2624);
						AddAlphaRegion(180, 10, 230, 480);
						
						AddButton(12, 140, 4006, 4006, (int)Buttons.Button5, GumpButtonType.Reply, 0);//bush
						
						AddLabel(205, 13, 1153, @"Focus Attack");
                        AddLabel(205, 43, 1153, @"Death Strike ");
                        AddLabel(205, 73, 1153, @"Animal Form");
                        AddLabel(205, 103, 1153, @"Ki Attack ");
                        AddLabel(205, 133, 1153, @"Surprise Attack");
                        AddLabel(205, 163, 1153, @"Backstab");
                        AddLabel(205, 193, 1153, @"Shadowjump");
                        AddLabel(205, 223, 1153, @"Mirror Image");
						
						
						
						
						
                        if (mI01DeathStrike == 1 ) { this.AddButton( 190, 50,  2361, 2361, (int)Buttons.Button105, GumpButtonType.Reply, 1); }
                        if (mI01DeathStrike == 0 ) { this.AddButton( 190, 50,  2360, 2360, (int)Buttons.Button105, GumpButtonType.Reply, 1); }

                        if (mI02AnimalForm == 1 ) { this.AddButton( 190, 80,  2361, 2361, (int)Buttons.Button106, GumpButtonType.Reply, 1); }
                        if (mI02AnimalForm == 0 ) { this.AddButton( 190, 80,  2360, 2360, (int)Buttons.Button106, GumpButtonType.Reply, 1); }

                        if (mI03KiAttack == 1 ) { this.AddButton( 190, 110,  2361, 2361, (int)Buttons.Button107, GumpButtonType.Reply, 1); }
                        if (mI03KiAttack == 0 ) { this.AddButton( 190, 110,  2360, 2360, (int)Buttons.Button107, GumpButtonType.Reply, 1); }

                        if (mI04SurpriseAttack == 1 ) { this.AddButton( 190, 140,  2361, 2361, (int)Buttons.Button108, GumpButtonType.Reply, 1); }
                        if (mI04SurpriseAttack == 0 ) { this.AddButton( 190, 140,  2360, 2360, (int)Buttons.Button108, GumpButtonType.Reply, 1); }

                        if (mI05Backstab == 1 ) { this.AddButton( 190, 170,  2361, 2361, (int)Buttons.Button109, GumpButtonType.Reply, 1); }
                        if (mI05Backstab == 0 ) { this.AddButton( 190, 170,  2360, 2360, (int)Buttons.Button109, GumpButtonType.Reply, 1); }

                        if (mI06Shadowjump == 1 ) { this.AddButton( 190, 200,  2361, 2361, (int)Buttons.Button110, GumpButtonType.Reply, 1); }
                        if (mI06Shadowjump == 0 ) { this.AddButton( 190, 200,  2360, 2360, (int)Buttons.Button110, GumpButtonType.Reply, 1); }

                        if (mI07MirrorImage == 1 ) { this.AddButton( 190, 230,  2361, 2361, (int)Buttons.Button111, GumpButtonType.Reply, 1); }
                        if (mI07MirrorImage == 0 ) { this.AddButton( 190, 230,  2360, 2360, (int)Buttons.Button111, GumpButtonType.Reply, 1); }
						
						if (mI08FocusAttack == 1 ) { this.AddButton( 190, 20,  2361, 2361, (int)Buttons.Button145, GumpButtonType.Reply, 1); }
                        if (mI08FocusAttack == 0 ) { this.AddButton( 190, 20,  2360, 2360, (int)Buttons.Button145, GumpButtonType.Reply, 1); }

                        break;
                    }    
                case 6: /// spellweaving
                    {
						AddBackground(170, 0, 250, 500, 9200);
						AddImageTiled(180, 10, 230, 480, 2624);
						AddAlphaRegion(180, 10, 230, 480);
					
						AddButton(12, 170, 4006, 4006, (int)Buttons.Button6, GumpButtonType.Reply, 0);//weave
					
						if( HasSpell (from, 600) ) { AddLabel(205, 13, 1153, @"Arcane Circle"); }
						else if ( !HasSpell( from, 600 ) ){ AddLabel(205, 13, 33, @"Arcane Circle"); }
						
                        if( HasSpell (from, 601) ) { AddLabel(205, 43, 1153, @"Gift of Renewal"); }
						else if ( !HasSpell( from, 601 ) ){ AddLabel(205, 43, 33, @"Gift of Renewal"); }
						
                        if( HasSpell (from, 602) ) {  AddLabel(205, 73, 1153, @"Immolating Weapon"); }
						else if ( !HasSpell( from, 602 ) ){  AddLabel(205, 73, 33, @"Immolating Weapon"); }
						
                        if( HasSpell (from, 603) ) {  AddLabel(205, 103, 1153, @"Attune Weapon"); }
						else if ( !HasSpell( from, 603 ) ){  AddLabel(205, 103, 33, @"Attune Weapon"); }
						
                        if( HasSpell (from, 604) ) {  AddLabel(205, 133, 1153, @"Thunderstorm"); }
						else if ( !HasSpell( from, 604 ) ){  AddLabel(205, 133, 33, @"Thunderstorm"); }
						
                        if( HasSpell (from, 605) ) {  AddLabel(205, 163, 1153, @"Nature's Fury"); }
						else if ( !HasSpell( from, 605 ) ){  AddLabel(205, 163, 33, @"Nature's Fury"); }
						
                        if( HasSpell (from, 606) ) {  AddLabel(205, 193, 1153, @"Summon Fey"); }
						else if ( !HasSpell( from, 606 ) ){  AddLabel(205, 193, 33, @"Summon Fey"); }
						
                        if( HasSpell (from, 607) ) { AddLabel(205, 223, 1153, @"Summon Fiend"); }
						else if ( !HasSpell( from, 607 ) ){ AddLabel(205, 223, 33, @"Summon Fiend"); }
						
                        if( HasSpell (from, 608) ) { AddLabel(205, 253, 1153, @"Reapor Form"); }
						else if ( !HasSpell( from, 608 ) ){ AddLabel(205, 253, 33, @"Reapor Form"); }
						
                        if( HasSpell (from, 609) ) {  AddLabel(205, 283, 1153, @"WildfireSpell"); }
						else if ( !HasSpell( from, 609 ) ){  AddLabel(205, 283, 33, @"WildfireSpell"); }
						
                        if( HasSpell (from, 610) ) { AddLabel(205, 313, 1153, @"Essence of Wind"); }
						else if ( !HasSpell( from, 610 ) ){ AddLabel(205, 313, 33, @"Essence of Wind"); }
						
                        if( HasSpell (from, 611) ) {  AddLabel(205, 343, 1153, @"Dryad Allure"); }
						else if ( !HasSpell( from, 611 ) ){  AddLabel(205, 343, 33, @"Dryad Allure"); }
						
                        if( HasSpell (from, 612) ) {  AddLabel(205, 373, 1153, @"Ethereal Voyage"); }
						else if ( !HasSpell( from, 612 ) ){  AddLabel(205, 373, 33, @"Ethereal Voyage"); }
						
                        if( HasSpell (from, 613) ) { AddLabel(205, 403, 1153, @"Word of Death"); }
						else if ( !HasSpell( from, 613 ) ){ AddLabel(205, 403, 33, @"Word of Death"); }
						
                        if( HasSpell (from, 614) ) {  AddLabel(205, 434, 1153, @"Gift of Life"); }
						else if ( !HasSpell( from, 614 ) ){  AddLabel(205, 434, 33, @"Gift of Life"); }
						
                        if( HasSpell (from, 615) ) { AddLabel(205, 463, 1153, @"Arcane Empowerment"); }
						else if ( !HasSpell( from, 615 ) ){ AddLabel(205, 463, 33, @"Arcane Empowerment"); }
						
					 
                        if (mS01ArcaneCircleSpell== 1 ) { this.AddButton( 190, 20,  2361, 2361, (int)Buttons.Button112, GumpButtonType.Reply, 1); }
                        if (mS01ArcaneCircleSpell== 0 ) { this.AddButton( 190, 20,  2360, 2360, (int)Buttons.Button112, GumpButtonType.Reply, 1); }

                        if (mS02GiftOfRenewalSpell== 1 ) { this.AddButton( 190, 50,  2361, 2361, (int)Buttons.Button113, GumpButtonType.Reply, 1); }
                        if (mS02GiftOfRenewalSpell== 0 ) { this.AddButton( 190, 50,  2360, 2360, (int)Buttons.Button113, GumpButtonType.Reply, 1); }

                        if (mS03ImmolatingWeaponSpell== 1 ) { this.AddButton( 190, 80,  2361, 2361, (int)Buttons.Button114, GumpButtonType.Reply, 1); }
                        if (mS03ImmolatingWeaponSpell== 0 ) { this.AddButton( 190, 80,  2360, 2360, (int)Buttons.Button114, GumpButtonType.Reply, 1); }

                        if (mS04AttuneWeaponSpell== 1 ) { this.AddButton( 190, 110,  2361, 2361, (int)Buttons.Button115, GumpButtonType.Reply, 1); }
                        if (mS04AttuneWeaponSpell== 0 ) { this.AddButton( 190, 110,  2360, 2360, (int)Buttons.Button115, GumpButtonType.Reply, 1); }

                        if (mS05ThunderstormSpell== 1 ) { this.AddButton( 190, 140,  2361, 2361, (int)Buttons.Button116, GumpButtonType.Reply, 1); }
                        if (mS05ThunderstormSpell== 0 ) { this.AddButton( 190, 140,  2360, 2360, (int)Buttons.Button116, GumpButtonType.Reply, 1); }

                        if (mS06NatureFurySpell== 1 ) { this.AddButton( 190, 170,  2361, 2361, (int)Buttons.Button117, GumpButtonType.Reply, 1); }
                        if (mS06NatureFurySpell== 0 ) { this.AddButton( 190, 170,  2360, 2360, (int)Buttons.Button117, GumpButtonType.Reply, 1); }

                        if (mS07SummonFeySpell== 1 ) { this.AddButton( 190, 200,  2361, 2361, (int)Buttons.Button118, GumpButtonType.Reply, 1); }
                        if (mS07SummonFeySpell== 0 ) { this.AddButton( 190, 200,  2360, 2360, (int)Buttons.Button118, GumpButtonType.Reply, 1); }

                        if (mS08SummonFiendSpell== 1 ) { this.AddButton( 190, 230,  2361, 2361, (int)Buttons.Button119, GumpButtonType.Reply, 1); }
                        if (mS08SummonFiendSpell== 0 ) { this.AddButton( 190, 230,  2360, 2360, (int)Buttons.Button119, GumpButtonType.Reply, 1); }

                        if (mS09ReaperFormSpell== 1 ) { this.AddButton( 190, 260,  2361, 2361, (int)Buttons.Button120, GumpButtonType.Reply, 1); }
                        if (mS09ReaperFormSpell== 0 ) { this.AddButton( 190, 260,  2360, 2360, (int)Buttons.Button120, GumpButtonType.Reply, 1); }

                        if (mS10WildfireSpell== 1 ) { this.AddButton( 190, 290,  2361, 2361, (int)Buttons.Button121, GumpButtonType.Reply, 1); }
                        if (mS10WildfireSpell== 0 ) { this.AddButton( 190, 290,  2360, 2360, (int)Buttons.Button121, GumpButtonType.Reply, 1); }

                        if (mS11EssenceOfWindSpell== 1 ) { this.AddButton( 190, 320,  2361, 2361, (int)Buttons.Button122, GumpButtonType.Reply, 1); }
                        if (mS11EssenceOfWindSpell== 0 ) { this.AddButton( 190, 320,  2360, 2360, (int)Buttons.Button122, GumpButtonType.Reply, 1); }

                        if (mS12DryadAllureSpell== 1 ) { this.AddButton( 190, 350,  2361, 2361, (int)Buttons.Button123, GumpButtonType.Reply, 1); }
                        if (mS12DryadAllureSpell== 0 ) { this.AddButton( 190, 350,  2360, 2360, (int)Buttons.Button123, GumpButtonType.Reply, 1); }

                        if (mS13EtherealVoyageSpell== 1 ) { this.AddButton( 190, 380,  2361, 2361, (int)Buttons.Button124, GumpButtonType.Reply, 1); }
                        if (mS13EtherealVoyageSpell== 0 ) { this.AddButton( 190, 380,  2360, 2360, (int)Buttons.Button124, GumpButtonType.Reply, 1); }

                        if (mS14WordOfDeathSpell== 1 ) { this.AddButton( 190, 410,  2361, 2361, (int)Buttons.Button125, GumpButtonType.Reply, 1); }
                        if (mS14WordOfDeathSpell== 0 ) { this.AddButton( 190, 410,  2360, 2360, (int)Buttons.Button125, GumpButtonType.Reply, 1); }

                        if (mS15GiftOfLifeSpell== 1 ) { this.AddButton( 190, 440,  2361, 2361, (int)Buttons.Button126, GumpButtonType.Reply, 1); }
                        if (mS15GiftOfLifeSpell== 0 ) { this.AddButton( 190, 440,  2360, 2360, (int)Buttons.Button126, GumpButtonType.Reply, 1); }

                        if (mS16ArcaneEmpowermentSpell== 1 ) { this.AddButton( 190, 470,  2361, 2361, (int)Buttons.Button127, GumpButtonType.Reply, 1); }
                        if (mS16ArcaneEmpowermentSpell== 0 ) { this.AddButton( 190, 470,  2360, 2360, (int)Buttons.Button127, GumpButtonType.Reply, 1); }

                        break;
                    }    
                case 7: /// mysticism
                    {
						AddBackground(170, 0, 250, 500, 9200);
						AddImageTiled(180, 10, 230, 480, 2624);
						AddAlphaRegion(180, 10, 230, 480);
					
						AddButton(12, 200, 4006, 4006, (int)Buttons.Button7, GumpButtonType.Reply, 0);//myst
					
						if( HasSpell (from, 677) ) { AddLabel(205, 13, 1153, @"Nether Bolt"); }
						else if ( !HasSpell( from, 677 ) ){ AddLabel(205, 13, 33, @"Nether Bolt"); }
						
                        if( HasSpell (from, 678) ) { AddLabel(205, 43, 1153, @"Healing Stone"); }
						else if ( !HasSpell( from, 678 ) ){ AddLabel(205, 43, 33, @"Healing Stone"); }
						
                        if( HasSpell (from, 679) ) { AddLabel(205, 73, 1153, @"Purge Magic"); }
						else if ( !HasSpell( from, 679 ) ){ AddLabel(205, 73, 33, @"Purge Magic"); }
						
                        if( HasSpell (from, 680) ) { AddLabel(205, 103, 1153, @"Enchant Spell"); }
						else if ( !HasSpell( from, 680 ) ){ AddLabel(205, 103, 33, @"Enchant Spell"); }
						
                        if( HasSpell (from, 681) ) { AddLabel(205, 133, 1153, @"Sleep"); }
						else if ( !HasSpell( from, 681 ) ){ AddLabel(205, 133, 33, @"Sleep"); }
						
                        if( HasSpell (from, 682) ) { AddLabel(205, 163, 1153, @"Eagle Strike"); }
						else if ( !HasSpell( from, 682 ) ){ AddLabel(205, 163, 33, @"Eagle Strike"); }
						
                        if( HasSpell (from, 683) ) { AddLabel(205, 193, 1153, @"Animated Weapon"); }
						else if ( !HasSpell( from, 683 ) ){ AddLabel(205, 193, 33, @"Animated Weapon"); }
						
                        if( HasSpell (from, 684) ) { AddLabel(205, 223, 1153, @"Stone Form"); }
						else if ( !HasSpell( from, 684 ) ){ AddLabel(205, 223, 33, @"Stone Form"); }
						
                        if( HasSpell (from, 685) ) { AddLabel(205, 253, 1153, @"Spell Trigger"); }
						else if ( !HasSpell( from, 685 ) ){ AddLabel(205, 253, 33, @"Spell Trigger"); }
						
                        if( HasSpell (from, 686) ) { AddLabel(205, 283, 1153, @"Mass Sleep"); }
						else if ( !HasSpell( from, 686 ) ){ AddLabel(205, 283, 33, @"Mass Sleep"); }
						
                        if( HasSpell (from, 687) ) { AddLabel(205, 313, 1153, @"Cleansing Winds"); }
						else if ( !HasSpell( from, 687 ) ){ AddLabel(205, 313, 33, @"Cleansing Winds"); }
						
                        if( HasSpell (from, 688) ) { AddLabel(205, 343, 1153, @"Bombard"); }
						else if ( !HasSpell( from, 688 ) ){ AddLabel(205, 343, 33, @"Bombard"); }
						
                        if( HasSpell (from, 689) ) { AddLabel(205, 373, 1153, @"Spell Plague"); }
						else if ( !HasSpell( from, 689 ) ){ AddLabel(205, 373, 33, @"Spell Plague"); }
						
                        if( HasSpell (from, 690) ) { AddLabel(205, 403, 1153, @"Hail Storm"); }
						else if ( !HasSpell( from, 690 ) ){ AddLabel(205, 403, 33, @"Hail Storm"); }
						
                        if( HasSpell (from, 691) ) { AddLabel(205, 434, 1153, @"Nether Cyclone"); }
						else if ( !HasSpell( from, 691 ) ){ AddLabel(205, 434, 33, @"Nether Cyclone"); }
						
                        if( HasSpell (from, 692) ) { AddLabel(205, 463, 1153, @"Rising Colossus"); }
						else if ( !HasSpell( from, 692 ) ){ AddLabel(205, 463, 33, @"Rising Colossus"); }
						
					
                        if (mM01NetherBoltSpell== 1 ) { this.AddButton( 190, 20,  2361, 2361, (int)Buttons.Button128, GumpButtonType.Reply, 1); }
                        if (mM01NetherBoltSpell== 0 ) { this.AddButton( 190, 20,  2360, 2360, (int)Buttons.Button128, GumpButtonType.Reply, 1); }
						
						if (mM02HealingStoneSpell== 1 ) { this.AddButton( 190, 50,  2361, 2361, (int)Buttons.Button129, GumpButtonType.Reply, 1); }
                        if (mM02HealingStoneSpell== 0 ) { this.AddButton( 190, 50,  2360, 2360, (int)Buttons.Button129, GumpButtonType.Reply, 1); }
						
						if (mM03PurgeMagicSpell== 1 ) { this.AddButton( 190, 80,  2361, 2361, (int)Buttons.Button130, GumpButtonType.Reply, 1); }
                        if (mM03PurgeMagicSpell== 0 ) { this.AddButton( 190, 80,  2360, 2360, (int)Buttons.Button130, GumpButtonType.Reply, 1); }
					
						if (mM04EnchantSpell== 1 ) { this.AddButton( 190, 110,  2361, 2361, (int)Buttons.Button131, GumpButtonType.Reply, 1); }
                        if (mM04EnchantSpell== 0 ) { this.AddButton( 190, 110,  2360, 2360, (int)Buttons.Button131, GumpButtonType.Reply, 1); }
					
						if (mM05SleepSpell== 1 ) { this.AddButton( 190, 140,  2361, 2361, (int)Buttons.Button132, GumpButtonType.Reply, 1); }
                        if (mM05SleepSpell== 0 ) { this.AddButton( 190, 140,  2360, 2360, (int)Buttons.Button132, GumpButtonType.Reply, 1); }
					
						if (mM06EagleStrikeSpell== 1 ) { this.AddButton( 190, 170,  2361, 2361, (int)Buttons.Button133, GumpButtonType.Reply, 1); }
                        if (mM06EagleStrikeSpell== 0 ) { this.AddButton( 190, 170,  2360, 2360, (int)Buttons.Button133, GumpButtonType.Reply, 1); }
					
						if (mM07AnimatedWeaponSpell== 1 ) { this.AddButton( 190, 200,  2361, 2361, (int)Buttons.Button134, GumpButtonType.Reply, 1); }
                        if (mM07AnimatedWeaponSpell== 0 ) { this.AddButton( 190, 200,  2360, 2360, (int)Buttons.Button134, GumpButtonType.Reply, 1); }
					
						if (mM08SpellTriggerSpell== 1 ) { this.AddButton( 190, 230,  2361, 2361, (int)Buttons.Button135, GumpButtonType.Reply, 1); }
                        if (mM08SpellTriggerSpell== 0 ) { this.AddButton( 190, 230,  2360, 2360, (int)Buttons.Button135, GumpButtonType.Reply, 1); }
					
						if (mM09MassSleepSpell== 1 ) { this.AddButton( 190, 260,  2361, 2361, (int)Buttons.Button136, GumpButtonType.Reply, 1); }
                        if (mM09MassSleepSpell== 0 ) { this.AddButton( 190, 260,  2360, 2360, (int)Buttons.Button136, GumpButtonType.Reply, 1); }
					
						if (mM10CleansingWindsSpell== 1 ) { this.AddButton( 190, 290,  2361, 2361, (int)Buttons.Button137, GumpButtonType.Reply, 1); }
                        if (mM10CleansingWindsSpell== 0 ) { this.AddButton( 190, 290,  2360, 2360, (int)Buttons.Button137, GumpButtonType.Reply, 1); }
					
						if (mM11BombardSpell== 1 ) { this.AddButton( 190, 320,  2361, 2361, (int)Buttons.Button138, GumpButtonType.Reply, 1); }
                        if (mM11BombardSpell== 0 ) { this.AddButton( 190, 320,  2360, 2360, (int)Buttons.Button138, GumpButtonType.Reply, 1); }
					
						if (mM12SpellPlagueSpell== 1 ) { this.AddButton( 190, 350,  2361, 2361, (int)Buttons.Button139, GumpButtonType.Reply, 1); }
                        if (mM12SpellPlagueSpell== 0 ) { this.AddButton( 190, 350,  2360, 2360, (int)Buttons.Button139, GumpButtonType.Reply, 1); }
					
						if (mM13HailStormSpell== 1 ) { this.AddButton( 190, 380,  2361, 2361, (int)Buttons.Button140, GumpButtonType.Reply, 1); }
                        if (mM13HailStormSpell== 0 ) { this.AddButton( 190, 380,  2360, 2360, (int)Buttons.Button140, GumpButtonType.Reply, 1); }
					
						if (mM14NetherCycloneSpell== 1 ) { this.AddButton( 190, 410,  2361, 2361, (int)Buttons.Button141, GumpButtonType.Reply, 1); }
                        if (mM14NetherCycloneSpell== 0 ) { this.AddButton( 190, 410,  2360, 2360, (int)Buttons.Button141, GumpButtonType.Reply, 1); }
					
						if (mM15RisingColossusSpell== 1 ) { this.AddButton( 190, 440,  2361, 2361, (int)Buttons.Button142, GumpButtonType.Reply, 1); }
                        if (mM15RisingColossusSpell== 0 ) { this.AddButton( 190, 440,  2360, 2360, (int)Buttons.Button142, GumpButtonType.Reply, 1); }
					
						if (mM16StoneFormSpell== 1 ) { this.AddButton( 190, 470,  2361, 2361, (int)Buttons.Button143, GumpButtonType.Reply, 1); }
                        if (mM16StoneFormSpell== 0 ) { this.AddButton( 190, 470,  2360, 2360, (int)Buttons.Button143, GumpButtonType.Reply, 1); }
					
						break;
                    }    
                case 8://help
                    {
						
						AddBackground(170, 0, 380, 300, 9200);
						//AddButton( 185,268, 2453,2454, 0, GumpButtonType.Reply, 1); // Cancel
						AddHtml( 180, 10, 350, 250, @"<br><H2>SpellBar Help</H2><br><br>Use the Selection Menu to the left to navigate between the different types of magic. You can choose spells from any section, and they will all be combined into one hot bar.<br>*Note: If you do not have a type of spellbook in your pack, you will not be able to select that section and the name will appear in red text. If you have the book but it is missing a certain spell, the missing spell's name will appear red.<br><br>Your selection is limited based on how many Columns and Rows are selected in the Options Menu. Below the Open Hot Bar button, you will see an indicator of how many spells you've selected and how many are allowed based on the current settings for Columns and Rows.<br>To easily reset your selection, click the default button in the Options Menu.<br><br>", (bool)true, (bool)true);    
						
						
						
                        break;
                    }
				case 9: // options
					{
						AddButton(12, 230, 4012, 4012, (int)Buttons.Button148, GumpButtonType.Reply, 0); // options
						
                        AddBackground(170, 0, 570, 350, 9200);
						AddImageTiled(180, 10, 550, 330, 2624);
						AddAlphaRegion(180, 10, 550, 330);
						
						AddButton(190, 20, 246, 244, (int)Buttons.Button147, GumpButtonType.Reply, 0);//reset
						AddLabel(260, 21, 1153, @"Reset selection");
						
						AddHtml( 193, 68, 526, 67, @"<br>The number of spells you can select is limited to how many columns and rows you have selected. If you wish to reset your selection, click the Default button above.<br><br><H2>Columns</H2><br>If the hot bar set to the horizontal position, columns indicate how many buttons will stretch from left to right.<br>If it's in the vertical position, columns indicate how many buttons will stretch up and down.<br><br><H2>Rows</H2><br>If the hot bar is in a horizontal position, rows indicate how many buttons will stretch up and down.<br>If it is in a vertical position, it indciates how many buttons stretch from left to right.<br><br>Example: If you choose 10 columns and 2 rows and then select only 10 spells, you'll only see one row of 10. However if you choose between 11 and 20 spells, you'll see the 11th spell drop down into a second row.<br><br>", (bool)true, (bool)true); 
			//////////////////////		
						
						if( m_Scroll.Open == 1 )
						{
							this.AddButton( 215, 155,  211, 211, (int)Buttons.Button158, GumpButtonType.Reply, 1);
						}
						if( m_Scroll.Open == 0 )
						{
							this.AddButton( 215, 155,  210, 210, (int)Buttons.Button158, GumpButtonType.Reply, 1);
						}
						
						AddLabel(240, 153, 1153, @"Auto-open on login");
						
						this.AddButton( 475, 158,  2362, 2361, (int)Buttons.Button159, GumpButtonType.Reply, 1);
						AddLabel(497, 153, 1153, @"Set hotbar screen location");

			/////////////////
						AddLabel(395, 204, 1153, @"Columns");
						
						AddLabel(236, 228, 1153, @"10");
						AddLabel(336, 228, 1153, @"15");
						AddLabel(436, 228, 1153, @"20");
						AddLabel(536, 228, 1153, @"30");
						
						if (mXselect_10== 1 ) { this.AddButton( 214, 233,  2361, 2361, (int)Buttons.Button149, GumpButtonType.Reply, 1); }
                        if (mXselect_10== 0 ) { this.AddButton( 214, 233,  2360, 2360, (int)Buttons.Button149, GumpButtonType.Reply, 1); }
						
						if (mXselect_15== 1 ) { this.AddButton( 314, 233,  2361, 2361, (int)Buttons.Button150, GumpButtonType.Reply, 1); }
                        if (mXselect_15== 0 ) { this.AddButton( 314, 233,  2360, 2360, (int)Buttons.Button150, GumpButtonType.Reply, 1); }
						
						if (mXselect_20== 1 ) { this.AddButton( 414, 233,  2361, 2361, (int)Buttons.Button151, GumpButtonType.Reply, 1); }
                        if (mXselect_20== 0 ) { this.AddButton( 414, 233,  2360, 2360, (int)Buttons.Button151, GumpButtonType.Reply, 1); }
						
						if (mXselect_30== 1 ) { this.AddButton( 514, 233,  2361, 2361, (int)Buttons.Button152, GumpButtonType.Reply, 1); }
                        if (mXselect_30== 0 ) { this.AddButton( 514, 233,  2360, 2360, (int)Buttons.Button152, GumpButtonType.Reply, 1); }
						
			///////////////////////
						AddImageTiled(209, 258, 490, 1, 2624);
			//////////////////////////	   
						AddLabel(403, 265, 1153, @"Rows");
						
						AddLabel(236, 289, 1153, @"1");
						AddLabel(336, 289, 1153, @"2");
						AddLabel(436, 289, 1153, @"3");
						AddLabel(536, 289, 1153, @"4");
						
						if (mYselect_1 == 1 ) { this.AddButton( 214, 294,  2361, 2361, (int)Buttons.Button153, GumpButtonType.Reply, 1); }
                        if (mYselect_1 == 0 ) { this.AddButton( 214, 294,  2360, 2360, (int)Buttons.Button153, GumpButtonType.Reply, 1); }
						
						if (mYselect_2== 1 ) { this.AddButton( 314, 294,  2361, 2361, (int)Buttons.Button154, GumpButtonType.Reply, 1); }
                        if (mYselect_2== 0 ) { this.AddButton( 314, 294,  2360, 2360, (int)Buttons.Button154, GumpButtonType.Reply, 1); }
						
						if (mYselect_3== 1 ) { this.AddButton( 414, 294,  2361, 2361, (int)Buttons.Button155, GumpButtonType.Reply, 1); }
                        if (mYselect_3== 0 ) { this.AddButton( 414, 294,  2360, 2360, (int)Buttons.Button155, GumpButtonType.Reply, 1); }
						
						if (mYselect_4== 1 ) { this.AddButton( 514, 294,  2361, 2361, (int)Buttons.Button156, GumpButtonType.Reply, 1); }
                        if (mYselect_4== 0 ) { this.AddButton( 514, 294,  2360, 2360, (int)Buttons.Button156, GumpButtonType.Reply, 1); }
			
			
						break;
					}
					case 10:
					{
						//AddBackground(170, 0, 250, 500, 9200);
						//AddImageTiled(180, 10, 230, 480, 2624);
						//AddLabel( 25, 336, 1153, "You have selected" );
			//AddLabel( 35, 356, 1153, String.Format("{0} of {1} spells", mCount, xselect_num * yselect_var ) );
						
						//AddAlphaRegion(170, 0, 375, 425);
						AddBackground(170, 0, 358, 338, 9200);
						AddHtml( 180, 10, 328, 220, @"<br>You have selected too many spells.<br><br>Please reduce the number of spells chosen or increase the size of the hot bar in the Options Menu.<br><br>Check the readout to the left to see how many spells are currently chosen and how many are currently allowed.<br>To easily reset your selection, click the default button in the Options Menu.<br><br>", (bool)true, (bool)true); 
						
						
						AddButton(180, 300, 247, 249, (int)Buttons.Button157, GumpButtonType.Reply, 0); // options
						
						break;
					}
					
					
            }
        }
       

        public enum Buttons { Button0, Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Button10, Button11, Button12, Button13, Button14, Button15, Button16, Button17, Button18, Button19, Button20, Button21, Button22, Button23, Button24, Button25, Button26, Button27, Button28, Button29, Button30, Button31, Button32, Button33, Button34, Button35, Button36, Button37, Button38, Button39, Button40, Button41, Button42, Button43, Button44, Button45, Button46, Button47, Button48, Button49, Button50, Button51, Button52, Button53, Button54, Button55, Button56, Button57, Button58, Button59, Button60, Button61, Button62, Button63, Button64, Button65, Button66, Button67, Button68, Button69, Button70, Button71, Button72, Button73, Button74, Button75, Button76, Button77, Button78, Button79, Button80, Button81, Button82, Button83, Button84, Button85, Button86, Button87, Button88, Button89, Button90, Button91, Button92, Button93, Button94, Button95, Button96, Button97, Button98, Button99, Button100, Button101, Button102, Button103, Button104, Button105, Button106, Button107, Button108, Button109, Button110, Button111, Button112, Button113, Button114, Button115, Button116, Button117, Button118, Button119, Button120, Button121, Button122, Button123, Button124, Button125, Button126, Button127, Button128, Button129, Button130, Button131, Button132, Button133, Button134, Button135, Button136, Button137, Button138, Button139, Button140, Button141, Button142, Button143, Button144, Button145, Button146, Button147, Button148, Button149, Button150, Button151, Button152, Button153, Button154, Button155, Button156, Button157, Button158, Button159 }


        public override void OnResponse( NetState sender, RelayInfo info )
        {
            Mobile from = sender.Mobile;
        

            switch(info.ButtonID)
            {
                case (int)Buttons.Button0://cancel
                    {
                        from.CloseGump( typeof( SpellBarGump ) );
                        break;
                    }
                case (int)Buttons.Button1://magery
                    {
                         
                        page = 1;
                        from.SendGump(new SpellBarGump(from, page, m_Scroll));
                        break;
                    }
                case (int)Buttons.Button2://necromancy
                {
                     
                    page = 2;
                    from.SendGump(new SpellBarGump(from, page, m_Scroll ));
                    break;
                }
                case (int)Buttons.Button3://chivalry
                {
                     
                    page = 3;
                    from.SendGump(new SpellBarGump(from, page, m_Scroll ));
                    break;
                }
                case (int)Buttons.Button4://ninjitsu
                {
                     
                    page = 4;
                    from.SendGump(new SpellBarGump(from, page, m_Scroll ));
                    break;
                }
                case (int)Buttons.Button5://bushido
                {
                     
                    page = 5;
                    from.SendGump(new SpellBarGump(from, page, m_Scroll ));
                    break;
                }
                case (int)Buttons.Button6://spellweaver
                {
                     
                    page = 6;
                    from.SendGump(new SpellBarGump(from, page, m_Scroll ));
                    break;
                }
                case (int)Buttons.Button7://mysticism
                {
                     
                    page = 7;
                    from.SendGump(new SpellBarGump(from, page, m_Scroll ));
                    break;
                }
                case (int)Buttons.Button8://send to spellbar_bargump
                {
					int mCount = m_Scroll.Count;
					int yselect_var = 0; //xselect_var = 0;
					int xselect_num = 0;
					
					
					if ( m_Scroll.Xselect_10 == 1) { xselect_num = 10; } 
					if ( m_Scroll.Xselect_15 == 1) { xselect_num = 15; } 
					if ( m_Scroll.Xselect_20 == 1) { xselect_num = 20; } 
					if ( m_Scroll.Xselect_30 == 1) { xselect_num = 30; }
					if ( m_Scroll.Yselect_1 == 1) { yselect_var = 1; }
					if ( m_Scroll.Yselect_2 == 1) { yselect_var = 2; }
					if ( m_Scroll.Yselect_3 == 1) { yselect_var = 3; }
					if ( m_Scroll.Yselect_4 == 1) { yselect_var = 4; }
				
					if ( mCount > xselect_num * yselect_var )
					{
						 
						page = 10;
						from.SendGump(new SpellBarGump(from, page, m_Scroll ));
					}
					else
					{
						 int dbx = 0; //dbx = 50;
		 int dbxa = 0; //dbxa = 45;
		 int dby = 0; //dby = 5;
		 int dbya = 0; //dbya = 0;
		// int xselect_var = 0; //xselect_var = 0;  //dbx = 50;
		int xo = m_Scroll.Xo;
		int yo = m_Scroll.Yo;
						
						
						
						from.CloseGump( typeof( SpellBarGump ) );
						from.CloseGump( typeof( SpellBar_BarGump ) );
						from.SendGump(new SpellBar_BarGump(from, m_Scroll, m_Scroll.Xo, m_Scroll.Yo ));
						
					}
                    break;
                }
                case (int)Buttons.Button9://clumsy
                {
                     
                    page = 1;
                    //from.SendGump(new SpellBarGump(from, page, m_Scroll ));
                    if ( m_Scroll.W00_ClumsySpell == 0 ) { m_Scroll.W00_ClumsySpell = 1; m_Scroll.Count += 1;}
                   
                    else { m_Scroll.W00_ClumsySpell = 0;  m_Scroll.Count -= 1; }
					
                   
                    from.SendGump( new SpellBarGump ( from, page, m_Scroll ) );
           
                    break;
                }
                case (int)Buttons.Button10:
                {
                     
                    page = 1;
                    if ( m_Scroll.W01_CreateFoodSpell == 0 ) { m_Scroll.W01_CreateFoodSpell = 1; m_Scroll.Count += 1; }
                   
                    else { m_Scroll.W01_CreateFoodSpell = 0; m_Scroll.Count -= 1; }
                   
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button11:
                {
                     
                    page = 1;
                   if ( m_Scroll.W02_FeeblemindSpell == 0 ) { m_Scroll.W02_FeeblemindSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W02_FeeblemindSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button12:
                {
                     
                    page = 1;
                   if ( m_Scroll.W03_HealSpell == 0 ) { m_Scroll.W03_HealSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W03_HealSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button13:
                {
                     
                    page = 1;
                    if ( m_Scroll.W04_MagicArrowSpell == 0 ) { m_Scroll.W04_MagicArrowSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W04_MagicArrowSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button14:
                {
                     
                    page = 1;
                    if ( m_Scroll.W05_NightSightSpell == 0 ) { m_Scroll.W05_NightSightSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W05_NightSightSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button15:
                {
                     
                    page = 1;
                    if ( m_Scroll.W06_ReactiveArmorSpell == 0 ) { m_Scroll.W06_ReactiveArmorSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W06_ReactiveArmorSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button16:
                {
                     
                    page = 1;
                    if ( m_Scroll.W07_WeakenSpell == 0 ) { m_Scroll.W07_WeakenSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W07_WeakenSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
        ///        
                case (int)Buttons.Button17:
                {
                     
                    page = 1;
                    if ( m_Scroll.W08_AgilitySpell == 0 ) { m_Scroll.W08_AgilitySpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W08_AgilitySpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button18:
                {
                     
                    page = 1;
                    if ( m_Scroll.W09_CunningSpell == 0 ) { m_Scroll.W09_CunningSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W09_CunningSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button19:
                {
                     
                    page = 1;
                    if ( m_Scroll.W10_CureSpell == 0 ) { m_Scroll.W10_CureSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W10_CureSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button20:
                {
                     
                    page = 1;
                    if ( m_Scroll.W11_HarmSpell == 0 ) { m_Scroll.W11_HarmSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W11_HarmSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button21:
                {
                     
                    page = 1;
                    if ( m_Scroll.W12_MagicTrapSpell == 0 ) { m_Scroll.W12_MagicTrapSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W12_MagicTrapSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button22:
                {
                     
                    page = 1;
                    if ( m_Scroll.W13_RemoveTrapSpell == 0 ) { m_Scroll.W13_RemoveTrapSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W13_RemoveTrapSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button23:
                {
                     
                    page = 1;
                   if ( m_Scroll.W14_ProtectionSpell == 0 ) { m_Scroll.W14_ProtectionSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W14_ProtectionSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button24:
                {
                     
                    page = 1;
                    if ( m_Scroll.W15_StrengthSpell == 0 ) { m_Scroll.W15_StrengthSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W15_StrengthSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
        // row 2
                case (int)Buttons.Button25://
                {
                     
                    page = 1;
                    if ( m_Scroll.W16_BlessSpell == 0 ) { m_Scroll.W16_BlessSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W16_BlessSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button26://
                {
                     
                    page = 1;
                    if ( m_Scroll.W17_FireballSpell == 0 ) { m_Scroll.W17_FireballSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W17_FireballSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button27://
                {
                     
                    page = 1;
                    if ( m_Scroll.W18_MagicLockSpell == 0 ) { m_Scroll.W18_MagicLockSpell = 1; m_Scroll.Count += 1; }
					else { m_Scroll.W18_MagicLockSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button28://
                {
                     
                    page = 1;
                        if ( m_Scroll.W19_PoisonSpell == 0 ) { m_Scroll.W19_PoisonSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W19_PoisonSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button29://
                {
                     
                    page = 1;
                    if ( m_Scroll.W20_TelekinesisSpell == 0 ) { m_Scroll.W20_TelekinesisSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W20_TelekinesisSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button30://
                {
                     
                    page = 1;
                    if ( m_Scroll.W21_TeleportSpell == 0 ) { m_Scroll.W21_TeleportSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W21_TeleportSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button31://
                {
                     
                    page = 1;
                    if ( m_Scroll.W22_UnlockSpell == 0 ) { m_Scroll.W22_UnlockSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W22_UnlockSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button32://
                {
                     
                    page = 1;
                    if ( m_Scroll.W23_WallOfStoneSpell == 0 ) { m_Scroll.W23_WallOfStoneSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W23_WallOfStoneSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button33://
                {
                     
                    page = 1;
                    if ( m_Scroll.W24_ArchCureSpell == 0 ) { m_Scroll.W24_ArchCureSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W24_ArchCureSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button34://
                {
                     
                    page = 1;
                    if ( m_Scroll.W25_ArchProtectionSpell == 0 ) { m_Scroll.W25_ArchProtectionSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W25_ArchProtectionSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button35://
                {
                     
                    page = 1;
                    if ( m_Scroll.W26_CurseSpell == 0 ) { m_Scroll.W26_CurseSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W26_CurseSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button36://
                {
                     
                    page = 1;
                    if ( m_Scroll.W27_FireFieldSpell == 0 ) { m_Scroll.W27_FireFieldSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W27_FireFieldSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button37://
                {
                     
                    page = 1;
                    if ( m_Scroll.W28_GreaterHealSpell == 0 ) { m_Scroll.W28_GreaterHealSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W28_GreaterHealSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button38://
                {
                     
                    page = 1;
                    if ( m_Scroll.W29_LightningSpell == 0 ) { m_Scroll.W29_LightningSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W29_LightningSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button39://
                {
                     
                    page = 1;
                    if ( m_Scroll.W30_ManaDrainSpell == 0 ) { m_Scroll.W30_ManaDrainSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W30_ManaDrainSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button40://
                {
                     
                    page = 1;
                    if ( m_Scroll.W31_RecallSpell == 0 ) { m_Scroll.W31_RecallSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W31_RecallSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
                    break;
                }
    /// 3rd row
                case (int)Buttons.Button41:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W32_BladeSpiritsSpell == 0 ) { m_Scroll.W32_BladeSpiritsSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W32_BladeSpiritsSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button42:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W33_DispelFieldSpell == 0 ) { m_Scroll.W33_DispelFieldSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W33_DispelFieldSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button43:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W34_IncognitoSpell == 0 ) { m_Scroll.W34_IncognitoSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W34_IncognitoSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button44:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W35_MagicReflectSpell == 0 ) { m_Scroll.W35_MagicReflectSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W35_MagicReflectSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button45:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W36_MindBlastSpell == 0 ) { m_Scroll.W36_MindBlastSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W36_MindBlastSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button46:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W37_ParalyzeSpell == 0 ) { m_Scroll.W37_ParalyzeSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W37_ParalyzeSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button47:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W38_PoisonFieldSpell == 0 ) { m_Scroll.W38_PoisonFieldSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W38_PoisonFieldSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button48:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W39_SummonCreatureSpell == 0 ) { m_Scroll.W39_SummonCreatureSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W39_SummonCreatureSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button49:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W40_DispelSpell == 0 ) { m_Scroll.W40_DispelSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W40_DispelSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button50:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W41_EnergyBoltSpell == 0 ) { m_Scroll.W41_EnergyBoltSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W41_EnergyBoltSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                break;
                 
                }
                case (int)Buttons.Button51:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W42_ExplosionSpell == 0 ) { m_Scroll.W42_ExplosionSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W42_ExplosionSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button52:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W43_InvisibilitySpell == 0 ) { m_Scroll.W43_InvisibilitySpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W43_InvisibilitySpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button53:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W44_MarkSpell == 0 ) { m_Scroll.W44_MarkSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W44_MarkSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button54:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W45_MassCurseSpell == 0 ) { m_Scroll.W45_MassCurseSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W45_MassCurseSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button55:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W46_ParalyzeFieldSpell == 0 ) { m_Scroll.W46_ParalyzeFieldSpell = 1; m_Scroll.Count += 1; }
                else { m_Scroll.W46_ParalyzeFieldSpell = 0; m_Scroll.Count -= 1; }
                from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button56:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W47_RevealSpell == 0 ) { m_Scroll.W47_RevealSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W47_RevealSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
               
    ///3rd row end
                case (int)Buttons.Button57:
                {
                     
                    page = 1;
                    if ( m_Scroll.W48_ChainLightningSpell == 0 ) { m_Scroll.W48_ChainLightningSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W48_ChainLightningSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
               
                case (int)Buttons.Button58:///
                {
                     
                    page = 1;
                    if ( m_Scroll.W49_EnergyFieldSpell == 0 ) { m_Scroll.W49_EnergyFieldSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W49_EnergyFieldSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button59:
                {
                     
                    page = 1;
                    if ( m_Scroll.W50_FlameStrikeSpell == 0 ) { m_Scroll.W50_FlameStrikeSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W50_FlameStrikeSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button60:
                {
                     
                    page = 1;
                    if ( m_Scroll.W51_GateTravelSpell == 0 ) { m_Scroll.W51_GateTravelSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W51_GateTravelSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button61:
                {
                     
                    page = 1;
                    if ( m_Scroll.W52_ManaVampireSpell == 0 ) { m_Scroll.W52_ManaVampireSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W52_ManaVampireSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button62:
                {
                     
                    page = 1;
                    if ( m_Scroll.W53_MassDispelSpell == 0 ) { m_Scroll.W53_MassDispelSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W53_MassDispelSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button63:
                {
                     
                    page = 1;
                    if ( m_Scroll.W54_MeteorSwarmSpell == 0 ) { m_Scroll.W54_MeteorSwarmSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W54_MeteorSwarmSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button64:
                {
                     
                    page = 1;
                    if ( m_Scroll.W55_PolymorphSpell == 0 ) { m_Scroll.W55_PolymorphSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W55_PolymorphSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button65:
                {
                     
                    page = 1;
                    if ( m_Scroll.W56_EarthquakeSpell == 0 ) { m_Scroll.W56_EarthquakeSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W56_EarthquakeSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button66:
                {
                     
                    page = 1;
                    if ( m_Scroll.W57_EnergyVortexSpell == 0 ) { m_Scroll.W57_EnergyVortexSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W57_EnergyVortexSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button67:
                {
                     
                    page = 1;
                    if ( m_Scroll.W58_ResurrectionSpell == 0 ) { m_Scroll.W58_ResurrectionSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W58_ResurrectionSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button68:
                {
                     
                    page = 1;
                    if ( m_Scroll.W59_AirElementalSpell == 0 ) { m_Scroll.W59_AirElementalSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W59_AirElementalSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button69:
                {
                     
                    page = 1;
                    if ( m_Scroll.W60_SummonDaemonSpell == 0 ) { m_Scroll.W60_SummonDaemonSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W60_SummonDaemonSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button70:
                {
                     
                    page = 1;
                    if ( m_Scroll.W61_EarthElementalSpell == 0 ) { m_Scroll.W61_EarthElementalSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W61_EarthElementalSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button71:
                {
                     
                    page = 1;
                    if ( m_Scroll.W62_FireElementalSpell == 0 ) { m_Scroll.W62_FireElementalSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W62_FireElementalSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
                case (int)Buttons.Button72:
                {
                     
                    page = 1;
                    if ( m_Scroll.W63_WaterElementalSpell == 0 ) { m_Scroll.W63_WaterElementalSpell = 1; m_Scroll.Count += 1; }
                    else { m_Scroll.W63_WaterElementalSpell = 0; m_Scroll.Count -= 1; }
                    from.SendGump( new SpellBarGump( from, page,  m_Scroll ) );
                    break;
                }
				
	/// necromancy
                case (int)Buttons.Button73 : {  
                    page = 2; { if ( m_Scroll.N01AnimateDeadSpell == 0 ) { m_Scroll.N01AnimateDeadSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N01AnimateDeadSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; } }
                case (int)Buttons.Button74 : { 
                    page = 2;  { if ( m_Scroll.N02BloodOathSpell == 0 ) { m_Scroll.N02BloodOathSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N02BloodOathSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; } }
                case (int)Buttons.Button75 : { 
                    page = 2;  { if ( m_Scroll.N03CorpseSkinSpell == 0 ) { m_Scroll.N03CorpseSkinSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N03CorpseSkinSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; } }
                case (int)Buttons.Button76 : { 
                    page = 2;  { if ( m_Scroll.N04CurseWeaponSpell == 0 ) { m_Scroll.N04CurseWeaponSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N04CurseWeaponSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button77 : { 
                    page = 2;  { if ( m_Scroll.N05EvilOmenSpell == 0 ) { m_Scroll.N05EvilOmenSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N05EvilOmenSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; } }
                case (int)Buttons.Button78 : {  
                    page = 2;  { if ( m_Scroll.N06HorrificBeastSpell == 0 ) { m_Scroll.N06HorrificBeastSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N06HorrificBeastSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; } }
                case (int)Buttons.Button79 : { 
                    page = 2;  { if ( m_Scroll.N07LichFormSpell == 0 ) { m_Scroll.N07LichFormSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N07LichFormSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; } }
                case (int)Buttons.Button80 : { 
                    page = 2;  { if ( m_Scroll.N08MindRotSpell == 0 ) { m_Scroll.N08MindRotSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N08MindRotSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button81 : { 
                    page = 2;  { if ( m_Scroll.N09PainSpikeSpell == 0 ) { m_Scroll.N09PainSpikeSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N09PainSpikeSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button82 :{  
                    page = 2;  { if ( m_Scroll.N10PoisonStrikeSpell == 0 ) { m_Scroll.N10PoisonStrikeSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N10PoisonStrikeSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button83 : { 
                    page = 2;  { if ( m_Scroll.N11StrangleSpell == 0 ) { m_Scroll.N11StrangleSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N11StrangleSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button84 : { 
                    page = 2;  { if ( m_Scroll.N12SummonFamiliarSpell == 0 ) { m_Scroll.N12SummonFamiliarSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N12SummonFamiliarSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button85 : { 
                    page = 2;  { if ( m_Scroll.N13VampiricEmbraceSpell == 0 ) { m_Scroll.N13VampiricEmbraceSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N13VampiricEmbraceSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button86 : { 
                    page = 2;  { if ( m_Scroll.N14VengefulSpiritSpell == 0 ) { m_Scroll.N14VengefulSpiritSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N14VengefulSpiritSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button87 : { 
                    page = 2;  { if ( m_Scroll.N15WitherSpell == 0 ) { m_Scroll.N15WitherSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N15WitherSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }}
                case (int)Buttons.Button88 : { 
                    page = 2;  { if ( m_Scroll.N16WraithFormSpell == 0 ) { m_Scroll.N16WraithFormSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N16WraithFormSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }    }
               
				case (int)Buttons.Button89 : { 
                    page = 2;  { if ( m_Scroll.N17ExorcismSpell == 0 ) { m_Scroll.N17ExorcismSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.N17ExorcismSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }    }

    // CHIVALRY
                
				case (int)Buttons.Button90 : {  
                    page = 3;  { if ( m_Scroll.C01CleanseByFireSpell == 0 ) { m_Scroll.C01CleanseByFireSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C01CleanseByFireSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button91 : {  
                    page = 3;  { if ( m_Scroll.C02CloseWoundsSpell == 0 ) { m_Scroll.C02CloseWoundsSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C02CloseWoundsSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ) ;break; } }
                case (int)Buttons.Button92 : {  
                    page = 3;  { if ( m_Scroll.C03ConsecrateWeaponSpell == 0 ) { m_Scroll.C03ConsecrateWeaponSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C03ConsecrateWeaponSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button93 : {  
                    page = 3;  { if ( m_Scroll.C04DispelEvilSpell == 0 ) { m_Scroll.C04DispelEvilSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C04DispelEvilSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button94 : {  
                    page = 3;   { if ( m_Scroll.C05DivineFurySpell == 0 ) { m_Scroll.C05DivineFurySpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C05DivineFurySpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button95 : {  
                    page = 3;   { if ( m_Scroll.C06EnemyOfOneSpell == 0 ) { m_Scroll.C06EnemyOfOneSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C06EnemyOfOneSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button96 : {  
                    page = 3;   { if ( m_Scroll.C07HolyLightSpell == 0 ) { m_Scroll.C07HolyLightSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C07HolyLightSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button97 : {  
                    page = 3;   { if ( m_Scroll.C08NobleSacrificeSpell == 0 ) { m_Scroll.C08NobleSacrificeSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C08NobleSacrificeSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button98 : {  
                    page = 3;   { if ( m_Scroll.C09RemoveCurseSpell == 0 ) { m_Scroll.C09RemoveCurseSpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C09RemoveCurseSpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button99 : {  
                    page = 3;   { if ( m_Scroll.C10SacredJourneySpell == 0 ) { m_Scroll.C10SacredJourneySpell = 1; m_Scroll.Count += 1; } else { m_Scroll.C10SacredJourneySpell = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
// BUSHIDO

				case (int)Buttons.Button100 : { 
                    page = 4;  { if ( m_Scroll.B01Confidence == 0 ) { m_Scroll.B01Confidence = 1; m_Scroll.Count += 1; } else { m_Scroll.B01Confidence = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }    }

				case (int)Buttons.Button101 : { 
                    page = 4;  { if ( m_Scroll.B02CounterAttack == 0 ) { m_Scroll.B02CounterAttack = 1; m_Scroll.Count += 1; } else { m_Scroll.B02CounterAttack = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }    }

				case (int)Buttons.Button102 : { 
                    page = 4;  { if ( m_Scroll.B03Evasion == 0 ) { m_Scroll.B03Evasion = 1; m_Scroll.Count += 1; } else { m_Scroll.B03Evasion = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }    }

				case (int)Buttons.Button103 : { 
                    page = 4;  { if ( m_Scroll.B04LightningStrike == 0 ) { m_Scroll.B04LightningStrike = 1; m_Scroll.Count += 1; } else { m_Scroll.B04LightningStrike = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }    }

				case (int)Buttons.Button104 : { 
                    page = 4;  { if ( m_Scroll.B05MomentumStrike == 0 ) { m_Scroll.B05MomentumStrike = 1; m_Scroll.Count += 1; } else { m_Scroll.B05MomentumStrike = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); break; }    }
			/*		
				case (int)Buttons.Button144 : 
				{
					 
                    page = 4;  
					{ 
						if ( m_Scroll.B06HonorableExecution == 0 ) 
						{ 
							m_Scroll.B06HonorableExecution = 1; m_Scroll.Count += 1; 
						} 
						else 
						{ 
							m_Scroll.B06HonorableExecution = 0; 
						} 
						from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); 
						break; 
					}    
				}
			*/		
					
// NINJITSU
                case (int)Buttons.Button105 : 
				{ 
					 
                    page = 5;   
					{ 
						if ( m_Scroll.I01DeathStrike == 0 ) 
						{ 
							m_Scroll.I01DeathStrike = 1; 
							m_Scroll.Count += 1; 
						} 
						else 
						{ 
							m_Scroll.I01DeathStrike = 0;
							m_Scroll.Count -= 1;
						} 
						from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); 
						break; 
					} 
				}
                case (int)Buttons.Button106: {  
                    page = 5;   { if ( m_Scroll.I02AnimalForm == 0 ) { m_Scroll.I02AnimalForm = 1; m_Scroll.Count += 1; } else { m_Scroll.I02AnimalForm = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button107: {  
                    page = 5;   { if ( m_Scroll.I03KiAttack == 0 ) { m_Scroll.I03KiAttack = 1; m_Scroll.Count += 1; } else { m_Scroll.I03KiAttack = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button108: {  
                    page = 5;   { if ( m_Scroll.I04SurpriseAttack == 0 ) { m_Scroll.I04SurpriseAttack = 1; m_Scroll.Count += 1; } else { m_Scroll.I04SurpriseAttack = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button109: {  
                    page = 5;   { if ( m_Scroll.I05Backstab == 0 ) { m_Scroll.I05Backstab = 1; m_Scroll.Count += 1; } else { m_Scroll.I05Backstab = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button110: {  
                    page = 5;   { if ( m_Scroll.I06Shadowjump == 0 ) { m_Scroll.I06Shadowjump = 1; m_Scroll.Count += 1; } else { m_Scroll.I06Shadowjump = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button111: {  
                    page = 5;   { if ( m_Scroll.I07MirrorImage == 0 ) { m_Scroll.I07MirrorImage = 1; m_Scroll.Count += 1; } else { m_Scroll.I07MirrorImage = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				/*
				case (int)Buttons. Button145: {  
                    page = 5;   { if ( m_Scroll.I08FocusAttack == 0 ) { m_Scroll.I08FocusAttack = 1; m_Scroll.Count += 1; } else { m_Scroll.I08FocusAttack = 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				*/
					
// SPELLWEAVING
                case (int)Buttons.Button112 : {  
                    page = 6;   { if ( m_Scroll.S01ArcaneCircleSpell== 0 ) { m_Scroll.S01ArcaneCircleSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S01ArcaneCircleSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button113 : {  
                    page = 6;   { if ( m_Scroll.S02GiftOfRenewalSpell== 0 ) { m_Scroll.S02GiftOfRenewalSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S02GiftOfRenewalSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button114 : {  
                    page = 6;   { if ( m_Scroll.S03ImmolatingWeaponSpell== 0 ) { m_Scroll.S03ImmolatingWeaponSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S03ImmolatingWeaponSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button115 : {  
                    page = 6;   { if ( m_Scroll.S04AttuneWeaponSpell== 0 ) { m_Scroll.S04AttuneWeaponSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S04AttuneWeaponSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button116 : {  
                    page = 6;   { if ( m_Scroll.S05ThunderstormSpell== 0 ) { m_Scroll.S05ThunderstormSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S05ThunderstormSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button117 : {  
                    page = 6;   { if ( m_Scroll.S06NatureFurySpell== 0 ) { m_Scroll.S06NatureFurySpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S06NatureFurySpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button118 : {  
                    page = 6;   { if ( m_Scroll.S07SummonFeySpell== 0 ) { m_Scroll.S07SummonFeySpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S07SummonFeySpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button119 : {  
                    page = 6;   { if ( m_Scroll.S08SummonFiendSpell== 0 ) { m_Scroll.S08SummonFiendSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S08SummonFiendSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button120 : {  
                    page = 6;   { if ( m_Scroll.S09ReaperFormSpell== 0 ) { m_Scroll.S09ReaperFormSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S09ReaperFormSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button121 : {  
                    page = 6;   { if ( m_Scroll.S10WildfireSpell== 0 ) { m_Scroll.S10WildfireSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S10WildfireSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button122 : {  
                    page = 6;   { if ( m_Scroll.S11EssenceOfWindSpell== 0 ) { m_Scroll.S11EssenceOfWindSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S11EssenceOfWindSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button123 : {  
                    page = 6;   { if ( m_Scroll.S12DryadAllureSpell== 0 ) { m_Scroll.S12DryadAllureSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S12DryadAllureSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button124 : {  
                    page = 6;   { if ( m_Scroll.S13EtherealVoyageSpell== 0 ) { m_Scroll.S13EtherealVoyageSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S13EtherealVoyageSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button125 : {  
                    page = 6;   { if ( m_Scroll.S14WordOfDeathSpell== 0 ) { m_Scroll.S14WordOfDeathSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S14WordOfDeathSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button126 : {  
                    page = 6;   { if ( m_Scroll.S15GiftOfLifeSpell== 0 ) { m_Scroll.S15GiftOfLifeSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S15GiftOfLifeSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
                case (int)Buttons.Button127 : {  
                    page = 6;   { if ( m_Scroll.S16ArcaneEmpowermentSpell== 0 ) { m_Scroll.S16ArcaneEmpowermentSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.S16ArcaneEmpowermentSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				
			// MYSTICISM
				case (int)Buttons.Button128 : {  
                    page = 7;   { if ( m_Scroll.M01NetherBoltSpell== 0 ) { m_Scroll.M01NetherBoltSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M01NetherBoltSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button129 : {  
                    page = 7;   { if ( m_Scroll.M02HealingStoneSpell== 0 ) { m_Scroll.M02HealingStoneSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M02HealingStoneSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button130 : {  
                    page = 7;   { if ( m_Scroll.M03PurgeMagicSpell== 0 ) { m_Scroll.M03PurgeMagicSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M03PurgeMagicSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button131 : {  
                    page = 7;   { if ( m_Scroll.M04EnchantSpell== 0 ) { m_Scroll.M04EnchantSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M04EnchantSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button132 : {  
                    page = 7;   { if ( m_Scroll.M05SleepSpell== 0 ) { m_Scroll.M05SleepSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M05SleepSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button133 : {  
                    page = 7;   { if ( m_Scroll.M06EagleStrikeSpell== 0 ) { m_Scroll.M06EagleStrikeSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M06EagleStrikeSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button134 : {  
                    page = 7;   { if ( m_Scroll.M07AnimatedWeaponSpell== 0 ) { m_Scroll.M07AnimatedWeaponSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M07AnimatedWeaponSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button135 : {  
                    page = 7;   { if ( m_Scroll.M08SpellTriggerSpell== 0 ) { m_Scroll.M08SpellTriggerSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M08SpellTriggerSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button136 : {  
                    page = 7;   { if ( m_Scroll.M09MassSleepSpell== 0 ) { m_Scroll.M09MassSleepSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M09MassSleepSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button137 : {  
                    page = 7;   { if ( m_Scroll.M10CleansingWindsSpell== 0 ) { m_Scroll.M10CleansingWindsSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M10CleansingWindsSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button138 : {  
                    page = 7;   { if ( m_Scroll.M11BombardSpell== 0 ) { m_Scroll.M11BombardSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M11BombardSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button139 : {  
                    page = 7;   { if ( m_Scroll.M12SpellPlagueSpell== 0 ) { m_Scroll.M12SpellPlagueSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M12SpellPlagueSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button140 : {  
                    page = 7;   { if ( m_Scroll.M13HailStormSpell== 0 ) { m_Scroll.M13HailStormSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M13HailStormSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button141 : {  
                    page = 7;   { if ( m_Scroll.M14NetherCycloneSpell== 0 ) { m_Scroll.M14NetherCycloneSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M14NetherCycloneSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button142 : {  
                    page = 7;   { if ( m_Scroll.M15RisingColossusSpell== 0 ) { m_Scroll.M15RisingColossusSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M15RisingColossusSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
				case (int)Buttons.Button143 : {  
                    page = 7;   { if ( m_Scroll.M16StoneFormSpell== 0 ) { m_Scroll.M16StoneFormSpell= 1; m_Scroll.Count += 1; } else { m_Scroll.M16StoneFormSpell= 0; m_Scroll.Count -= 1; } from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; } }
					
			//bush		
				case (int)Buttons.Button144 : 
				{
					 
                    page = 4;  
					{ 
						if ( m_Scroll.B06HonorableExecution == 0 ) 
						{ 
							m_Scroll.B06HonorableExecution = 1; 
							m_Scroll.Count += 1; 
						} 
						else 
						{ 
							m_Scroll.B06HonorableExecution = 0; 
							m_Scroll.Count -= 1;
						} 
						from.SendGump( new SpellBarGump( from, page, m_Scroll ) ); 
						break; 
					}    
				}
			// ninjitsu
				case (int)Buttons.Button145: 
					{ 
						 
						page = 5;   
						{ 
							if ( m_Scroll.I08FocusAttack == 0 ) 
							{ 
								m_Scroll.I08FocusAttack = 1; m_Scroll.Count += 1; 
							} 
							else 
							{ 
								m_Scroll.I08FocusAttack = 0; m_Scroll.Count -= 1; 
							} 
							
							from.SendGump( new SpellBarGump( from, page ,m_Scroll ) ); break; 
						} 
					}
		
		/// help button
				case (int)Buttons.Button146:
                {
                     
                    page = 8;
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
                    //from.SendGump(new SpellBar_HelpGump( from ));
                    break;
                }
				
				case (int)Buttons.Button147: // reset
                {
					 
                    page = 9;
					
					if ( m_Scroll.W00_ClumsySpell == 1 ) { m_Scroll.W00_ClumsySpell = 0; }
					if ( m_Scroll.W01_CreateFoodSpell == 1 ) { m_Scroll.W01_CreateFoodSpell = 0; }
					if ( m_Scroll.W02_FeeblemindSpell == 1 ) { m_Scroll.W02_FeeblemindSpell = 0; }
					if ( m_Scroll.W03_HealSpell == 1 ) { m_Scroll.W03_HealSpell = 0;}
					if ( m_Scroll.W04_MagicArrowSpell == 1 ) { m_Scroll.W04_MagicArrowSpell = 0;}
					if ( m_Scroll.W05_NightSightSpell == 1 ) { m_Scroll.W05_NightSightSpell = 0;}
					if ( m_Scroll.W06_ReactiveArmorSpell == 1 ) { m_Scroll.W06_ReactiveArmorSpell = 0;}
					if ( m_Scroll.W07_WeakenSpell == 1 ) { m_Scroll.W07_WeakenSpell = 0;}
					if ( m_Scroll.W08_AgilitySpell == 1 ) { m_Scroll.W08_AgilitySpell = 0;}
					if ( m_Scroll.W09_CunningSpell == 1 ) { m_Scroll.W09_CunningSpell = 0;}
					if ( m_Scroll.W10_CureSpell == 1 ) { m_Scroll.W10_CureSpell = 0;}
					if ( m_Scroll.W11_HarmSpell == 1 ) { m_Scroll.W11_HarmSpell = 0;}
					if ( m_Scroll.W12_MagicTrapSpell == 1 ) { m_Scroll.W12_MagicTrapSpell = 0;}
					if ( m_Scroll.W13_RemoveTrapSpell == 1 ) { m_Scroll.W13_RemoveTrapSpell = 0;}
					if ( m_Scroll.W14_ProtectionSpell == 1 ) { m_Scroll.W14_ProtectionSpell = 0; }
					if ( m_Scroll.W15_StrengthSpell == 1 ) { m_Scroll.W15_StrengthSpell = 0;}
					if ( m_Scroll.W16_BlessSpell == 1 ) { m_Scroll.W16_BlessSpell = 0; }
					if ( m_Scroll.W17_FireballSpell == 1 ) { m_Scroll.W17_FireballSpell = 0; }
					if ( m_Scroll.W18_MagicLockSpell == 1 ) { m_Scroll.W18_MagicLockSpell = 0; }
					if ( m_Scroll.W19_PoisonSpell == 1 ) { m_Scroll.W19_PoisonSpell = 0; }
					if ( m_Scroll.W20_TelekinesisSpell == 1 ) { m_Scroll.W20_TelekinesisSpell = 0; }
					if ( m_Scroll.W21_TeleportSpell == 1 ) { m_Scroll.W21_TeleportSpell = 0; }
					if ( m_Scroll.W22_UnlockSpell == 1 ) { m_Scroll.W22_UnlockSpell = 0;}
					if ( m_Scroll.W23_WallOfStoneSpell == 1 ) { m_Scroll.W23_WallOfStoneSpell = 0; }
					if ( m_Scroll.W24_ArchCureSpell == 1 ) { m_Scroll.W24_ArchCureSpell = 0; }
					if ( m_Scroll.W25_ArchProtectionSpell == 1 ) { m_Scroll.W25_ArchProtectionSpell = 0; }
					if ( m_Scroll.W26_CurseSpell == 1 ) { m_Scroll.W26_CurseSpell = 0; }
					if ( m_Scroll.W27_FireFieldSpell == 1 ) { m_Scroll.W27_FireFieldSpell = 0; m_Scroll.Count += 0; }
					if ( m_Scroll.W28_GreaterHealSpell == 1 ) { m_Scroll.W28_GreaterHealSpell = 0; }
					if ( m_Scroll.W29_LightningSpell == 1 ) { m_Scroll.W29_LightningSpell = 0; }
					if ( m_Scroll.W30_ManaDrainSpell == 1 ) { m_Scroll.W30_ManaDrainSpell = 0;}
					if ( m_Scroll.W31_RecallSpell == 1 ) { m_Scroll.W31_RecallSpell = 0; }
					if ( m_Scroll.W32_BladeSpiritsSpell == 1 ) { m_Scroll.W32_BladeSpiritsSpell = 0; }
					if ( m_Scroll.W33_DispelFieldSpell == 1 ) { m_Scroll.W33_DispelFieldSpell = 0; }
					if ( m_Scroll.W34_IncognitoSpell == 1 ) { m_Scroll.W34_IncognitoSpell = 0; }
					if ( m_Scroll.W35_MagicReflectSpell == 1 ) { m_Scroll.W35_MagicReflectSpell = 0; }
					if ( m_Scroll.W36_MindBlastSpell == 1 ) { m_Scroll.W36_MindBlastSpell = 0; }
					if ( m_Scroll.W37_ParalyzeSpell == 1 ) { m_Scroll.W37_ParalyzeSpell = 0; }
					if ( m_Scroll.W38_PoisonFieldSpell == 1 ) { m_Scroll.W38_PoisonFieldSpell = 0; }
					if ( m_Scroll.W39_SummonCreatureSpell == 1 ) { m_Scroll.W39_SummonCreatureSpell = 0; }
					if ( m_Scroll.W40_DispelSpell == 1 ) { m_Scroll.W40_DispelSpell = 0; }
					if ( m_Scroll.W41_EnergyBoltSpell == 1 ) { m_Scroll.W41_EnergyBoltSpell = 0; }
					if ( m_Scroll.W42_ExplosionSpell == 1 ) { m_Scroll.W42_ExplosionSpell = 0; }
					if ( m_Scroll.W43_InvisibilitySpell == 1 ) { m_Scroll.W43_InvisibilitySpell = 0; }
					if ( m_Scroll.W44_MarkSpell == 1 ) { m_Scroll.W44_MarkSpell = 0;}
					if ( m_Scroll.W45_MassCurseSpell == 1 ) { m_Scroll.W45_MassCurseSpell = 0; }
					if ( m_Scroll.W46_ParalyzeFieldSpell == 1 ) { m_Scroll.W46_ParalyzeFieldSpell = 0; }
					if ( m_Scroll.W47_RevealSpell == 1 ) { m_Scroll.W47_RevealSpell = 0; }
					if ( m_Scroll.W48_ChainLightningSpell == 1 ) { m_Scroll.W48_ChainLightningSpell = 0; }
					if ( m_Scroll.W49_EnergyFieldSpell == 1 ) { m_Scroll.W49_EnergyFieldSpell = 0; }
					if ( m_Scroll.W50_FlameStrikeSpell == 1 ) { m_Scroll.W50_FlameStrikeSpell = 0; }
					if ( m_Scroll.W51_GateTravelSpell == 1 ) { m_Scroll.W51_GateTravelSpell = 0; }
					if ( m_Scroll.W52_ManaVampireSpell == 1 ) { m_Scroll.W52_ManaVampireSpell = 0; }
					if ( m_Scroll.W53_MassDispelSpell == 1 ) { m_Scroll.W53_MassDispelSpell = 0; }
					if ( m_Scroll.W54_MeteorSwarmSpell == 1 ) { m_Scroll.W54_MeteorSwarmSpell = 0; }
					if ( m_Scroll.W55_PolymorphSpell == 1 ) { m_Scroll.W55_PolymorphSpell = 0; }
					if ( m_Scroll.W56_EarthquakeSpell == 1 ) { m_Scroll.W56_EarthquakeSpell = 0; }
					if ( m_Scroll.W57_EnergyVortexSpell == 1 ) { m_Scroll.W57_EnergyVortexSpell = 0; }
					if ( m_Scroll.W58_ResurrectionSpell == 1 ) { m_Scroll.W58_ResurrectionSpell = 0; }
					if ( m_Scroll.W59_AirElementalSpell == 1 ) { m_Scroll.W59_AirElementalSpell = 0; }
					if ( m_Scroll.W60_SummonDaemonSpell == 1 ) { m_Scroll.W60_SummonDaemonSpell = 0; }
					if ( m_Scroll.W61_EarthElementalSpell == 1 ) { m_Scroll.W61_EarthElementalSpell = 0; }
					if ( m_Scroll.W62_FireElementalSpell == 1 ) { m_Scroll.W62_FireElementalSpell = 0; }
					if ( m_Scroll.W63_WaterElementalSpell == 1 ) { m_Scroll.W63_WaterElementalSpell = 0; }
	// necro
					if ( m_Scroll.N01AnimateDeadSpell == 1 ) { m_Scroll.N01AnimateDeadSpell = 0; }
					if ( m_Scroll.N02BloodOathSpell == 1 ) { m_Scroll.N02BloodOathSpell = 0;}
					if ( m_Scroll.N03CorpseSkinSpell == 1 ) { m_Scroll.N03CorpseSkinSpell = 0; }
					if ( m_Scroll.N04CurseWeaponSpell == 1 ) { m_Scroll.N04CurseWeaponSpell = 0; }
					if ( m_Scroll.N05EvilOmenSpell == 1 ) { m_Scroll.N05EvilOmenSpell = 0; }
					if ( m_Scroll.N06HorrificBeastSpell == 1 ) { m_Scroll.N06HorrificBeastSpell = 0; }
					if ( m_Scroll.N07LichFormSpell == 1 ) { m_Scroll.N07LichFormSpell = 0; }
					if ( m_Scroll.N08MindRotSpell == 1 ) { m_Scroll.N08MindRotSpell = 0; }
					if ( m_Scroll.N09PainSpikeSpell == 1 ) { m_Scroll.N09PainSpikeSpell = 0; }
					if ( m_Scroll.N10PoisonStrikeSpell == 1 ) { m_Scroll.N10PoisonStrikeSpell = 0; }
					if ( m_Scroll.N11StrangleSpell == 1 ) { m_Scroll.N11StrangleSpell = 0; }
					if ( m_Scroll.N12SummonFamiliarSpell == 1 ) { m_Scroll.N12SummonFamiliarSpell = 0; }
					if ( m_Scroll.N13VampiricEmbraceSpell == 1 ) { m_Scroll.N13VampiricEmbraceSpell = 0; }
					if ( m_Scroll.N14VengefulSpiritSpell == 1 ) { m_Scroll.N14VengefulSpiritSpell = 0; }
					if ( m_Scroll.N15WitherSpell == 1 ) { m_Scroll.N15WitherSpell = 0; }
					if ( m_Scroll.N16WraithFormSpell == 1 ) { m_Scroll.N16WraithFormSpell = 0; }
					if ( m_Scroll.N17ExorcismSpell == 1 ) { m_Scroll.N17ExorcismSpell = 0;}
	//CHIVALRY
					if ( m_Scroll.C01CleanseByFireSpell == 1 ) { m_Scroll.C01CleanseByFireSpell = 0;}
					if ( m_Scroll.C02CloseWoundsSpell == 1 ) { m_Scroll.C02CloseWoundsSpell = 0; }
					if ( m_Scroll.C03ConsecrateWeaponSpell == 1 ) { m_Scroll.C03ConsecrateWeaponSpell = 0; }
					if ( m_Scroll.C04DispelEvilSpell == 1 ) { m_Scroll.C04DispelEvilSpell = 0; }
					if ( m_Scroll.C05DivineFurySpell == 1 ) { m_Scroll.C05DivineFurySpell = 0; }
					if ( m_Scroll.C06EnemyOfOneSpell == 1 ) { m_Scroll.C06EnemyOfOneSpell = 0; }
					if ( m_Scroll.C07HolyLightSpell == 1 ) { m_Scroll.C07HolyLightSpell = 0;}
					if ( m_Scroll.C08NobleSacrificeSpell == 1 ) { m_Scroll.C08NobleSacrificeSpell = 0;}
					if ( m_Scroll.C09RemoveCurseSpell == 1 ) { m_Scroll.C09RemoveCurseSpell = 0; }
					if ( m_Scroll.C10SacredJourneySpell == 1 ) { m_Scroll.C10SacredJourneySpell = 0; }
	// BUSHIDO
					if ( m_Scroll.B06HonorableExecution ==1 ){ m_Scroll.B06HonorableExecution = 0;}
					if ( m_Scroll.B01Confidence == 1 ) { m_Scroll.B01Confidence = 0; }
					if ( m_Scroll.B02CounterAttack == 1 ) { m_Scroll.B02CounterAttack = 0; }
					if ( m_Scroll.B03Evasion == 1 ) { m_Scroll.B03Evasion = 0; }
					if ( m_Scroll.B04LightningStrike == 1 ) { m_Scroll.B04LightningStrike = 0; }
					if ( m_Scroll.B05MomentumStrike == 1 ) { m_Scroll.B05MomentumStrike = 0; }
	// NINJITSU
					if ( m_Scroll.I08FocusAttack == 1 ) { m_Scroll.I08FocusAttack = 0; }
					if ( m_Scroll.I01DeathStrike == 1 ) { m_Scroll.I01DeathStrike = 0; }
					if ( m_Scroll.I02AnimalForm == 1 ) { m_Scroll.I02AnimalForm = 0; }
					if ( m_Scroll.I03KiAttack == 1 ) { m_Scroll.I03KiAttack = 0;}
					if ( m_Scroll.I04SurpriseAttack == 1 ) { m_Scroll.I04SurpriseAttack = 0;}
					if ( m_Scroll.I05Backstab == 1 ) { m_Scroll.I05Backstab = 0; }
					if ( m_Scroll.I06Shadowjump == 1 ) { m_Scroll.I06Shadowjump = 0; }
					if ( m_Scroll.I07MirrorImage == 1 ) { m_Scroll.I07MirrorImage = 0; }
	// SPELLWEAVING
					if ( m_Scroll.S01ArcaneCircleSpell== 1 ) { m_Scroll.S01ArcaneCircleSpell= 0; }
					if ( m_Scroll.S02GiftOfRenewalSpell== 1 ) { m_Scroll.S02GiftOfRenewalSpell= 0; }
					if ( m_Scroll.S03ImmolatingWeaponSpell== 1 ) { m_Scroll.S03ImmolatingWeaponSpell= 0; }
					if ( m_Scroll.S04AttuneWeaponSpell== 1 ) { m_Scroll.S04AttuneWeaponSpell= 0; }
					if ( m_Scroll.S05ThunderstormSpell== 1 ) { m_Scroll.S05ThunderstormSpell= 0; }
					if ( m_Scroll.S06NatureFurySpell== 1 ) { m_Scroll.S06NatureFurySpell= 0; }
					if ( m_Scroll.S07SummonFeySpell== 1 ) { m_Scroll.S07SummonFeySpell= 0; }
					if ( m_Scroll.S08SummonFiendSpell== 1 ) { m_Scroll.S08SummonFiendSpell= 0; }
					if ( m_Scroll.S09ReaperFormSpell== 1 ) { m_Scroll.S09ReaperFormSpell= 0; }
					if ( m_Scroll.S10WildfireSpell== 1 ) { m_Scroll.S10WildfireSpell= 0; }
					if ( m_Scroll.S11EssenceOfWindSpell== 1 ) { m_Scroll.S11EssenceOfWindSpell= 0; }
					if ( m_Scroll.S12DryadAllureSpell== 1 ) { m_Scroll.S12DryadAllureSpell= 0; }
					if ( m_Scroll.S13EtherealVoyageSpell== 1 ) { m_Scroll.S13EtherealVoyageSpell= 0; }
					if ( m_Scroll.S14WordOfDeathSpell== 1 ) { m_Scroll.S14WordOfDeathSpell= 0; }
					if ( m_Scroll.S15GiftOfLifeSpell== 1 ) { m_Scroll.S15GiftOfLifeSpell= 0; }
					if ( m_Scroll.S16ArcaneEmpowermentSpell== 1 ) { m_Scroll.S16ArcaneEmpowermentSpell= 0; }
	// MYSTICISM
					if ( m_Scroll.M01NetherBoltSpell== 1 ) { m_Scroll.M01NetherBoltSpell= 0; }
					if ( m_Scroll.M02HealingStoneSpell== 1 ) { m_Scroll.M02HealingStoneSpell= 0; }
					if ( m_Scroll.M03PurgeMagicSpell== 1 ) { m_Scroll.M03PurgeMagicSpell= 0; }
					if ( m_Scroll.M04EnchantSpell== 1 ) { m_Scroll.M04EnchantSpell= 0; }
					if ( m_Scroll.M05SleepSpell== 1 ) { m_Scroll.M05SleepSpell= 0; }
					if ( m_Scroll.M06EagleStrikeSpell== 1 ) { m_Scroll.M06EagleStrikeSpell= 0; }
					if ( m_Scroll.M07AnimatedWeaponSpell== 1 ) { m_Scroll.M07AnimatedWeaponSpell= 0; }
					if ( m_Scroll.M08SpellTriggerSpell== 1 ) { m_Scroll.M08SpellTriggerSpell= 0; }
					if ( m_Scroll.M09MassSleepSpell== 1 ) { m_Scroll.M09MassSleepSpell= 0; }
					if ( m_Scroll.M10CleansingWindsSpell== 1 ) { m_Scroll.M10CleansingWindsSpell= 0; }
					if ( m_Scroll.M11BombardSpell== 1 ) { m_Scroll.M11BombardSpell= 0; }
					if ( m_Scroll.M12SpellPlagueSpell== 1 ) { m_Scroll.M12SpellPlagueSpell= 0; }
					if ( m_Scroll.M13HailStormSpell== 1 ) { m_Scroll.M13HailStormSpell= 0; }
					if ( m_Scroll.M14NetherCycloneSpell== 1 ) { m_Scroll.M14NetherCycloneSpell= 0; }
					if ( m_Scroll.M15RisingColossusSpell== 1 ) { m_Scroll.M15RisingColossusSpell= 0; }
					if ( m_Scroll.M16StoneFormSpell== 1 ) { m_Scroll.M16StoneFormSpell= 0; }
					
					
					
					
					m_Scroll.Count = 0;
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					break;
				}
				
				case (int)Buttons.Button148: // options
                {
					 
                    page = 9;
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					break;
				}
				case (int)Buttons.Button149: // 
                {
					 
                    page = 9;
					
					
					if ( m_Scroll.Xselect_10 == 0) 
					{ 
						m_Scroll.Xselect_10 = 1;
						m_Scroll.Xselect_15 = 0;
						m_Scroll.Xselect_20 = 0;
						m_Scroll.Xselect_30 = 0; 
						
					} 
					
					else 
					{ 
						m_Scroll.Xselect_10 = 0; 
					} 
					
							
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				
				
				case (int)Buttons.Button150: // 
                {
					 
                    page = 9;
					
					
					if ( m_Scroll.Xselect_15 == 0) 
					{ 
						m_Scroll.Xselect_10 = 0;
						m_Scroll.Xselect_15 = 1;
						m_Scroll.Xselect_20 = 0;
						m_Scroll.Xselect_30 = 0; 
						
						
					} 
					
					else 
					{ 
						m_Scroll.Xselect_15 = 0; 
					} 
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				
				
				case (int)Buttons.Button151: // 
                {
					 
                    page = 9;
					
					if ( m_Scroll.Xselect_20 == 0) 
					{ 
						m_Scroll.Xselect_10 = 0;
						m_Scroll.Xselect_15 = 0;
						m_Scroll.Xselect_20 = 1;
						m_Scroll.Xselect_30 = 0; 
					} 
					
					else 
					{ 
						m_Scroll.Xselect_20 = 0; 
					} 
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				
				
				case (int)Buttons.Button152: // 
                {
					 
                    page = 9;
					
					if ( m_Scroll.Xselect_30 == 0) 
					{ 
						m_Scroll.Xselect_10 = 0;
						m_Scroll.Xselect_15 = 0;
						m_Scroll.Xselect_20 = 0;
						m_Scroll.Xselect_30 = 1; 
					} 
					
					else 
					{ 
						m_Scroll.Xselect_30 = 0; 
					} 
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				
	/////////////////
				case (int)Buttons.Button153: // 
                {
					 
                    page = 9;
					int yselect_var = 0;
					
					if ( m_Scroll.Yselect_1 == 0) 
					{ 
						m_Scroll.Yselect_1 = 1;
						m_Scroll.Yselect_2 = 0;
						m_Scroll.Yselect_3 = 0;
						m_Scroll.Yselect_4 = 0; 
						
						yselect_var = 1;
					} 
					
					else 
					{ 
						m_Scroll.Yselect_1 = 0; 
					} 
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				case (int)Buttons.Button154: // 
                {
					 
                    page = 9;
					int yselect_var = 0;
					
					if ( m_Scroll.Yselect_2 == 0) 
					{ 
						m_Scroll.Yselect_1 = 0;
						m_Scroll.Yselect_2 = 1;
						m_Scroll.Yselect_3 = 0;
						m_Scroll.Yselect_4 = 0; 
						
						yselect_var = 2;
					} 
					
					else 
					{ 
						m_Scroll.Yselect_2 = 0; 
					} 
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				case (int)Buttons.Button155: // 
                {
					 
                    page = 9;
					int yselect_var = 0;
					
					if ( m_Scroll.Yselect_3 == 0) 
					{ 
						m_Scroll.Yselect_1 = 0;
						m_Scroll.Yselect_2 = 0;
						m_Scroll.Yselect_3 = 1;
						m_Scroll.Yselect_4 = 0; 
						
						yselect_var = 3;
					} 
					
					else 
					{ 
						m_Scroll.Yselect_3 = 0; 
					} 
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				case (int)Buttons.Button156: // 
                {
					 
                    page = 9;
					int yselect_var = 0;
					
					if ( m_Scroll.Yselect_4 == 0) 
					{ 
						m_Scroll.Yselect_1 = 0;
						m_Scroll.Yselect_2 = 0;
						m_Scroll.Yselect_3 = 0;
						m_Scroll.Yselect_4 = 1; 
						
						yselect_var = 4;
					} 
					
					else 
					{ 
						m_Scroll.Yselect_4 = 0; 
					} 
					
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				case (int)Buttons.Button157: // 
                {
					 
                    page = 0;
				
					from.SendGump( new SpellBarGump( from, page ,m_Scroll ) );
					
					break;
				}
				case (int)Buttons.Button158: // 
                {
					 
                    page = 9;
					
					
					if ( m_Scroll.Open == 0 ) { m_Scroll.Open = 1; } 
					else { m_Scroll.Open = 0; } 
				
					from.SendGump( new SpellBarGump( from, page, m_Scroll ) );
					
					break;
				}
				case (int)Buttons.Button159: // 
                {
					 
                    page = 9;
					
					from.SendGump( new PositionGump( from, m_Scroll ) );
					
					break;
				}
				
				
			
            }
        }
        
/////////////////////////////
 
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
////******** spellbar_bargump  ************////
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

////////////////////////////

    public class SpellBar_BarGump : Gump
    {
	
		
		
        public static bool HasSpell( Mobile from, int spellID )
        {
            Spellbook book = Spellbook.Find( from, spellID );
            return ( book != null && book.HasSpell( spellID ) );
        }

        public SpellBarScroll m_Scroll;
		
		//private int mXselect_var;
		private int mYselect_var;
		
		private int mdbx; 
		private int mdbxa; 
		private int mdby; 
		private int mdbya; 
		
		int xo;
		int yo;
		
		private int mxselect_var; 
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int dbx { get { return mdbx; } set { mdbx = value; }  }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int dbxa { get { return mdbxa; } set { mdbxa = value; }  }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int dby { get { return mdby; } set { mdby = value; }  }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int dbya { get { return mdbya; } set { mdbya = value; }  }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int xselect_var { get { return mxselect_var; } set { mxselect_var = value; }  }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public int Yselect_var { get { return mYselect_var; } set { mYselect_var = value; }  }
	
/*
		public void CalcPos ( int dbx,  int dbxa, int dby, int dbya)
		{
			//return base.CalcPos (  dbx,  dbxa,  dby,  dbya );
			dbx = 67; dbxa = 45; dby = 5; dbya = 0;
			// dbx = dbx + dbxa; dby = dby + dbya; 
			 if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } 
			 
			 if ( m_Scroll.Xselect_30 == 1) 
			 { xselect_var = 1462;  } 
			 if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) 
			 { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  
			 if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) 
			 { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  
			 if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) 
			 { dbx = 67; dbxa = 45; dby = 140; dbya = 0; } 
			 
			 if ( m_Scroll.Switch == 1 ) 
			 {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				
			
		}
	*/
	
		

        public SpellBar_BarGump( Mobile from, SpellBarScroll scroll, int xo, int yo  ) : base( 0 + xo, 0 + yo )
        {
            m_Scroll = scroll;
		
			//mXselect_var = xselect_var;
			
			//int open = 0;
			
			if ( m_Scroll.Lock == 0 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;
			}
			else
			{
				this.Closable=false;
				this.Disposable=true;
				this.Dragable=false;
				this.Resizable=false;
			}
			
		
			
			
			
			this.AddPage(1);
			   
				
			if ( m_Scroll.Switch == 0 ) 
			{ 
				
				dbx = 67; dbxa = 45; dby = 5; dbya = 0;

				AddImage( 24, 0, 2234, 0);
				AddImageTiled( 0,0, 25,80, 2624 ); //options background
				AddAlphaRegion(0, 0, 25, 80);
				
					if ( m_Scroll.Lock == 0 )
					{
					
						

						this.AddButton( 2, 28,  22404, 22404, 138, GumpButtonType.Reply, 1); // flip button
						this.AddButton( 2, 5,  5603, 5603, 0, GumpButtonType.Page, 2); // minimize
						this.AddButton( 5, 54,  2510, 2510, 139, GumpButtonType.Reply, 1); // unlocked
					}
					else
					{
						this.AddButton( 5, 54,  2092, 2092, 139, GumpButtonType.Reply, 1); // locked
					}
			}
			else 
			{ 
					dbx = 0; dbxa = 0; dby = 54; dbya = 45; 
					
					AddImage( 0, 0, 2234, 0);
					AddImageTiled( 42,0, 47,51, 2624 ); //options background
					AddAlphaRegion(42, 0, 47, 51);
					
					if ( m_Scroll.Lock == 0 )
					{
						this.AddButton( 48, 28,  22404, 22404, 138, GumpButtonType.Reply, 1); // flip button
						this.AddButton( 48, 7,  5600, 5600, 0, GumpButtonType.Page, 3); // minimize
						this.AddButton( 70, 16,  2510, 2510, 139, GumpButtonType.Reply, 1); // unlocked
					}
					else 
					{
						this.AddButton( 70, 16,  2092, 2092, 139, GumpButtonType.Reply, 1); // locked
					}
					
					
			}
			

			if ( HasSpell( from, 0 ) && m_Scroll.W00_ClumsySpell == 1) 
			{ 
				
				this.AddButton(dbx, dby, 2240, 2240, 1, GumpButtonType.Reply, 1); 
				
				 dbx = dbx + dbxa; dby = dby + dbya; 
			
				if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } 
				if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } 
				if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } 
				if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } 
				
				if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  
				if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } 
				if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  
			
				if ( m_Scroll.Switch == 1 ) 
				{  
					if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  
					if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  
					if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } 
				}
			
				
				AddTooltip( 1015164 ); 
				
			}
            if ( HasSpell( from, 1 ) && m_Scroll.W01_CreateFoodSpell == 1)
			{
				
				this.AddButton(dbx, dby, 2241, 2241, 2, GumpButtonType.Reply, 1);
			
				dbx = dbx + dbxa; dby = dby + dbya; 
		
				if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			
				AddTooltip( 1015165 ); 
				
			}
			
            if ( HasSpell( from, 2 ) && m_Scroll.W02_FeeblemindSpell == 1)
			{ 
				
				this.AddButton(dbx, dby, 2242, 2242, 3, GumpButtonType.Reply, 1); 
				
				dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } } 
		
				AddTooltip( 1015166 ); }
			
            if ( HasSpell( from, 3 ) && m_Scroll.W03_HealSpell == 1){
			
			this.AddButton(dbx, dby, 2243, 2243, 4, GumpButtonType.Reply, 1); 
			
			dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			
			AddTooltip( 1015011 ); }//dont change
			
            if ( HasSpell( from, 4 ) && m_Scroll.W04_MagicArrowSpell == 1){
			
			this.AddButton(dbx, dby, 2244, 2244, 5, GumpButtonType.Reply, 1); 
			
			dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			
			AddTooltip( 1015167 ); }
			
            if ( HasSpell( from, 5 ) && m_Scroll.W05_NightSightSpell == 1){
		
			this.AddButton(dbx, dby, 2245, 2245, 6, GumpButtonType.Reply, 1); 
			
			dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			
			AddTooltip( 1015168 ); }
			
            if ( HasSpell( from, 6 ) && m_Scroll.W06_ReactiveArmorSpell == 1){this.AddButton(dbx, dby, 2246, 2246, 7, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			AddTooltip( 1015169 ); }
			
            if ( HasSpell( from, 7 ) && m_Scroll.W07_WeakenSpell == 1){this.AddButton(dbx, dby, 2247, 2247, 8, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			AddTooltip( 1015170 );}
			
            if ( HasSpell( from, 8 ) && m_Scroll.W08_AgilitySpell == 1)
			{this.AddButton(dbx, dby, 2248, 2248, 9, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				AddTooltip( 1015005 );
			}
			
            if ( HasSpell( from, 9 ) && m_Scroll.W09_CunningSpell == 1)
			{
				this.AddButton(dbx, dby, 2249, 2249, 10, GumpButtonType.Reply, 1); 
				dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				   AddTooltip( 1015172 ); 
			}
				
            if ( HasSpell( from, 10 ) && m_Scroll.W10_CureSpell == 1)
			{this.AddButton(dbx, dby, 2250, 2250, 11, GumpButtonType.Reply, 1);dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			 AddTooltip( 1027991 );
				} 
				
            if ( HasSpell( from, 11 ) && m_Scroll.W11_HarmSpell == 1){this.AddButton(dbx, dby, 2251, 2251, 12, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				AddTooltip( 1015173 ); }
			
            if ( HasSpell( from, 12 ) && m_Scroll.W12_MagicTrapSpell == 1){this.AddButton(dbx, dby, 2252, 2252, 13, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015174 );}
			
            if ( HasSpell( from, 13 ) && m_Scroll.W13_RemoveTrapSpell == 1){this.AddButton(dbx, dby, 2253, 2253, 14, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			AddTooltip( 1015175 );}
			
            if ( HasSpell( from, 14 ) && m_Scroll.W14_ProtectionSpell == 1){this.AddButton(dbx, dby, 2254, 2254, 15, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015176 );}
			
            if ( HasSpell( from, 15 ) && m_Scroll.W15_StrengthSpell == 1){this.AddButton(dbx, dby, 2255, 2255, 16, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1027996 );}
			
            if ( HasSpell( from, 16 ) && m_Scroll.W16_BlessSpell == 1){this.AddButton(dbx, dby, 2256, 2256, 17, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			AddTooltip( 1015178 );}
			
            if ( HasSpell( from, 17 ) && m_Scroll.W17_FireballSpell == 1){this.AddButton(dbx, dby, 2257, 2257, 18, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			AddTooltip( 1015179 );}
			
            if ( HasSpell( from, 18 ) && m_Scroll.W18_MagicLockSpell == 1){this.AddButton(dbx, dby, 2258, 2258, 19, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015180 );}
			
            if ( HasSpell( from, 19 ) && m_Scroll.W19_PoisonSpell == 1){this.AddButton(dbx, dby, 2259, 2259, 20, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1028000 );}
			
            if ( HasSpell( from, 20 ) && m_Scroll.W20_TelekinesisSpell == 1){this.AddButton(dbx, dby, 2260, 2260, 21, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015181 );}
			
            if ( HasSpell( from, 21 ) && m_Scroll.W21_TeleportSpell == 1){this.AddButton(dbx, dby, 2261, 2261, 22, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015182 );}
			
            if ( HasSpell( from, 22 ) && m_Scroll.W22_UnlockSpell == 1){this.AddButton(dbx, dby, 2262, 2262, 23, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015183 );}
			
            if ( HasSpell( from, 23 ) && m_Scroll.W23_WallOfStoneSpell == 1){this.AddButton(dbx, dby, 2263, 2263, 24, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015184 ); }
			
            if ( HasSpell( from, 24 ) && m_Scroll.W24_ArchCureSpell == 1){this.AddButton(dbx, dby, 2264, 2264, 25, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015186 ); }
			
            if ( HasSpell( from, 25 ) && m_Scroll.W25_ArchProtectionSpell == 1){this.AddButton(dbx, dby, 2265, 2265, 26, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015187 ); }
			
            if ( HasSpell( from, 26 ) && m_Scroll.W26_CurseSpell == 1){this.AddButton(dbx, dby, 2266, 2266, 27, GumpButtonType.Reply, 1); 
			
			dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			
			AddTooltip( 1015188 ); }
			
            if ( HasSpell( from, 27 ) && m_Scroll.W27_FireFieldSpell == 1){this.AddButton(dbx, dby, 2267, 2267, 28, GumpButtonType.Reply, 1); 
			
			dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
		
			AddTooltip( 1015189 ); }
			
            if ( HasSpell( from, 28 ) && m_Scroll.W28_GreaterHealSpell == 1)
			{
				this.AddButton(dbx, dby, 2268, 2268, 29, GumpButtonType.Reply, 1); 
				
				dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			
				AddTooltip( 1015012 ); //dont change
			}
			
            if ( HasSpell( from, 29 ) && m_Scroll.W29_LightningSpell == 1){this.AddButton(dbx, dby, 2269, 2269, 30, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015190 ); }
			
            if ( HasSpell( from, 30 ) && m_Scroll.W30_ManaDrainSpell == 1){this.AddButton(dbx, dby, 2270, 2270, 31, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015191 ); }
			
            if ( HasSpell( from, 31 ) && m_Scroll.W31_RecallSpell == 1){this.AddButton(dbx, dby, 2271, 2271, 32, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015192 ); }
			
            if ( HasSpell( from, 32 ) && m_Scroll.W32_BladeSpiritsSpell == 1){this.AddButton(dbx, dby, 2272, 2272, 33, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } } AddTooltip( 1015194 ); }
			
            if ( HasSpell( from, 33 ) && m_Scroll.W33_DispelFieldSpell == 1){this.AddButton(dbx, dby, 2273, 2273, 34, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } } AddTooltip( 1015195 ); }
			
            if ( HasSpell( from, 34 ) && m_Scroll.W34_IncognitoSpell == 1){this.AddButton(dbx, dby, 2274, 2274, 35, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015196 ); }
			
            if ( HasSpell( from, 35 ) && m_Scroll.W35_MagicReflectSpell == 1){this.AddButton(dbx, dby, 2275, 2275, 36, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015197 ); }
			
            if ( HasSpell( from, 36 ) && m_Scroll.W36_MindBlastSpell == 1){this.AddButton(dbx, dby, 2276, 2276, 37, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015198 ); }
			
            if ( HasSpell( from, 37 ) && m_Scroll.W37_ParalyzeSpell == 1){this.AddButton(dbx, dby, 2277, 2277, 38, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015199 ); }
			
            if ( HasSpell( from, 38 ) && m_Scroll.W38_PoisonFieldSpell == 1){this.AddButton(dbx, dby, 2278, 2278, 39, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015200 ); }
			
            if ( HasSpell( from, 39 ) && m_Scroll.W39_SummonCreatureSpell == 1){this.AddButton(dbx, dby, 2279, 2279, 40, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015201 ); }
			
            if ( HasSpell( from, 40 ) && m_Scroll.W40_DispelSpell == 1){this.AddButton(dbx, dby, 2280, 2280, 41, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015203 ); }
			
            if ( HasSpell( from, 41 ) && m_Scroll.W41_EnergyBoltSpell == 1){this.AddButton(dbx, dby, 2281, 2281, 42, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015204 ); }
			
            if ( HasSpell( from, 42 ) && m_Scroll.W42_ExplosionSpell == 1){this.AddButton(dbx, dby, 2282, 2282, 43, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1028023 ); }
			
            if ( HasSpell( from, 43 ) && m_Scroll.W43_InvisibilitySpell == 1){this.AddButton(dbx, dby, 2283, 2283, 44, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015205 ); }
			
            if ( HasSpell( from, 44 ) && m_Scroll.W44_MarkSpell == 1){this.AddButton(dbx, dby, 2284, 2284, 45, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			AddTooltip( 1015206 ); }
			
            if ( HasSpell( from, 45 ) && m_Scroll.W45_MassCurseSpell == 1){this.AddButton(dbx, dby, 2285, 2285, 46, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015207 ); }
			
            if ( HasSpell( from, 46 ) && m_Scroll.W46_ParalyzeFieldSpell == 1){this.AddButton(dbx, dby, 2286, 2286, 47, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015208 ); }
			
            if ( HasSpell( from, 47 ) && m_Scroll.W47_RevealSpell == 1){this.AddButton(dbx, dby, 2287, 2287, 48, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015209 ); }
			
			
			if ( HasSpell( from, 48 ) && m_Scroll.W48_ChainLightningSpell == 1){this.AddButton(dbx, dby, 2288, 2288, 49, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015211 ); }
			
            if ( HasSpell( from, 49 ) && m_Scroll.W49_EnergyFieldSpell == 1){this.AddButton(dbx, dby, 2289, 2289, 50, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip( 1015212 ); }
			
            if ( HasSpell( from, 50 ) && m_Scroll.W50_FlameStrikeSpell == 1){this.AddButton(dbx, dby, 2290, 2290, 51, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015213 );}
			
            if ( HasSpell( from, 51 ) && m_Scroll.W51_GateTravelSpell == 1){this.AddButton(dbx, dby, 2291, 2291, 52, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015214 );}
			
            if ( HasSpell( from, 52 ) && m_Scroll.W52_ManaVampireSpell == 1){this.AddButton(dbx, dby, 2292, 2292, 53, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015215 );}
			
            if ( HasSpell( from, 53 ) && m_Scroll.W53_MassDispelSpell == 1){this.AddButton(dbx, dby, 2293, 2293, 54, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015216 );}
			
            if ( HasSpell( from, 54 ) && m_Scroll.W54_MeteorSwarmSpell == 1){this.AddButton(dbx, dby, 2294, 2294, 55, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015217 );}
			
            if ( HasSpell( from, 55 ) && m_Scroll.W55_PolymorphSpell == 1){this.AddButton(dbx, dby, 2295, 2295, 56, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015218 );}
			
            if ( HasSpell( from, 56 ) && m_Scroll.W56_EarthquakeSpell == 1){this.AddButton(dbx, dby, 2296, 2296, 57, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015220 );}
			
            if ( HasSpell( from, 57 ) && m_Scroll.W57_EnergyVortexSpell == 1){this.AddButton(dbx, dby, 2297, 2297, 58, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015221 );}
			
            if ( HasSpell( from, 58 ) && m_Scroll.W58_ResurrectionSpell == 1){this.AddButton(dbx, dby, 2298, 2298, 59, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015222 );}
			
            if ( HasSpell( from, 59 ) && m_Scroll.W59_AirElementalSpell == 1){this.AddButton(dbx, dby, 2299, 2299, 60, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015223 );}
			
            if ( HasSpell( from, 60 ) && m_Scroll.W60_SummonDaemonSpell == 1){this.AddButton(dbx, dby, 2300, 2300, 61, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015224 );}
            
			if ( HasSpell( from, 61 ) && m_Scroll.W61_EarthElementalSpell == 1){this.AddButton(dbx, dby, 2301, 2301, 62, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015225 );}
           
		   if ( HasSpell( from, 62 ) && m_Scroll.W62_FireElementalSpell == 1){this.AddButton(dbx, dby, 2302, 2302, 63, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015226 );}
          
		  if ( HasSpell( from, 63 ) && m_Scroll.W63_WaterElementalSpell == 1)
			{this.AddButton(dbx, dby, 2303, 2303, 64, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1015227 );}

    // NECROMANCY

            if ( HasSpell( from, 100 ) && m_Scroll.N01AnimateDeadSpell == 1) { this.AddButton(dbx, dby, 20480,20480, 65, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1060509 );}
			
            if ( HasSpell( from, 101 ) && m_Scroll.N02BloodOathSpell == 1){this.AddButton(dbx, dby, 20481,20481, 66, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } } AddTooltip(1060510 );}
			
            if ( HasSpell( from, 102 ) && m_Scroll.N03CorpseSkinSpell == 1){this.AddButton(dbx, dby, 20482,20482, 67, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060511 );}
			
            if ( HasSpell( from, 103 ) && m_Scroll.N04CurseWeaponSpell == 1){this.AddButton(dbx, dby, 20483 ,20483 , 68 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } } AddTooltip(1060512 );}
			
            if ( HasSpell( from, 104 ) && m_Scroll.N05EvilOmenSpell == 1){this.AddButton(dbx, dby, 20484 ,20484 , 69 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060513 );}
			
            if ( HasSpell( from, 105 ) && m_Scroll.N06HorrificBeastSpell == 1){this.AddButton(dbx, dby, 20485 ,20485 , 70 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060514 );}
			
            if ( HasSpell( from, 106 ) && m_Scroll.N07LichFormSpell == 1){this.AddButton(dbx, dby, 20486 ,20486 , 71 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060515 );}
			
            if ( HasSpell( from, 107 ) && m_Scroll.N08MindRotSpell == 1){this.AddButton(dbx, dby, 20487 ,20487 , 72 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060516 );}
			
            if ( HasSpell( from, 108 ) && m_Scroll.N09PainSpikeSpell == 1){this.AddButton(dbx, dby, 20488 ,20488 , 73 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060517 );}
			
            if ( HasSpell( from, 109 ) && m_Scroll.N10PoisonStrikeSpell == 1){this.AddButton(dbx, dby, 20489 ,20489 , 74 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060518 ); }
			
            if ( HasSpell( from, 110 ) && m_Scroll.N11StrangleSpell == 1){this.AddButton(dbx, dby, 20490 ,20490 , 75 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060519 );}
			
            if ( HasSpell( from, 111 ) && m_Scroll.N12SummonFamiliarSpell == 1){this.AddButton(dbx, dby, 20491 ,20491 , 76 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060520 );}
			
            if ( HasSpell( from, 112 ) && m_Scroll.N13VampiricEmbraceSpell == 1){this.AddButton(dbx, dby, 20492 ,20492 , 77 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060521 );}
			
            if ( HasSpell( from, 113 ) && m_Scroll.N14VengefulSpiritSpell == 1){this.AddButton(dbx, dby, 20493 ,20493 , 78 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060522 );}
			
            if ( HasSpell( from, 114 ) && m_Scroll.N15WitherSpell == 1){this.AddButton(dbx, dby, 20494 ,20494 , 79 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060523 );}
			
            if ( HasSpell( from, 115 ) && m_Scroll.N16WraithFormSpell == 1){this.AddButton(dbx, dby, 20495 ,20495 , 80 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060524 );}
			
            if ( HasSpell( from, 116 ) && m_Scroll.N17ExorcismSpell == 1){this.AddButton(dbx, dby, 20496 ,20496 , 81 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060525 );}
           
        // CHIVALRY

            if ( HasSpell( from, 200 ) && m_Scroll.C01CleanseByFireSpell == 1){this.AddButton(dbx, dby, 20736, 20736, 82, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } } AddTooltip(1060493 );}
			
            if ( HasSpell( from, 201 ) && m_Scroll.C02CloseWoundsSpell == 1){this.AddButton(dbx, dby, 20737, 20737, 83, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1060494 ); }
			
            if ( HasSpell( from, 202 ) && m_Scroll.C03ConsecrateWeaponSpell == 1){this.AddButton(dbx, dby, 20738, 20738, 84, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1060495 ); }
			
            if ( HasSpell( from, 203 ) && m_Scroll.C04DispelEvilSpell == 1){this.AddButton(dbx, dby, 20739, 20739, 85, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060496 ); }
			
            if ( HasSpell( from, 204 ) && m_Scroll.C05DivineFurySpell == 1){this.AddButton(dbx, dby, 20740, 20740, 86, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060497 ); }
			
            if ( HasSpell( from, 205 ) && m_Scroll.C06EnemyOfOneSpell == 1){this.AddButton(dbx, dby, 20741, 20741, 87, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060498 ); }
			
            if ( HasSpell( from, 206 ) && m_Scroll.C07HolyLightSpell == 1){this.AddButton(dbx, dby, 20742, 20742, 88, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060499 ); }
			
            if ( HasSpell( from, 207 ) && m_Scroll.C08NobleSacrificeSpell == 1){this.AddButton(dbx, dby, 20743, 20743, 89, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060500 ); }
			
            if ( HasSpell( from, 208 ) && m_Scroll.C09RemoveCurseSpell == 1){this.AddButton(dbx, dby, 20744, 20744, 90, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }AddTooltip(1060501 ); }
			
            if ( HasSpell( from, 209 ) && m_Scroll.C10SacredJourneySpell == 1){this.AddButton(dbx, dby, 20745, 20745, 91, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1060502 ); }
			

// BUSHIDO
			
            //adds button to gump
            if ( HasSpell( from, 400) && m_Scroll.B06HonorableExecution == 1)
			{
			
				if ( SpecialMove.GetCurrentMove( from ) is HonorableExecution )
				{
						//this.AddButton(dbx, dby, 21536 ,21536 , 92 , GumpButtonType.Reply, 1);
						//this.AddAlphaRegion(dbx, dby, 45, 45);
						AddImage( dbx, dby, 21536, 33 );
						dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
						
						if ( !(SpecialMove.GetCurrentMove( from ) is HonorableExecution) & SpecialMove.GetCurrentMove( from ) != null  )
						{
							from.CloseGump( typeof( SpellBarGump.SpellBar_BarGump ) );
					
							//int dbx = 0; int dbxa = 0; int dby = 0; int dbya = 0; int xselect_var = 0;
					
							from.SendGump(new SpellBarGump.SpellBar_BarGump(from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ));
						
						}
						 
				}
				// 
				else 
				{
					this.AddButton(dbx, dby, 21536 ,21536 , 92 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  
				}   AddTooltip(1060595 );  
			}
			if ( HasSpell( from, 401 ) && m_Scroll.B01Confidence == 1) 
			{ 
				if ( Confidence.IsConfident(from) )
				{
					
					//this.AddButton(dbx, dby, 21537 ,21537 , 93 , GumpButtonType.Reply, 1); 
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21537, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  
					
					if ( !Confidence.IsConfident(from) )
						{
							from.CloseGump( typeof( SpellBarGump.SpellBar_BarGump ) );
					
							//int dbx = 0; int dbxa = 0; int dby = 0; int dbya = 0; int xselect_var = 0;
					
							from.SendGump(new SpellBarGump.SpellBar_BarGump(from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ));
						
						}
					  
				}
				else
				{
					this.AddButton(dbx, dby, 21537 ,21537 , 93 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  
				}   AddTooltip(1060596 );  
			}
				
			if ( HasSpell( from, 402 ) && m_Scroll.B03Evasion == 1)
			{
				 if (Evasion.IsEvading(from))
				 {
					//this.AddButton(dbx, dby, 21538 ,21538 , 94 , GumpButtonType.Reply, 1); 
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21538, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
					
					if ( !Evasion.IsEvading(from) )
						{
							from.CloseGump( typeof( SpellBarGump.SpellBar_BarGump ) );
					
							//int dbx = 0; int dbxa = 0; int dby = 0; int dbya = 0; int xselect_var = 0;
					
							from.SendGump(new SpellBarGump.SpellBar_BarGump(from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ));
						
						}   
					
				}
				else
				{
					this.AddButton(dbx, dby, 21538 ,21538 , 94 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				}  AddTooltip(1060597 );  
			}
			
            if ( HasSpell( from, 403 ) && m_Scroll.B02CounterAttack  == 1)
			{
				if ( CounterAttack.IsCountering(from) )
				{
						//this.AddButton(dbx, dby, 21539 ,21539, 95 , GumpButtonType.Reply, 1);
						//this.AddAlphaRegion(dbx, dby, 45, 45);
						AddImage( dbx, dby, 21539, 33 );
						dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
						
						if ( !CounterAttack.IsCountering(from) )
						{
							from.CloseGump( typeof( SpellBarGump.SpellBar_BarGump ) );
					
							//int dbx = 0; int dbxa = 0; int dby = 0; int dbya = 0; int xselect_var = 0;
					
							from.SendGump(new SpellBarGump.SpellBar_BarGump(from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ));
						
						}    
						
				
				}
			else
				{
					this.AddButton(dbx, dby, 21539 ,21539, 95 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				}   AddTooltip(1060598 );  
			}
			
			if ( HasSpell( from, 404 ) && m_Scroll.B04LightningStrike == 1)
			{
				
				if ( SpecialMove.GetCurrentMove( from ) is LightningStrike )
				{
					//this.AddButton(dbx, dby, 21540 ,21540 , 96 , GumpButtonType.Reply, 1);
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21540, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
					
					if ( !(SpecialMove.GetCurrentMove( from ) is LightningStrike) & SpecialMove.GetCurrentMove( from ) != null  )
						{
							from.CloseGump( typeof( SpellBarGump.SpellBar_BarGump ) );
					
							//int dbx = 0; int dbxa = 0; int dby = 0; int dbya = 0; int xselect_var = 0;
					
							from.SendGump(new SpellBarGump.SpellBar_BarGump(from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ));
						
						}
					   
				}
				else 
				{
					this.AddButton(dbx, dby, 21540 ,21540 , 96 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				}  AddTooltip(1060599 );  
			}
            if ( HasSpell( from, 405 ) && m_Scroll.B05MomentumStrike == 1)
			{
				if ( SpecialMove.GetCurrentMove( from ) is MomentumStrike )
				{
					//this.AddButton(dbx, dby, 21541 ,21541 , 97 , GumpButtonType.Reply, 1);
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21541, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
					
				}   
				else
				{
					this.AddButton(dbx, dby, 21541 ,21541 , 97 , GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				}   AddTooltip(1060600 );  
			}
	
			

// NINJITSU
		
			if ( HasSpell( from, 500 ) && m_Scroll.I08FocusAttack == 1)
			{ 
				if ( SpecialMove.GetCurrentMove( from ) is FocusAttack )
				{
					//this.AddButton(dbx, dby, 21280 ,21280 , 98 , GumpButtonType.Reply, 1);
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21280, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
					  
				}
				else
				{
					this.AddButton(dbx, dby, 21280, 21280, 98, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  
				}	  AddTooltip(1060610 );   
			}

            if ( HasSpell( from, 501 ) && m_Scroll.I01DeathStrike == 1)
			{
				if ( SpecialMove.GetCurrentMove( from ) is DeathStrike )
				{
					//this.AddButton(dbx, dby, 21281 ,21281 , 99 , GumpButtonType.Reply, 1);
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21281, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
					 
				}
				else
				{
					this.AddButton(dbx, dby, 21281, 21281, 99, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				}  AddTooltip(1060611 );   
			}
			
            if ( HasSpell( from, 502 ) && m_Scroll.I02AnimalForm == 1){this.AddButton(dbx, dby, 21282, 21282, 100, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } } 
			AddTooltip(1060612 );   }
			
            if ( HasSpell( from, 503 ) && m_Scroll.I03KiAttack == 1)
			{
				if ( SpecialMove.GetCurrentMove( from ) is KiAttack )
				{
					//this.AddButton(dbx, dby, 21283 ,21283 , 101 , GumpButtonType.Reply, 1);
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21283, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
					
					if ( !(SpecialMove.GetCurrentMove( from ) is KiAttack) )
						{
							from.CloseGump( typeof( SpellBarGump.SpellBar_BarGump ) );
					
							//int dbx = 0; int dbxa = 0; int dby = 0; int dbya = 0; int xselect_var = 0;
					
							from.SendGump(new SpellBarGump.SpellBar_BarGump(from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ));
						
						}
					
					
				}
				else
				{
					this.AddButton(dbx, dby, 21283, 21283, 101, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				}   AddTooltip(1060613 );   
			}
			
            if ( HasSpell( from, 504 ) && m_Scroll.I04SurpriseAttack == 1)
			{
				if ( SpecialMove.GetCurrentMove( from ) is SurpriseAttack )
				{
					//this.AddButton(dbx, dby, 21284 ,21284 , 102 , GumpButtonType.Reply, 1);
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21284, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
					
				}
				else
				{
					this.AddButton(dbx, dby, 21284, 21284, 102, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				}   AddTooltip(1060614 );   
			}
			
            if ( HasSpell( from, 505 ) && m_Scroll.I05Backstab == 1)
			{
				
				if ( SpecialMove.GetCurrentMove( from ) is Backstab )
				{
					//this.AddButton(dbx, dby, 21285 ,21285 , 103 , GumpButtonType.Reply, 1);
					//this.AddAlphaRegion(dbx, dby, 45, 45);
					AddImage( dbx, dby, 21285, 33 );
					dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; } if ( m_Scroll.Switch == 1 ) { if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; } }
					
				}
				else
				{
					this.AddButton(dbx, dby, 21285, 21285, 103, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
				}   AddTooltip(1060615 );   
			}
            if ( HasSpell( from, 506 ) && m_Scroll.I06Shadowjump == 1){this.AddButton(dbx, dby, 21286, 21286, 104, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }
			  AddTooltip(1060616 );   }
			
            if ( HasSpell( from, 507 ) && m_Scroll.I07MirrorImage == 1){
			this.AddButton(dbx, dby, 21287, 21287, 105, GumpButtonType.Reply, 1); 
			dbx = dbx + dbxa; dby = dby + dbya; 
			if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }   AddTooltip(1060617 );   }
			

// SPELLWEAVING

			if ( HasSpell( from, 600 ) && m_Scroll.S01ArcaneCircleSpell== 1){
		//	this.AddButton(dbx, dby, 23000, 23000, 106, GumpButtonType.Reply, 1); 
		this.AddButton(dbx, dby, 23000, 23000, 106, GumpButtonType.Reply, 1); 
			dbx = dbx + dbxa; dby = dby + dbya; 
			if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031601 );  }
			
			if ( HasSpell( from, 601 ) && m_Scroll.S02GiftOfRenewalSpell== 1){this.AddButton(dbx, dby, 23001, 23001, 107, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031602 );  }
			
			if ( HasSpell( from, 602 ) && m_Scroll.S03ImmolatingWeaponSpell== 1){this.AddButton(dbx, dby, 23002, 23002, 108, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031603 );  }
			
			if ( HasSpell( from, 603 ) && m_Scroll.S04AttuneWeaponSpell== 1){this.AddButton(dbx, dby, 23003, 23003, 109, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031604 );  }
			
			if ( HasSpell( from, 604 ) && m_Scroll.S05ThunderstormSpell== 1){this.AddButton(dbx, dby, 23004, 23004, 110, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031605 );  }
			
			if ( HasSpell( from, 605 ) && m_Scroll.S06NatureFurySpell== 1){this.AddButton(dbx, dby, 23005, 23005, 111, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031606 );  }
			
			if ( HasSpell( from, 606 ) && m_Scroll.S07SummonFeySpell== 1){this.AddButton(dbx, dby, 23006, 23006, 112, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031607 );  }
			
			if ( HasSpell( from, 607 ) && m_Scroll.S08SummonFiendSpell== 1){this.AddButton(dbx, dby, 23007, 23007, 113, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031608 );  }
			
			if ( HasSpell( from, 608 ) && m_Scroll.S09ReaperFormSpell== 1){this.AddButton(dbx, dby, 23008, 23008, 114, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031609 );  }
			
			if ( HasSpell( from, 609 ) && m_Scroll.S10WildfireSpell== 1){this.AddButton(dbx, dby, 23009, 23009, 115, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031610 );  }
			
			if ( HasSpell( from, 610 ) && m_Scroll.S11EssenceOfWindSpell== 1){this.AddButton(dbx, dby, 23010, 23010, 116, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031611 );  }
			
			if ( HasSpell( from, 611 ) && m_Scroll.S12DryadAllureSpell== 1){this.AddButton(dbx, dby, 23011, 23011, 117, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031612 );  }
			
			if ( HasSpell( from, 612 ) && m_Scroll.S13EtherealVoyageSpell== 1){this.AddButton(dbx, dby, 23012, 23012, 118, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031613 );  }
			
			if ( HasSpell( from, 613 ) && m_Scroll.S14WordOfDeathSpell== 1){this.AddButton(dbx, dby, 23013, 23013, 119, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031614 );  }
			
			if ( HasSpell( from, 614 ) && m_Scroll.S15GiftOfLifeSpell== 1){this.AddButton(dbx, dby, 23014, 23014, 120, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031615 );  }
			
			if ( HasSpell( from, 615 ) && m_Scroll.S16ArcaneEmpowermentSpell== 1){this.AddButton(dbx, dby, 23015, 23015, 121, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031616 );  }

 // MYSTICISM
			if ( HasSpell( from, 677 ) && m_Scroll.M01NetherBoltSpell== 1){this.AddButton(dbx, dby, 24000, 24000, 122, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031678 );  }
			
			if ( HasSpell( from, 678 ) && m_Scroll.M02HealingStoneSpell== 1){this.AddButton(dbx, dby, 24001, 24001, 123, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031679 );  }
			
			if ( HasSpell( from, 679 ) && m_Scroll.M03PurgeMagicSpell== 1){this.AddButton(dbx, dby, 24002, 24002, 124, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031680 );  }
			
			if ( HasSpell( from, 680 ) && m_Scroll.M04EnchantSpell== 1){this.AddButton(dbx, dby, 24003, 24003, 125, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031681 );  }
			
			if ( HasSpell( from, 681 ) && m_Scroll.M05SleepSpell== 1){this.AddButton(dbx, dby, 24004, 24004, 126, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031682 );  }
			
			if ( HasSpell( from, 682 ) && m_Scroll.M06EagleStrikeSpell== 1){this.AddButton(dbx, dby, 24005, 24005, 127, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031683 );  }
			
			if ( HasSpell( from, 683 ) && m_Scroll.M07AnimatedWeaponSpell== 1){this.AddButton(dbx, dby, 24006, 24006, 128, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031684 );  }
	////
			if ( HasSpell( from, 684 ) && m_Scroll.M16StoneFormSpell== 1){this.AddButton(dbx, dby, 24007, 24007, 129, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031685 );  }
			
			if ( HasSpell( from, 685 ) && m_Scroll.M08SpellTriggerSpell== 1){this.AddButton(dbx, dby, 24008, 24008, 130, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031686 );  }
			
			if ( HasSpell( from, 686 ) && m_Scroll.M09MassSleepSpell== 1){this.AddButton(dbx, dby, 24009, 24009, 131, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031687 );  }
			
			if ( HasSpell( from, 687 ) && m_Scroll.M10CleansingWindsSpell== 1){this.AddButton(dbx, dby, 24010, 24010, 132, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031688 );  }
			
			if ( HasSpell( from, 688 ) && m_Scroll.M11BombardSpell== 1){this.AddButton(dbx, dby, 24011, 24011, 133, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031689 );  }
			
			if ( HasSpell( from, 689 ) && m_Scroll.M12SpellPlagueSpell== 1){this.AddButton(dbx, dby, 24012, 24012, 134, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031690 );  }
			
			if ( HasSpell( from, 690 ) && m_Scroll.M13HailStormSpell== 1){this.AddButton(dbx, dby, 24013, 24013, 135, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031691 );  }
			
			if ( HasSpell( from, 691 ) && m_Scroll.M14NetherCycloneSpell== 1){this.AddButton(dbx, dby, 24014, 24014, 136, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031692 );  }
			
			if ( HasSpell( from, 692 ) && m_Scroll.M15RisingColossusSpell== 1){this.AddButton(dbx, dby, 24015, 24015, 137, GumpButtonType.Reply, 1); dbx = dbx + dbxa; dby = dby + dbya; if ( m_Scroll.Xselect_10 == 1) { xselect_var = 562; } if ( m_Scroll.Xselect_15 == 1) { xselect_var = 787; } if ( m_Scroll.Xselect_20 == 1) { xselect_var = 1012;  } if ( m_Scroll.Xselect_30 == 1) { xselect_var = 1462;  } if ( dbx + dbxa >= xselect_var & dby + dbya == 5 ) { dbx = 67; dbxa = 45; dby = 50; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 50 ) { dbx = 67; dbxa = 45; dby = 95; dbya = 0; }  if ( dbx + dbxa >= xselect_var & dby + dbya == 95 ) { dbx = 67; dbxa = 45; dby = 140; dbya = 0; }  if ( m_Scroll.Switch == 1 ) {  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 0 ) { dbx = 45; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 45 ) { dbx = 90; dbxa = 0; dby = 54; dbya = 45; }  if ( dby + dbya >= xselect_var - 13 & dbx + dbxa == 90 ) { dbx = 135; dbxa = 0; dby = 54; dbya = 45; } }  AddTooltip(1031693 );  }
			
			
			AddPage(2); // minimize _ horizontal
			
			this.AddImage( 24, 0, 2234, 0);
			AddImageTiled( 0,0, 25,80, 2624 ); //options background
			//this.AddBackground( 0,0, 25,80, 9270 ); //options background
			AddAlphaRegion( 0,0, 25,80 ); //options background
			this.AddButton( 2, 5,  5601, 5601, 0, GumpButtonType.Page, 1); // minimize
			
			AddPage(3); // minimize _ vertical
			
			this.AddImage( 0, 0, 2234, 0);
			AddImageTiled( 42,0, 47,51, 2624 ); //options background
			//this.AddBackground( 42,0, 47,51, 9270 ); 
			AddAlphaRegion( 42,0, 47,51 ); 
			this.AddButton( 48, 7,  5602, 5602, 0, GumpButtonType.Page, 1); // minimize
			
			
        }
   


        public override void OnResponse( NetState state, RelayInfo info )
        {
            Mobile from = state.Mobile;
           
            switch ( info.ButtonID )
            {
                case 0: { break; }
                case 1: {           if ( HasSpell( from, 0 ) ) { new ClumsySpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 2: {           if ( HasSpell( from, 1 ) ) { new CreateFoodSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 3: {           if ( HasSpell( from, 2 ) ) { new FeeblemindSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 4: {           if ( HasSpell( from, 3 ) ) { new HealSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 5: {           if ( HasSpell( from, 4 ) ) { new MagicArrowSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 6: {           if ( HasSpell( from, 5 ) ) { new NightSightSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 7: {           if ( HasSpell( from, 6 ) ) { new ReactiveArmorSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 8: {           if ( HasSpell( from, 7 ) ) { new WeakenSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 9: {           if ( HasSpell( from, 8 ) ) { new AgilitySpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 10: {           if ( HasSpell( from, 9 ) ) { new CunningSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 11: {           if ( HasSpell( from, 10 ) ) { new CureSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 12: {           if ( HasSpell( from, 11 ) ) { new HarmSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 13: {           if ( HasSpell( from, 12 ) ) { new MagicTrapSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 14: {           if ( HasSpell( from, 13 ) ) { new RemoveTrapSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 15: {           if ( HasSpell( from, 14 ) ) { new ProtectionSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 16: {           if ( HasSpell( from, 15 ) ) { new StrengthSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 17: {           if ( HasSpell( from, 16 ) ) { new BlessSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 18: {           if ( HasSpell( from, 17 ) ) { new FireballSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 19: {           if ( HasSpell( from, 18 ) ) { new MagicLockSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 20: {           if ( HasSpell( from, 19 ) ) { new PoisonSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 21: {           if ( HasSpell( from, 20 ) ) { new TelekinesisSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 22: {           if ( HasSpell( from, 21 ) ) { new TeleportSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 23: {           if ( HasSpell( from, 22 ) ) { new UnlockSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 24: {           if ( HasSpell( from, 23 ) ) { new WallOfStoneSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 25: {           if ( HasSpell( from, 24 ) ) { new ArchCureSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 26: {           if ( HasSpell( from, 25 ) ) { new ArchProtectionSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 27: {           if ( HasSpell( from, 26 ) ) { new CurseSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 28: {           if ( HasSpell( from, 27 ) ) { new FireFieldSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 29: {           if ( HasSpell( from, 28 ) ) { new GreaterHealSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 30: {           if ( HasSpell( from, 29 ) ) { new LightningSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 31: {           if ( HasSpell( from, 30 ) ) { new ManaDrainSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 32: {           if ( HasSpell( from, 31 ) ) { new RecallSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 33: {           if ( HasSpell( from, 32 ) ) { new BladeSpiritsSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 34: {           if ( HasSpell( from, 33 ) ) { new DispelFieldSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 35: {           if ( HasSpell( from, 34 ) ) { new IncognitoSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 36: {           if ( HasSpell( from, 35 ) ) { new MagicReflectSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 37: {           if ( HasSpell( from, 36 ) ) { new MindBlastSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 38: {           if ( HasSpell( from, 37 ) ) { new ParalyzeSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 39: {           if ( HasSpell( from, 38 ) ) { new PoisonFieldSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 40: {           if ( HasSpell( from, 39 ) ) { new SummonCreatureSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 41: {           if ( HasSpell( from, 40 ) ) { new DispelSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 42: {           if ( HasSpell( from, 41 ) ) { new EnergyBoltSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 43: {           if ( HasSpell( from, 42 ) ) { new ExplosionSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 44: {           if ( HasSpell( from, 43 ) ) { new InvisibilitySpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 45: {           if ( HasSpell( from, 44 ) ) { new MarkSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 46: {           if ( HasSpell( from, 45 ) ) { new MassCurseSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 47: {           if ( HasSpell( from, 46 ) ) { new ParalyzeFieldSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 48: {           if ( HasSpell( from, 47 ) ) { new RevealSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				//if (HasSpell( from, 47 ) && m_Scroll.W48_ChainLightningSpell == 1){this.AddButton(dbx, 5, 2287, 2287, 48, GumpButtonType.Reply, 1); }
				case 49: {           if ( HasSpell( from, 48 ) ) { new ChainLightningSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 50: {           if ( HasSpell( from, 49 ) ) { new EnergyFieldSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 51: {           if ( HasSpell( from, 50 ) ) { new FlameStrikeSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 52: {           if ( HasSpell( from, 51 ) ) { new GateTravelSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 53: {           if ( HasSpell( from, 52 ) ) { new ManaVampireSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 54: {           if ( HasSpell( from, 53 ) ) { new MassDispelSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 55: {           if ( HasSpell( from, 54 ) ) { new MeteorSwarmSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 56: {           if ( HasSpell( from, 55 ) ) { new PolymorphSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 57: {           if ( HasSpell( from, 56 ) ) { new EarthquakeSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 58: {           if ( HasSpell( from, 57 ) ) { new EnergyVortexSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 59: {           if ( HasSpell( from, 58 ) ) { new ResurrectionSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 60: {           if ( HasSpell( from, 59 ) ) { new AirElementalSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 61: {           if ( HasSpell( from, 60 ) ) { new SummonDaemonSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 62: {           if ( HasSpell( from, 61 ) ) { new EarthElementalSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 63: {           if ( HasSpell( from, 62 ) ) { new FireElementalSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 64: {           if ( HasSpell( from, 63 ) ) { new WaterElementalSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }

    // NECROMANCY
                case 65: {           if ( HasSpell( from, 100 ) ) { new AnimateDeadSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 66: {           if ( HasSpell( from, 101 ) ) { new BloodOathSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 67: {           if ( HasSpell( from, 102 ) ) { new CorpseSkinSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 68: {           if ( HasSpell( from, 103 ) ) { new CurseWeaponSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 69: {           if ( HasSpell( from, 104 ) ) { new EvilOmenSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 70: {           if ( HasSpell( from, 105 ) ) { new HorrificBeastSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 71: {           if ( HasSpell( from, 106 ) ) { new LichFormSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 72: {           if ( HasSpell( from, 107 ) ) { new MindRotSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 73: {           if ( HasSpell( from, 108 ) ) { new PainSpikeSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 74: {           if ( HasSpell( from, 109 ) ) { new PoisonStrikeSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 75: {           if ( HasSpell( from, 110 ) ) { new StrangleSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 76: {           if ( HasSpell( from, 111 ) ) { new SummonFamiliarSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 77: {           if ( HasSpell( from, 112 ) ) { new VampiricEmbraceSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 78: {           if ( HasSpell( from, 113 ) ) { new VengefulSpiritSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 79: {           if ( HasSpell( from, 114 ) ) { new WitherSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 80: {           if ( HasSpell( from, 115 ) ) { new WraithFormSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 81: {           if ( HasSpell( from, 116 ) ) { new ExorcismSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }

    // CHIVALRY

                case 82 : {           if ( HasSpell( from, 200 ) ) { new CleanseByFireSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 83 : {           if ( HasSpell( from, 201 ) ) { new CloseWoundsSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }  
                case 84 : {           if ( HasSpell( from, 202 ) ) { new ConsecrateWeaponSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 85 : {           if ( HasSpell( from, 203 ) ) { new DispelEvilSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 86 : {           if ( HasSpell( from, 204 ) ) { new DivineFurySpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 87 : {           if ( HasSpell( from, 205 ) ) { new EnemyOfOneSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 88 : {           if ( HasSpell( from, 206 ) ) { new HolyLightSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 89 : {           if ( HasSpell( from, 207 ) ) { new NobleSacrificeSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 90 :  {           if ( HasSpell( from, 208 ) ) { new RemoveCurseSpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 91 : {           if ( HasSpell( from, 209 ) ) { new SacredJourneySpell( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; } 
				
	// BUSHIDO
				
				case 92: {           if ( HasSpell( from, 400) )  {  SamuraiMove.SetCurrentMove( from, new HonorableExecution() ); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) );  }  break;  }
				
                case 93: {           if ( HasSpell( from, 401 ) ) { new Confidence ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 94: {           if ( HasSpell( from, 402 ) ) { new Evasion ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
                case 95: {           if ( HasSpell( from, 403 ) ) { new CounterAttack ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 96: 
				{ 
					          if ( HasSpell( from, 404 ) ) 
					{ 
						
						SamuraiMove.SetCurrentMove( from, new LightningStrike() ); 
						from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); 
					}
					
					break; 
				}
                case 97: {           if ( HasSpell( from, 405  ) ) { SamuraiMove.SetCurrentMove( from, new MomentumStrike() ); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
				
	// NINJITSU
				case 98: 
				{            if ( HasSpell( from, 500) ) { NinjaMove.SetCurrentMove( from, new FocusAttack() ); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); }  break; }
				
                case 99: {           if ( HasSpell( from, 501 ) ) { NinjaMove.SetCurrentMove( from, new DeathStrike() ); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
                case 100: {           if ( HasSpell( from, 502 ) ) { new AnimalForm ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
                case 101: {           if ( HasSpell( from, 503 ) ) { NinjaMove.SetCurrentMove( from, new KiAttack() ); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
                case 102: {           if ( HasSpell( from, 504 ) ) { NinjaMove.SetCurrentMove( from, new SurpriseAttack() ); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
                case 103: {           if ( HasSpell( from, 505 ) ) { NinjaMove.SetCurrentMove( from, new Backstab() ); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
                 case 104: {           if ( HasSpell( from, 506 ) ) { new Shadowjump ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				 
                case 105: {           if ( HasSpell( from, 507 ) ) { new MirrorImage ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
			
				
			
	// SPELLWEAVING

                case 106 : {           if ( HasSpell( from, 600 ) ) { new ArcaneCircleSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 107 : {           if ( HasSpell( from, 601 ) ) { new GiftOfRenewalSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 108 : {           if ( HasSpell( from, 602 ) ) { new ImmolatingWeaponSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 109 : {           if ( HasSpell( from, 603 ) ) { new AttuneWeaponSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 110 : {           if ( HasSpell( from, 604 ) ) { new ThunderstormSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 111 : {           if ( HasSpell( from, 605 ) ) { new NatureFurySpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 112 : {           if ( HasSpell( from, 606 ) ) { new SummonFeySpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 113 : {           if ( HasSpell( from, 607 ) ) { new SummonFiendSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 114 : {           if ( HasSpell( from, 608 ) ) { new ReaperFormSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 115 : {           if ( HasSpell( from, 609) ) { new WildfireSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 116: {           if ( HasSpell( from, 610) ) { new EssenceOfWindSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 117: {           if ( HasSpell( from, 611) ) { new DryadAllureSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 118 : {           if ( HasSpell( from, 612) ) { new EtherealVoyageSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 119: {           if ( HasSpell( from, 613) ) { new WordOfDeathSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 120: {           if ( HasSpell( from, 614) ) { new GiftOfLifeSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 121: {           if ( HasSpell( from, 615) ) { new ArcaneEmpowermentSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
	// MYSTICISM
				
				case 122: {           if ( HasSpell( from, 677) ) { new NetherBoltSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 123: {           if ( HasSpell( from, 678) ) { new HealingStoneSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 124: {           if ( HasSpell( from, 679) ) { new PurgeMagicSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 125 : {           if ( HasSpell( from, 680) ) { new EnchantSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 126: {           if ( HasSpell( from, 681) ) { new SleepSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 127: {           if ( HasSpell( from, 682) ) { new EagleStrikeSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 128: {           if ( HasSpell( from, 683) ) { new AnimatedWeaponSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
	/////////////////
				case 129: {           if ( HasSpell( from, 684) ) { new StoneFormSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
				case 130: {           if ( HasSpell( from, 685) ) { new SpellTriggerSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 131: {           if ( HasSpell( from, 686) ) { new MassSleepSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 132: {           if ( HasSpell( from, 687) ) { new CleansingWindsSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 133: {           if ( HasSpell( from, 688) ) { new BombardSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 134: {           if ( HasSpell( from, 689) ) { new SpellPlagueSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 135: {           if ( HasSpell( from, 690) ) { new HailStormSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 136: {           if ( HasSpell( from, 691) ) { new NetherCycloneSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				case 137: {           if ( HasSpell( from, 692) ) { new RisingColossusSpell ( from, null ).Cast(); from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); } break; }
				
				case 138: 
				{ 
					         
					
					if ( m_Scroll.Switch == 0)
					{
						m_Scroll.Switch = 1; m_Scroll.Count += 1;
						from.SendGump( new SpellBar_BarGump( from, m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); 
					}
					else
					{
						m_Scroll.Switch = 0;
						from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) );  
					} 

					break; 	
				}
				
				case 139: 
				{ 
					         
					
					if ( m_Scroll.Lock == 0)
					{
						m_Scroll.Lock = 1; m_Scroll.Count += 1;
						from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) ); 
					}
					else
					{
						m_Scroll.Lock = 0;
						from.SendGump( new SpellBar_BarGump( from,  m_Scroll, m_Scroll.Xo, m_Scroll.Yo ) );  
					} 

					break; 	
				}
				
            }
        }
    }
       
    }
 }

 