using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

using Server.Targeting;

namespace Server.Items
{
	public class RuneChisel : Item
	{
		private int m_Uses;

		[CommandProperty(AccessLevel.GameMaster)]
        public int Uses 
		{ 
			get { return m_Uses; } 
			set 
			{ 
				m_Uses = value; 
				InvalidateProperties();
			} 
		}


		[Constructable]
		public RuneChisel() : base()
		{
			ItemID = 0x9E7E;
			Name = "Rune Chisel";
			Hue = 2262;
			Uses = 1000;
		}
		
		public override void OnDoubleClick(Mobile from) 
		{
			if (!from.Player)
            {
                return;
            }
			if(Uses <= 0)
			{	
				from.SendMessage("The Rune Chisel has no more uses available.");
			}
			if (from.InRange(GetWorldLocation(), 0) || from.IsStaff())
            {
                from.Target = new RuneChiselTarget(from, this);
				//from.SendGump(new RuneChiselGump(from, stone.CurrentPage, stone, this)); 
            }
			else
			{
				from.SendLocalizedMessage(500446); // That is too far away.
			}
		}

		public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

			list.Add($"Uses: {m_Uses.ToString("#,0")}");

		}
		
        public class RuneChiselTarget : Target
		{
			private Mobile m_From;
			private RuneChisel m_Chisel;
			
			public RuneChiselTarget( Mobile from, RuneChisel chisel) :  base ( 10, false, TargetFlags.None )
			{
				m_From = from;
				m_Chisel = chisel;
               
				//from.SendMessage("Select an animal to bond");
			}
            protected override void OnTarget( Mobile from, object targeted )
            {

                if(targeted is Item item)
				{
					if(item is BaseWeapon || item is BaseArmor || item is BaseClothing || item is BaseJewel || item is Spellbook || item is BaseTalisman || item is BaseQuiver)
					{   
						if( from.HasGump(typeof(RuneChiselGump)) ) 
						{
							from.CloseGump(typeof(RuneChiselGump));
						}
						from.SendGump(new RuneChiselGump(from, m_Chisel, item, 1)); 
					}
					else
						from.SendMessage("A Rune Chisel cannot be used on that");
				}
				else
					from.SendMessage("A Rune Chisel cannot be used on that");
            }
        }
		
		
		public RuneChisel( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{ 	
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version

			// 0
			writer.Write((int)m_Uses);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			// 0 
			m_Uses = reader.ReadInt();
		}
	}
}
