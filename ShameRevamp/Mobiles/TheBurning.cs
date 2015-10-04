using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "a burnt corpse" )] 
	public class TheBurning : AuraCreature 
	{ 
		[Constructable] 
		public TheBurning() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
		
			AuraMessage = "The intense heat is damaging you!"; // // TODO Cliloc support: 1008112
			AuraType = ResistanceType.Fire;
			MinAuraDelay = 1;
			MaxAuraDelay = 3;
			MinAuraDamage = 2;
			MaxAuraDamage = 4;
			AuraRange = 5;
			
			Title = "the Burning";
			Name = NameList.RandomName( "male" );
			//Title = "Burning";
			Body = 400;
			Hue = 1255;
			
			AddItem( new Robe( Utility.RandomNeutralHue() ) );
			AddItem( new Sandals( Utility.RandomNeutralHue() ) );
			Utility.AssignRandomHair( this );
			Utility.AssignRandomFacialHair( this );
/*
			public virtual int GetHairHue()
		{
			return Utility.RandomHairHue();
		}
*/
			SetStr( 100, 125 );
			SetDex( 91, 115 );
			SetInt( 96, 120 );

			SetHits( 150, 250 );

			SetDamage( 8, 15 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Fire, 70 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.EvalInt, 75.1, 100.0 );
			SetSkill( SkillName.Magery, 75.1, 100.0 );
			SetSkill( SkillName.MagicResist, 75.0, 97.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 20.2, 60.0 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 36;
			PackReg( 6 );
			//PackItem( new Robe( Utility.RandomNeutralHue() ) ); // TODO: Proper hue
			//PackItem( new Sandals() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int TreasureMapLevel{ get{ return Core.AOS ? 1 : 0; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled

		public TheBurning( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}