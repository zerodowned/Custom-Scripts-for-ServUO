using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Commands;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Engines.Quests;
using Server.Engines.Quests.Necro;
using Server.Items;
using Server.Spells;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Items
{
    [FlipableAttribute(0x2683, 0x2684)]
    public class AncientMonksShroud : BaseClothing_ItemOfLight
    {
        public Point3D m_HomeLocation;
        public Map m_HomeMap;

        private LightSource light;

        [Constructable]
        public AncientMonksShroud(): base(0x2683, Layer.OuterTorso)
        {
            LootType = LootType.Blessed;
            //Layer = Layer.OuterTorso;
            Weight = 5.0;
            Hue = 2406;
            Name = "An Ancients Shroud";
        }

        public override void OnDoubleClick(Mobile from)
        {
			base.OnDoubleClick(from);
			
			if (Parent != from)
            {
                from.SendMessage("You must be wearing the robe to use it!");
            }
            else
            {
                if (ItemID == 0x2683 || ItemID == 0x2684)
                {
                    from.SendMessage("You lower the hood.");
                    from.PlaySound(0x57);
                    ItemID = 0x1F03;
                    Name = "An Ancients Shroud";
         
                    from.RemoveItem(this);
                    from.EquipItem(this);
                }

                else if (ItemID == 0x1F03 || ItemID == 0x1F04)
                {
                    from.SendMessage("You raise the hood.");
                    from.PlaySound(0x57);
                    ItemID = 0x2683;
                    Name = "An Ancients Shroud";
                    from.NameMod = "";

                    from.RemoveItem(this);
                    from.EquipItem(this);
                }
            }

            if (from.AccessLevel >= AccessLevel.Player)
            {
                this.HomeLocation = from.Location;
                this.HomeMap = from.Map;
                return;
            }
        }

  
        public override bool Dye( Mobile from, DyeTub sender )
		{
			from.SendLocalizedMessage( sender.FailMessage );
			return false;
		}

        public AncientMonksShroud(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.Player)]
        public Point3D HomeLocation
        {
            get { return m_HomeLocation; }
            set { m_HomeLocation = value; }
        }

        [CommandProperty(AccessLevel.Player)]
        public Map HomeMap
        {
            get { return m_HomeMap; }
            set { m_HomeMap = value; }
        }

        private class GoHomeEntry : ContextMenuEntry
        {
            private AncientMonksShroud m_Item;
            private Mobile m_Mobile;

            public GoHomeEntry(Mobile from, Item item)
                : base(5134) // uses "Goto Loc" entry
            {
                m_Item = (AncientMonksShroud)item;
                m_Mobile = from;
            }

            public override void OnClick()
            {
                m_Mobile.Location = m_Item.HomeLocation;

                if (m_Item.HomeMap != null)
                    m_Mobile.Map = m_Item.HomeMap;
            }
        }

        private class SetHomeEntry : ContextMenuEntry
        {
            private AncientMonksShroud m_Item;
            private Mobile m_Mobile;

            public SetHomeEntry(Mobile from, Item item)
                : base(2055) // uses "Mark" entry
            {
                m_Item = (AncientMonksShroud)item;
                m_Mobile = from;
            }

            public override void OnClick()
            {
                m_Item.HomeLocation = m_Mobile.Location;
                m_Item.HomeMap = m_Mobile.Map;
                m_Mobile.SendMessage("The home location on your robe has been set to your current position.");
            }
        }

        public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
        {
            list.Add(new GoHomeEntry(from, item));
            list.Add(new SetHomeEntry(from, item));
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            AncientMonksShroud.GetContextMenuEntries(from, this, list);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1); // version

            writer.Write(m_HomeLocation);
            writer.Write(m_HomeMap);       
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            switch (version)
            {
                case 1:
                    {
                        m_HomeLocation = reader.ReadPoint3D();
                        m_HomeMap = reader.ReadMap();
                    }   goto case 0;
                case 0:
                    {
                        break;
                    }
            }
        }
    }
}