using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class AIOBaker : BaseAIOVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public AIOBaker() : base( "the baker" )
		{
			CantWalk = true;
			SetSkill( SkillName.Cooking, 75.0, 98.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );
		}
		

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBBaker() );
			//m_SBInfos.Add( new SBSellAll() );
		}

		public AIOBaker( Serial serial ) : base( serial )
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