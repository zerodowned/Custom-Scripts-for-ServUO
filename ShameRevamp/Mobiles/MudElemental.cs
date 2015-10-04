

    using System;
    using System.Collections;
    using Server.Items;
    using Server.Targeting;
    namespace Server.Mobiles
    {
		 [CorpseName( "a mud elemental corpse" )]
		 public class MudElemental : BaseCreature
		 {

			  public override double DispelDifficulty{ get{ return 117.5; } }
			  public override double DispelFocus{ get{ return 45.0; } }

			  [Constructable]
			  public MudElemental () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
				  {
				   Name = "a mud elemental";
				   Body = 14;
				   Hue= 2418;
				   BaseSoundID = 268;
				   SetStr( 448, 523 );
				   SetDex( 76, 94 );
				   SetInt( 92, 111 );
				   SetHits( 690, 828 );
				   SetDamage( 17, 19 );

				   SetDamageType( ResistanceType.Physical, 50 );
					SetDamageType( ResistanceType.Fire, 50 );

				   SetResistance( ResistanceType.Physical, 60, 65 );
				   SetResistance( ResistanceType.Fire, 45, 50 );
				   SetResistance( ResistanceType.Cold, 45, 50 );
				   SetResistance( ResistanceType.Poison, 55, 60 );
				   SetResistance( ResistanceType.Energy, 40, 45 );

				   SetSkill( SkillName.MagicResist, 90.0, 100.0 );
				   SetSkill( SkillName.Tactics, 85.0, 100.0 );
				   SetSkill( SkillName.Wrestling, 90.0, 120.0 );

				   Fame = 4000;
				   Karma = -4000;

				   VirtualArmor = 34;

				  

				   //PackItem( new FertileDirt( Utility.RandomMinMax( 1, 4 ) ) );
				   //PackItem( new IronOre( 3 ) ); // TODO: Five small iron ore
				   //PackItem( new MandrakeRoot() );
				  // shamecrystal
				  }

			  public override void GenerateLoot()
			  {
			   AddLoot( LootPack.Average );
			   AddLoot( LootPack.Meager );
			   AddLoot( LootPack.Gems );
			  }

			  public override bool BleedImmune{ get{ return true; } }
			  public override int TreasureMapLevel{ get{ return 1; } }

			  public MudElemental ( Serial serial ) : base( serial )
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