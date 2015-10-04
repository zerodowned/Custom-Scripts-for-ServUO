//Created by Peoharen for the Mobile Abilities Package.
//Edited by zerodowned for the All In One NPC Vendor stone. I used Peoharen's script as a template.
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Misc;
using Server.Engines.BulkOrders;
using Server.Regions;
using Server.Factions;
using Server;

namespace Server.Mobiles
{
	
	public class BaseAIOVendor : BaseVendor
	{
		//protected override List<SBInfo> SBInfos { get; }
		//protected abstract List<SBInfo> SBInfos { get; }
		
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		private DateTime m_DecayTime;
		public virtual TimeSpan m_Delay{ get{ return TimeSpan.FromMinutes( 2.0 ); } }

		public BaseAIOVendor( string title ) : base( title )
		{
			this.Title = title;
			m_DecayTime = DateTime.Now + m_Delay;
			
		}
		
		//private List<SBInfo> m_SBInfos = new List<SBInfo>();
		//protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override void InitSBInfo()
		{
		}
		
			public override void OnDoubleClick( Mobile from )
		{
			Delete();
		}
		
		public bool HandlesOnMovement{ get{ return true; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( InRange( m.Location, 2 ) && !InRange( oldLocation, 1 ) )
			{
				Delete();
			}

			base.OnMovement( m, oldLocation );
		}

		public override void OnThink()
		{
			if ( DateTime.Now > m_DecayTime )
			{
				this.FixedParticles( 14120, 10, 15, 5012, EffectLayer.Waist );
				//this.PlaySound( 510 );
				this.Delete();
			}
		}

		public BaseAIOVendor(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			m_DecayTime = DateTime.Now + TimeSpan.FromMinutes( 2.0 );
		}
	}
}