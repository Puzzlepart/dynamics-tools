using System.Runtime.Serialization;

namespace PuzzlepartDynamicsTools.Helpers
{
    [DataContract]
    public class CategoryInfo
    {
        [DataMember]
        public string AllPropertiesToSerialize { get; set; }
    }
}
