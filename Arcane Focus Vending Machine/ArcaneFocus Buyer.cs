using System;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Spells.Spellweaving;

namespace Server.Gumps
{
    public class ArcaneFocusBuyerGump : Gump
    {
        const int OnehourCost = 10000; // 10k
        const int FivehourCost = 50000; // 50k 
        const int TenhourCost = 100000; // 100k

        public ArcaneFocusBuyerGump() : base( 200,100 )
        {
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);

            AddBackground(0, 0, 387, 234, 9200);

            AddHtml( 3, 5, 378, 50, "<center><big>Arcane Focus Vending Machine", false, false);

            AddButton(15, 70, 247, 247, 1, GumpButtonType.Reply, 0);
            AddLabel(85, 71, 0, String.Format("1 hour for {0} gold", OnehourCost.ToString("#,0")) );

            AddButton(15, 120, 247, 247, 2, GumpButtonType.Reply, 0);
            AddLabel(85, 121, 0, String.Format("5 hours for {0} gold", FivehourCost.ToString("#,0")) );

            AddButton(15, 170, 247, 247, 3, GumpButtonType.Reply, 0);
            AddLabel(85, 171, 0, String.Format("10 hours for {0} gold", TenhourCost.ToString("#,0")) );
        }
 
        public override void OnResponse( NetState sender, RelayInfo info )
        {
            Mobile from = sender.Mobile;			

            Container bank = from.BankBox;
            Container pack = from.Backpack;

            if (bank == null || pack == null)
            {
                return;
            }

            if ( info.ButtonID == 1 ) 
            {
                if( Charge(from, bank, OnehourCost) )
                {
                    GiveArcaneFocus(from, TimeSpan.FromHours(1), 3);
                }
                else
                    from.SendMessage("You don't have enough gold in your bank for that.");
            }

            else if ( info.ButtonID == 2 ) 
            {
                if( Charge(from, bank, FivehourCost) )
                {
                    GiveArcaneFocus(from, TimeSpan.FromHours(5), 4);
                }
                else
                    from.SendMessage("You don't have enough gold in your bank for that.");
            }

            else if ( info.ButtonID == 3 ) 
            {
                if( Charge(from, bank, TenhourCost) )
                {
                    GiveArcaneFocus(from, TimeSpan.FromHours(10), 5);
                }
                else
                    from.SendMessage("You don't have enough gold in your bank for that.");
            }

            
        }

        private static bool Charge(Mobile m, Container bank, int cost)
        {
            int bankBalance = Banker.GetBalance(m);
            if( bankBalance >= cost )
            {
                Banker.Withdraw(m, cost);
                return true;
            }

            return false;
        }

        private static void GiveArcaneFocus(Mobile to, TimeSpan duration, int strengthBonus)
        {
            if (to == null)	//Sanity
                return;

            ArcaneFocus focus = ArcanistSpell.FindArcaneFocus(to);

            if (focus == null)
            {
                ArcaneFocus f = new ArcaneFocus((int)duration.TotalSeconds, strengthBonus);
                if (to.PlaceInBackpack(f))
                {
                    to.AddStatMod(new StatMod(StatType.Str, "[ArcaneFocus]", strengthBonus, duration));

                    f.SendTimeRemainingMessage(to);
                    to.SendLocalizedMessage(1072740); // An arcane focus appears in your backpack.
                }
                else
                {
                    f.Delete();
                }
            }
            else //OSI renewal rules: the new one will override the old one, always.
            {
                to.SendLocalizedMessage(1072828); // Your arcane focus is renewed.
                focus.TimeLeft = (int)duration.TotalSeconds;
                focus.StrengthBonus = strengthBonus;
                focus.InvalidateProperties();
                focus.SendTimeRemainingMessage(to);
            }
        }
    }

    public class ArcaneFocusBuyer : Item
    {
        public override string DefaultName => "Arcane Focus Vending Machine";

        [Constructable]
        public ArcaneFocusBuyer() : base(0xEDc)
        {
            Movable = false;
            Hue = 1919;
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.CloseGump(typeof(ArcaneFocusBuyerGump));
            from.SendGump(new ArcaneFocusBuyerGump());

        }

        public ArcaneFocusBuyer(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
} 

