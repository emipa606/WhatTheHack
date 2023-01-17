﻿using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using WhatTheHack.Buildings;

namespace WhatTheHack.Alerts
{
    class Alert_RogueAI_DrainingMood : Alert
    {
        private IEnumerable<Building_RogueAI> RogueAIs
        {
            get
            {
                foreach (Map map in Find.Maps)
                {
                    foreach (Building_RogueAI rAI in map.listerBuildings.AllBuildingsColonistOfDef(WTH_DefOf.WTH_RogueAI).Cast<Building_RogueAI>())
                    {
                        if (rAI.CurrentlyDrainingMood)
                        {
                            yield return rAI;
                        }
                    }
                }
            }
        }

        public Alert_RogueAI_DrainingMood()
        {
            this.defaultLabel = "WTH_Alert_RogueAI_DrainingMood_Label".Translate();
            this.defaultPriority = AlertPriority.High;
        }

        public override TaggedString GetExplanation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            return string.Format("WTH_Alert_RogueAI_DrainingMood_Description".Translate(), stringBuilder.ToString());
        }

        public override AlertReport GetReport()
        {
            return AlertReport.CulpritIs(RogueAIs.FirstOrDefault<Building_RogueAI>());
        }
    }
}
