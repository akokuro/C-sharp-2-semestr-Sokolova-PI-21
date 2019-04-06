using System.Runtime.Serialization;

namespace AbstractRepairOrderServiceDAL.BindingModel
{
    [DataContract]
    /// <summary>
    /// Клиент ремонта
    /// </summary>
    public class ClientBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ClientFIO { get; set; }
    }
}
