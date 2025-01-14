﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace FundingMock.Web.Models
{
    /// <summary>
    /// A funding group (a parent grouping organisation - such as an LA, MAT, Region etc...).
    /// </summary>
    public class FundingFeed : Funding
    {
        /// <summary>
        /// The fundings (child organisation level lines, e.g. providers under an LA) that are grouped into this funding group.
        /// </summary>
        [JsonProperty("providerFundings", Order = 8)]
        public IEnumerable<string> ProviderFundings { get; set; }
    }
}