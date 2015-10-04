using System;
using Server;
using Server.Items;
using System.Collections;

/*
 It can be challenged by clicking on the Guardian's Altar at 130° N, 74° W which will cost 30 dungeon points for Shame. Note that you will have one hour to find and defeat it
*/


namespace Server.Mobiles
{
	 [CorpseName( "a wind elemental guardian corpse" )]
	 public class WindElementalGuardian : BaseCreature
	 {
	 
			private DateTime m_DecayTime;
			public virtual TimeSpan m_Delay{ get{ return TimeSpan.FromHours( 1.0 ); } }
			
			private ShameAltarAddon mShameAltarAddon;
	 
		  [Constructable]
		  public WindElementalGuardian (ShameAltarAddon altar) : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
			  {
			  mShameAltarAddon = altar;
			   Name = "a wind elemental Guardian";
			   Body = 131;
			   BaseSoundID = 768;

			   SetStr( 376, 403 );
			   SetDex( 183, 230 );
			   SetInt( 164, 213 );
			   SetStam( 230, 250 );
			   SetMana( 1050, 1100 );

			   SetHits( 2500, 2600 );

			   SetDamage( 15, 17 );

			   SetDamageType( ResistanceType.Physical, 20 );
			   SetDamageType( ResistanceType.Cold, 40 );
			   SetDamageType( ResistanceType.Energy, 40 );

			   SetResistance( ResistanceType.Physical, 65, 75 );
			   SetResistance( ResistanceType.Fire, 55, 65 );
			   SetResistance( ResistanceType.Cold, 55, 65 );
			   SetResistance( ResistanceType.Poison, 100 );
			   SetResistance( ResistanceType.Energy, 60, 75 );

			   SetSkill( SkillName.EvalInt, 60.1, 75.0 );
			   SetSkill( SkillName.Magery, 60.1, 75.0 );
			   SetSkill( SkillName.MagicResist, 60.1, 75.0 );
			   SetSkill( SkillName.Tactics, 60.1, 75.0 );
			   SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			   Fame = 10000;
			   Karma = -10000;

			   VirtualArmor = 56;
			   
			     m_DecayTime = DateTime.UtcNow + m_Delay;
			   
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
		   AddLoot( LootPack.Rich );
		   AddLoot( LootPack.Average );
		   AddLoot( LootPack.Gems );
		  }

		  public override int TreasureMapLevel{ get{ return Core.AOS ? 4 : 5; } }

		  public WindElementalGuardian ( Serial serial ) : base( serial )
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
		   
		   m_DecayTime = DateTime.UtcNow + TimeSpan.FromHours( 1.0 );
		  }
	 }
}