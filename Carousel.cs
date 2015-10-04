using System;
using Server;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
    public class Carousel : Item
    {
		private Timer m_RecordLocation;
		private Timer m_CarouselMovement;
		
		int mXr = 0;
		int mYr = 0; 
		int mZr = 0;
		
		bool mPower = false;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Xr { get { return mXr;} set { mXr = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Yr { get { return mYr;} set { mYr = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Zr { get { return mZr;} set { mZr = value; } }
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool Power { get { return mPower;} set { mPower = value; } }
		
		[Constructable]
        public Carousel() : base( ) 
        {
			Movable = false;
			Name = "Carousel";
			ItemID = 0x3E57;
            Hue = 0;
			
			this.m_RecordLocation = new RecordLocation (this);
			this.m_RecordLocation.Start();
        }
	
		public override void OnDoubleClick(Mobile from)
		{
			if (from == null) {return;}
			 
			if (!from.InRange(this.GetWorldLocation(), 4))
				from.SendMessage("I can't reach that!");

			else if (this.Power == false) {
				from.SendMessage("You turn the Carousel on.");
				this.Power = true;
				this.m_CarouselMovement = new CarouselMovement (this);
				this.m_CarouselMovement.Start();
			}
			
			else if (this.Power == true) {
				from.SendMessage("You turn the Carousel off.");
				this.Power = false;
				this.m_CarouselMovement.Stop();
			}
		
		base.OnDoubleClick(from);
		}
	
	
		public Carousel(Serial serial) : base(serial){}

        public override void Serialize( GenericWriter writer ) {
            base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write((int)mXr);
			writer.Write((int)mYr);
			writer.Write((int)mZr);
			writer.Write((bool)mPower);
        }

        public override void Deserialize( GenericReader reader ){
            base.Deserialize( reader );
			int version = reader.ReadInt();
			
			mXr = reader.ReadInt();
			mYr = reader.ReadInt();
			mZr = reader.ReadInt();
			mPower = reader.ReadBool();
        }
	
	
	////////////////////////
		private class RecordLocation : Timer
		{
				private Carousel m_Carousel;
				
				public RecordLocation ( Carousel carousel ) : base( TimeSpan.Zero ){
					m_Carousel = carousel; }
				
				public void RecordCarouselLocation() {
					Point3D loc = m_Carousel.GetWorldLocation();
					m_Carousel.Xr = loc.X;
					m_Carousel.Yr = loc.Y;
					m_Carousel.Zr = loc.Z;
				}

				protected override void OnTick() {
					RecordCarouselLocation();
					Stop();
					
					
				}
		}
	///////////////////////////
		private class CarouselMovement  : Timer
		{
				private Carousel m_Carousel;
				
				public CarouselMovement ( Carousel carousel ) : base( TimeSpan.FromSeconds( 0.5 ) ){
					Priority = TimerPriority.FiftyMS; m_Carousel = carousel; }
	
				protected override void OnTick() {
					List<Item> list = new List<Item>();
					
					Point3D loc = m_Carousel.GetWorldLocation();
					foreach( Item item in m_Carousel.GetItemsInRange( 2 ) ) {
						//Point3D loc = item.GetWorldLocation();
						list.Add(item);
					}
					
					foreach ( Item item in list)
					{
						Point3D itemloc = item.GetWorldLocation();
						
						if( item.X == (m_Carousel.Xr-2) & item.Y == (m_Carousel.Yr-2) ) {
							item.Y++;  }
						else if ( item.X == (m_Carousel.Xr-2) & item.Y == (m_Carousel.Yr-1) ) {
							item.Y++;  }
						else if ( item.X == (m_Carousel.Xr-2) & item.Y == m_Carousel.Yr ) {
							item.Y++;  }
						else if ( item.X == (m_Carousel.Xr-2) & item.Y == (m_Carousel.Yr+1) ) {
							item.Y++; }
						else if ( item.X == (m_Carousel.Xr-2) & item.Y == (m_Carousel.Yr+2) ) {
							item.X++;  }
						else if ( item.X == (m_Carousel.Xr-1) & item.Y == (m_Carousel.Yr+2) ) {
							item.X++;  }
						else if ( item.X == m_Carousel.Xr & item.Y == (m_Carousel.Yr+2) ) {
							item.X++;  }
						else if ( item.X == (m_Carousel.Xr+1) & item.Y == (m_Carousel.Yr+2) ) {
							item.X++; }
						else if ( item.X == (m_Carousel.Xr+2) & item.Y == (m_Carousel.Yr+2) ) {
							item.Y--;  }
						else if ( item.X == (m_Carousel.Xr+2) & item.Y == (m_Carousel.Yr+1) ) {
							item.Y--; }	
						else if ( item.X == (m_Carousel.Xr+2) & item.Y == m_Carousel.Yr ) {
							item.Y--; }
						else if ( item.X == (m_Carousel.Xr+2) & item.Y == (m_Carousel.Yr-1) ) {
							item.Y--; }
						else if ( item.X == (m_Carousel.Xr+2) & item.Y == (m_Carousel.Yr-2) ) {
							item.X--; }
						else if ( item.X == (m_Carousel.Xr+1) & item.Y == (m_Carousel.Yr-2) ) {
							item.X--; }
						else if ( item.X == m_Carousel.Xr & item.Y == (m_Carousel.Yr-2) ) {
							item.X--; }
						else if ( item.X == (m_Carousel.Xr-1) & item.Y == (m_Carousel.Yr-2) ) {
							item.X--; }
					
					}
					
					List<Mobile> mobilelist = new List<Mobile>();

					foreach( Mobile mobile in m_Carousel.GetMobilesInRange( 2 ) ) {
						mobilelist.Add(mobile);
					}
					
					foreach ( Mobile mobile in mobilelist)
					{
						if( mobile.X == (m_Carousel.Xr-2) & mobile.Y == (m_Carousel.Yr-2) ) {
							mobile.Y++; mobile.Direction = Direction.Left; }
							
						else if ( mobile.X == (m_Carousel.Xr-2) & mobile.Y == (m_Carousel.Yr-1) ) {
							mobile.Y++; mobile.Direction = Direction.South; }
						else if ( mobile.X == (m_Carousel.Xr-2) & mobile.Y == m_Carousel.Yr ) {
							mobile.Y++; mobile.Direction = Direction.South; }
						else if ( mobile.X == (m_Carousel.Xr-2) & mobile.Y == (m_Carousel.Yr+1) ) {
							mobile.Y++; mobile.Direction = Direction.South; }
							
						else if ( mobile.X == (m_Carousel.Xr-2) & mobile.Y == (m_Carousel.Yr+2) ) {
							mobile.X++; mobile.Direction = Direction.Down; }
							
						else if ( mobile.X == (m_Carousel.Xr-1) & mobile.Y == (m_Carousel.Yr+2) ) {
							mobile.X++; mobile.Direction = Direction.East; }
						else if ( mobile.X == (m_Carousel.Xr) & mobile.Y == (m_Carousel.Yr+2) ) {
							mobile.X++; mobile.Direction = Direction.East; }
						else if ( mobile.X == (m_Carousel.Xr+1) & mobile.Y == (m_Carousel.Yr+2) ) {
							mobile.X++; mobile.Direction = Direction.East ; }
							
						else if ( mobile.X == (m_Carousel.Xr+2) & mobile.Y == (m_Carousel.Yr+2) ) {
							mobile.Y--; mobile.Direction = Direction.Right; }
							
						else if ( mobile.X == (m_Carousel.Xr+2) & mobile.Y == (m_Carousel.Yr+1) ) {
							mobile.Y--; mobile.Direction = Direction.North; }	
						else if ( mobile.X == (m_Carousel.Xr+2) & mobile.Y == m_Carousel.Yr ) {
							mobile.Y--; mobile.Direction = Direction.North; }
						else if ( mobile.X == (m_Carousel.Xr+2) & mobile.Y == (m_Carousel.Yr-1) ) {
							mobile.Y--; mobile.Direction = Direction.North; }
							
						else if ( mobile.X == (m_Carousel.Xr+2) & mobile.Y == (m_Carousel.Yr-2) ) {
							mobile.X--; mobile.Direction = Direction.Mask; }
							
						else if ( mobile.X == (m_Carousel.Xr+1) & mobile.Y == (m_Carousel.Yr-2) ) {
							mobile.X--; mobile.Direction = Direction.West; }
						else if ( mobile.X == m_Carousel.Xr & mobile.Y == (m_Carousel.Yr-2) ) {
							mobile.X--; mobile.Direction = Direction.West; }
						else if ( mobile.X == (m_Carousel.Xr-1) & mobile.Y == (m_Carousel.Yr-2) ) {
							mobile.X--; mobile.Direction = Direction.West; }
					
					}
					
					if(m_Carousel.Power == false) {Stop();}
					else{ Start(); }
					
				}
		}
	}
}