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
using System.Text;
using PitneyBowes.Developer.ShippingApi;

namespace PitneyBowes.Developer.ShippingApi.Model
{
    /// <summary>
    /// This operation retrieves a carrier’s license agreement. The operation is used in the Carrier Registration Tutorial.
    /// </summary>
    public class CarrierLicense : ICarrierLicense
    {
        /// <summary>
        /// Required. The carrier.
        /// Valid value:
        ///   UPS
        /// </summary>
        public Carrier Carrier { get; set; }
        /// <summary>
        /// ISO Country code
        /// </summary>
        public string OriginCountryCode { get; set; }
        /// <summary>
        /// License Text
        /// </summary>
        public string LicenseText { get; set; }
    }
}
