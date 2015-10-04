using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	[TypeAlias( "Server.Mobiles.GargoyleAlchemist" )]
	public class AIOGlassblower : BaseAIOVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.MagesGuild; } }

		[Constructable]
		public AIOGlassblower() : base( "the alchemist" )
		{

			CantWalk = true;
			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.TasteID, 85.0, 100.0 );
		}
		
		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBGlassblower() );
			m_SBInfos.Add( new SBAlchemist() );
			//sm_SBInfos.Add( new SBSellAll() );
		}

		public AIOGlassblower( Serial serial ) : base( serial )
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

			if ( Body == 0x2F2 )
				Body = 0x2F6;
		}
	}
}