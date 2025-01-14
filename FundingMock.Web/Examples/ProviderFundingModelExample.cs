﻿using System;
using System.Collections.Generic;
using FundingMock.Web.Enums;
using FundingMock.Web.Models;
using Swashbuckle.AspNetCore.Filters;

namespace FundingMock.Web.Examples
{
    public class ProviderFundingModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var ukOffset = new TimeSpan(0, 0, 0);
            var fundingVersion = "1-0";

            var period = new FundingPeriod
            {
                Code = "AY1920",
                Name = "Academic year 2019-20",
                Type = PeriodType.AcademicYear,
                StartDate = new DateTimeOffset(2019, 9, 1, 0, 0, 0, ukOffset),
                EndDate = new DateTimeOffset(2020, 8, 31, 0, 0, 0, ukOffset)
            };

            var templateVersion = "2.1";

            var stream = new StreamWithTemplateVersion
            {
                Code = "PESports",
                Name = "PE + Sport Premium",
                TemplateVersion = templateVersion,
            };

            string providerId = "12345678";

            var groupingOrg = new OrganisationGroup()
            {
                Type = OrganisationType.LocalAuthority,
                Name = "Camden",
                Identifiers = new List<OrganisationIdentifier>
                {
                    new OrganisationIdentifier
                    {
                        Type = OrganisationIdentifierType.LACode,
                        Value = "203"
                    },
                    new OrganisationIdentifier
                    {
                        Type = OrganisationIdentifierType.UKPRN,
                        Value = providerId
                    }
                }
            };


            var id = $"{stream.Code}_{period.Code}_{providerId}_{fundingVersion}";

            var financialYearPeriod1920 = new FundingPeriod
            {
                Code = "FY1920",
                Name = "Financial Year 2019-20",
                Type = PeriodType.FinancialYear,
                StartDate = new DateTimeOffset(2019, 4, 1, 0, 0, 0, ukOffset),
                EndDate = new DateTimeOffset(2020, 3, 30, 0, 0, 0, ukOffset)
            };

            var financialYearPeriod2021 = new FundingPeriod
            {
                Code = "FY2021",
                Name = "Financial Year 2020-21",
                Type = PeriodType.FinancialYear,
                StartDate = new DateTimeOffset(2020, 4, 1, 0, 0, 0, ukOffset),
                EndDate = new DateTimeOffset(2021, 3, 30, 0, 0, 0, ukOffset)
            };

            return new ProviderFunding
            {
                Id = id,
                FundingVersion = fundingVersion,
                FundingPeriodCode = period.Code,
                FundingStreamCode = stream.Code,
                Organisation = new Organisation
                {
                    Name = "Example School 1",
                    SearchableName = "ExampleSchool1",
                    OrganisationDetails = new OrganisationDetails()
                    {
                        DateClosed = null,
                        DateOpened = new DateTimeOffset(2012, 12, 2, 0, 0, 0, 0, TimeSpan.Zero),
                        PhaseOfEducation = "Secondary",
                        Status = "Open",
                        OpenReason = ProviderOpenReason.AcademyConverter,
                        CloseReason = null,
                        TrustName = "Trust Name",
                        TrustStatus = TrustStatus.SupportedByASingleAacademyTrust,
                        Address = new OrganisationAddress
                        {
                            Postcode = "MOCK POSTCODE",
                            Town = "MOCK TOWN"
                        }
                    },
                    ProviderType = "Academies",
                    ProviderSubType = "Academy alternative provision converter",
                    ProviderVersionId = "3",
                    Identifiers = new List<OrganisationIdentifier>
                    {
                        new OrganisationIdentifier
                        {
                            Type = OrganisationIdentifierType.URN,
                            Value = "123453"
                        },
                        new OrganisationIdentifier
                        {
                            Type = OrganisationIdentifierType.UKPRN,
                            Value = providerId
                        },
                        new OrganisationIdentifier
                        {
                            Type = OrganisationIdentifierType.AcademyTrustCode,
                            Value = "2705",
                        }
                    },
                },
                Variations = new Variations()
                {
                    VariationReasons = new List<VariationReason>()
                    {
                        VariationReason.NameFieldUpdated,
                        VariationReason.FundingUpdated,
                    },
                    Successors = new List<ProviderInformationModel>()
                    {
                        new ProviderInformationModel()
                        {
                            ProviderVersionId = "pes2",
                            Ukprn = "2345333",
                        },
                    },
                },
                FundingValue = new FundingValue
                {
                    TotalValue = 1200,
                    FundingValueByDistributionPeriod = new List<FundingValueByDistributionPeriod>
                    {
                        new FundingValueByDistributionPeriod
                        {
                            DistributionPeriodCode = financialYearPeriod1920.Code,
                            Value = 700,
                            FundingLines = new List<FundingLine>
                            {
                                new FundingLine
                                {
                                    Name = "Total funding line",
                                    FundingLineCode= "TotalFundingLine",
                                    TemplateLineId = 1,
                                    Type = FundingLineType.Payment,
                                    Value = 700,
                                    ProfilePeriods = new List<FundingLinePeriod>
                                    {
                                        new FundingLinePeriod
                                        {
                                            Occurence = 1,
                                            Year = 2019,
                                            TypeValue = "October",
                                            ProfiledValue = 700,
                                            Type = FundingLinePeriodType.CalendarMonth,
                                            PeriodCode = financialYearPeriod1920.Code
                                        }
                                    },
                                    Calculations = new List<Calculation>
                                    {
                                        new Calculation
                                        {
                                            Name = "Number of pupils",
                                            Type = CalculationType.PupilNumber,
                                            TemplateCalculationId = 1,
                                            Value = "456",
                                            ValueFormat = CalculationValueFormat.Number,
                                            FormulaText = "Something * something",
                                            ReferenceData = new List<ReferenceData>
                                            {
                                                new ReferenceData
                                                {
                                                    Name = "Academic year 2018 to 2019 pupil number on roll",
                                                    Value = "1",
                                                    Format = ReferenceDataValueFormat.Number,
                                                    TemplateReferenceId = 1,
                                                }
                                            }
                                        },
                                        new Calculation
                                        {
                                            Name = "Number of pupils",
                                            Type = CalculationType.PupilNumber,
                                            TemplateCalculationId = 1,
                                            Value = "456",
                                            ValueFormat = CalculationValueFormat.Number,
                                            FormulaText = "Something * something",
                                            ReferenceData = new List<ReferenceData>
                                            {
                                                new ReferenceData
                                                {
                                                    Name = "Academic year 2018 to 2019 pupil number on roll",
                                                    Value = "1",
                                                    Format = ReferenceDataValueFormat.Number,
                                                    TemplateReferenceId = 2,
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new FundingValueByDistributionPeriod
                        {
                            DistributionPeriodCode = financialYearPeriod2021.Code,
                            Value = 500,
                            FundingLines = new List<FundingLine>
                            {
                                new FundingLine
                                {
                                    Name = "Total funding line",
                                    FundingLineCode= "TotalFundingLine2",
                                    TemplateLineId = 1,
                                    Type = FundingLineType.Payment,
                                    Value = 500,
                                    ProfilePeriods = new List<FundingLinePeriod>
                                    {
                                        new FundingLinePeriod
                                        {
                                            Occurence = 1,
                                            Year = 2020,
                                            TypeValue = "April",
                                            ProfiledValue = 500,
                                            Type = FundingLinePeriodType.CalendarMonth,
                                            PeriodCode = financialYearPeriod2021.Code
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}