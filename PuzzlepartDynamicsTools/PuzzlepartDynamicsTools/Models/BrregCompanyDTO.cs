using System.Runtime.Serialization;

namespace PuzzlepartDynamicsTools.Models
{
    [DataContract]
    public class BrregCompanyDTO
    {
        [DataMember]
        public string navn { get; set; }
        [DataMember]
        public int organisasjonsnummer { get; set; }
        [DataMember]
        public string organisasjonsform { get; set; }
        [DataMember]
        public string registreringsdatoEnhetsregisteret { get; set; }
        [DataMember]
        public string registrertIFrivillighetsregisteret { get; set; }
        [DataMember]
        public string registrertIMvaregisteret { get; set; }
        [DataMember]
        public string registrertIForetaksregisteret { get; set; }
        [DataMember]
        public string registrertIStiftelsesregisteret { get; set; }
        [DataMember]
        public string konkurs { get; set; }
        [DataMember]
        public string underAvvikling { get; set; }
        [DataMember]
        public string underTvangsavviklingEllerTvangsopplosning { get; set; }
        [DataMember]
        public IndustryCode naeringskode1 { get; set; }
        [DataMember]
        public IndustryCode naeringskode2 { get; set; }
        [DataMember]
        public IndustryCode naeringskode3 { get; set; }
        [DataMember]
        public Address forretningsadresse { get; set; }
        [DataMember]
        public Address postadresse { get; set; }

        [DataContract]
        public class Address
        {
            [DataMember]
            public string adresse { get; set; }
            [DataMember]
            public string postnummer { get; set; }
            [DataMember]
            public string poststed { get; set; }
            [DataMember]
            public string kommunenummer { get; set; }
            [DataMember]
            public string kommune { get; set; }
            [DataMember]
            public string landkode { get; set; }
            [DataMember]
            public string land { get; set; }
        }

        [DataContract]
        public class IndustryCode
        {
            [DataMember]
            public string kode { get; set; }
            [DataMember]
            public string beskrivelse { get; set; }
        }
    }
}
