using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	 [CorpseName( "an air elemental corpse" )]
	 public class ShameAirElementalGuardian : BaseCreature
	 {
		  //public override double DispelDifficulty{ get{ return 117.5; } }
		  //public override double DispelFocus{ get{ return 45.0; } }

		  [Constructable]
		  public ShameAirElementalGuardian () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
			   Name = "an air elemental";
			   Body = 13;
			   Hue = 0x4001;
			   BaseSoundID = 655;

			   SetStr( 270, 295 );
			   SetDex( 180, 200 );
			   SetInt( 130, 160 );

			   SetHits( 790, 850 );

			   SetDamage( 13, 18 );

			   SetDamageType( ResistanceType.Physical, 20 );
			   SetDamageType( ResistanceType.Cold, 40 );
			   SetDamageType( ResistanceType.Energy, 40 );

			   SetResistance( ResistanceType.Physical, 75, 85);
			   SetResistance( ResistanceType.Fire, 45, 60 );
			   SetResistance( ResistanceType.Cold, 50, 60 );
			   SetResistance( ResistanceType.Poison, 50, 60 );
			   SetResistance( ResistanceType.Energy, 40, 55 );

			   SetSkill( SkillName.EvalInt, 90.0, 103.0 );
			   SetSkill( SkillName.Magery, 85.0, 105.0 );
			   SetSkill( SkillName.MagicResist, 90.0, 105.0 );
			   SetSkill( SkillName.Tactics, 90.0, 105.0 );
			   SetSkill( SkillName.Wrestling, 90.0, 115.0 );

			   Fame = 4500;
			   Karma = -4500;

			   VirtualArmor = 40;
			   //ControlSlots = 2;
			  }

		  public override void GenerateLoot()
		  {
		   AddLoot( LootPack.Average );
		   AddLoot( LootPack.Meager );
		   AddLoot( LootPack.LowScrolls );
		   AddLoot( LootPack.MedScrolls );
		  }

		  public override bool BleedImmune{ get{ return true; } }
		  public override int TreasureMapLevel{ get{ return 2; } }

		  public ShameAirElementalGuardian ( Serial serial ) : base( serial )
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

		   if ( BaseSoundID == 263 )
			BaseSoundID = 655;
		  }
	 }
}