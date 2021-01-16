﻿using MEC;
using Respawning;
using Synapse;
using Synapse.Api;
using Synapse.Api.Items;
using Synapse.Api.Plugin;
using Synapse.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace SupplyDrops.Handlers
{
    class EventHandlers
    {
        Random r = new Random();
        Vector3 mtfSpawn = new Vector3(180, 993, -58);
        Vector3 ciSpawn = new Vector3(5, 988, -58);
        private CoroutineHandle _start;
        public EventHandlers()
        {
            //You can also use SynapseController.Server to get the Server!
            Server.Get.Events.Round.RoundStartEvent += onStart;
            Server.Get.Events.Round.RoundEndEvent += onRoundEnd;
            Server.Get.Events.Round.RoundRestartEvent += onRoundRestart;
        }


        public void onStart()
        {
            _start = Timing.RunCoroutine(doSupplyDrop());
        }

        public void onRoundEnd() => Timing.KillCoroutines(_start);

        public void onRoundRestart() => Timing.KillCoroutines(_start);
        

        public IEnumerator<float> doSupplyDrop()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(Plugin.Config.SupplyIntervall);

                if (Server.Get.Players.Count >= Plugin.Config.MinPlayersForSupply)
                {
                    if (Plugin.Config.DoCassieAnnouncement)
                        Map.Get.GlitchedCassie(Plugin.Config.CassieAnnouncement);
                    if (Plugin.Config.IsOnlyCICar)
                    {
                        int i = r.Next(1, 101);
                        if (i <= Plugin.Config.CiCarChance)
                        {
                            RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.ChaosInsurgency);

                            if (Plugin.Config.DoBroadcast)
                                Map.Get.SendBroadcast(Plugin.Config.BroadcastDuration, Plugin.Config.BroadcastMessageCI);

                            yield return Timing.WaitForSeconds(15f);


                            foreach (var items in Plugin.Config.Items)
                                items.Parse().Drop(ciSpawn);

                        }
                    }

                    if (!Plugin.Config.IsOnlyHelicopter)
                    {
                        int i = r.Next(1, 101);
                        if (i <= Plugin.Config.CiCarChance)
                        {
                            RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.ChaosInsurgency);

                            if (Plugin.Config.DoBroadcast)
                                Map.Get.SendBroadcast(Plugin.Config.BroadcastDuration, Plugin.Config.BroadcastMessageCI);

                            yield return Timing.WaitForSeconds(15f);


                            foreach (var items in Plugin.Config.Items)
                                items.Parse().Drop(ciSpawn);

                        }
                        else
                        {
                            RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);

                            if (Plugin.Config.DoBroadcast)
                                Map.Get.SendBroadcast(Plugin.Config.BroadcastDuration, Plugin.Config.BroadcastMessageMTF);

                            yield return Timing.WaitForSeconds(15f);

                            foreach (var items in Plugin.Config.Items)
                                items.Parse().Drop(ciSpawn);

                        }
                    }
                    else
                    {
                        RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);

                        if (Plugin.Config.DoBroadcast)
                            Map.Get.SendBroadcast(Plugin.Config.BroadcastDuration, Plugin.Config.BroadcastMessageMTF);

                        yield return Timing.WaitForSeconds(15f);

                        foreach (var items in Plugin.Config.Items)
                            items.Parse().Drop(ciSpawn);
                    }

                    yield return Timing.WaitForOneFrame;
                }
                else
                    Server.Get.Logger.Info("Not enough players for a supplydrop, skipping");
            }
        }



        


    }
}
