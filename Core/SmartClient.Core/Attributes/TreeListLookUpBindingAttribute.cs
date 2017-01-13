namespace SmartClient.Core.Attributes
{
    public class TreeListLookUpBindingAttribute : SearchLookUpBindingAttribute
    {
        public string KeyFieldName { get; set; }
        public string ParentKeyFieldName { get; set; }
    }
}
