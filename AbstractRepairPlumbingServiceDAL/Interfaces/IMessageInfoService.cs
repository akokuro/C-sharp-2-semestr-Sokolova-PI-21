using AbdtractFoodOrderServiceDAL.BindingModel;
using AbdtractFoodOrderServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbdtractFoodOrderServiceDAL.Interfaces
{
    public interface IMessageInfoService
    {
        List<MessageInfoViewModel> GetList();
        MessageInfoViewModel GetElement(int id);
        void AddElement(MessageInfoBindingModel model);
    }
}
