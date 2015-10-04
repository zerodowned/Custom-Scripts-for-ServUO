using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class AIOJeweler : BaseAIOVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public AIOJeweler() : base( "the jeweler" )
		{

			CantWalk = true;
			SetSkill( SkillName.ItemID, 64.0, 100.0 );
		}
		
		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBJewel() );
			//m_SBInfos.Add( new SBSellAll() );
		}

		public AIOJeweler( Serial serial ) : base( serial )
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