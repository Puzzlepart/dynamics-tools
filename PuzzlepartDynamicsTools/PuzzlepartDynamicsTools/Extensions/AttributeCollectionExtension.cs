namespace Microsoft.Xrm.Sdk
{
    public static class AttributeCollectionExtension
    {
        public static void AddOrUpdate(this AttributeCollection attributeCollection, string key, object value)
        {
            if (attributeCollection.Contains(key))
            {
                attributeCollection[key] = value;
            }
            else
            {
                attributeCollection.Add(key, value);
            }
        }
    }
}
