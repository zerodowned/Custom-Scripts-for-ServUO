using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

/* to do 
At about 35% health it goes into a rage, at which point it has a good chance of dealing out hits with "stunning force" which leave the player paralyzed and unable to move, attack or cast for about 5 seconds. 
*/

namespace Server.Mobiles
{
	 [CorpseName( "a greater earth elemental corpse" )]
	 public class GreaterEarthElemental : BaseCreature
	 {
		  
		  [Constructable]
		  public GreaterEarthElemental () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
				   Name = "a greater earth elemental";
				   Body = 14;
				   BaseSoundID = 268;

				   SetStr( 129, 154 ); 
				   SetDex( 76, 95 );
				   SetInt( 91, 108 );

				   SetHits( 537, 582 );

				   SetDamage( 9, 16 );

				   SetDamageType( ResistanceType.Physical, 100 );

				   SetResistance( ResistanceType.Physical, 50, 65 );
				   SetResistance( ResistanceType.Fire, 35, 45 );
				   SetResistance( ResistanceType.Cold, 35, 40 );
				   SetResistance( ResistanceType.Poison, 45, 55 );
				   SetResistance( ResistanceType.Energy, 25, 35 );

				   SetSkill( SkillName.MagicResist, 49.7, 60.7 );
				   SetSkill( SkillName.Tactics, 71.4, 84.1 );
				   SetSkill( SkillName.Wrestling, 82.4, 91.1 );

				   Fame = 2500;
				   Karma = -2500;

				   VirtualArmor = 34;
				   //ControlSlots = 2;

				   //PackItem( new FertileDirt( Utility.RandomMinMax( 1, 4 ) ) );
				   //PackItem( new IronOre( 3 ) ); // TODO: Five small iron ore
				   //PackItem( new MandrakeRoot() );

				   ////shamecrystal
			  }

		  public override void GenerateLoot()
			  {
			   AddLoot( LootPack.Average );
			   AddLoot( LootPack.Meager );
			   AddLoot( LootPack.Gems );
			  }

		  public override bool BleedImmune{ get{ return true; } }
		  public override int TreasureMapLevel{ get{ return 1; } }

		  public GreaterEarthElemental ( Serial serial ) : base( serial )
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