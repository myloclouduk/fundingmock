﻿using Newtonsoft.Json;
using FundingMock.Web.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FundingMock.Web.Models
{
    /// <summary>
    /// A funding line.
    /// </summary>
    public class FundingLine
    {
        /// <summary>
        ///  Create a funding line, setting properties to defaults. 
        /// </summary>
        public FundingLine()
        {
            Type = FundingLineType.Information;
        }

        /// <summary>
        /// The name of a funding line (e.g. "Total funding line").
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Funding Line Code - unique code within the template to lookup this specific funding line.
        /// Used to map this funding line in consuming systems (eg nav for payment)
        /// </summary>
        [JsonProperty("fundingLineCode", NullValueHandling = NullValueHandling.Ignore)]
        public string FundingLineCode { get; set; }

        /// <summary>
        /// The funding value in pence.
        /// </summary>
        [JsonProperty("value")]
        public long Value { get; set; }

        /// <summary>
        /// A unique ID (in terms of template, not data) for this funding line (e.g. 345).
        /// </summary>
        [JsonProperty("templateLineId")]
        public uint TemplateLineId { get; set; }

        /// <summary>
        /// The type of the funding line (e.g. paid on this basis, or informational only).
        /// </summary>
        [EnumDataType(typeof(FundingLineType))]
        [JsonProperty("type")]
        public FundingLineType Type { get; set; }

        /// <summary>
        /// The periods that this funding line where paid in / are due to be paid in.
        /// </summary>
        [JsonProperty("profilePeriods", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<FundingLinePeriod> ProfilePeriods { get; set; }

        /// <summary>
        /// Calculations that make up this funding line.
        /// </summary>
        [JsonProperty("calculations", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Calculation> Calculations { get; set; }

        /// <summary>
        /// Sub funding lines that make up this funding line.
        /// </summary>
        [JsonProperty("fundingLines", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<FundingLine> FundingLines { get; set; }
    }
}