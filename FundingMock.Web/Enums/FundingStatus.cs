﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FundingMock.Web.Models
{
    /// <summary>
    /// The funding status (wehter its published or otherwise).
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FundingStatus
    {
        /// <summary>
        /// Published.
        /// </summary>
        Published,
    }
}