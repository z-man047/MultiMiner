﻿using MultiMiner.Utility.Serialization;
using MultiMiner.Xgminer.Data;
using System.Collections.Generic;
using System.Linq;

namespace MultiMiner.Win.Extensions
{
    internal static class XgminerConfigurationExtensions
    {
        public static Remoting.Data.Transfer.Configuration.Xgminer ToTransferObject(this Engine.Data.Configuration.Xgminer modelObject)
        {
            Remoting.Data.Transfer.Configuration.Xgminer transferObject = new Remoting.Data.Transfer.Configuration.Xgminer();

            ObjectCopier.CopyObject(modelObject, transferObject,
                "AlgorithmFlags",
                "StratumProxies",
                "AlgorithmMiners");

            foreach (KeyValuePair<CoinAlgorithm, string> pair in modelObject.AlgorithmFlags)
                transferObject.AlgorithmFlags.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<CoinAlgorithm, string> pair in modelObject.AlgorithmMiners)
                transferObject.AlgorithmMiners.Add(pair.Key, pair.Value);

            transferObject.StratumProxies = modelObject.StratumProxies.ToArray();

            return transferObject;
        }

        public static Engine.Data.Configuration.Xgminer ToModelObject(this Remoting.Data.Transfer.Configuration.Xgminer transferObject)
        {
            Engine.Data.Configuration.Xgminer modelObject = new Engine.Data.Configuration.Xgminer();

            ObjectCopier.CopyObject(transferObject, modelObject,
                "AlgorithmFlags",
                "StratumProxies",
                "AlgorithmMiners");

            foreach (CoinAlgorithm key in transferObject.AlgorithmFlags.Keys)
                modelObject.AlgorithmFlags.Add(key, (string)transferObject.AlgorithmFlags[key]);

            foreach (CoinAlgorithm key in transferObject.AlgorithmMiners.Keys)
                modelObject.AlgorithmMiners.Add(key, (string)transferObject.AlgorithmMiners[key]);

            modelObject.StratumProxies = transferObject.StratumProxies.ToList();

            return modelObject;
        }
    }
}