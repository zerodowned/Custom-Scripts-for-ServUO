using System;
using Server;
using Server.Mobiles;


namespace Server.Items
{
    public class CountDownTimer1 : Item
    {
	
		public virtual int Lifespan{ get{ return 60; } }
		
		private int m_Lifespan;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int TimeLeft
		{
			get{ return m_Lifespan; }
			set{ m_Lifespan = value; InvalidateProperties(); }
		}
		
		
		
		 [Constructable]
        public CountDownTimer1() : base( 0x1870 )
			{
				Name = "CountDownTimer1";
				Movable = false;
				Visible = false;
			
				if ( Lifespan > 0 )
					{
						m_Lifespan = Lifespan;
						StartTimer();
					}
			}
	/*		
		 private void Expire()
        {
			
				if (Deleted)
                return;

				Delete();
				if (m is Mobile) m.SendMessage("You failed to defeat the Champion");
			
		}
	*/
		
	
		
		public CountDownTimer1(Serial serial) : base(serial)
		{
		}
/*		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			
			if ( Lifespan > 0 )
			string lisths = String.Format("{0} Minutes.",  m_Lifespan.ToString());
            list.Add("<BASEFONT COLOR=#00FF00>Half Life Remaining: {0}<BASEFONT COLOR=#FFFFFF>", lisths); //FFFFFF
			
			
				//list.Add( 1072517, m_Lifespan.ToString() ); // Lifespan: ~1_val~ seconds
		}
	*/	
		private Timer m_Timer;		
		
		public virtual void StartTimer()
		{
			if ( m_Timer != null )
				return;
				
			m_Timer = Timer.DelayCall( TimeSpan.FromSeconds( 10 ), TimeSpan.FromSeconds( 10 ), new TimerCallback( Slice ) );
			m_Timer.Priority = TimerPriority.OneMinute;
		}
		
		public virtual void StopTimer()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = null;
		}
		
		public virtual void Slice()
		{
			m_Lifespan -= 10;
			
			InvalidateProperties();
			
			if ( m_Lifespan <= 0 )
				Decay();
		}
		
		public virtual void Decay()
		{
			if ( RootParent is Mobile )
			{
				Mobile parent = (Mobile) RootParent;
				parent.SendMessage("You failed to defeat the Champion");
			}
			StopTimer();
			Delete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
			writer.Write( (int) m_Lifespan );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			
			m_Lifespan = reader.ReadInt();
			
			StartTimer();
		}
	}
}