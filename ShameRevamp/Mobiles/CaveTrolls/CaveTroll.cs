using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	 [CorpseName( "a cave troll corpse" )]
	 public class CaveTroll : BaseCreature
	 {
			
		
			private ShameWall_1 mWall;
			
			
			[CommandProperty( AccessLevel.GameMaster )]
		public ShameWall_1 Link
		{
			get
			{
				return mWall;
			}
		}
	 
	 
		  [Constructable]
		  public CaveTroll (ShameWall_1 wall) : base( AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4 )
		  {
				mWall = wall;
		  
				Title = "the Wall Guardian";
			   Name = "a cave troll";
			   Body = Utility.RandomList( 53, 54 );
			   BaseSoundID = 461;
			   Hue = 2116;

			   SetStr( 180, 205 );
			   SetDex( 122, 142 );
			   SetInt( 47, 64 );

			   SetHits( 722, 887 );

			   SetDamage( 15, 17 );

			   SetDamageType( ResistanceType.Physical, 100 );

			   SetResistance( ResistanceType.Physical, 55, 65 );
			   SetResistance( ResistanceType.Fire, 45, 55 );
			   SetResistance( ResistanceType.Cold, 45, 55 );
			   SetResistance( ResistanceType.Poison, 35, 45 );
			   SetResistance( ResistanceType.Energy, 35, 45 );

			   SetSkill( SkillName.MagicResist, 71.7, 82.9 );
			   SetSkill( SkillName.Tactics, 87.9, 101.6 );
			   SetSkill( SkillName.Wrestling, 81.5, 104.5 );
			   SetSkill( SkillName.Anatomy, 0.0 );
			   

			   Fame = 3500;
			   Karma = -3500;

			   VirtualArmor = 40;
			   
			   // sets home location as the wall location
			   // this way the troll won't wander too far
			   // default rangehome is 10
			   this.Home = mWall.Location;
			  
		  }
		  
		 
		  
		

		  public override void GenerateLoot()
			  {
			   AddLoot( LootPack.Average );
			   
			  }
			  
		
		 
		public override WeaponAbility GetWeaponAbility() { return WeaponAbility.ArmorIgnore; }
		  public override bool CanRummageCorpses{ get{ return true; } }
		  public override int TreasureMapLevel{ get{ return 1; } }
		  public override int Meat{ get{ return 2; } }
		  


		

		public override bool OnBeforeDeath()
		{
			this.mWall.RemoveTele();
			this.mWall.Delete();
				
			//new PKLGate( ).MoveToWorld( new Point3D( 5404, 85, 10), Map );
				
			return base.OnBeforeDeath();
		}

     
		  
		  public CaveTroll( Serial serial ) : base( serial )
			  {
			  }

		public override void Serialize( GenericWriter writer )
		{
			   base.Serialize( writer );
			   writer.Write( (int) 0 );
			   
				writer.Write( ( Item )mWall );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			   
			mWall = ( ShameWall_1 )reader.ReadItem( );
		}
	
		
	 }
}