using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	 [CorpseName( "a water elemental corpse" )]
	 public class ShameWaterElemental : BaseCreature
	 {
		  //public override double DispelDifficulty{ get{ return 117.5; } }
		  //public override double DispelFocus{ get{ return 45.0; } }

		  [Constructable]
		  public ShameWaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
			   Name = "a water elemental";
			   Body = 16;
			   BaseSoundID = 278;

			   SetStr( 126, 155 );
			   SetDex( 66, 85 );
			   SetInt( 101, 125 );

			   SetHits( 570, 595 );

			   SetDamage( 14, 16 );

			   SetDamageType( ResistanceType.Physical, 50);
			   SetDamageType( ResistanceType.Cold, 50 );

			   SetResistance( ResistanceType.Physical, 35, 45 );
			   SetResistance( ResistanceType.Fire, 45, 50 );
			   SetResistance( ResistanceType.Cold, 53, 58 );
			   SetResistance( ResistanceType.Poison, 70, 75 );
			   SetResistance( ResistanceType.Energy, 40, 50 );

			   SetSkill( SkillName.EvalInt, 91.0, 95.0 );
			   SetSkill( SkillName.Magery, 96.0, 105.0 );
			   SetSkill( SkillName.MagicResist, 100.0, 105.0 );
			   SetSkill( SkillName.Tactics, 99.0, 110.0 );
			   SetSkill( SkillName.Wrestling, 95.0, 103.1 );

			   Fame = 4500;
			   Karma = -4500;

			   VirtualArmor = 40;
			   //ControlSlots = 3;
			   CanSwim = true;

			   PackItem( new BlackPearl( 3 ) );
			  }

		  public override void GenerateLoot()
		  {
		   AddLoot( LootPack.Average );
		   AddLoot( LootPack.Meager );
		   AddLoot( LootPack.Potions );
		  }

		  public override bool BleedImmune{ get{ return true; } }
		  public override int TreasureMapLevel{ get{ return 2; } }

		  public ShameWaterElemental ( Serial serial ) : base( serial )
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