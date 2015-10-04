using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	 [CorpseName( "a poison elementals corpse" )]
	 public class ShamePoisonElemental : BaseCreature
	 {
		  [Constructable]
		  public ShamePoisonElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
			   Name = "a poison elemental";
			   Body = 162;
			   BaseSoundID = 263;

			   SetStr( 445, 475 );
			   SetDex( 170, 175 );
			   SetInt( 405, 435 );

			   SetHits( 980, 1020 );

			   SetDamage( 16, 19 );

			   SetDamageType( ResistanceType.Physical, 10 );
			   SetDamageType( ResistanceType.Poison, 90 );

			 

			   SetResistance( ResistanceType.Physical, 65, 75 );
			   SetResistance( ResistanceType.Fire, 50, 55 );
			   SetResistance( ResistanceType.Cold, 50, 55 );
			   SetResistance( ResistanceType.Poison, 100 );
			   SetResistance( ResistanceType.Energy, 40, 50 );

			   SetSkill( SkillName.EvalInt, 90.0, 100.0 );
			   SetSkill( SkillName.Magery, 95.0, 105.0 );
			   SetSkill( SkillName.Meditation, 105.0, 120.0 );
			   SetSkill( SkillName.Poisoning, 90.1, 100.0 );
			   SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			   SetSkill( SkillName.Tactics, 95.0, 115.0 );
			   SetSkill( SkillName.Wrestling, 100.0, 115.0 );

			   Fame = 12500;
			   Karma = -12500;

			   VirtualArmor = 70;

			   PackItem( new Nightshade( 4 ) );
			   PackItem( new LesserPoisonPotion() );
			  }

		  public override void GenerateLoot()
		  {
		   AddLoot( LootPack.FilthyRich );
		   AddLoot( LootPack.Rich );
		   AddLoot( LootPack.MedScrolls );
		  }

		  public override bool BleedImmune{ get{ return true; } }
		  public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		  public override Poison HitPoison{ get{ return Poison.Lethal; } }
		  public override double HitPoisonChance{ get{ return 0.75; } }

		  public override int TreasureMapLevel{ get{ return 5; } }

		  public ShamePoisonElemental ( Serial serial ) : base( serial )
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