﻿/*
Copyright 2019 Pitney Bowes Inc.

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

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PitneyBowes.Developer.ShippingApi.Json;

namespace PitneyBowes.Developer.ShippingApi
{
    /// <summary>
    /// Class to manage object creation during the serialization and deserialization process. A wrapper class is used to specify the JSON 
    /// attributes during both serialization and deserialization. During deserialization an object implementing the service data constract
    /// is created. The SerializationRegistry holds the relationship between the data contract interface, the wrapper and the deserialization class.
    /// </summary>
    public class SerializationRegistry
    {
        private Dictionary<Type, JsonConverter> _serializationRegistry = new Dictionary<Type, JsonConverter>();
        private Dictionary<Type, Type> _wrapperRegistry = new Dictionary<Type, Type>();
        /// <summary>
        /// Gets the wrapper for given interface.
        /// </summary>
        /// <returns>The wrapper for.</returns>
        /// <param name="type">Type.</param>
        public Type GetWrapperFor(Type type)
        {
            return _wrapperRegistry[type];
        }
        /// <summary>
        /// Default constructor - initializes the structures.
        /// </summary>
        public SerializationRegistry()
        {
            _serializationRegistry.Add(typeof(SpecialServiceCodes), new SpecialServiceCodesConverter());
            _serializationRegistry.Add(typeof(PackageLocation), new PackageLocationConverter());
            _serializationRegistry.Add(typeof(TrackingStatusCode), new TrackingStatusConverter());
            _serializationRegistry.Add(typeof(TransactionType), new TransactionTypeConverter());
            _serializationRegistry.Add(typeof(ParcelType), new ParcelTypeConverter());
            _serializationRegistry.Add(typeof(Services), new ServicesConverter());

            RegisterSerializationWrappers();
        }

        internal JsonConverter GetConverter(Type type)
        {
            if (_serializationRegistry.ContainsKey(type))
            {
                return _serializationRegistry[type];
            }
            return null;
        }

        /// <summary>
        /// Register a type for the deserializer to create. Works like an IoC container. Would be good to be able to plug in an IoC container here
        /// but JSON.net doesnt have support for this.
        /// </summary>
        /// <typeparam name="I">Data contract interface</typeparam>
        /// <typeparam name="T">Type of object to create</typeparam>
        public void RegisterSerializationTypes<I, T>() where T : I
        {
            Type interfaceType = typeof(I);
            Type objectType = typeof(T);
            Type wrapperType = _wrapperRegistry[interfaceType];
            JsonConverter c = new ShippingApiConverter(objectType, wrapperType.MakeGenericType(new Type[] { objectType }));

            _serializationRegistry[interfaceType] = c;
            _serializationRegistry[objectType] = c;
        }

        private void RegisterSerializationWrappers()
        {
            _wrapperRegistry.Add(typeof(IAddress), typeof(JsonAddress<>));
            _wrapperRegistry.Add(typeof(IAutoRefill), typeof(JsonAutoRefill<>));
            _wrapperRegistry.Add(typeof(ICarrierAccount), typeof(JsonCarrierAccount<>));
            _wrapperRegistry.Add(typeof(ICarrierLicense), typeof(JsonCarrierLicense<>));
            _wrapperRegistry.Add(typeof(ICcPaymentDetails), typeof(JsonCcPaymentDetails<>));
            _wrapperRegistry.Add(typeof(ICustoms), typeof(JsonCustoms<>));
            _wrapperRegistry.Add(typeof(ICustomsInfo), typeof(JsonCustomsInfo<>));
            _wrapperRegistry.Add(typeof(ICustomsItems), typeof(JsonCustomsItems<>));
            _wrapperRegistry.Add(typeof(IDeliveryCommitment), typeof(JsonDeliveryCommitment<>));
            _wrapperRegistry.Add(typeof(IDocument), typeof(JsonDocument<>));
            _wrapperRegistry.Add(typeof(IDocTab), typeof(JsonDocTab<>));
            _wrapperRegistry.Add(typeof(IManifest), typeof(JsonManifest<>));
            _wrapperRegistry.Add(typeof(IMerchant), typeof(JsonMerchant<>));
            _wrapperRegistry.Add(typeof(IPage), typeof(JsonPage<>));
            _wrapperRegistry.Add(typeof(IParameter), typeof(JsonParameter<>));
            _wrapperRegistry.Add(typeof(IParcel), typeof(JsonParcel<>));
            _wrapperRegistry.Add(typeof(IParcelDimension), typeof(JsonParcelDimension<>));
            _wrapperRegistry.Add(typeof(IParcelWeight), typeof(JsonParcelWeight<>));
            _wrapperRegistry.Add(typeof(IPaymentInfo), typeof(JsonPaymentInfo<>));
            _wrapperRegistry.Add(typeof(IPickup), typeof(JsonPickup<>));
            _wrapperRegistry.Add(typeof(IPickupCount), typeof(JsonPickupCount<>));
            _wrapperRegistry.Add(typeof(IPpPaymentDetails), typeof(JsonPpPaymentDetails<>));
            _wrapperRegistry.Add(typeof(IRates), typeof(JsonRates<>));
            _wrapperRegistry.Add(typeof(IReference), typeof(JsonReference<>));
            _wrapperRegistry.Add(typeof(ISpecialServices), typeof(JsonSpecialServices<>));
            _wrapperRegistry.Add(typeof(IShipmentOptions), typeof(JsonShipmentOptions<>));
            _wrapperRegistry.Add(typeof(IShipment), typeof(JsonShipment<>));
            _wrapperRegistry.Add(typeof(ITransaction), typeof(JsonTransaction<>));
            _wrapperRegistry.Add(typeof(ITrackingEvent), typeof(JsonTrackingEvent<>));
            _wrapperRegistry.Add(typeof(ITrackingStatus), typeof(JsonTrackingStatus<>));
            _wrapperRegistry.Add(typeof(ITransactionSort), typeof(JsonTransactionSort<>));
            _wrapperRegistry.Add(typeof(IUserInfo), typeof(JsonUserInfo<>));
            _wrapperRegistry.Add(typeof(ICarrierSurcharge), typeof(JsonCarrierSurcharge<>));
        }
    }
}
