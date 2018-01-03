/*
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

namespace PitneyBowes.Developer.ShippingApi.Model
{
    /// <summary>
    /// Customs clearance information that is used to fill out a commercial invoice
    /// </summary>
    public class CustomsInfo : ICustomsInfo
    {
        /// <summary>
        /// Gets or sets the reason for export.
        /// </summary>
        /// <value>The reason for export.</value>
        virtual public ReasonForExport ReasonForExport { get; set;}
        /// <summary>
        /// Required if the ``reasonForExport`` field is set to ``OTHER``.
        /// </summary>
        /// <value>The reason for export explanation.</value>
        virtual public string ReasonForExportExplanation { get; set;}
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        virtual public string Comments { get;set;}
        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        /// <value>The invoice number.</value>
        virtual public string InvoiceNumber {get;set;}
        /// <summary>
        /// A reference number used by the imported. For example, a PO number or insured number.
        /// </summary>
        /// <value>The importer customs reference.</value>
        virtual public string ImporterCustomsReference {get;set;}
        /// <summary>
        /// If the sender wishes to insure the contents, they complete an insurance
        /// receipt and affix the insured numbered label to the package.The
        /// insured number label is what this field represents.
        /// </summary>
        virtual public string InsuredNumber {get;set;}
        /// <summary>
        /// The declared value of the item for insurance purposes expressed in USD.
        /// </summary>
        /// <value>The insured amount.</value>
        virtual public decimal InsuredAmount {get;set;}
        /// <summary>
        /// When an international parcel is insured, the insured value must be
        /// expressed in Special Drawing Rights values.E.g. $100 USD = 66.87 SDR.
        /// </summary>
        /// <value>The sdr value.</value>
        virtual public decimal SdrValue { get;set;}
        /// <summary>
        /// EEI/PFC is the Electronic Export Information and Proof of Filing
        /// Citation.Both are required if the item you are shipping
        /// internationally is valued over $2,500 USD per schedule b export codes.
        /// </summary>
        /// <value>The eelpfc.</value>
        virtual public string EELPFC {get;set;}
        /// <summary>
        /// Free form reference information provided by the requestor of the
        /// shipment.Depending on the carrier this information may or may not be
        /// rendered on the customs documents.
        /// </summary>
        /// <value>From customs reference.</value>
        virtual public string FromCustomsReference {get;set;}
        /// <summary>
        /// The value of the item that is going to be declared in customs.
        /// </summary>
        /// <value>The customs declared value.</value>
        virtual public decimal CustomsDeclaredValue { get;set;}
        /// <summary>
        /// Type of currency referenced in the piece price. Use three uppercase
        /// letters, per ISO 4217. For example: ``USD``, ``CAD``, ``EUR``.
        /// </summary>
        /// <value>The currency code.</value>
        virtual public string CurrencyCode {get;set;}
        /// <summary>
        /// The export license number associated with the commodity.
        /// </summary>
        /// <value>The license number.</value>
        virtual public string LicenseNumber {get;set;}
        /// <summary>
        /// The certificate number associated with the commodity.
        /// </summary>
        /// <value>The certificate number.</value>
        virtual public string CertificateNumber {get;set;}
    }
}