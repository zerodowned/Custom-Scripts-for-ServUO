using System;
using Server.Items;

namespace Server.Items
{
    public abstract class SmartItem : Item
    {
		public double mDelay;
		private Timer mUpdateTimer;
		
		[Constructable]
        public SmartItem(int itemID, double delay  ) : base ( itemID )
        {
			mDelay = delay;
			Timer.DelayCall(TimeSpan.Zero, OnCreate); 
			
			this.mUpdateTimer = new UpdateTimer(this, mDelay );
			this.mUpdateTimer.Start();
			
        }
		
		public virtual void OnThink(){}
		
		public abstract void OnThink(Mobile m);
		
		public abstract void OnCreate();
		
		
        public SmartItem(Serial serial) : base(serial) {}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
			
			writer.Write( ( double )mDelay );
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
			
			mDelay = (double) reader.ReadDouble();
        }
    

		private class UpdateTimer : Timer
		{
			private SmartItem mSmartItem;
			private double mTimerDelay;

			public UpdateTimer( SmartItem smartitem, double timerdelay ) : base( TimeSpan.FromSeconds( timerdelay ) )
			{
				Priority = TimerPriority.FiftyMS;
				mSmartItem = smartitem;
				mTimerDelay = timerdelay;
			}

			protected override void OnTick() {
				if( mSmartItem == null || mSmartItem.Deleted ) { Stop(); }
				
				mSmartItem.OnThink();
				Start();
			}
		}
		
		
    }
}