using System;
using Server;
using Server.Items;
using System.Collections;

/*
Flame Elemental the Guardian is also the champion of the second level of the dungeon Shame. It can be challenged by clicking on the Guardian's Altar at 130° N, 60° W which will cost 20 dungeon points for Shame. Note that you will have one hour to find and defeat it.
*/

namespace Server.Mobiles
{
	 [CorpseName( "a flame elemental corpse" )]
	 public class FlameElementalGuardian : BaseCreature
	 {
		  //public override double DispelDifficulty{ get{ return 117.5; } }
		  //public override double DispelFocus{ get{ return 45.0; } }
		  
			private DateTime m_DecayTime;
			public virtual TimeSpan m_Delay{ get{ return TimeSpan.FromHours( 1.0 ); } }
			
			private ShameAltarAddon mShameAltarAddon;

		  [Constructable]
		  public FlameElementalGuardian(ShameAltarAddon altar) : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			mShameAltarAddon = altar;
			
			   Name = "a flame elemental Guardian";
			   Body = 15;
			   BaseSoundID = 838;

			   SetStr( 450, 480 );
			   SetDex( 210, 240 );
			   SetInt( 150, 175 );

			   SetHits( 700, 800 );

			   SetDamage( 18, 20 );

			   SetDamageType( ResistanceType.Physical, 25, 55 );
			   SetDamageType( ResistanceType.Fire, 75 );

			 

			   SetResistance( ResistanceType.Physical, 45, 55 );
			   SetResistance( ResistanceType.Fire, 100 );
			   SetResistance( ResistanceType.Cold, 30, 40 );
			   SetResistance( ResistanceType.Poison, 60, 70 );
			   SetResistance( ResistanceType.Energy, 30, 40 );

			   SetSkill( SkillName.EvalInt, 60.1, 75.0 );
			   SetSkill( SkillName.Magery, 60.1, 75.0 );
			   SetSkill( SkillName.MagicResist, 75.2, 105.0 );
			   SetSkill( SkillName.Tactics, 80.1, 100.0 );
			   SetSkill( SkillName.Wrestling, 70.1, 100.0 );

			   Fame = 4500;
			   Karma = -4500;

			   VirtualArmor = 40;
			   ControlSlots = 4;

			   PackItem( new SulfurousAsh( 3 ) );

			   AddItem( new LightSource() );
			   
			   m_DecayTime = DateTime.UtcNow + m_Delay;
			   
			  }
			  
			public override void OnThink()
			{
					if ( DateTime.UtcNow > m_DecayTime ) {
						ArrayList list = new ArrayList();

						foreach ( Mobile m in this.GetMobilesInRange( 10 ) ) {
							if ( m.Player ){ list.Add( m ); }
						}
						foreach ( Mobile m in list ) {
							m.SendMessage( "You have failed to defeat the Guardian" );
						}
						this.PlaySound( 1622 );
						this.Delete();
						
						mShameAltarAddon.Active = true;
						mShameAltarAddon.HueShift();
					}
			}
			
		public override bool OnBeforeDeath()
			{
				mShameAltarAddon.Active = true;
				mShameAltarAddon.HueShift();
				return base.OnBeforeDeath();
			}
				
		 public override void GenerateLoot()
		  {
		   AddLoot( LootPack.Average );
		   AddLoot( LootPack.Meager );
		   AddLoot( LootPack.Gems );
		  }

		  public override bool BleedImmune{ get{ return true; } }
		  public override bool HasBreath{ get{ return true; } } // fire breath
		  public override int TreasureMapLevel{ get{ return 2; } }

		  public FlameElementalGuardian( Serial serial ) : base( serial )
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

		   if ( BaseSoundID == 274 )
			BaseSoundID = 838;
			
			m_DecayTime = DateTime.UtcNow + TimeSpan.FromHours( 1.0 );
		  }
	 }
}