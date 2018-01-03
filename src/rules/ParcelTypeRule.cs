﻿/*
Copyright 2016 Pitney Bowes Inc.

Licensed under the MIT License(the "License"); you may not use this file except in compliance with the License.  
You may obtain a copy of the License in the README file or at
   https://opensource.org/licenses/MIT 
Unless required by applicable law or agreed to in writing, software distributed under the License is distributed 
on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the License 
for the specific language governing permissions and limitations under the License.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS 
OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PitneyBowes.Developer.ShippingApi.Rules
{
    /// <summary>
    /// Carrier rule for parcel types. 
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ParcelTypeRule : IRateRule
    {
        /// <summary>
        /// The abbreviated name of the parcel type.
        /// </summary>
        [JsonProperty("parcelType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ParcelType ParcelType { get; set; }
        /// <summary>
        /// 	The full name of the parvel type.
        /// </summary>
        [JsonProperty("brandedName")]
        public string BrandedName { get; set; }
        /// <summary>
        /// The type of rate requested. If a type was not specified in the request, the API returns all the eligible rate types.
        /// </summary>
        [JsonProperty("rateTypeId")]
        public string RateTypeId { get; set; }
        /// <summary>
        /// The full name of the rate type.
        /// </summary>
        [JsonProperty("rateTypeBrandedName")]
        public string RateTypeBrandedName { get; set; }
        /// <summary>
        /// Whether this parcel type is trackable.
        /// </summary>
        [JsonProperty("trackable")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Trackable Trackable { get; set; }
        /// <summary>
        /// 	The special services applicable for this combination of service type, rate type, and parcel type.
        /// </summary>
        public IndexedList<SpecialServiceCodes, SpecialServicesRule> SpecialServiceRules { get; set; }
        /// <summary>
        /// Weight rules for this combination of service type, rate type, and parcel type.
        /// </summary>
        [JsonProperty("weightRules")]
        public IEnumerable<WeightRule> WeightRules { get; set; }
        /// <summary>
        /// 	Dimension rules for this combination of service type, rate type, and parcel type.
        /// </summary>
        [JsonProperty("dimensionRules")]
        public IEnumerable<DimensionRule> DimensionRules { get; set; }
        /// <summary>
        /// Most common choice for tracking this parcel type.
        /// </summary>
        [JsonProperty("suggestedTrackableSpecialServiceId")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SpecialServiceCodes SuggestedTrackableSpecialServiceId { get; set; }

        [JsonProperty("specialServiceRules")]
        internal IEnumerable<SpecialServicesRule> SerializerSpecialServiceRules
        {
            get => SpecialServiceRules;
            set
            {
                if (SpecialServiceRules == null) SpecialServiceRules = new IndexedList<SpecialServiceCodes, SpecialServicesRule>();
                foreach (var ss in value)
                {
                    SpecialServiceRules.Add(ss.SpecialServiceId, ss);
                }
            }
        }
        /// <summary>
        /// Accept method for Visitor pattern
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IRateRuleVisitor visitor)
        {
            visitor.Visit(this);
        }
        /// <summary>
        /// If true, the dimensions object fits within the boundaries specified by the dimension rules rule.
        /// </summary>
        /// <param name="dimensions"></param>
        /// <returns></returns>
        public bool FitsDimensions(IParcelDimension dimensions)
        {
            foreach (var d in DimensionRules)
            {
                if (!dimensions.IsWithin(d))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// If true, the weight object is within the boundaries specified by the weight rules
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public bool HoldsWeight(IParcelWeight weight)
        {
            foreach (var w in WeightRules)
            {
                if (!weight.IsWithin(w))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
