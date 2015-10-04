using System;
using Server.Items;

namespace Server.Mobiles
{
	 [CorpseName( "a mud pie corpse" )]
	 public class MudPie: BaseCreature
	 {
		  [Constructable]
		  public MudPie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
				   Name = "a mud pie";
				   Body = 779;
				   BaseSoundID = 422;

				   SetStr( 145, 204 );
				   SetDex( 75, 93 );
				   SetInt( 97, 110 );

				   SetHits( 284, 336 );

				   SetDamage( 9, 12 );

				   SetDamageType( ResistanceType.Physical, 80 );
				   SetDamageType( ResistanceType.Poison, 20 );

				   SetResistance( ResistanceType.Physical, 30, 45 );
				   SetResistance( ResistanceType.Fire, 35, 40 );
				   SetResistance( ResistanceType.Cold, 30, 40 );
				   SetResistance( ResistanceType.Poison, 35, 45 );
				   SetResistance( ResistanceType.Energy, 40 );

				   SetSkill( SkillName.MagicResist, 64.6, 85.0 );
				   SetSkill( SkillName.Tactics, 66.2, 85.0 );
				   SetSkill( SkillName.Wrestling, 65.0, 81.8 );

				   Fame = 3500;
				   Karma = -3500;

				   VirtualArmor = 28;

				   //PackItem( new Log( 4 ) );
				   //PackItem( new Engines.Plants.Seed() );
				   //SHAME CRYSTAL
			  }

		  public override void GenerateLoot()
			  {
			   AddLoot( LootPack.Meager );
			  }
			  
	/*	public override void OnDeath(Container c)
			{
				base.OnDeath(c);
 
					if (Utility.RandomDouble() < 0.30)
						{
						switch (Utility.Random(1))
							{
							case 0: c.DropItem(new ShameCrystal()); break;
 
							}
						}
			}  
	*/
		  //public override int Hides{ get{ return 6; } }
		  //public override int Meat{ get{ return 1; } }

		  public MudPie( Serial serial ) : base( serial )
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