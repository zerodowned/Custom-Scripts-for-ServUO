using System;
using Server;
using Server.Items;
using System.Collections;

/*

Quartz Elemental is the champion of the first level of the dungeon Shame. It can be challenged by clicking on the Guardian's Altar at 139° N, 73° W which will cost 10 dungeon points for Shame. Note that you will have one hour to find and defeat it.
*/

namespace Server.Mobiles
{
	 [CorpseName( "a quartz elemental corpse" )]
	 public class QuartzElementalGuardian : BaseCreature
	{
			private DateTime m_DecayTime;
			public virtual TimeSpan Delay{ get{ return TimeSpan.FromMinutes( 1.0 ); } }
			
			private ShameAltarAddon mShameAltarAddon;

		  [Constructable]
		  public QuartzElementalGuardian (ShameAltarAddon altar) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
					mShameAltarAddon = altar;
					
				   Name = "a quartz elemental Guardian";
				   Body = 107;
				   BaseSoundID = 268;

				   SetStr( 226, 255 );
				   SetDex( 75, 120 );
				   SetInt( 80, 104 );

				   SetHits( 1000, 1100 );

				   SetDamage( 14, 21 );

				   SetDamageType( ResistanceType.Physical, 60 );
				   SetDamageType( ResistanceType.Physical, 40 );

				   SetResistance( ResistanceType.Physical, 30, 40 );
				   SetResistance( ResistanceType.Fire, 20, 30 );
				   SetResistance( ResistanceType.Cold, 20, 30 );
				   SetResistance( ResistanceType.Poison, 25, 35 );
				   SetResistance( ResistanceType.Energy, 15, 25 );

				   SetSkill( SkillName.MagicResist, 70.1, 100.0 );
				   SetSkill( SkillName.Tactics, 80.1, 110.0 );
				   SetSkill( SkillName.Wrestling, 90.1, 100.0 );

				   Fame = 3500;
				   Karma = -3500;

				   VirtualArmor = 32;
				   
				   m_DecayTime = DateTime.UtcNow + Delay;

				   //PackItem( new AgapiteOre( oreAmount ) );
				   //baglvl2
				   //key1
			  }
			  
			public override bool OnBeforeDeath()
			{
				mShameAltarAddon.Active = true;
				mShameAltarAddon.HueShift();
				return base.OnBeforeDeath();
			}
			  
			public override void OnThink()
			{
					if ( DateTime.UtcNow > m_DecayTime )
					{

						ArrayList list = new ArrayList();

						foreach ( Mobile m in this.GetMobilesInRange( 10 ) ) {
							if ( m.Player ){ list.Add( m ); }
						}

						foreach ( Mobile m in list )
						{
							m.SendMessage( "You have failed to defeat the Guardian" );
						}
					
					
						this.PlaySound( 1622 );
						
						//Map map = this.Map;
											
					
						this.Delete();
						mShameAltarAddon.Active = true;
						mShameAltarAddon.HueShift();
					}
			}
				
				
				

		  public override void GenerateLoot()
			  {
			   AddLoot( LootPack.Average );
			   AddLoot( LootPack.Gems, 2 );
			  }

		  public override bool BleedImmune{ get{ return true; } }
		  public override bool AutoDispel{ get{ return true; } }
		  public override int TreasureMapLevel{ get{ return 1; } }

		  public QuartzElementalGuardian ( Serial serial ) : base( serial )
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
			   m_DecayTime = DateTime.UtcNow + TimeSpan.FromMinutes( 1.0 );
			  }
	 }
}