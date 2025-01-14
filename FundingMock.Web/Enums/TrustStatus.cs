﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FundingMock.Web.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrustStatus
    {
        [EnumMember(Value = "Not applicable")]
        NotApplicable,

        [EnumMember(Value = "Not supported by a trust")]
        NotSupportedByATrust,

        [EnumMember(Value = "Supported by a trust")]
        SupportedByATrust,

        [EnumMember(Value = "Supported by a single-academy trust")]
        SupportedByASingleAacademyTrust,

        [EnumMember(Value = "Supported by a multi-academy trust")]
        SupportedByAMultiAcademyTrust,
    }
}
