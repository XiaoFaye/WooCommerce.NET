using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WooCommerceNET.WooCommerce.v3
{
    [DataContract]
    public class Data
    {
        public static string Endpoint { get { return "data"; } }

        /// <summary>
        /// Data resource ID.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }

        /// <summary>
        /// Data resource description.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }
    }

    [DataContract]
    public class Continent
    {
        /// <summary>
        /// 2 character continent code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Full name of continent.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// List of countries on this continent. See Continents - Countries properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<Country> countries { get; set; }
    }

    [DataContract]
    public class Country
    {
        /// <summary>
        /// ISO3166 alpha-2 country code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Default ISO4127 alpha-3 currency code for the country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string currency_code { get; set; }

        /// <summary>
        /// Currency symbol position for this country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string currency_pos { get; set; }

        /// <summary>
        /// Decimal separator for displayed prices for this country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string decimal_sep { get; set; }

        /// <summary>
        /// The unit lengths are defined in for this country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string dimension_unit { get; set; }

        /// <summary>
        /// Full name of country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Number of decimal points shown in displayed prices for this country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int num_decimals { get; set; }

        /// <summary>
        /// List of states in this country. See Continents - Countries - States properties
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<State> states { get; set; }

        /// <summary>
        /// Thousands separator for displayed prices in this country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string thousand_sep { get; set; }

        /// <summary>
        /// The unit weights are defined in for this country.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string weight_unit { get; set; }
    }

    [DataContract]
    public class State
    {
        /// <summary>
        /// State code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Full name of state.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }
    }

    [DataContract]
    public class Currency
    {
        /// <summary>
        /// ISO4217 currency code.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string code { get; set; }

        /// <summary>
        /// Full name of currency.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        /// <summary>
        /// Currency symbol.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string symbol { get; set; }
    }
}
