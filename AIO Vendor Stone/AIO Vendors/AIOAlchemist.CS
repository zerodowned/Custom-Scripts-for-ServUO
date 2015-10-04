using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class AIOAlchemist : BaseAIOVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.MagesGuild; } }
		
		[Constructable]
		public AIOAlchemist() : base( "the alchemist" )
		{
			CantWalk = true;
			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );
		
		}
	
		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBAlchemist() );
			//m_SBInfos.Add( new SBSellAll() );
		}
		

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.Robe( Utility.RandomPinkHue() ) );
		}

		public AIOAlchemist( Serial serial ) : base( serial )
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