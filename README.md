# My-Stuff
Various scripts for use with RunUO and ServUO

[Rune Chisel](https://github.com/zerodowned/My-Stuff/tree/master/RuneChisel "")<br>
  Rune Chisel is an item with charges that allows players to remove selected properties from an item. 
  This would typically be done as a means to further enhance the item via the Imbuing skill.
  *NOTE: This has never been tested in a live setting due poor reception during testing with select players.
 
[SOS Decoder](https://github.com/zerodowned/My-Stuff/tree/master/SOS%20Decoder "")<br>
  The SOS Decoder will teleport a player and their boat (plus any other players or pets on the boat) to the location of a SOS/Message-in-a-Bottle chest.
  
[Treasure Map Decoder](https://github.com/zerodowned/My-Stuff/tree/master/Treasure%20Map%20Decoder "")<br>
  Similar to the SOS Decoder, it will teleport a player to the location of the Treasure Map chest. This is wildly popular with players.
  
[Map Charter](https://github.com/zerodowned/My-Stuff/tree/master/Map%20Charter "")<br>
  Altered version of the Map Charter, it will give a Treasure Map every (X) amount of time. The timer will stop once the Map Charter reaches it max cached     amount of Treasure Maps and will start again once a player redeems one from it's cache. 
  
[Stealable Signs](https://github.com/zerodowned/My-Stuff/tree/master/StealableSigns "")<br>
  Superclass BaseStealableSign.cs
  A stealable sign is something that players can steal and then lock down in their house. Once locked down, they can double click it to set a custom message.
  The sign also tracks who edited the message for tracking purposes in case an inappropriate message is added - then staff will know who. This property is 
  only viewable to staff.
  
------

[AIO Vendor Stone](https://github.com/zerodowned/My-Stuff/tree/master/AIO%20Vendor%20Stone "")<br>
  Needs a little work. It's one of my older works. 
  It's a stone that can be used to summon almost any Vendor from it. 
  Once the summoner walks away, the vendor self deletes.
  
[Animation Locator](https://github.com/zerodowned/My-Stuff/tree/master/AnimationLocator "")<br>
  Original script by Father Time / vermillion2083.
  I added options for FreezeFrame viewing to help with my Mobile Statues code.
  Also did a little work in the original gump to make it a little easier to see and use.
  
[Crystal Portals](https://github.com/zerodowned/My-Stuff/tree/master/CrystalPortals "")<br> 
  Already included in the repos for Serv and Justuo ( I believe ) with edits to improve functionality
  
[Item Of Light](https://github.com/zerodowned/My-Stuff/tree/master/ItemOfLight "")<br>
A light source that's truely equipable and moves with you naturally.
  
[Living Statue](https://github.com/zerodowned/My-Stuff/tree/master/LivingStatue "")<br>
  I edited the BaseDesItem script by Vorspire so the mobile attached to the item can move (but cannot be seen) and making it appear as though the item is walking.
  The Mobile corpse almost instantly self-deletes OnDeath and can drop loot on the ground.
  One downfall to this is that the static item won't turn to face the direct it's moving, so the fake animation can seem...pretty sloppy.
  
  You'll also notice that mobile bleeds, I have a commented out line to show how I handled it to prevent the mobile from bleeding.

//public override bool DoesNotBleed{ get{ return true;}} under IDamageableItem2 - the mobile

then in BaseWeapon find the AddBlood method and edit like below
public virtual void AddBlood(Mobile attacker, Mobile defender, int damage)
     {
       if (defender is BaseCreature) {
         if( ((BaseCreature)defender).DoesNotBleed ) {
           return;
         }
       }

[Mobile Statues](https://github.com/zerodowned/My-Stuff/tree/master/Mobile%20Statues "")<br>
  An idea presented to my by Talow...
  This is kind of a twist to the LivingStatue code, the Mobile IS the statue, with "frozen" animation.
  It stands on a pedastal until you get too close to it, then it comes alive and starts to attack you until you kill it.
  Once animated, if there are no players within a certain range, it will go back to it's pedastal and "freeze" again.
  
[Monster In A Box](https://github.com/zerodowned/My-Stuff/tree/master/Monster%20In%20A%20Box "")<br>
  * * Currently under development * *
  This code, when completed, is intended to allow you to script custom mobiles in game ( within limitations )
  Allowing you to create custom Mobs for events without writing a full script and restarting.
  * Eventually intended to have a system to save and spawn mobiles via XML as well.
  * Also intended to eventually expand on to create items, weapons, armor, etc.
  
[Pause](https://github.com/zerodowned/My-Stuff/tree/master/pause "")<br>
  This allows players to "Pause" making them frozen, hidden, and invulnerable. 
  It also puts them in Peace Mode and auto stables pets to prevent afk hunting.
  Cannot be used near Champion areas, or while involved in a PVP match.
  * System has an option to allow Staff to change the settings of certain to stop them from using it if they are abusing it via the [getxmlatt and target the player and select the Pause attachment and then change the propert "CanPause"
  - Intended to allow players to go afk randomly when Real Life calls. 
  
[Shame Revamp](https://github.com/zerodowned/My-Stuff/tree/master/ShameRevamp "")<br>
  Various mobiles and items to be used for the Shame Dungeon revamp. 
  Probably needs some tweaking.
  
[Spellbar](https://github.com/zerodowned/My-Stuff/tree/master/Spellbar "")<br>
  A gump based hotbar to add spells and allows players to cast them via the hotbar with a single click.
  Player's must have the corresponding book with spell in their pack to cast them.
  - The hotbar can be locked to prevent movement/closing.
  - Can be minimized when you need more screen room
  - Can be flipped horizontally or vertically
  - Additional edits are needed to fully work with Ninjitsu/Bushido spells ( will post later )
  
[Carousel](https://github.com/zerodowned/My-Stuff/blob/master/Carousel.cs "")<br>
  Exactly what it sounds like. Needs some editing to add tiles around it OnCreate. ** ToDo List **

[Elevator](https://github.com/zerodowned/My-Stuff/blob/master/Elevator.cs "")<br> 
  Platform that raises and lowers on a timer. Players and step on it and it will carry them up with it.
  
[Freeze Tile](https://github.com/zerodowned/My-Stuff/blob/master/FreezeTile.cs "")<br>
  ** Incomplete - Needs editing to only work with certain mobiles **
  Intended to be used with XML Waypoints ( with edits ) to make mobiles pause at a certain spot before carrying on down the waypoint path.
  
[Guardian Knight](https://github.com/zerodowned/My-Stuff/blob/master/GuardianKnight.cs "")<br>
** Needs more work **
  A Knight that certain parts of armor "fall Off" depending on how much damage has been taken.
  
[Moving Trap](https://github.com/zerodowned/My-Stuff/blob/master/MovingTrap.cs "")<br>
  A block that moves back and forth and will damage you if you're in it's path ( like those spiked blocks from Zelda )

[SBSellAll](https://github.com/zerodowned/My-Stuff/blob/master/SBSellAll.cs "")<br> 
  Intended to be used to allow Players to sell anything to any NPC Vendor
  Takes some of the tediousness out of selling loot.
  
[Smart Item](https://github.com/zerodowned/My-Stuff/blob/master/SmartItem.cs  "")<br>
** Needs a liitle work but functional **
  Items with OnThink and OnCreate similar to Mobiles.
  Inherit from this to prevent needing to create timers all the time.
  
[Speaking Sign](https://github.com/zerodowned/My-Stuff/blob/master/SpeakingSign.cs "")<br>
  Sign that speaks it's name when a player is nearby. 
  - To add use [add Speakingsign "This is the signs name in quotes"
  - Future work intended to prevent the sign from showing up in player's joural as " SpeakingSign says SpeakingSign "
  
[WayStone DungeonVersion](https://github.com/zerodowned/My-Stuff/blob/master/WayStone_DungeonVersion.cs "")<br>
  A spinoff from Talow's WayStone. 
  This is a Stone ( as often used for Stone Vendors, etc ) that sits on the ground instead of being in their pack.
  When doubleclicked, if the player is in a party, it sends a summons request to each member of the party.
  If the member accepts, they are teleported to the Summoner's position.
  If they decline, a message is sent to the summoner. 
  
  
