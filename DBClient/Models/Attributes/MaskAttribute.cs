namespace DBClient.Models.Attributes
{
    public class MaskAttribute : System.Attribute
    {
        public string Mask { get; set; }
        public MaskAttribute(string mask)
        {
            Mask = mask;
        }
    }
}
