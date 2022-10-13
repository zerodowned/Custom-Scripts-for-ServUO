using Server.Engines.Craft;
using Server.Mobiles;
using Server.Targeting;
using Server.Prompts;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using System.Collections.Generic;
using Server.Accounting;

namespace Server.Items
{    
    public class BaseStealableSign : Item, ISecurable
    {
        private SecureLevel m_Level;
        private string m_ownerName;
        private string m_acctName;

        [CommandProperty(AccessLevel.GameMaster)]
        public SecureLevel Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string OwnerName
        {
            get { return m_ownerName; }
            set { m_ownerName = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string AcctName
        {
            get { return m_acctName; }
            set { m_acctName = value; }
        }

        public BaseStealableSign() : this(0x129c)
        {
        }

        //[Constructable]
        public BaseStealableSign(int itemid) : base(itemid)
        {
            Name = "Stealable Sign";
            Hue = 0;
            Weight = 0;
        }

        public override void OnDoubleClick( Mobile from )
		{
			BaseHouse house = BaseHouse.FindHouseAt(this);

            if (house == null || !IsLockedDown)
            {
                from.SendMessage("This must be locked down in a house to use!");
                return;
            }

            if (!house.HasSecureAccess(from, m_Level))
            {
                from.SendLocalizedMessage(503301, "", 0x22); // You don't have permission to do that.
                return;
            }

            if (!from.InRange(Location, 3))
			{	
                //from.SendLocalizedMessage( 1042001 );
                from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
                return;
            }
            
            from.SendMessage(43, "Type the message that you would like to appear on the sign.");
            from.SendMessage(33, "Signs with messages that are inappropriate or against the rules will be deleted.");

            from.Prompt = new NamePrompt(this);
		}

        public class NamePrompt : Prompt
        {
            public override int MessageCliloc { get { return 501804; } }
            
            private BaseStealableSign m_sign;

            public NamePrompt(BaseStealableSign sign)
            {
                m_sign = sign;
            }

            public override void OnResponse(Mobile from, string text)
            {
                text = text.Trim();

                if (text.Length > 40)
                    text = text.Substring(0, 40);

                if (text.Length > 0)
                    m_sign.Name = text;
                
                m_sign.OwnerName = from.Name;

                Account acct = from.Account as Account;
                m_sign.AcctName = acct.Username;
            }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            SetSecureLevelEntry.AddTo(from, this, list);
        }

        public BaseStealableSign(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version

            //0
            writer.WriteEncodedInt((int)m_Level);
            writer.Write((string)m_ownerName);
            writer.Write((string)m_acctName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            //0
            m_Level = (SecureLevel)reader.ReadEncodedInt();
            m_ownerName = reader.ReadString();
            m_acctName = reader.ReadString();
        }
    }
}