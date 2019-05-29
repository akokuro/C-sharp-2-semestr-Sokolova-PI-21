using System.Runtime.Serialization;


namespace AbstractRepairPlumbingServiceDAL.BindingModel
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
        public string Mail { get; set; }

        [DataMember]
        public string ClientFIO { get; set; }
    }
}
