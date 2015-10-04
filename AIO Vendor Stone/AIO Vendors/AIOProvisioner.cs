using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class AIOProvisioner : BaseAIOVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public AIOProvisioner() : base( "the provisioner" )
		{
		
			CantWalk = true;
			SetSkill( SkillName.Camping, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 45.0, 68.0 );
		}
		
		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBProvisioner() );
			//m_SBInfos.Add( new SBSellAll() );

			if ( IsTokunoVendor )
				m_SBInfos.Add( new SBSEHats() );
		}

		public AIOProvisioner( Serial serial ) : base( serial )
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