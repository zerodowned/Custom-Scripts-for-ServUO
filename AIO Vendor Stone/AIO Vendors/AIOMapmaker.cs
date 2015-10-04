using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class AIOMapmaker : BaseAIOVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public AIOMapmaker() : base( "the mapmaker" )
		{

			CantWalk = true;
			SetSkill( SkillName.Cartography, 90.0, 100.0 );
		}
		
		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBMapmaker() );
			//m_SBInfos.Add( new SBSellAll() );
		}

		public AIOMapmaker( Serial serial ) : base( serial )
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