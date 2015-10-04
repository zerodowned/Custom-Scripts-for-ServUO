using System; 
using System.Collections.Generic; 
using Server; 

namespace Server.Mobiles 
{ 
	public class AIOLeatherWorker : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		[Constructable]
		public AIOLeatherWorker() : base( "the leather worker" ) 
		{ 
		//Start Int Timer--->
				new InternalTimer( this ).Start();//Special Timer makes it auto delete after time period
				//End Int Timer<---
				CantWalk = true;
		} 
		
						//Start Int Timer--->
		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer( Mobile mobile ) : base( TimeSpan.FromMinutes( 2.0 ) )
			{
				m_Mobile = mobile;
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				m_Mobile.Delete();
			}
		}
		//End Int Timer<----
		
		public override void OnDoubleClick( Mobile from )
		{
			Delete();
		}
		
		public bool HandlesOnMovement{ get{ return true; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( InRange( m.Location, 8 ) && !InRange( oldLocation, 7 ) )
			{
				Delete();
			}

			base.OnMovement( m, oldLocation );
		}
		
		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBLeatherArmor() ); 
			m_SBInfos.Add( new SBStuddedArmor() ); 
			m_SBInfos.Add( new SBLeatherWorker() ); 
			m_SBInfos.Add( new SBSellAll() );
		} 
		public AIOLeatherWorker( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 
} 
