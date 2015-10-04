using System;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
	

	public class MovingTrap : Item
	{
	
		private int mXa;
		private Timer m_XPlus;
		private Timer m_XMinus;
		private Timer m_RecordLocationTimer;
	
		[CommandProperty(AccessLevel.GameMaster)]
		public int Xa
		{
			get { return mXa; }
			set { mXa = value; }
		}

	
	
		[Constructable]
		public MovingTrap() : base( )
		{
			Weight = 100.0;
			//Hue = 1906;
			Name = "Moving Trap";
			ItemID = 1872;
			
			this.m_RecordLocationTimer = new RecordLocationTimer (this);
			this.m_RecordLocationTimer.Start();
		}
		
		public MovingTrap( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write(mXa);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			LootType = LootType.Blessed;

			int version = reader.ReadInt();
			
			mXa = reader.ReadInt();
			
			this.m_XMinus = new XMinus (this);
			this.m_XMinus.Start();
		}
		
///////////////////////		
		private class RecordLocationTimer  : Timer
		{
			private MovingTrap m_MovingTrap;
			
		
			public RecordLocationTimer ( MovingTrap trap ) : base( TimeSpan.Zero )
			{
				m_MovingTrap = trap;
			}
			
			public void RecordLocation()
			{
				Point3D loc = m_MovingTrap.GetWorldLocation();
				m_MovingTrap.Xa = loc.X;
			}

			protected override void OnTick()
			{
				RecordLocation();
				Stop();
				
				m_MovingTrap.m_XPlus = new XPlus (m_MovingTrap);
				m_MovingTrap.m_XPlus.Start();
			}
		}
		
	///////////////////
		private class XPlus  : Timer
		{
			private MovingTrap m_MovingTrap;
			
		

			public XPlus ( MovingTrap trap ) : base( TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_MovingTrap = trap;
				
			}
	
			protected override void OnTick()
			{
				
				if( (m_MovingTrap.Xa + 5) > m_MovingTrap.X )
					{
						m_MovingTrap.X++;
						
						
						List<Mobile> list = new List<Mobile>();
						foreach( Mobile mob in m_MovingTrap.GetMobilesInRange( 1 ) ) 
						{
							Point3D traploc = m_MovingTrap.GetWorldLocation();
							//Point3D mobloc = mob.X();
							if( ( mob.X == ( m_MovingTrap.X + 1 ) & mob.Y == m_MovingTrap.Y || mob.X == ( m_MovingTrap.X - 1 ) & mob.Y == m_MovingTrap.Y ) & mob.Alive )
							{
								//if (mob is Mobile & mob.Alive)
								list.Add(mob);
							}
						}
						
						foreach (Mobile mob in list)
						{
							Spells.SpellHelper.Damage(TimeSpan.FromTicks(1), mob, mob, Utility.RandomMinMax(1, 3));
							
							if( mob is PlayerMobile )
							{
								mob.PlaySound(mob.Female ? 0x327 : 0x437);
								mob.Animate(20, 1, 1, true, false, 0);
							}
							else
							{
								BaseCreature bc = (BaseCreature)mob;
								bc.PlaySound(bc.GetAngerSound());
								if (bc.Body.IsAnimal)
								{
									bc.Animate(10, 5, 1, true, false, 0);
								}
								else if (bc.Body.IsMonster)
								{
									bc.Animate(18, 5, 1, true, false, 0);
								}
							}
						}
						
						Start();
						
					}
				else
				{
					Stop();
					m_MovingTrap.m_XMinus = new XMinus (m_MovingTrap);
					m_MovingTrap.m_XMinus.Start();
				}
				
			}
		}
		
	///////////////////////////////
		private class XMinus  : Timer
		{
			private MovingTrap m_MovingTrap;

			public XMinus ( MovingTrap trap ) : base( TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_MovingTrap = trap;
			}
			
			

			protected override void OnTick()
			{
				if( (m_MovingTrap.Xa - 5) < m_MovingTrap.X )
					{
						m_MovingTrap.X--;
						
						List<Mobile> list = new List<Mobile>();
						foreach( Mobile mob in m_MovingTrap.GetMobilesInRange( 1 ) ) 
						{
							Point3D traploc = m_MovingTrap.GetWorldLocation();
							//Point3D mobloc = mob.Location();
							if( ( mob.X == ( m_MovingTrap.X + 1 ) & mob.Y == m_MovingTrap.Y || mob.X == ( m_MovingTrap.X - 1 ) & mob.Y == m_MovingTrap.Y ) & mob.Alive )
							{
								//if (mob is Mobile & mob.Alive)
								list.Add(mob);
							}
						}
						
						foreach (Mobile mob in list)
						{
							Spells.SpellHelper.Damage(TimeSpan.FromTicks(1), mob, mob, Utility.RandomMinMax(1, 3));
							
							if( mob is PlayerMobile )
							{
								mob.PlaySound(mob.Female ? 0x327 : 0x437);
								mob.Animate(20, 1, 1, true, false, 0);
							}
							else
							{
								BaseCreature bc = (BaseCreature)mob;
								bc.PlaySound(bc.GetAngerSound());
								if (bc.Body.IsAnimal)
								{
									bc.Animate(10, 5, 1, true, false, 0);
								}
								else if (bc.Body.IsMonster)
								{
									bc.Animate(18, 5, 1, true, false, 0);
								}
							}
						}
						
						Start();
					}
				else
				{
					Stop();
					m_MovingTrap.m_XPlus = new XPlus (m_MovingTrap);
					m_MovingTrap.m_XPlus.Start();
				}
				
			}
		}	// end of XMinus Timer
		
	}	// end of class MovingTrap
}	// end of namespace



