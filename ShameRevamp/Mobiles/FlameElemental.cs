using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a flame elemental corpse" )]
	public class FlameElemental : AuraCreature
	{
		//public override double DispelDifficulty{ get{ return 117.5; } }
		//public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public FlameElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a flame elemental";
			Body = 15;
			BaseSoundID = 838;

			SetStr( 435, 450 );
			SetDex( 166, 185 );
			SetInt( 130, 165 );
			
			SetMana( 1020, 1285 );
			SetStam( 165, 205 );
			SetHits( 720, 780 );

			SetDamage( 18, 20 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 75 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.EvalInt, 97.0, 134.0 );
			SetSkill( SkillName.Meditation, 80.0, 115.0 );
			SetSkill( SkillName.Magery, 104.0, 142.0 );
			SetSkill( SkillName.MagicResist, 96.0, 140.0 );
			SetSkill( SkillName.Tactics, 90.0, 122.0 );
			SetSkill( SkillName.Wrestling, 90.0, 116.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 40;
			ControlSlots = 4;

			PackItem( new SulfurousAsh( 3 ) );

			AddItem( new LightSource() );
			
			AuraMessage = "The intense heat is damaging you!"; // // TODO Cliloc support: 1008112
			AuraType = ResistanceType.Fire;
			MinAuraDelay = 1;
			MaxAuraDelay = 3;
			MinAuraDamage = 2;
			MaxAuraDamage = 4;
			AuraRange = 5;
			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Gems );
		}

		public override bool BleedImmune{ get{ return true; } }
	//	public override int TreasureMapLevel{ get{ return 3; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return !Controlled; } }

		public FlameElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 274 )
				BaseSoundID = 838;
		}
	}
}

   