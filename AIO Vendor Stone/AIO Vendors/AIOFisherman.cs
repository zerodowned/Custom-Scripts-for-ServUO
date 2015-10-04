using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class AIOFisherman : BaseAIOVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.FishermensGuild; } }

		[Constructable]
		public AIOFisherman() : base( "the fisher" )
		{
			CantWalk = true;
			SetSkill( SkillName.Fishing, 75.0, 98.0 );
		}
		
		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBFisherman() );
			//m_SBInfos.Add( new SBSellAll() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.FishingPole() );
		}

		public AIOFisherman( Serial serial ) : base( serial )
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