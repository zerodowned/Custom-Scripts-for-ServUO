using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	 public class CorruptedMage: BaseCreature
	 {
		  

		  [Constructable]
		  public CorruptedMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
			   //SpeechHue = Utility.RandomDyedHue();
			   //Title = "the brigand";
			   //Hue = Utility.RandomSkinHue();
			
			   if ( this.Female = Utility.RandomBool() )
			   {
				Body = 0x191;
				Name = NameList.RandomName( "female" );
				AddItem( new HoodedShroudOfShadows( Utility.RandomNeutralHue() ) );
			   }
			   else
			   {
				Body = 0x190;
				Name = NameList.RandomName( "male" );
				AddItem( new HoodedShroudOfShadows( Utility.RandomNeutralHue() ) );
			   }
			
				//Body = 0x4E1;
			   SetStr( 130, 170 );
			   SetDex( 110, 120 );
			   SetInt( 180, 200 );

			   SetHits( 1110, 1300 );

			   SetDamage( 14, 17 );

			   SetDamageType( ResistanceType.Physical, 100 );

			   SetResistance( ResistanceType.Physical, 75, 85);
				  SetResistance( ResistanceType.Fire, 65, 75 );
				  SetResistance( ResistanceType.Cold, 60, 70 );
				  SetResistance( ResistanceType.Poison, 60, 70 );
				  SetResistance( ResistanceType.Energy, 60, 70 );
			 
			   //SetSkill( SkillName.Fencing, 66.0, 97.5 );
			   //SetSkill( SkillName.Macing, 65.0, 87.5 );
			   SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			   
			   SetSkill( SkillName.Tactics, 65.0, 87.5 );
			   SetSkill( SkillName.Wrestling, 100.0, 110.0 );
			   SetSkill( SkillName.Magery, 120.0, 130.0 );
			   SetSkill( SkillName.EvalInt, 120.0, 130.0 );

			   Fame = 1000;
			   Karma = -1000;

			   //AddItem( new Boots( Utility.RandomNeutralHue() ) );
			   //AddItem( new FancyShirt());
			   //AddItem( new Bandana());
			/*
			   switch ( Utility.Random( 7 ))
			   {
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Broadsword() ); break;
				case 3: AddItem( new Axe() ); break;
				case 4: AddItem( new Club() ); break;
				case 5: AddItem( new Dagger() ); break;
				case 6: AddItem( new Spear() ); break;
			   }
			*/

			  // Utility.AssignRandomHair( this );
			  }

		  public override void GenerateLoot()
		  {
		   AddLoot( LootPack.Average );
		  }

		  public override bool AlwaysMurderer{ get{ return true; } }

		  public CorruptedMage( Serial serial ) : base( serial )
		  {
		  }

		  public override void Serialize( GenericWriter writer )
		  {
		   base.Serialize( writer );

		   writer.Write( (int) 0 ); // version
		  }

		  public override void Deserialize( GenericReader reader )
		  {
		   base.Deserialize( reader );

		   int version = reader.ReadInt();
		  }
	 }
}