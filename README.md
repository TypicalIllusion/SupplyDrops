# SupplyDrops
Help the humans to defeat the anomalies in the facility with equipment from outside!

## Future Updates/Ideas
* A Command that allows to force a supplydrop
* A Command that stops supplydrops from happening
* Spawnchances for certain items

## Config
Config  | Default Value | Description
------------ | ------------- | ------------ 
minPlayersForSupply | 4 | This helps to prevent to spawn endless supplies with just less players than the given value (recommend to atleast have it at 1)
isOnlyHelicopter | true | Do you want that supplies only spawn via NTF Helicopter or do you want that the  CI Car also can bring supplies?
ciCarChance | 50 | The percentage that the CI Car brings in the supplies instead of the NTF Helicopter (requieres `isOnlyHelicopter` to be set to `false`)
items | 14, 0, 0, 0, 1, 1, 1 | `iD` is basicly the item id (look up in the Synapse resources to find item ids; you can also use custom ids for custom items) `durability` if you use weapons you can set the ammo (if not just let it stay at 0) `sight`, `barrel`, `other` are only useful for weapons (you can set the attachments for weapons; if not just the value 0), `X`, `Y`, `Z` values are for the size of the weapon
supplyIntervall | 300 | The intervall in which the supply drops happen (in seconds)
doBroadcast | true | Should the players be notified via a Broadcast that a Supplydrop is happening?
broadcastDuration | 15 | How long should the broadcast be?
doCassieAnnouncement | true | Should C.A.S.S.I.E announce the supply drop?
broadcastMessageCI | <b>A Supply drop has arrived via <color=#2EB800>CI Car</color></b> | What should the Broadcast be when the CI Car brings in supplies?
broadcastMessageMTF | <b>A Supply drop has arrived via <color=#1F22C7>NTF Helicopter</color>!</b> | What should the Broadcast be when the NTF Helicopter brings in supplies?
cassieAnnouncement | Supply has enter the facility | What should the C.A.S.S.I.E announcement be?
