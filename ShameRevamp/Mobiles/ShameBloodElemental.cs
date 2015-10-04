using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	 [CorpseName( "a blood elemental corpse" )]
	 public class ShameBloodElemental : BaseCreature
	 {
		  [Constructable]
		  public ShameBloodElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
			   Name = "a blood elemental";
			   Body = 159;
			   BaseSoundID = 278;

			   SetStr( 526, 615 );
			   SetDex( 66, 85 );
			   SetInt( 226, 350 );

			   SetHits( 1390, 1450 );

			   SetDamage( 17, 27 );

			   SetDamageType( ResistanceType.Physical, 0 );
			   SetDamageType( ResistanceType.Poison, 50 );
			   SetDamageType( ResistanceType.Energy, 50 );

			 

			   SetResistance( ResistanceType.Physical, 55, 65 );
			   SetResistance( ResistanceType.Fire, 35, 45 );
			   SetResistance( ResistanceType.Cold, 40, 50 );
			   SetResistance( ResistanceType.Poison, 50, 60 );
			   SetResistance( ResistanceType.Energy, 30, 40 );

			   SetSkill( SkillName.EvalInt, 90.0, 120.0 );
			   SetSkill( SkillName.Magery, 85.1, 100.0 );
			   SetSkill( SkillName.Meditation, 100.0, 135.0 );
			   SetSkill( SkillName.MagicResist, 100.0, 115.0 );
			   SetSkill( SkillName.Tactics, 100.0, 120.0 );
			   SetSkill( SkillName.Wrestling, 95.0, 120.0 );

			   Fame = 12500;
			   Karma = -12500;

			   VirtualArmor = 60;
			  }

		  public override void GenerateLoot()
		  {
		   AddLoot( LootPack.FilthyRich );
		   AddLoot( LootPack.Rich );
		  }

		  public override int TreasureMapLevel{ get{ return 5; } }

		  public ShameBloodElemental ( Serial serial ) : base( serial )
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