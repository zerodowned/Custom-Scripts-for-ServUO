using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class AIOArchitect : BaseAIOVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.TinkersGuild; } }

		[Constructable]
		public AIOArchitect() : base( "the architect" )
		{
				
			CantWalk = true;
		}

		public override void InitSBInfo()
		{
			if ( !Core.AOS )
				m_SBInfos.Add( new SBHouseDeed() );

			m_SBInfos.Add( new SBArchitect() );
			//m_SBInfos.Add( new SBSellAll() );
		}

		public AIOArchitect( Serial serial ) : base( serial )
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