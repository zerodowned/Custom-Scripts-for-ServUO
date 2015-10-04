using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

/* to do 
Stunning Blow, at about 35% health it goes into a rage, at which point it has a good chance of dealing out hits with "stunning force" which leave the player paralyzed and unable to move, attack or cast for about 5 seconds. 
*/


namespace Server.Mobiles
{
	 [CorpseName( "a stone elemental corpse" )]
	 public class StoneElemental : BaseCreature
	 {
		  public override double DispelDifficulty{ get{ return 117.5; } }
		  public override double DispelFocus{ get{ return 45.0; } }

		  [Constructable]
		  public StoneElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
				   Name = "a stone elemental";
				   Body = 14;
				   BaseSoundID = 268;
				   Hue= 741;

				   SetStr( 163, 184 );
				   SetDex( 85, 105 );
				   SetInt( 97, 115 );

				   SetHits( 925, 975 );

				   SetDamage( 15, 17 );

				   SetDamageType( ResistanceType.Physical, 100 );

				   SetResistance( ResistanceType.Physical, 60, 65 );
				   SetResistance( ResistanceType.Fire, 45, 50 );
				   SetResistance( ResistanceType.Cold, 45, 50 );
				   SetResistance( ResistanceType.Poison, 55, 60 );
				   SetResistance( ResistanceType.Energy, 40, 45 );

				   SetSkill( SkillName.MagicResist, 100.0 );
				   SetSkill( SkillName.Tactics, 85.9, 95.0 );
				   SetSkill( SkillName.Wrestling, 85.0, 95.3 );

				   Fame = 4000;
				   Karma = -4000;

				   VirtualArmor = 34;
				   ControlSlots = 2;

				   //PackItem( new FertileDirt( Utility.RandomMinMax( 1, 4 ) ) );
				   //PackItem( new IronOre( 3 ) ); // TODO: Five small iron ore
				   //PackItem( new MandrakeRoot() );

				   //shamecrystal
			  }

		  public override void GenerateLoot()
			  {
			   AddLoot( LootPack.Average );
			   AddLoot( LootPack.Meager );
			   AddLoot( LootPack.Gems );
			  }

		  public override bool BleedImmune{ get{ return true; } }
		  public override int TreasureMapLevel{ get{ return 1; } }

		  public StoneElemental( Serial serial ) : base( serial )
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