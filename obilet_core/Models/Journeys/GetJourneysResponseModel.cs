using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class GetJourneysResponseModel
{
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("data")]
    public List<ServiceResponseData> Data { get; set; }
    [JsonProperty("message")]
    public string Message { get; set; }
    [JsonProperty("user-message")]
    public string UserMessage { get; set; }
    [JsonProperty("api-request-id")]
    public string ApiRequestId { get; set; }
    [JsonProperty("controller")]
    public string Controller { get; set; }
    [JsonProperty("client-request-id")]
    public string ClientRequestId { get; set; }
    [JsonProperty("web-correlation-id")]
    public string WebCorrelationId { get; set; }
    [JsonProperty("correlation-id")]
    public string CorrelationId { get; set; }
}

public class ServiceResponseData
{
    [JsonProperty("id")]
    public long? Id { get; set; }
    [JsonProperty("partner-id")]
    public int? PartnerId { get; set; }
    [JsonProperty("partner-name")]
    public string PartnerName { get; set; }
    [JsonProperty("route-id")]
    public int? RouteId { get; set; }
    [JsonProperty("bus-type")]
    public string BusType { get; set; }
    [JsonProperty("bus-type-name")]
    public string BusTypeName { get; set; }
    [JsonProperty("total-seats")]
    public int? TotalSeats { get; set; }
    [JsonProperty("available-seats")]
    public int? AvailableSeats { get; set; }
    [JsonProperty("journey")]
    public Journey Journey { get; set; }
    [JsonProperty("features")]
    public List<Feature> Features { get; set; }
    [JsonProperty("origin-location")]
    public string OriginLocation { get; set; }
    [JsonProperty("destination-location")]
    public string DestinationLocation { get; set; }
    [JsonProperty("is-active")]
    public bool IsActive { get; set; }
    [JsonProperty("origin-location-id")]
    public int? OriginLocationId { get; set; }
    [JsonProperty("destination-location-id")]
    public int? DestinationLocationId { get; set; }
    [JsonProperty("is-promoted")]
    public bool IsPromoted { get; set; }
    [JsonProperty("cancellation-offset")]
    public int? CancellationOffset { get; set; }
    [JsonProperty("has-bus-shuttle")]
    public bool HasBusShuttle { get; set; }
    [JsonProperty("disable-sales-without-gov-id")]
    public bool DisableSalesWithoutGovId { get; set; }
    [JsonProperty("display-offset")]
    public string DisplayOffset { get; set; }
    [JsonProperty("partner-rating")]
    public double? PartnerRating { get; set; }
    [JsonProperty("has-dynamic-pricing")]
    public bool HasDynamicPricing { get; set; }
    [JsonProperty("disable-sales-without-hes-code")]
    public bool DisableSalesWithoutHesCode { get; set; }
    [JsonProperty("disable-single-seat-selection")]
    public bool DisableSingleSeatSelection { get; set; }
    [JsonProperty("change-offset")]
    public int? ChangeOffset { get; set; }
    [JsonProperty("rank")]
    public int? Rank { get; set; }
    [JsonProperty("display-coupon-code-input")]
    public bool DisplayCouponCodeInput { get; set; }
    [JsonProperty("disable-sales-without-date-of-birth")]
    public bool DisableSalesWithoutDateOfBirth { get; set; }
    [JsonProperty("open-offset")]
    public int? OpenOffset { get; set; }
    [JsonProperty("display-buffer")]
    public string DisplayBuffer { get; set; }
    [JsonProperty("allow-sales-foreign-passenger")]
    public bool AllowSalesForeignPassenger { get; set; }
    [JsonProperty("has-seat-selection")]
    public bool HasSeatSelection { get; set; }
    [JsonProperty("branded-fares")]
    public List<object> BrandedFares { get; set; }  
    [JsonProperty("has-gender-selection")]
    public bool HasGenderSelection { get; set; }
    [JsonProperty("has-dynamic-cancellation")]
    public bool HasDynamicCancellation { get; set; }
    [JsonProperty("partner-terms-and-conditions")]
    public string PartnerTermsAndConditions { get; set; }
    [JsonProperty("partner-available-alphabets")]
    public string PartnerAvailableAlphabets { get; set; }
    [JsonProperty("provider-name")]
    public string ProviderName { get; set; }
    [JsonProperty("enable-full-journey-display")]
    public bool EnableFullJourneyDisplay { get; set; }
}

public class Policy
{
    [JsonProperty("max-seats")]
    public int? MaxSeats { get; set; }

    [JsonProperty("max-single")]
    public int? MaxSingle { get; set; }

    [JsonProperty("max-single-males")]
    public int? MaxSingleMales { get; set; }

    [JsonProperty("max-single-females")]
    public int? MaxSingleFemales { get; set; }

    [JsonProperty("mixed-genders")]
    public bool MixedGenders { get; set; }

    [JsonProperty("gov-id")]
    public bool GovId { get; set; }

    [JsonProperty("lht")]
    public bool Lht { get; set; }
}

public class Journey
{
    [JsonProperty("kind")]
    public string Kind { get; set; }
    [JsonProperty("code")]
    public string Code { get; set; }
    [JsonProperty("stops")]
    public List<Stop> Stops { get; set; }
    [JsonProperty("origin")]
    public string Origin { get; set; }
    [JsonProperty("destination")]
    public string Destination { get; set; }
    [JsonProperty("departure")]
    public DateTime Departure { get; set; }
    [JsonProperty("arrival")]
    public DateTime Arrival { get; set; }
    [JsonProperty("currency")]
    public string Currency { get; set; }
    [JsonProperty("duration")]
    public string Duration { get; set; }
    [JsonProperty("original-price")]
    public double OriginalPrice { get; set; }
    [JsonProperty("internet-price")]
    public double InternetPrice { get; set; }
    [JsonProperty("provider-internet-price")]
    public double? ProviderInternetPrice { get; set; }
    [JsonProperty("booking")]
    public string Booking { get; set; }
    [JsonProperty("bus-name")]
    public string BusName { get; set; }
    [JsonProperty("policy")]
    public Policy Policy { get; set; }
    [JsonProperty("features")]
    public List<string> Features { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("available")]
    public bool? Available { get; set; }
}

public class Feature
{
    [JsonProperty("id")]
    public int? Id { get; set; }
    [JsonProperty("priority")]
    public int? Priority { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("is-promoted")]
    public bool IsPromoted { get; set; }
    [JsonProperty("back-color")]
    public string BackColor { get; set; }
    [JsonProperty("fore-color")]
    public string ForeColor { get; set; }
}

public class Stop
{
    [JsonProperty("id")]
    public int? Id { get; set; }
    [JsonProperty("kolayCarLocationId")]
    public int? KolayCarLocationId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("station")]
    public string Station { get; set; }
    [JsonProperty("time")]
    public string Time { get; set; }
    [JsonProperty("is-origin")]
    public bool IsOrigin { get; set; }
    [JsonProperty("is-destination")]
    public bool IsDestination { get; set; }
}
