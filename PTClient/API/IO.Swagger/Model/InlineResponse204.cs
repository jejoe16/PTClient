/* 
 * TrackServer
 *
 * Server for People Tracking System
 *
 * OpenAPI spec version: 1.0.2
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using PTClient.SharedResources;

namespace PTClient.IO.Swagger.Model
{
    /// <summary>
    /// InlineResponse204
    /// </summary>
    [DataContract]
    public partial class InlineResponse204 :  IEquatable<InlineResponse204>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse204" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InlineResponse204() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse204" /> class.
        /// </summary>
        /// <param name="Routemarker">Routemarker (required).</param>
        public InlineResponse204(List<TurbineItem> Routemarker = default(List<TurbineItem>))
        {
            // to ensure "Routemarker" is required (not null)
            if (Routemarker == null)
            {
                throw new InvalidDataException("Routemarker is a required property for InlineResponse204 and cannot be null");
            }
            else
            {
                this.Routemarker = Routemarker;
            }
        }
        
        /// <summary>
        /// Gets or Sets Routemarker
        /// </summary>
        [DataMember(Name="routemarker", EmitDefaultValue=false)]
        public List<TurbineItem> Routemarker { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse204 {\n");
            sb.Append("  Routemarker: ").Append(Routemarker).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as InlineResponse204);
        }

        /// <summary>
        /// Returns true if InlineResponse204 instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse204 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse204 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Routemarker == input.Routemarker ||
                    this.Routemarker != null &&
                    this.Routemarker.SequenceEqual(input.Routemarker)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Routemarker != null)
                    hashCode = hashCode * 59 + this.Routemarker.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
